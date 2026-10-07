using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescription _prescription;
        public PrescriptionController(IPrescription prescription)
        {
           _prescription = prescription;
        }

        [HttpGet("GetDoctorListData")]
        public async Task<IActionResult> GetDoctorListData()
        {
            try
            {
                var result = await _prescription.GetDoctorListData();
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
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

        [HttpGet("GetPrescriptionDataByDoctorId")]
        public async Task<IActionResult> GetPrescriptionDataByDoctorId(string doctorId)
        {
            try
            {
                var result = await _prescription.GetPrescriptionDataByDoctorId(doctorId);
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
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
        [HttpGet("GetPrescriptionPreviewDataById")]
        public async Task<IActionResult> GetPrescriptionPreviewDataById(string prescriptionId)
        {
            try
            {
                var result = await _prescription.GetPrescriptionPreviewDataById(prescriptionId);
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
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

        [HttpGet("GetLicenseListData")]
        public async Task<IActionResult> GetLicenseListData()
        {
            try
            {
                var result = await _prescription.GetLicenseListData();
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
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
