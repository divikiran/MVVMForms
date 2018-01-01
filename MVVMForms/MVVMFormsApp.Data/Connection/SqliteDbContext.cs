using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MVVMFormsApp.Data.Entities;

namespace MVVMFormsApp.Data.Connection
{
    public class SqliteDbContext : DbContext
    {
        public string DatabasePath
        {
            get;
            set;
        }

        public DbSet<PersonEntity> PersonEntity
        {
            get;
            set;
        }

        public SqliteDbContext(string sqliteDbName)
        {
            DatabasePath = GetDatabasePath(sqliteDbName);
        }

        private string GetDatabasePath(string sqliteDbName)
        {
            if (string.IsNullOrEmpty(sqliteDbName))
                return null;

            var sqliteFilename = sqliteDbName.Replace(".", "") + ".db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            Debug.WriteLine("Database path" + path);
            return path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
