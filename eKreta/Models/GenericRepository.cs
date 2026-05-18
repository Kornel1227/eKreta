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
            return null;
        }
        public void Insert(T item)
        {
        }
        public void Update(T item)
        {
        }
        public void Delete(T item)
        {
        }
    }
}
