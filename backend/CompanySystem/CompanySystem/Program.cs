
using CompanyAPI.BAL.Mangers.DepartementManger;
using CompanyAPI.BAL.Mangers.EmployeeManager;
using CompanyAPI.BAL.Mapper;
using CompanyAPI.DAL.Context;
using CompanyAPI.DAL.Interfaces;
using CompanyAPI.DAL.Models;
using CompanyAPI.DAL.Reprostaories;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region handle connection string
            var connectionString = builder.Configuration.GetConnectionString("CompanyDB");
            builder.Services.AddDbContext<CompanyDB>(
                        options => options.UseSqlServer(connectionString));
            #endregion

            #region injecting mangers and repos 
            builder.Services.AddScoped<IContextRepo<Departement> , DepartementRepo>();
            builder.Services.AddScoped<IDepartementManager, DepartementManager>();

            builder.Services.AddScoped<IContextRepo<Employee>, EmployeeRepo>();
            builder.Services.AddScoped<IEemployeeManager, EmployeeManager>();

            builder.Services.AddAutoMapper(mapper => mapper.AddProfile(new MappingProfile()));
            #endregion

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            #region handle CROS HTTP
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            #endregion

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}