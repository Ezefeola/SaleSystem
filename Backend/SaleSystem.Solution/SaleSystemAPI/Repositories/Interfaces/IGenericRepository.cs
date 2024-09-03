using SaleSystemAPI.Models;

namespace SaleSystemAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T model);
        Task<T> Update(int id, T newData);
        Task<T> Delete(int id); 
            
    }
}
