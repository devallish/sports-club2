using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Devallish.SportsClub.Data;
using Devallish.SportsClub.Api.DTOs;
using Devallish.SportsClub.Data.Models;
using static Devallish.SportsClub.Api.DTOs.Mappers.ArticleMapper;
using static Devallish.SportsClub.Api.DTOs.Mappers.SquadMapper;
using static Devallish.SportsClub.Api.DTOs.Mappers.ClubMapper;

namespace Devallish.SportsClub.Api.Controllers
{
    [Route("api/v1/")]
    public sealed class ArticlesController : BaseController
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly ISquadsRepository _squadsRepository;
        private readonly IClubsRepository _clubsRepository;
        public ArticlesController(IArticlesRepository articlesRepository,
                                  ISquadsRepository squadsRepository,
                                  IClubsRepository clubsRepository,
                                  ILogger<ArticlesController> logger) : base(logger)
        {
            _articlesRepository = articlesRepository;
            _squadsRepository = squadsRepository;
            _clubsRepository = clubsRepository;   
        }

        [HttpGet("clubs/{id:int}/articles")]
        public async Task<IActionResult> GetArticlesForClubId(int id)
            => await this.TakeActionJson(GetArticlesAsSummaryItemsForClubId(id));
        private async Task<IEnumerable<SummaryItemDto>> GetArticlesAsSummaryItemsForClubId(int clubId){
            var articles = await _articlesRepository.GetForClubId(clubId);
            var articleDtos = FromModelsToDTOs(articles);
            return articleDtos;
        }


        [HttpGet("articles/{id:int}")]
        public async Task<IActionResult> GetById(int id) 
            => await this.TakeActionJson(GetByIdAsDto(id));
        private async Task<ArticleDto> GetByIdAsDto(int id){
            var article = await _articlesRepository.GetById(id);
            var articleDto = FromModelToDto(article);
            return articleDto;
        }

        [HttpGet("articles/{id:int}/edit")]
        public async Task<IActionResult> GetForEditById(int id)
            => await this.TakeActionJson(GetForEditAsDto(id));
        private async Task<ArticleEditDto> GetForEditAsDto(int id){
            
            var article = await _articlesRepository.GetById(id);
            var articleEditDto = FromModelToEditDto(article);

            // Build possible associations..
            await AddAssociationsToArticleEditDto(articleEditDto);

            // Update to indicate if already associated..
            var squadArticles = await _articlesRepository.GetSquadAssociationsForArticleId(id);
            MapSelectionFromSquadArticlesToAssociations(squadArticles, articleEditDto.Associations);

            var clubArticles = await _articlesRepository.GetClubAssociationsForClubId(id);
            MapSelectionFromClubArticlesToAssociations(clubArticles, articleEditDto.Associations);

            return articleEditDto;
        }

        [HttpGet("articles/new")]
        public async Task<IActionResult> GetForNew()
            => await this.TakeActionJson(GetForNewAsDto());
        private async Task<ArticleEditDto> GetForNewAsDto(){

            var articleEditDto = FromModelToEditDto(new Article());
            await AddAssociationsToArticleEditDto(articleEditDto);            
            return articleEditDto;
        }

        private async Task AddAssociationsToArticleEditDto(ArticleEditDto articleDto){
            
            var squads = await _squadsRepository.GetAll();
            var squadAssociations = FromModelToDto(squads);
            
            var club = await _clubsRepository.GetFirst();
            var clubAssociations = FromModelToDTOs(club);

            // Need to call the ToArray to resolve all deferred executions.
            // This is needed because we are modifiying the IsSelected and
            // without resolution the objects in collections would refresh.
            articleDto.Associations = Enumerable.Concat(clubAssociations, squadAssociations)
                                                .ToArray();
        }


        [HttpPost("articles")]
        public async Task<IActionResult> Post([FromBody]ArticleEditDto articleDto) 
            => await this.TakeAction(CreateArticle(articleDto));
        private async Task CreateArticle(ArticleEditDto articleDto){
            var article = FromDtoToModel(articleDto);
            await _articlesRepository.Create(article);
        }
         

        [HttpPut("articles")]
        public async Task<IActionResult> Put([FromBody]ArticleEditDto articleDto)
            => await this.TakeAction(UpdateArticle(articleDto));

        private async Task UpdateArticle(ArticleEditDto articleDto){

            var article = FromDtoToModel(articleDto);

            // Get the associations that already exist for this article.
            // This would include both squads and the club association.
            var clubArticles = await _articlesRepository.GetClubAssociationsForArticleId(articleDto.Id);
            var squadArticles = await _articlesRepository.GetSquadAssociationsForArticleId(articleDto.Id);

            var instructions = CreateArticleAssociationInstructions(articleDto, clubArticles, squadArticles);
            var articlesTo = ExtractArticleCollectionsFor(instructions);
        
            await _articlesRepository.UpdateWithAssociations(
                article, articlesTo.CreateForClub, articlesTo.DeleteForClub, 
                articlesTo.CreateForSquad, articlesTo.DeleteForSquad);
        }
    }
}