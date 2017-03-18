using System.Collections.Generic;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Api.DTOs.Mappers{

    public static class ClubMapper{

        public static ClubDto FromModelToDTO(Club club){
            // TODO: is this good use of null checks and coalescing.
            return new ClubDto{
                Id = club?.Id ?? 0,
                Name = club?.Name ?? "Sample Club",
                BrowserTitle = club?.BrowserTitle ?? "Sample Club",
                Summary = club?.Summary ?? "The club hasn't been set up yet."
            };
        }

        public static IEnumerable<ArticleAssociationDto> FromModelToDTOs(Club club){
            return new [] { new ArticleAssociationDto{Name=club.Name, IsClub = true, AssociatedToId = club.Id} };
        }
    }
}