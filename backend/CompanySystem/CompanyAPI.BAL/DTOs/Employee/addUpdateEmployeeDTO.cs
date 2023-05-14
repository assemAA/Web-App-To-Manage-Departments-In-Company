using CompanyAPI.DAL.Models.abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.BAL.DTOs.Employee
{
    public class addUpdateEmployeeDTO : Person
    {
        [RegularExpression("^-?\\d*(\\.\\d+)?$", ErrorMessage = "employee salary is not valid")]
        public double salary { get; set; }

        public int deptId { get; set; }


    }
}
