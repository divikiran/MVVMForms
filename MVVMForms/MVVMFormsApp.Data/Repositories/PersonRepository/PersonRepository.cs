

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVVMFormsApp.Data.Entities;
using MVVMFormsApp.Data.Repositories.Base;

namespace MVVMFormsApp.Data.Repositories.PersonRepository
{
    public class PersonRepository : Repository<PersonEntity>, IPersonRepository
    {
        public override async Task<IEnumerable<PersonEntity>> GetAll()
        {
            
            //return await SqliteDbContextExtension.PersonEntity.ToListAsync();
            return await Context.PersonEntity.ToListAsync();


        }
    }
}
