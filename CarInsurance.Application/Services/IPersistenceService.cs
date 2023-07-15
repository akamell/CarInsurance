using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInsurance.Application.Services
{
    public interface IPersistenceService<T>
    {
        IMongoCollection<T> GetInstanceCollection();
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task CreateAsync(T newBook);
        Task UpdateAsync(string id, T updatedBook);
        Task RemoveAsync(string id);
    }
}
