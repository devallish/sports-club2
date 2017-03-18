using Devallish.SportsClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devallish.SportsClub.Data
{
    public class Repository : IRepository
    {
        protected readonly SportsClubContext _context;
        public Repository(SportsClubContext context)
        {
            _context = context;
        }
        public IQueryable<T> Set<T>() where T: BaseEntity 
            => _context.Set<T>();
        public async Task Create<T>(T entity) where T : BaseEntity 
            => await Save<T>(c => c.Add(entity).State = EntityState.Added);
        public async Task Update<T>(T entity) where T : BaseEntity 
            => await Save<T>(c => c.Update(entity).State = EntityState.Modified);
        public async Task Delete<T>(int id) where T : BaseEntity 
            => await Save<T>(c => {
                var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);
                if (entity != null) {
                    c.Remove(entity);
                };
            });

        private async Task Save<T>(Action<SportsClubContext> action) where T : BaseEntity
        {
            action.Invoke(_context);
            await _context.SaveChangesAsync();
        }

        private void DoSomething()
        {
            _context.Clubs
                .Include(c => c.Articles.Select(ca => ca.Article).Where(a => a.PublishDate > DateTime.Now))
                    .ThenInclude(a => a.Author)
                .OrderBy(c => c.Id)
                .FirstOrDefault();
        }

    }
}
