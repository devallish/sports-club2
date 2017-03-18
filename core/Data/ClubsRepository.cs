using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data{

    public class ClubsRepository : Repository, IRepository, IClubsRepository
    {
        public ClubsRepository(SportsClubContext context): base(context){}
        public async Task<Club> GetFirst()
        {
            return await _context.Clubs.FirstOrDefaultAsync();
        }
    }
}