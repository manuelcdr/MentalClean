using System.Threading.Tasks;

namespace DDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase
    {
        Task<int> SaveChanges();
    }
}
