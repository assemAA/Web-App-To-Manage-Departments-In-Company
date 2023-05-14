using CompanyAPI.DAL.Context;
using CompanyAPI.DAL.Interfaces;
using CompanyAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Reprostaories
{
    public class DepartementRepo : IContextRepo<Departement>
    {
        private readonly CompanyDB dbContext;

        public DepartementRepo(CompanyDB _context) { 
        
            dbContext= _context;
        }
        public async Task addItem(Departement item)
        {
            await dbContext.Departements.AddAsync(item);
        }

        public async Task deleteItem(int id)
        {
            Departement? departement = await dbContext.Departements.FirstOrDefaultAsync(ele => ele.id == id);
            dbContext.Departements.Remove(departement);
        }

        public async Task<IEnumerable<Departement>> getAll()
        {
            IEnumerable<Departement> departements =   await dbContext.Departements.ToListAsync();
            return departements;

        }

        

        public async Task<Departement> getItemById(int id)
        {
            Departement? departement = await dbContext.Departements.FindAsync(id);
            return departement;
        }

        public async Task saveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task updateItem(Departement item)
        {
            Departement? departement = await dbContext.Departements.FirstOrDefaultAsync(ele => ele.id == item.id);
            if (departement != null) { 
                departement.name = item.name;
                departement.description = item.description; 
            }
        }
    }
}
