using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Devallish.SportsClub.Data;

namespace api.Migrations
{
    [DbContext(typeof(SportsClubContext))]
    partial class SportsClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArticleDate");

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Content1");

                    b.Property<string>("Content2");

                    b.Property<string>("Content3");

                    b.Property<string>("Content4");

                    b.Property<string>("ImageUrl1");

                    b.Property<string>("ImageUrl2");

                    b.Property<string>("ImageUrl3");

                    b.Property<string>("ImageUrl4");

                    b.Property<string>("Keywords");

                    b.Property<DateTime?>("PublishDate");

                    b.Property<DateTime?>("RemoveDate");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrowserTitle");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Summary");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<int>("ClubId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ClubId");

                    b.ToTable("ClubArticle");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubId");

                    b.Property<int>("PersonId");

                    b.Property<int>("PersonRoleId");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonRoleId");

                    b.ToTable("ClubPerson");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubSponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubId");

                    b.Property<int>("SponsorId");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("SponsorId");

                    b.ToTable("ClubSponsor");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookProfile");

                    b.Property<string>("Forenames");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("MobileNo");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("Surname");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.PersonRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PersonRoles");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LinkUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Summary");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Information");

                    b.Property<string>("Name");

                    b.Property<string>("Summary");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Squads");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<int>("SquadId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("SquadId");

                    b.ToTable("SquadArticle");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.Property<int>("PersonRoleId");

                    b.Property<int>("SquadId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonRoleId");

                    b.HasIndex("SquadId");

                    b.ToTable("SquadPerson");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadSponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SponsorId");

                    b.Property<int>("SquadId");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("SquadId");

                    b.ToTable("SquadSponsor");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.Article", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubArticle", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Club", "Club")
                        .WithMany("Articles")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubPerson", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Club", "Club")
                        .WithMany("Persons")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.PersonRole", "Role")
                        .WithMany()
                        .HasForeignKey("PersonRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.ClubSponsor", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Club", "Club")
                        .WithMany("Sponsors")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadArticle", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Squad", "Squad")
                        .WithMany("Articles")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadPerson", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.PersonRole", "PersonRole")
                        .WithMany()
                        .HasForeignKey("PersonRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Squad", "Squad")
                        .WithMany("Persons")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Devallish.SportsClub.Data.Models.SquadSponsor", b =>
                {
                    b.HasOne("Devallish.SportsClub.Data.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Devallish.SportsClub.Data.Models.Squad", "Squad")
                        .WithMany("Sponsors")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
