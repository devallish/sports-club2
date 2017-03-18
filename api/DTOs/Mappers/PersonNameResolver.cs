using AutoMapper;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Api.DTOs.Mappers{

    public class PersonNameResolver : IValueResolver<Person, AuthorDto, string>
    {
        public string Resolve(Person source, AuthorDto destination, string destMember, ResolutionContext context)
        {
            return $"{source.Forenames} {source.Surname}".Trim();
        }
    }
}