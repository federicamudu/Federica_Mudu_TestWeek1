using ProvaWeek1Academy_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy_Core.Interface
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public bool Add(T item);
        public T GetByCode(string code);
    }
}
