using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Devallish.SportsClub.Data{

    public class SponsorsRepository : Repository, IRepository, ISponsorsRepository
    {
        public SponsorsRepository(SportsClubContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClubSponsor>> GetForClubId(int id)
        {
            if (_context.Clubs.Any(c => c.Id == id)){


                var club = await _context.Clubs
                                         .Include(c => c.Sponsors) 
                                            .ThenInclude(s => s.Sponsor)
                                         .FirstAsync(c => c.Id == id);

                return club.Sponsors;
            }
            return null;
        }

        public Task<IEnumerable<SquadSponsor>> GetForSquadId(int id)
        {
            throw new NotImplementedException();
        }
    }
}