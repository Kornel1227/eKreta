using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
    internal class GenericRepository<T> : IGenemicRepository<T> where T : new()
    {
        private readonly string _databasePath;
        public GenericRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public List<T> GetAll()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                return connection.Table<T>().ToList();
            }
        }
        public void Insert(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Insert(item);
            }   
        }
        public void Update(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Update(item);
            }
        }
        public void Delete(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Delete(item);
            }
        }
    }
}
