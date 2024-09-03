using Microsoft.EntityFrameworkCore;
using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected DbSet<T> _set;
        protected DbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _set = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var dbRecord = await _set.FindAsync(id);

            if(dbRecord is null)
            {
                throw new Exception();
            }

            return dbRecord;
        }

        public async Task<T> Create(T model)
        {
            _set.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<T> Update(int id, T newData)
        {
            newData.Id = id;

            _set.Update(newData);

            await _dbContext.SaveChangesAsync();

            return newData;
        }

        public async Task<T> Delete(int id)
        {
            var fileToDelete = await _set.FindAsync(id);
            if(fileToDelete is null)
            {
                throw new Exception();
            }
            var deletedFile = fileToDelete;

            await _set.Where(x => x.Id == id).ExecuteDeleteAsync();

            return deletedFile;
        }
    }
}
