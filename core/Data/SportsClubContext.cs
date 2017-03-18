using Devallish.SportsClub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Devallish.SportsClub.Data
{
    public class SportsClubContext: DbContext
    {
        public SportsClubContext(DbContextOptions<SportsClubContext> options): base(options)
        {
        }
        // public SportsClubContext(){

        // }
        // protected override void OnConfiguring(DbContextOptionsBuilder builder){
        //     builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DevallishRFC;Trusted_Connection=True;");
        // }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SquadArticle> SquadArticle { get; set; }
        public DbSet<ClubArticle> ClubArticle { get; set; }
    }
}