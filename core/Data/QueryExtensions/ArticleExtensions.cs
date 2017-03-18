using System;
using System.Linq;
using System.Collections.Generic;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data.QueryExtensions{

    public static class ArticleExtensions{
        
        public static bool IsPublishable(this Article article){

            return (article.PublishDate.GetValueOrDefault(DateTime.MinValue) <= DateTime.Now)
                && (article.RemoveDate.GetValueOrDefault(DateTime.MaxValue) >= DateTime.Now);
        }

        public static IQueryable<ClubArticle> WhereArticlesArePublishable(this IQueryable<ClubArticle> clubArticles){
            return clubArticles.Where(ca => ca.Article.IsPublishable());
        }

        public static IQueryable<ClubArticle> WithCustomOrdering(this IQueryable<ClubArticle> clubArticles){
            return clubArticles.OrderByDescending(ca => ca.Article.ArticleDate)
                               .ThenByDescending(ca => ca.Article.Id);
        }

        public static IEnumerable<SquadArticle> WhereArticlesArePublishable(this IEnumerable<SquadArticle> squadArticles){
            return squadArticles.Where(sa => sa.Article.IsPublishable());
        }
        public static IEnumerable<SquadArticle> WithCustomOrdering(this IEnumerable<SquadArticle> squadArticles){
            return squadArticles.OrderByDescending(sa => sa.Article.ArticleDate)
                                .ThenByDescending(sa => sa.Article.Id);
        }

    }
}