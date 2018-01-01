using System.Collections.Generic;
using System.Threading.Tasks;
using MVVMFormsApp.Data.Connection;

namespace MVVMFormsApp.Data.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        SqliteDbContext Context { get; }
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        //CRUD
        Task Insert(T item);
        Task Delete(T item);
        Task Update(T item);

    }
}
