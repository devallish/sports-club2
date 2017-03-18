using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data{

    public interface IClubsRepository {
        Task<Club> GetFirst();
    }
}