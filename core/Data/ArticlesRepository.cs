using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Devallish.SportsClub.Data.Models;
using Devallish.SportsClub.Data.QueryExtensions;

namespace Devallish.SportsClub.Data{

    public class ArticlesRepository : Repository, IArticlesRepository
    {
        public ArticlesRepository(SportsClubContext context) : base(context){} 

        public async Task<IEnumerable<ClubArticle>> GetForClubId(int id)
        {
            if (await _context.Clubs.AnyAsync(c => c.Id == id)){

                var club = await _context.Clubs.FirstAsync(c => c.Id == id);

                var clubEntry = _context.Entry(club);

                await clubEntry.Collection(c => c.Articles)
                               .Query()
                               .Include(a => a.Article)
                               .WhereArticlesArePublishable()
                               .WithCustomOrdering()
                               .Take(10) // TODO possible configurable.
                               .LoadAsync();
                return club.Articles;
            }
            return null;
        }

        public Task<IEnumerable<Article>> GetForSquadId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetById(int id){
            return await _context.Articles.Include(a => a.Author)
                                          .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<SquadArticle>> GetSquadAssociationsForArticleId(int id)
        {
            return await _context.SquadArticle.Where(sa => sa.ArticleId == id).ToArrayAsync();
        }

        public async Task<IEnumerable<ClubArticle>> GetClubAssociationsForClubId(int id)
        {
            return await _context.ClubArticle.Where(ca => ca.ArticleId == id).ToArrayAsync();
        }

        public async Task UpdateWithAssociations(
            Article article, 
            IEnumerable<ClubArticle> createClubArticles, 
            IEnumerable<ClubArticle> deleteClubArticles,
            IEnumerable<SquadArticle> createSquadArticles,
            IEnumerable<SquadArticle> deleteSquadArticles){

                await _context.ClubArticle.AddRangeAsync(createClubArticles);
                _context.ClubArticle.RemoveRange(deleteClubArticles);
                await _context.SquadArticle.AddRangeAsync(createSquadArticles);
                _context.SquadArticle.RemoveRange(deleteSquadArticles);
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClubArticle>> GetClubAssociationsForArticleId(int id)
            => await _context.ClubArticle.Where(ca => ca.ArticleId == id).ToArrayAsync();
        
    }
}