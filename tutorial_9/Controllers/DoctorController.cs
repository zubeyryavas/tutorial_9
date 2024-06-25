using Microsoft.AspNetCore.Mvc;
using tutorial_9.Exceptions;
using tutorial_9.Models;
using tutorial_9.Services;

namespace tutorial_9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IHospitalServices _hospitalServices;

        public DoctorController(IHospitalServices hospitalServices)
        {
            _hospitalServices = hospitalServices;            
        }

        [HttpGet("{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            return Ok(await _hospitalServices.GetDoctorAsync(idDoctor));
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            try
            {
                await _hospitalServices.PutDoctorAsync(doctor);
            }
            catch (NotFoundException)
            {
                return NotFound("Doctor does not exists");
            }
            
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostDoctor(Doctor doctor)
        {
            await _hospitalServices.PostDoctorAsync(doctor);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(Doctor doctor)
        {
            try
            {
                await _hospitalServices.DeleteDoctorAsync(doctor);
            }
            catch (NotFoundException)
            {
                return NotFound("Doctor does not exists");
            }
            return Ok();
        }
    }
}
