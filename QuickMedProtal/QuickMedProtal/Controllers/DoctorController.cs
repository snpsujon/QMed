using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctor _doctor;
        public DoctorController(IDoctor doctor)
        {
            _doctor = doctor;
        }

        [HttpPost("SaveDoctorData")]
        public async Task<IActionResult> SaveDoctorData(DoctorVM data)
        {

            try
            {
                var result = await _doctor.SaveDoctorData(data);
                var response = new
                {
                    status = 200,
                    message = "Success"
                    //data = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = 500,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete("DeleteDoctorData")]
        public async Task<IActionResult> DeleteDoctorData(string id)
        {
            try
            {
                var result = await _doctor.DeleteDoctorData(id);
                var response = new
                {
                    status = 200,
                    message = "Success"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = 500,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}
