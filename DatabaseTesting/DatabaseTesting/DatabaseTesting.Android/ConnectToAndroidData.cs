using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using SQLite;
using DatabaseTesting.Droid;
using DatabaseTesting.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectToAndroidData))]
namespace DatabaseTesting.Droid
{
    class ConnectToAndroidData : IDataConnection
    {
        public SQLiteConnection DataConnection()
        {
            var dataName = "Tasks.db3";
            string libraryFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryFolder, dataName);

            return new SQLiteConnection(path);
        }
    }
}