using AutoMapper;
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
        private readonly IMapper _mapper;    
        public EmployeeManager(IContextRepo<Employee> _employeeRepo , CompanyDB _dbContext , IMapper _mapper) { 
        
            this.employeeRepo = _employeeRepo;
            this.dbContxt = _dbContext;
            this._mapper = _mapper;
        
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
            IEnumerable<EmployeeDTO> employees = _mapper.Map<IEnumerable<EmployeeDTO>>(employeesList);
            return employees;
        }

        public async Task<EmployeeDTO> getEmployeeById(int id)
        {
            Employee? employeeBeforeShow = await employeeRepo.getItemById(id);

            if (employeeBeforeShow != null)
            {
                EmployeeDTO employee = _mapper.Map<EmployeeDTO>(employeeBeforeShow);

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
