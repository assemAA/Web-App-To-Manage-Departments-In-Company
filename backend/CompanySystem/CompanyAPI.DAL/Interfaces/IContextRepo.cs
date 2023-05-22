using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Interfaces
{
    public  interface IContextRepo<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> getAll();

        public Task<TEntity> getItemById(int id);


        public Task addItem (TEntity item);

        public Task updateItem (TEntity item);

        public Task deleteItem (int id);

        public Task saveChanges();
    }
}
