using System.Linq;
using System.Collections.Generic;
using Devallish.SportsClub.Data.Models;
using static AutoMapper.Mapper;

namespace Devallish.SportsClub.Api.DTOs.Mappers{

    public static class ArticleMapper{

        public static IEnumerable<SummaryItemDto> FromModelsToDTOs(IEnumerable<ClubArticle> articles){
            return articles.Select(a => new SummaryItemDto{
                Id = a.Article.Id, 
                Title = a.Article.Title,
                Summary = a.Article.Summary,
                ImageUrl = a.Article.ImageUrl1,
                Date = a.Article.ArticleDate,
                RouteName = "article"} 
            );
        }

        public static ArticleDto FromModelToDto(Article article){
            var articleDto = null as ArticleDto;
            if (article != null){
                articleDto = Map<ArticleDto>(article);
            }
            return articleDto;
        }

        public static ArticleEditDto FromModelToEditDto(Article article){
            var articleEditDto = null as ArticleEditDto;
            if (article != null){
                articleEditDto = Map<ArticleEditDto>(article);
            }
            return articleEditDto;
        }

        public static Article FromDtoToModel(ArticleDto articleDto){
            var article = null as Article;
            if (articleDto != null){
                article = Map<Article>(articleDto);
            }
            return article;
        }

        public static void MapSelectionFromSquadArticlesToAssociations(
            IEnumerable<SquadArticle> squadArticles, 
            IEnumerable<ArticleAssociationDto> associations
        ){
            foreach(var squadArticle in squadArticles){
                var associationDto = associations.FirstOrDefault(
                    a => !a.IsClub && a.AssociatedToId == squadArticle.SquadId);
                if (associationDto != null){
                    associationDto.IsSelected = true;
                }
            }
        }

        public static void MapSelectionFromClubArticlesToAssociations(
            IEnumerable<ClubArticle> clubArticles,
            IEnumerable<ArticleAssociationDto> associations
        ){
            foreach(var clubArticle in clubArticles){
                var associationDto = associations.FirstOrDefault(
                    a => a.IsClub && a.AssociatedToId == clubArticle.ClubId);
                if (associationDto != null){
                    associationDto.IsSelected = true;
                }
            }
        }


        public static (IEnumerable<ClubArticle> CreateForClub, 
                       IEnumerable<ClubArticle> DeleteForClub, 
                       IEnumerable<SquadArticle> CreateForSquad, 
                       IEnumerable<SquadArticle> DeleteForSquad)
            ExtractArticleCollectionsFor(IEnumerable<ArticleAssociationPair> instructions){
                var createClubArticles = instructions.Where(p => p.Dto.IsClub && p.Action == ActionTypes.Create).Select(p => p.Club).ToArray();
                var deleteClubArticles = instructions.Where(p => p.Dto.IsClub && p.Action == ActionTypes.Delete).Select(p => p.Club).ToArray();
                var createSquadArticles = instructions.Where(p => !p.Dto.IsClub && p.Action == ActionTypes.Create).Select(p => p.Squad).ToArray();
                var deleteSquadArticles = instructions.Where(p => !p.Dto.IsClub && p.Action == ActionTypes.Delete).Select(p => p.Squad).ToArray();
                return (createClubArticles, deleteClubArticles, createSquadArticles, deleteSquadArticles);
            }

        public static IEnumerable<ArticleAssociationPair> CreateArticleAssociationInstructions(
            ArticleEditDto articleEditDto, 
            IEnumerable<ClubArticle> clubArticles, 
            IEnumerable<SquadArticle> squadArticles){
         
            var pairs = new List<ArticleAssociationPair>();

            // Iterate through the associations passed in Dto.
            // Match them as pair against existing squad and club articles.
            foreach(var association in articleEditDto.Associations){
                var pair = new ArticleAssociationPair { Dto = association };
                pairs.Add(pair);
                if (association.IsClub && clubArticles.Any(ca => ca.ClubId == association.AssociatedToId)){
                    // Should only be a one to one relationship between an article and a club.
                    pair.Club = clubArticles.First(ca => ca.ClubId == association.AssociatedToId);
                }else if(!association.IsClub && squadArticles.Any(sa => sa.SquadId == association.AssociatedToId)){
                    // Should only be a one to one relationship between an article and a squad.
                    pair.Squad = squadArticles.First(sa => sa.SquadId == association.AssociatedToId);
                }
            }
            // If there is no match from existing records we should create.
            // If we do match and the dto indicates it is not selected then remove existing.
            foreach(var pair in pairs){
                if (pair.IsAssociated() && !pair.Dto.IsSelected){
                    pair.Action = ActionTypes.Delete;
                }else if (!pair.IsAssociated() && pair.Dto.IsSelected){
                    pair.Action = ActionTypes.Create;
                    if (pair.Dto.IsClub){
                        pair.Club = new ClubArticle{ClubId = pair.Dto.AssociatedToId, ArticleId = articleEditDto.Id};
                    }else{
                        pair.Squad = new SquadArticle{SquadId = pair.Dto.AssociatedToId, ArticleId = articleEditDto.Id};
                    }
                }
            }
            
            // If there any existing not matched to dtos then then should be removed.
            // TODO: not to worried about this we 'might' end up with trailing records. meh!
            return pairs;
        }
        public class ArticleAssociationPair{
            public ArticleAssociationDto Dto { get; set; }
            public ClubArticle Club {get; set;}
            public SquadArticle Squad { get; set; }
            public bool IsAssociated() => Club != null || Squad != null;
            public ActionTypes Action { get; set; }
            
        }
        public enum ActionTypes{
            None = 0,
            Create = 1,
            Delete = 2
        }
    }
}