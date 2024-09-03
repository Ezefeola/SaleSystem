using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interfaces
{
        public interface IGenericService<T, TKey> where T : class
        {
            Task<List<T>> GetAllAsync();
            Task<T?> GetByIdAsync(TKey id);
            Task<bool> CreateAsync(T entity);
            Task<bool> UpdateAsync(TKey id, T entity);
            Task<bool> DeleteAsync(TKey id);
        }
}
