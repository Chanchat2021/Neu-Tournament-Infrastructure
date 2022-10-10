using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuTournament.Infrastructure.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int pageSize = 0, int pageNumber = 0);
        Task<T?> GetById(int id);
        Task Create(T entity);
        IQueryable<T> GetQuery();
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
