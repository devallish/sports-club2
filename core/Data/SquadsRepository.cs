using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data{

    public class SquadsRepository : Repository, ISquadsRepository
    {
        public SquadsRepository(SportsClubContext context): base(context){}

        public async Task<IEnumerable<Squad>> GetAll()
        {
            return await _context.Squads.OrderBy(s => s.Name)
                                        .ToArrayAsync();
        }
        public async Task<Squad> GetById(int id)
            => await _context.Squads.FirstOrDefaultAsync(s => s.Id == id);
    }
}