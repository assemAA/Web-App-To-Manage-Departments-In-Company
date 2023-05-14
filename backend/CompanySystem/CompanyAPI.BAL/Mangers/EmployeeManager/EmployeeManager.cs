using CompanyAPI.BAL.DTOs.Employee;
using CompanyAPI.DAL.Context;
using CompanyAPI.DAL.Interfaces;
using CompanyAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanyAPI.BAL.Mangers.EmployeeManager
{
    public class EmployeeManager : IEemployeeManager
    {
        private readonly IContextRepo<Employee> employeeRepo;
        private readonly CompanyDB dbContxt;
        public EmployeeManager(IContextRepo<Employee> _employeeRepo , CompanyDB _dbContext) { 
        
            this.employeeRepo = _employeeRepo;
            this.dbContxt = _dbContext;
        
        }
        public async Task addEmployee(Employee employee)
        {
           await employeeRepo.addItem(employee);
        }

        public async Task deleteEmployee(int id)
        {
            await employeeRepo.deleteItem(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> getAllEmployees()
        {
            IEnumerable<Employee> employeesList = await employeeRepo.getAll();
            IEnumerable<EmployeeDTO> employees = employeesList.Select(emp => new EmployeeDTO() {
                id = emp.id,
                name = emp.name,
                salary = emp.salary,
                age = emp.age,
                address = emp.address,
                departement = emp.departement.name
            });

            return employees;
        }

        public async Task<EmployeeDTO> getEmployeeById(int id)
        {
            Employee? employeeBeforeShow = await employeeRepo.getItemById(id);

            if (employeeBeforeShow != null)
            {
                EmployeeDTO employee = new EmployeeDTO()
                {
                    id = employeeBeforeShow.id,
                    name = employeeBeforeShow.name,
                    address = employeeBeforeShow.address,
                    age = employeeBeforeShow.age,
                    salary = employeeBeforeShow.salary,
                    departement = employeeBeforeShow.departement.name
                };

                return employee;
            }

            return null;
        }

        public async Task saveChanges()
        {
            await employeeRepo.saveChanges();
        }

        public async Task updateEmployee(Employee employee)
        {
            await employeeRepo.updateItem(employee);
        }
    }
}
