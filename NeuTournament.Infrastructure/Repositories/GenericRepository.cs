using NeuTournament.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using NeuTournament.Domain.Entities.Interfaces;

namespace NeuTournament.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        private readonly TournamentDBContext dBContext;
        private readonly DbSet<T> entities;

        public GenericRepository(TournamentDBContext dBContext)
        {
            this.dBContext = dBContext;
            entities = dBContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll(int pageSize = 0, int currentPage = 1)
        {
            if (pageSize == 0)
            {
                return await entities.OrderBy(e => e.Id).ToListAsync();
            }
            return await entities.OrderBy(e => e.Id).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await entities.FirstOrDefaultAsync(e => e.Id == id);
        }
        public IQueryable<T> GetQuery()
        {
            return entities;
        }
        public async Task Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await dBContext.SaveChangesAsync();
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await dBContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            T existing = entities.Find(id);
            if (existing != null)
            {
                entities.Remove(existing);
                await dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
