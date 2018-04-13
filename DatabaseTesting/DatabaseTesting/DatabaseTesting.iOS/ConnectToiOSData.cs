using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using DatabaseTesting.iOS;
using DatabaseTesting.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectToiOSData))]
namespace DatabaseTesting.iOS
{
    class ConnectToiOSData : IDataConnection
    {
        public SQLiteConnection DataConnection()
        {
            var dataName = "Tasks.db3";
            string personalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dataName);

            return new SQLiteConnection(path);
        }
    }
}