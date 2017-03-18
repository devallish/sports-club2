using System;
using System.Collections.Generic;

namespace Devallish.SportsClub.Data.Models
{
    public class SampleModels
    {

        private static int _idCounter;

        private static int NextId()
        {
            _idCounter++;
            return _idCounter;
        }

        public static Club Club() => new Club
        {
            Id = NextId(),
            Name = "Sample Club",
            Summary = "This is an sample club. Please create your own club.",
            BrowserTitle = "Sample Club Browser Title",
            CreatedBy = NextId(),
            CreatedDate = DateTime.Now,
        };

        public static Squad CreateSquad()
        {

            var squad = new Squad
            {
                Id = NextId(),
                Name = "Sample Squad",
                Summary = "This is the summary for a sample squad",
                Information = "This is the information for the sample squad.",
                CreatedBy = NextId(),
                CreatedDate = DateTime.Now,
                Sponsors = new List<SquadSponsor>(),
                Articles = new List<SquadArticle>(),
                Persons = new List<SquadPerson>(),
                UpdatedBy = NextId(),
                UpdatedDate = DateTime.Now
            };

            for (int i = 0; i < 2; i++)
            {
                var sponsor = CreateSponsor();
                squad.Sponsors.Add(CreateSquadSponsor(squad, sponsor));
            }

            for (int i = 0; i < 6; i++)
            {
                var person = CreatePerson();
                var personRole = CreatePersonRole();
                squad.Persons.Add(CreateSquadPerson(squad, person, personRole));
            }

            for (int i = 0; i < 10; i++)
            {
                squad.Articles.Add(CreateSquadArticle(squad, CreateArticle()));
            }
            return squad;
        }

        public static SquadArticle CreateSquadArticle(Squad squad, Article article) => new SquadArticle
        {
            Id = NextId(),
            Squad = squad,
            SquadId = squad.Id,
            ArticleId = article.Id,
            Article = article,
        };

        public static SquadSponsor CreateSquadSponsor(Squad forSquad, Sponsor andSponsor) =>
            new SquadSponsor
            {
                Id = NextId(),
                Squad = forSquad,
                SquadId = forSquad.Id,
                Sponsor = andSponsor,
                SponsorId = andSponsor.Id
            };

        public static SquadPerson CreateSquadPerson(
            Squad squad, Person person, PersonRole personRole)
            => new SquadPerson
            {
                Id = NextId(),
                Squad = squad,
                SquadId = squad.Id,
                Person = person,
                PersonId = person.Id,
                PersonRole = personRole,
                PersonRoleId = personRole.Id
            };


        public static Sponsor CreateSponsor() => new Sponsor
        {
            Id = NextId(),
            Name = "Sample Sponsor",
            Summary = "This is the summary for a sample squad",
            CreatedBy = NextId(),
            CreatedDate = DateTime.Now,
            ImageUrl = "Squads/SampleImage.jpg",
            LinkUrl = "www.somelink.com",
        };

        public static Person CreatePerson() => new Person
        {
            Id = NextId(),
            Forenames = "Sample Forename",
            Surname = "Sample Surname",
            Email = "email.sample@somedomain.com",
            FacebookProfile = "www.facebook.com/sampleprofile",
            ImageUrl = "persons/sample_image.jpg",
            MobileNo = "023456789",
            PhoneNo = "45678900",
            CreatedBy = NextId(),
            CreatedDate = DateTime.Now,
            UpdatedBy = NextId(),
            UpdatedDate = DateTime.Now
        };

        public static PersonRole CreatePersonRole() => new PersonRole
        {
            Id = NextId(),
            Name = "Sample Person Role"
        };

        public static Article CreateArticle() => new Article
        {
            Id = NextId(),
            Title = "Sample Title",
            Summary = "Sample Summary for Sample Article",
            Content1 = "Content 1 Content 1 Content 1 Content 1 Content 1 Content 1 Content 1 Content 1 ",
            Content2 = "Content 2 Content 2 Content 2 Content 2 Content 2 Content 2 Content 2 Content 2 ",
            Content3 = "Content 3 Content 3 Content 3 Content 3 Content 3 Content 3 Content 3 Content 3 ",
            Content4 = "Content 4 Content 4 Content 4 Content 4 Content 4 Content 4 Content 4 Content 4 ",
            ImageUrl1 = "articles/action/sameple_image1.jpg",
            ImageUrl2 = "articles/action/sameple_image2.jpg",
            ImageUrl3 = "articles/action/sameple_image3.jpg",
            ImageUrl4 = "articles/action/sameple_image4.jpg",
            ArticleDate = DateTime.Now,
            Author = CreatePerson(),
            Keywords = "Sample|Keyword|Search|For|This",
            PublishDate = DateTime.Now,
            RemoveDate = DateTime.Now.AddDays(10)
        };
    }
}
