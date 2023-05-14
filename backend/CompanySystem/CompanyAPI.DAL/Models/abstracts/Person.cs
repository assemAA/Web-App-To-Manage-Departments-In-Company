using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Models.abstracts
{
    public abstract class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(3 , ErrorMessage = "person name at least 3 chars")]
        [MaxLength(100 , ErrorMessage = "person name is not valid")]
        [RegularExpression(@"^[a-zA-Z]+$" , ErrorMessage = "person name contains from charters only")]
        public string name { get; set; }

        public int? age { get; set; }

        public string? address { get; set; }
    }
}
