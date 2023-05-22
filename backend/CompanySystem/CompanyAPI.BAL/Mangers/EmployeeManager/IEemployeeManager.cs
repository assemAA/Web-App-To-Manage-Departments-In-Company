using CompanyAPI.BAL.DTOs.Employee;
using CompanyAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.Mangers.EmployeeManager
{
    public interface IEemployeeManager
    {
        public Task<IEnumerable<EmployeeDTO>> getAllEmployees();

        public Task<EmployeeDTO> getEmployeeById(int id);

        public Task addEmployee(Employee employee);

        public Task updateEmployee(Employee employee);

        public Task deleteEmployee(int id);

        public Task saveChanges();
    }
}
