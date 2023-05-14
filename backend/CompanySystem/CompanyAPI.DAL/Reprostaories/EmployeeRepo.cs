using CompanyAPI.DAL.Context;
using CompanyAPI.DAL.Interfaces;
using CompanyAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Reprostaories
{
    public  class EmployeeRepo : IContextRepo<Employee>
    {
        private readonly CompanyDB dbContext;
        public EmployeeRepo(CompanyDB _dbContext) { 
        
            dbContext= _dbContext;
        }

        public async Task<IEnumerable<Employee>> getAll()
        {
            IEnumerable<Employee> employees =await dbContext.Employees.Include(emp => emp.departement).ToListAsync();
            return employees;
        }

        public async Task<Employee> getItemById(int id)
        {
            Employee? employee = await dbContext.Employees.Include(emp => emp.departement).
                FirstOrDefaultAsync(emp =>emp.id == id);
            return employee;
        }

        public async Task addItem(Employee item)
        {
            await dbContext.Employees.AddAsync(item);
        }

        public async Task updateItem(Employee item)
        {
            Employee employee = await dbContext.Employees.FirstOrDefaultAsync(ele => ele.id == item.id);
            
            if (employee != null)
            {
                employee.name = item.name;
                employee.age = item.age;
                employee.address = item.address;
                employee.departement = item.departement;
                employee.salary = item.salary;
            }

        }

        public async Task deleteItem(int id)
        {
            Employee employee = await dbContext.Employees.FindAsync(id);
            dbContext.Employees.Remove(employee);
        }

        public async Task saveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        
    }
}
