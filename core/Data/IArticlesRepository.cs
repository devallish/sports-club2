using System.Collections.Generic;
using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data{
    
    public interface IArticlesRepository : IRepository{
        Task<IEnumerable<ClubArticle>> GetForClubId(int id);
        Task<IEnumerable<Article>> GetForSquadId(int id);
        Task<Article> GetById(int id);
        Task<IEnumerable<SquadArticle>> GetSquadAssociationsForArticleId(int id);
        Task<IEnumerable<ClubArticle>> GetClubAssociationsForClubId(int id);
        Task<IEnumerable<ClubArticle>> GetClubAssociationsForArticleId(int id);
        Task UpdateWithAssociations(
            Article article, 
            IEnumerable<ClubArticle> createClubArticles, 
            IEnumerable<ClubArticle> deleteClubArticles,
            IEnumerable<SquadArticle> createSquadArticles,
            IEnumerable<SquadArticle> deleteSquadArticles);
        
    }
}