using cw6.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            Console.WriteLine(idPrescription);
            var prescription = await _dbService.GetPrescription(idPrescription);
            return Ok(prescription);
        }
    }
}
