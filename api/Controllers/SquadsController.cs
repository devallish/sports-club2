using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Devallish.SportsClub.Data;
using Devallish.SportsClub.Api.DTOs;
using Devallish.SportsClub.Data.Models;
using static Devallish.SportsClub.Api.DTOs.Mappers.SquadMapper;

namespace Devallish.SportsClub.Api.Controllers
{
    [Route("api/v1/[controller]/")]
    public sealed class SquadsController : BaseController
    {
        private readonly ISquadsRepository _squadsRepository;
        public SquadsController(ISquadsRepository squadsRepository, 
                                ILogger<SquadsController> logger) : base(logger)
        {
            _squadsRepository = squadsRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
            => await this.TakeActionJson(GetAsDtoById(id));
        private async Task<SquadDto> GetAsDtoById(int id){

            var squad = await _squadsRepository.GetById(id);
            var squadDto = FromModelToDto(squad);
            // TODO: Persons and Articles.
            return squadDto;
        }
        [HttpGet("{id:int}/edit")]
        public async Task<IActionResult> GetForEditById(int id)
            => await this.TakeActionJson(GetForEditAsDtoById(id));
        private async Task<SquadEditDto> GetForEditAsDtoById(int id){
            var squad = await _squadsRepository.GetById(id);
            var squadEditDto = FromModelToDto(squad);

            return squadEditDto;
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetForNew()
            => await this.TakeActionJson(GetForNewAsDto());
        private async Task<SquadEditDto> GetForNewAsDto(){
            return await Task.Run(() => FromModelToDto(new Squad()));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]SquadEditDto squadDto)
            => await this.TakeAction(CreateSquad(squadDto));
        private async Task CreateSquad(SquadEditDto squadDto){
            var squad = FromDtoToModel(squadDto);
            await _squadsRepository.Create(squad);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]SquadEditDto squadDto)
            => await this.TakeAction(UpdateSquad(squadDto));
        private async Task UpdateSquad(SquadEditDto squadDto){

            var squad = FromDtoToModel(squadDto);
            // TODO: person associations..

            await _squadsRepository.Update(squad);
        }

        [HttpGet("default")]
        public IActionResult GetDefault() => Json(SampleModels.CreateSquad());
    }
}
