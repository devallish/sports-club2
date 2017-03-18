using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserTitle = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FacebookProfile = table.Column<string>(nullable: true),
                    Forenames = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true),
                    Content1 = table.Column<string>(nullable: true),
                    Content2 = table.Column<string>(nullable: true),
                    Content3 = table.Column<string>(nullable: true),
                    Content4 = table.Column<string>(nullable: true),
                    ImageUrl1 = table.Column<string>(nullable: true),
                    ImageUrl2 = table.Column<string>(nullable: true),
                    ImageUrl3 = table.Column<string>(nullable: true),
                    ImageUrl4 = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    RemoveDate = table.Column<DateTime>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Persons_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PersonRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubPerson_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubPerson_PersonRoles_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubSponsor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(nullable: false),
                    SponsorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubSponsor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubSponsor_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubSponsor_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SquadPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    PersonRoleId = table.Column<int>(nullable: false),
                    SquadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadPerson_PersonRoles_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadPerson_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SquadSponsor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorId = table.Column<int>(nullable: false),
                    SquadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadSponsor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadSponsor_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadSponsor_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubArticle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    ClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubArticle_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubArticle_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SquadArticle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    SquadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadArticle_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadArticle_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubArticle_ArticleId",
                table: "ClubArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubArticle_ClubId",
                table: "ClubArticle",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPerson_ClubId",
                table: "ClubPerson",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPerson_PersonId",
                table: "ClubPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPerson_PersonRoleId",
                table: "ClubPerson",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubSponsor_ClubId",
                table: "ClubSponsor",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubSponsor_SponsorId",
                table: "ClubSponsor",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadArticle_ArticleId",
                table: "SquadArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadArticle_SquadId",
                table: "SquadArticle",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadPerson_PersonId",
                table: "SquadPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadPerson_PersonRoleId",
                table: "SquadPerson",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadPerson_SquadId",
                table: "SquadPerson",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadSponsor_SponsorId",
                table: "SquadSponsor",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadSponsor_SquadId",
                table: "SquadSponsor",
                column: "SquadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubArticle");

            migrationBuilder.DropTable(
                name: "ClubPerson");

            migrationBuilder.DropTable(
                name: "ClubSponsor");

            migrationBuilder.DropTable(
                name: "SquadArticle");

            migrationBuilder.DropTable(
                name: "SquadPerson");

            migrationBuilder.DropTable(
                name: "SquadSponsor");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "PersonRoles");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
