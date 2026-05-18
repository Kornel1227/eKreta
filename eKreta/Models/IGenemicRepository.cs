using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
    internal interface IGenemicRepository<T> where T : new()
    {
        List<T> GetAll();
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
