using System.Collections.Generic;
using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data{

    public interface ISquadsRepository: IRepository{
        Task<IEnumerable<Squad>> GetAll();
        Task<Squad> GetById(int id);
    }
}