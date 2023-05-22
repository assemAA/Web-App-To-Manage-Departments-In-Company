using CompanyAPI.DAL.Models.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.DTOs.Employee
{
    public class EmployeeDTO : Person
    {

        public double salary { get; set; }

        public string departement { get; set; }
    }
}
