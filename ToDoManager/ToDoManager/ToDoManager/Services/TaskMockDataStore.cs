using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Settings;
using SQLite;
using SQLiteNetExtensions.Extensions;
using ToDoManager.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToDoManager.Services.TaskMockDataStore))]
namespace ToDoManager.Services
{
    public class TaskMockDataStore : IDataStore<ToDoTask>
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<ToDoTask> Tasks;
        public ObservableCollection<ToDoTask> DeletedTasks;

        public TaskMockDataStore()
        {
            database = DataConnection();
            //database.DropTable<ToDoTask>();
            database.CreateTable<ToDoTask>();

            Tasks = new ObservableCollection<ToDoTask>(database.GetAllWithChildren<ToDoTask>());

            if (!database.Table<ToDoTask>().Any())
            {
                Tasks.Add(new ToDoTask
                {
                    Title = "Task 1",
                    Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1" },
                    new ToDoTask() { Title = "Subtask 2" },
                    },
                });
            }

            DeletedTasks = new ObservableCollection<ToDoTask>
            {
                new ToDoTask { Title = "Task 1",
                Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1" },
                    new ToDoTask() { Title = "Subtask 2" },
                    },
                },
                new ToDoTask { Title = "Task 2",
                Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1" },
                    new ToDoTask() { Title = "Subtask 2" },
                    },
                }
            };
        }
        
        public SQLiteConnection DataConnection()
        {
            var dataName = "Tasks.db3";
#if __ANDROID__
            string libraryFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryFolder, dataName);
#else
#if __IOS__
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dataName);
#endif
#endif
            return new SQLiteConnection(path);
        }

        public async Task<bool> AddAsync(ToDoTask item)
        {
            Tasks.Add(item);
            database.InsertWithChildren(item, true);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ToDoTask item)
        {
            ToDoTask _item;

            lock (collisionLock)
            {
                _item = database.GetAllWithChildren<ToDoTask>(arg => arg.Id == item.Id).FirstOrDefault();
                //database.Table<ToDoTask>().Where(arg => arg.Id == item.Id).FirstOrDefault()

                database.UpdateWithChildren(_item);
                database.InsertOrReplaceWithChildren(_item, true);
            }

            Tasks.Remove(item);
            Tasks.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(ToDoTask item)
        {
            ToDoTask _item;

            lock (collisionLock)
            {
                _item = database.GetAllWithChildren<ToDoTask>(arg => arg.Id == item.Id).FirstOrDefault();
                //database.Table<ToDoTask>().Where(arg => arg.Id == item.Id).FirstOrDefault();

                database.Delete(_item, true);
            }

            Tasks.Remove(item);
            DeletedTasks.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<ToDoTask> GetItemAsync(int id)
        {
            return await Task.FromResult(database.GetWithChildren<ToDoTask>(id, true));
            //database.Table<ToDoTask>().FirstOrDefault(s => s.Id == id)
        }

        public async Task<IEnumerable<ToDoTask>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Tasks);
        }

        public async Task<bool> AddDeletedAsync(ToDoTask item)
        {
            DeletedTasks.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> RemoveDeletedAsync(ToDoTask item)
        {
            DeletedTasks.Remove(item);

            return await Task.FromResult(true);
        }

        public async Task<ToDoTask> GetDeletedItemAsync(int id)
        {
            return await Task.FromResult(DeletedTasks.FirstOrDefault(s => s.Id == id));
            //database.Table<ToDoTask>().FirstOrDefault(s => s.Id == id)
        }

        public async Task<IEnumerable<ToDoTask>> GetDeletedItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(DeletedTasks);
        }
    }
}