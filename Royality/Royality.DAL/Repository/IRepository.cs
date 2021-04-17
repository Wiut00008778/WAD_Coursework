using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Royality.DAL.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);  
        bool Exists(int id);
    }
}
