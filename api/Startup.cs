using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Devallish.SportsClub.Data;
using Devallish.SportsClub.Data.Models;
using Devallish.SportsClub.Api.DTOs;
using Devallish.SportsClub.Api.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

namespace Devallish.SportsClub.Api
{
    public class Startup{

        private const string ConfigSectionNameCors = "LocalCorsOptions";
        
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnvironment){

            var builder = new ConfigurationBuilder()
                            .SetBasePath(hostingEnvironment.ContentRootPath)
                            .AddJsonFile("appsettings.json", 
                                         optional: false, 
                                         reloadOnChange: true)
                            .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", 
                                         optional: true, 
                                         reloadOnChange: true)
                            .AddEnvironmentVariables();
            
            Configuration = builder.Build();
            
            // Set up the Serilog from the configuration settings.
            Log.Logger = new LoggerConfiguration()
                            //.WriteTo.LiterateConsole()
                            .ReadFrom.Configuration(Configuration)
                            .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services){
            
            ConfigureServicesConfigurationOptions(services);
            ConfigureServicesCors(services);
            ConfigureServicesMvc(services);
            ConfigureServicesData(services);
        }

        private void ConfigureServicesConfigurationOptions(IServiceCollection services){
            services.AddOptions();
            // Use this method to get the service collection aware. Other option is to bind to section.
            services.Configure<LocalCorsOptions>(Configuration.GetSection(ConfigSectionNameCors));
        }
        private void ConfigureServicesMvc(IServiceCollection services){
            // Set up MVC with the camel case contract resolver to give
            // json responses that fashionableLook to thereProperties.
            services.AddMvc()
                    .AddJsonOptions(options => 
                        options.SerializerSettings.ContractResolver
                        = new CamelCasePropertyNamesContractResolver());
        }
        private void ConfigureServicesCors(IServiceCollection services){
            
            // Get the CORS settings from configuration.
            var corsOptions = Configuration.GetSection(ConfigSectionNameCors)
                                           .Get<LocalCorsOptions>();

            // TODO: sort this out. Need to understand settings not just apply random stuff..
            var corsPolicy = new CorsPolicyBuilder()
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins(corsOptions.AllowedOrigin)
                                .Build();
            
            services.AddCors(options => 
                options.AddPolicy(corsOptions.PolicyName, corsPolicy));
        }
        private void ConfigureServicesData(IServiceCollection services){
            
            var connectionString = Configuration.GetConnectionString("SportsClubDatabase");    
                services.AddDbContext<SportsClubContext>(options => 
                    options.UseSqlServer(connectionString, 
                                         optionsBuilder => optionsBuilder.MigrationsAssembly("api")));

            services.AddTransient<IClubsRepository, ClubsRepository>();
            services.AddTransient<IArticlesRepository, ArticlesRepository>();
            services.AddTransient<ISponsorsRepository, SponsorsRepository>();
            services.AddTransient<ISquadsRepository, SquadsRepository>();
        }
        

        public void Configure(IApplicationBuilder applicationBuilder,
                              IHostingEnvironment hostingEnvironment, 
                              ILoggerFactory loggerFactory){

            ConfigureLogging(loggerFactory);
            ConfigureAutoMappper();
            ConfigureApp(applicationBuilder);
        }

        private void ConfigureLogging(ILoggerFactory loggerFactory){

            loggerFactory.AddSerilog();
        }
        private void ConfigureApp(IApplicationBuilder applicationBuilder){

            var corsOptions = Configuration.GetSection(ConfigSectionNameCors)
                                           .Get<LocalCorsOptions>();
            applicationBuilder.UseCors(corsOptions.PolicyName);
            applicationBuilder.UseMvcWithDefaultRoute();
        }
        private void ConfigureAutoMappper(){
            // From -> To...
            Mapper.Initialize(config => {
                config.CreateMap<Article, ArticleDto>();
                config.CreateMap<Person, AuthorDto>()
                    .ForMember(dest => dest.FullName, 
                                opt => opt.MapFrom(src => $"{src.Forenames} {src.Surname}".Trim()));
                    //.ForMember(dest => dest.FullName, opt => opt.ResolveUsing<PersonNameResolver>());
                config.CreateMap<ArticleDto, Article>()
                    .ForMember(dest => dest.Author, opt => opt.Ignore());
                config.CreateMap<Article, ArticleEditDto>()
                    .ForMember(dest => dest.PublishDate, 
                                opt => opt.MapFrom(src => src.PublishDate.GetValueOrDefault(DateTime.Now).Date));
                config.CreateMap<ArticleEditDto, Article>()
                    .ForMember(dest => dest.Author, opt => opt.Ignore());
                config.CreateMap<Squad, SquadEditDto>();
                config.CreateMap<SquadEditDto, Squad>();
                config.CreateMap<Squad, SquadDto>();
                
            });
        }
    }
}