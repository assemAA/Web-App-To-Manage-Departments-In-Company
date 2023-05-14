using CompanyAPI.BAL.Mangers.DepartementManger;
using CompanyAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : Controller
    {

        private readonly IDepartementManager departementManager;

        public DepartementController(IDepartementManager departementManager)
        {
            this.departementManager = departementManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> getAllDepartements()
        {
            return Ok(await departementManager.getAllDepartements());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Departement>> getDepartementByID([FromRoute] int id)
        {
            Departement departement = await departementManager.GetDepartementById(id);
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }

        [HttpPost]
        public async Task<IActionResult> addDepartement([FromBody] Departement departement)
        {
            await departementManager.addDepartement(departement);
            await departementManager.saveChanges();

            return Ok( new { Message  = "departemnet added Successfuly" } );
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateDepartement([FromBody] Departement departement , [FromRoute] int id)
        {
            if (id != departement.id) return BadRequest();

            Departement? wantedDepartement = await departementManager.GetDepartementById(id);
            if (wantedDepartement == null) return NotFound();

            await departementManager.updateDepartement(departement);
            await departementManager.saveChanges();

            return Ok(new { Message = "departement updated Successfuly" });
        }


        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> deleteDepartement([FromRoute] int id)
        {
            Departement? wantedDepartement = await departementManager.GetDepartementById(id);
            if (wantedDepartement == null) return NotFound();

            await departementManager.deleteDepartement(id);
            await departementManager.saveChanges();

            return Ok(new { Message = "departement deleted Successfuly" });

        }

    }
}
