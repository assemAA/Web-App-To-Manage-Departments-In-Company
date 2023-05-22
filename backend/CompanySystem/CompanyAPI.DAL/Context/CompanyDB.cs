using CompanyAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.DAL.Context
{
    public class CompanyDB : DbContext 
    {
        public DbSet<Departement> Departements { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public CompanyDB(DbContextOptions<CompanyDB> dbContextOptions) : base(dbContextOptions) { }


    }
}
