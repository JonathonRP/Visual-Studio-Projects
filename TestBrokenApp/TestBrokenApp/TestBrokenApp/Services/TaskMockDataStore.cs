using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Settings;
using SQLite;
using TestBrokenApp.Models;
using Xamarin.Forms;
using Realms;
using Realms.Sync;

[assembly: Dependency(typeof(TestBrokenApp.Services.TaskMockDataStore))]
namespace TestBrokenApp.Services
{
    public class TaskMockDataStore : IDataStore<ToDoTask>
    {
        private Uri AuthUser = new Uri("https://tasks.us1.cloud.realm.io/auth");
        private Uri serverURL = new Uri("realms.us1.cloud.realm.io/Tasks");
        private SyncConfiguration config;
        private Realm Tasks;
        public ObservableCollection<ToDoTask> DeletedTasks;

        public TaskMockDataStore(IDataConnection data)
        {
            SetupRealm();

            if (Tasks.All<ToDoTask>().Count() <= 0)
            {
                var task = new ToDoTask
                {
                    Title = "Task 1",
                };

                task.Subtasks.Add(new ToDoTask() { Title = "Subtask 1" });
                task.Subtasks.Add(new ToDoTask() { Title = "Subtask 2" });

                Tasks.Add(task);
            }

            DeletedTasks = new ObservableCollection<ToDoTask>();

            var mockItems = new ObservableCollection<ToDoTask>
            {
                new ToDoTask { Title = "Task 1" },
                
                new ToDoTask { Title = "Task 2" },
            };

            mockItems.ElementAt(0).Subtasks.Add(new ToDoTask() { Title = "Subtask 1" });
            mockItems.ElementAt(0).Subtasks.Add(new ToDoTask() { Title = "Subtask 2" });
            mockItems.ElementAt(1).Subtasks.Add(new ToDoTask() { Title = "Subtask 1" });
            mockItems.ElementAt(1).Subtasks.Add(new ToDoTask() { Title = "Subtask 2" });

            foreach (var item in mockItems)
            {
                DeletedTasks.Add(item);
            }
        }

        public async Task<bool> AddAsync(ToDoTask item)
        {
            Tasks.Write(() =>
            {
                Tasks.Add(item);
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ToDoTask item)
        {
            var _item = Tasks.All<ToDoTask>().Where((ToDoTask arg) => arg.Id == item.Id).FirstOrDefault();

            Tasks.Write(() =>
            {
                _item = item;
            });
            
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(ToDoTask item)
        {
            var _item = Tasks.All<ToDoTask>().Where((ToDoTask arg) => arg.Id == item.Id).FirstOrDefault();

            Tasks.Write(() =>
            {
                Tasks.Remove(_item);
                DeletedTasks.Add(item);
            });

            return await Task.FromResult(true);
        }

        public async Task<ToDoTask> GetItemAsync(int id)
        {
            return await Task.FromResult(Tasks.All<ToDoTask>().FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ToDoTask>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Tasks.All<ToDoTask>());
        }

        private async void SetupRealm()
        {
            User.ConfigurePersistence(UserPersistenceMode.NotEncrypted);
            Credentials credentials = Credentials.Nickname("realm-admin", true);
            await User.LoginAsync(credentials, AuthUser);
            var user = User.Current;
            config = new SyncConfiguration(user, serverURL);
            Tasks = Realm.GetInstance(config);
        }
    }
}