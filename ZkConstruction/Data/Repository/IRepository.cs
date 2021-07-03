using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save(string query);
        void Update(string query);
        void Delete(string query);
        IEnumerable<T> GetAllData(string query);
        T FindByID(string query);
        int GetMaxId(string query);

    }
}
