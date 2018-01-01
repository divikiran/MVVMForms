using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVVMFormsApp.Data.Connection
{
    public sealed class DbConnect
    {
        private static object _syncRoot = new object();
        private static DbConnect _instance;
        public static DbConnect Instance
        {
            get
            {

                if (_instance != null)
                    return _instance;

                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DbConnect();
                    }
                }
                return _instance;
            }
        }


        string dbName;

        public string DbName
        {
            get
            {
                return dbName;
            }

            set
            {
                dbName = value;
            }
        }

        public string AssemblyName
        {
            get { return System.Reflection.Assembly.GetEntryAssembly().GetName().Name; }
        }

        public async void BuildDb()
        {
            await InitializeDatabase();
        }

        public SqliteDbContext DbContext => new SqliteDbContext(DbName ?? AssemblyName);

        private async Task InitializeDatabase()
        {
            SQLitePCL.Batteries.Init();
            using (var db = DbContext)
            {
                await db.Database.EnsureCreatedAsync();
                await db.Database.MigrateAsync();
            }
        }
    }
}
