using AutoMapper;
using CompanyAPI.BAL.DTOs.Employee;
using CompanyAPI.BAL.Mangers.DepartementManger;
using CompanyAPI.BAL.Mangers.EmployeeManager;
using CompanyAPI.DAL.Models;
using CompanyAPI.DAL.Reprostaories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEemployeeManager employeeManager;
        private readonly IDepartementManager departementManager;
        private readonly IMapper _mapper;
        public EmployeeController(IEemployeeManager employeeManager, IDepartementManager departementManager , IMapper _mapper)
        {
            this.employeeManager = employeeManager;
            this.departementManager = departementManager;
            this._mapper = _mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> getAllEmployees()
        {
            IEnumerable<EmployeeDTO> employees = await employeeManager.getAllEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeDTO>> getEmployeeById(int id)
        {
            EmployeeDTO employee = await employeeManager.getEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> addEmployee([FromBody] addUpdateEmployeeDTO employeeDTO)
        {
            Departement departementWhichEmployeeIn = await departementManager.GetDepartementById(employeeDTO.deptId);
            if (departementWhichEmployeeIn == null) return BadRequest();

            Employee employee = new Employee()
            {
                name = employeeDTO.name,
                age = employeeDTO.age,
                address = employeeDTO.address,
                salary = employeeDTO.salary,
                departement = departementWhichEmployeeIn
            };
            await employeeManager.addEmployee(employee);
            await employeeManager.saveChanges();
            return Ok(new { Message = "Employee added successfly" });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> updateEmployee([FromBody] addUpdateEmployeeDTO employeeDTO, [FromRoute] int id)
        {
            if (employeeDTO.id != id) return BadRequest();

            Departement departementWhichEmployeeIn = await departementManager.GetDepartementById(employeeDTO.deptId);
            if (departementWhichEmployeeIn == null) return BadRequest();

            EmployeeDTO? wantedEmployee = await employeeManager.getEmployeeById(employeeDTO.id);
            if (wantedEmployee == null) return NotFound();


            Employee employee = new Employee()
            {
                id = employeeDTO.id,
                name = employeeDTO.name,
                age = employeeDTO.age,
                salary = employeeDTO.salary,
                address = employeeDTO.address,
                departement = departementWhichEmployeeIn
            };

            await employeeManager.updateEmployee(employee);
            await employeeManager.saveChanges();

            return Ok(new { Message = " employee updated sucessfly" });

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> deleteEmployee([FromRoute] int id )
        {
            EmployeeDTO? wantedEmployee = await employeeManager.getEmployeeById(id);
            if (wantedEmployee == null) return NotFound();

            await employeeManager.deleteEmployee(id);
            await employeeManager.saveChanges();

            return Ok(new { Message = "employee deleted Successfuly" });
        }
    }
}
