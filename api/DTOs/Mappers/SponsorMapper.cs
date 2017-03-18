using System.Linq;
using System.Collections.Generic;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Api.DTOs.Mappers{

    public static class SponsorMapper{
         public static IEnumerable<SummaryItemDto> FromModelsToDTOs(IEnumerable<ClubSponsor> sponsors){
            return sponsors.Select(s => new SummaryItemDto{
                Id = s.Sponsor.Id, 
                Title = s.Sponsor.Name,
                Summary = s.Sponsor.Summary,
                ImageUrl = s.Sponsor.ImageUrl} 
            );
        }
    }
}