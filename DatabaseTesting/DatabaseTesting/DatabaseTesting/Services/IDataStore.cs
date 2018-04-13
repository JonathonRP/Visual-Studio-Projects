using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseTesting.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
