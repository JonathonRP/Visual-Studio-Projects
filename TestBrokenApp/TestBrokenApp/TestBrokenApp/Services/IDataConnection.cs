using System;
using System.Collections.Generic;
using System.Text;

namespace TestBrokenApp.Services
{
    public interface IDataConnection
    {
        SQLite.SQLiteConnection DataConnection();
    }
}
