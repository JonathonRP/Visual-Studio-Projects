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
        public ObservableCollection<ToDoTask> Today;
        public ObservableCollection<ToDoTask> Tasks;
        public ObservableCollection<ToDoTask> DeletedTasks;

        public TaskMockDataStore()
        {
            database = DataConnection();
            //database.DropTable<ToDoTask>();
            database.CreateTable<ToDoTask>();

            //Today = new ObservableCollection<ToDoTask>(database.GetAllWithChildren<ToDoTask>().Where(x => x.Tags == nameof(Today)));
            Tasks = new ObservableCollection<ToDoTask>(database.GetAllWithChildren<ToDoTask>());

            if (!database.Table<ToDoTask>().Any())
            {
                Tasks.Add(new ToDoTask
                {
                    Title = "Task 1",
                    Description = "This is a task description.",
                    Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1", Description = "This is a subtask description." },
                    new ToDoTask() { Title = "Subtask 2", Description = "This is a subtask description." },
                    },
                });
            }

            DeletedTasks = new ObservableCollection<ToDoTask>();

            var mockItems = new ObservableCollection<ToDoTask>
            {
                new ToDoTask { Title = "Task 1", Description="This is a task description.",
                Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1", Description = "This is a subtask description." },
                    new ToDoTask() { Title = "Subtask 2", Description = "This is a subtask description." },
                    },
                },
                new ToDoTask { Title = "Task 2", Description="This is a task description.",
                Subtasks = new ObservableCollection<ToDoTask>(){
                    new ToDoTask() { Title = "Subtask 1", Description = "This is a subtask description." },
                    new ToDoTask() { Title = "Subtask 2", Description = "This is a subtask description." },
                    },
                },
            };

            foreach (var item in mockItems)
            {
                DeletedTasks.Add(item);
            }
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
            database.InsertWithChildren(item, true);
            Tasks.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ToDoTask item)
        {
            ToDoTask _item;

            lock (collisionLock)
            {
                _item = database.GetAllWithChildren<ToDoTask>(arg => arg.Id == item.Id).FirstOrDefault();
                //database.Table<ToDoTask>().Where(arg => arg.Id == item.Id).FirstOrDefault()
                
                database.UpdateWithChildren(item);
                database.InsertOrReplaceWithChildren(item);
            }
            
            //Tasks.Remove(_item);
            //Tasks.Add(_item);

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