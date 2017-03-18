using System.Linq;
using System.Threading.Tasks;
using Devallish.SportsClub.Data.Models;

namespace Devallish.SportsClub.Data
{
    public interface IRepository
    {
        IQueryable<T> Set<T>() where T : BaseEntity;
        Task Create<T>(T entity) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;
        Task Delete<T>(int id) where T : BaseEntity;
    }
}
