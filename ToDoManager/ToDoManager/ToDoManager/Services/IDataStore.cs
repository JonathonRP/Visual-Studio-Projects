using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoManager.Services
{
    public interface IDataStore<T>
    {
        SQLite.SQLiteConnection DataConnection();
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> AddDeletedAsync(T item);
        Task<bool> RemoveDeletedAsync(T item);
        Task<T> GetDeletedItemAsync(int id);
        Task<IEnumerable<T>> GetDeletedItemsAsync(bool forceRefresh = false);
    }
}
