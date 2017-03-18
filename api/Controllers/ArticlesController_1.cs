// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Devallish.SportsClub.Data;

// namespace Devallish.SportsClub.Api.Controllers{

//     [Route("api/[controller]")]
//     public class ArticlesController : Controller{
//         private IArticlesRepository _repository;
//         public ArticlesController(IArticlesRepository repository){
//             _repository = repository;
//         }

//         [HttpGet("GetForHome")]
//         public async Task<JsonResult> GetForHomePage(){
//             return await Task.Run(() => Json(_repository.GetForHomePage()));
//         }

//         [HttpGet("GetForSquadId{id}")]
//         public async Task<JsonResult> GetForSquadId(int id){
//             return await Task.Run(() => Json(_repository.GetForSquadId(id)));
//         }
        
//     }
// }    