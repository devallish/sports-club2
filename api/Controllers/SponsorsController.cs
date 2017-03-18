using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Devallish.SportsClub.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Devallish.SportsClub.Api.DTOs;
using Devallish.SportsClub.Api.DTOs.Mappers;

namespace Devallish.SportsClub.Api.Controllers
{
    [Route("api/v1/")]
    public class SponsorsController : BaseController
    {
        private ISponsorsRepository _repository;
        public SponsorsController(ISponsorsRepository repository,
                                  ILogger<SponsorsController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet("clubs/{id:int}/sponsors")]
        public async Task<IActionResult> GetSponsorsForClubId(int id){
            return await this.TakeActionJson(GetSponsorsAsSummaryItemsForClubId(id));
        }
        private async Task<IEnumerable<SummaryItemDto>> GetSponsorsAsSummaryItemsForClubId(int clubId){
            var sponsors = await _repository.GetForClubId(clubId);
            var sponsorDtos = SponsorMapper.FromModelsToDTOs(sponsors);
            return sponsorDtos;
        }    
    }
}
