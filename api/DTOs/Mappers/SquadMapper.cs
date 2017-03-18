using System.Collections.Generic;
using System.Linq;
using Devallish.SportsClub.Data.Models;
using static AutoMapper.Mapper;

namespace Devallish.SportsClub.Api.DTOs.Mappers{

    public class SquadMapper{

        public static IEnumerable<ArticleAssociationDto> FromModelToDto(IEnumerable<Squad> squads){
            return squads.Select(s => new ArticleAssociationDto{ Name = s.Name, AssociatedToId = s.Id });
        }

        public static SquadEditDto FromModelToDto(Squad squad){
            var squadEditDto = null as SquadEditDto;
            if (squad != null){
                squadEditDto = Map<SquadEditDto>(squad);
            }
            return squadEditDto;
        }
        public static Squad FromDtoToModel(SquadEditDto squadEditDto){
            var squad = null as Squad;
            if (squadEditDto != null){
                squad = Map<Squad>(squadEditDto);
            }
            return squad;
        }
    }
}