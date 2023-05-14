using CompanyAPI.DAL.Models.abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Models
{
    public class Employee : Person
    {
        [RegularExpression("^-?\\d*(\\.\\d+)?$" , ErrorMessage = "employee salary is not valid")]
        public double salary { get; set; }

        public virtual Departement? departement { get; set; }
    }
}
