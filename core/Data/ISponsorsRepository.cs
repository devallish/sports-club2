using System.Collections.Generic;
using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data {

    public interface ISponsorsRepository{
        Task<IEnumerable<ClubSponsor>> GetForClubId(int id);
        Task<IEnumerable<SquadSponsor>> GetForSquadId(int id);
    }
}