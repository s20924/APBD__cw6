using cw6.Models;
using cw6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _dbService;

        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbService.GetDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            var doctors = _dbService.AddDoctor(doctor);
            if (doctors)
            {
                return Ok("pomyslnie dodano");
            }
            else
            {
                return BadRequest("Problem przy dodawaniu");
            }

        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            var doctors = _dbService.DeleteDoctor(idDoctor);
            if (doctors)
            {
                return Ok("Pomyslnie usunieto");
            }
            else
            {
                return BadRequest("Problem");
            }
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> EditDoctor(int idDoctor, Doctor doctor)
        {
            var doctors = _dbService.EditDoctor(idDoctor, doctor);
            if (doctors)
            {
                return Ok("Pomyslnie zaktualizowano");
            }
            else
            {
                return BadRequest("Problem");
            }
        }



    }
}
