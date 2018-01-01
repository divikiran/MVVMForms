using System.Collections.Generic;
using System.Threading.Tasks;
using MVVMFormsApp.Data.Connection;

namespace MVVMFormsApp.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        public SqliteDbContext Context => DbConnect.Instance.DbContext;

        public abstract Task<IEnumerable<T>> GetAll();

        public async Task<T> GetById(string id)
        {
            return await Context.FindAsync<T>(id);
        }

        public async Task Insert(T item)
        {
            using (var db = Context)
            {
                await db.AddAsync<T>(item);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(T item)
        {
            using (var db = Context)
            {
                db.Remove<T>(item);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(T item)
        {
            using (var db = Context)
            {
                db.Update<T>(item);
                await db.SaveChangesAsync();
            }
        }
    }
}
