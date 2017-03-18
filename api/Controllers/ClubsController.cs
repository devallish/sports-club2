using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Devallish.SportsClub.Data;
using Devallish.SportsClub.Api.DTOs;
using Devallish.SportsClub.Api.DTOs.Mappers;

namespace Devallish.SportsClub.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClubsController : BaseController {
        
        private IClubsRepository _repository;
        public ClubsController(IClubsRepository repository, 
                               ILogger<ClubsController> logger): base(logger) {
            _repository = repository;
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetForHome() {
            return await this.TakeActionJson(GetFirstClubWithSummaryItems());
        }
        private async Task<ClubDto> GetFirstClubWithSummaryItems(){
            var club = await _repository.GetFirst();
            var clubDTO = ClubMapper.FromModelToDTO(club);
            return clubDTO;
        }
    }
}