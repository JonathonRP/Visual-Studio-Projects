using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTesting.Services
{
    public interface IDataConnection
    {
        SQLite.SQLiteConnection DataConnection();
    }
}
