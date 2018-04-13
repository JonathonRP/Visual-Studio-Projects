using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using DatabaseTesting.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseTesting.Services.TaskMockDataStore))]
namespace DatabaseTesting.Services
{
    public class TaskMockDataStore : IDataStore<ToDoTask>
    {
        public Realm Realm { get; private set; }

        public ObservableCollection<ToDoTask> Tasks;
        public ObservableCollection<ToDoTask> DeletedTasks;

        public TaskMockDataStore()
        {
            var config = new RealmConfiguration("Tasks.realm");
            Realm = Realm.GetInstance(config);
            Tasks = new ObservableCollection<ToDoTask>(Realm.All<ToDoTask>());

            if (Tasks.Equals(Tasks.DefaultIfEmpty()))
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

            //Tasks = new ObservableCollection<ToDoTask>();

            //var mockItems = new ObservableCollection<ToDoTask>
            //{
            //    new ToDoTask { Title = "Task 1", Description="This is a task description.",
            //    Subtasks = new ObservableCollection<ToDoTask>(){
            //        new ToDoTask() { Title = "Subtask 1", Description = "This is a subtask description." },
            //        new ToDoTask() { Title = "Subtask 2", Description = "This is a subtask description." },
            //        },
            //    },
            //    new ToDoTask { Title = "Task 2", Description="This is a task description.",
            //    Subtasks = new ObservableCollection<ToDoTask>(){
            //        new ToDoTask() { Title = "Subtask 1", Description = "This is a subtask description." },
            //        new ToDoTask() { Title = "Subtask 2", Description = "This is a subtask description." },
            //        },
            //    },
            //};

            //foreach (var item in mockItems)
            //{
            //    Tasks.Add(item);
            //}
        }

        public async Task<bool> AddAsync(ToDoTask item)
        {
            Realm.Add(item);
            Tasks.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ToDoTask item)
        {
            var _item = Realm.All<ToDoTask>().Where((ToDoTask arg) => arg.Id == item.Id).FirstOrDefault();

            Realm.Add(item, true);
            Tasks.Remove(_item);
            Tasks.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(ToDoTask item)
        {
            var _item = Realm.All<ToDoTask>().Where((ToDoTask arg) => arg.Id == item.Id).FirstOrDefault();

            Realm.Remove(_item);
            Tasks.Remove(item);
            return await Task.FromResult(true);
        }

        public async Task<ToDoTask> GetItemAsync(int id)
        {
            return await Task.FromResult(Realm.Find<ToDoTask>(id));
        }

        public async Task<IEnumerable<ToDoTask>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Tasks);
        }
    }
}