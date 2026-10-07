using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceController : ControllerBase
    {
        private readonly ILicence _licence;
        public LicenceController(ILicence licence)
        {
            _licence = licence;
        }

        [HttpGet("GetLicenceInfo")]
        public async Task<IActionResult> GetLicenceInfo()
        {
            try
            {
                var result = await _licence.GetLicenceInfo();
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

        [HttpGet("GetLicenceKeydata")]
        public async Task<IActionResult> GetLicenceKeydata()
        {
            try
            {
                var result = await _licence.GetLicenceKeydata();
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

        [HttpPost("SaveLicenceData")]
        public async Task<IActionResult> SaveLicenceData(LicenceVm data)
        {

            try
            {

                var result = await _licence.SaveLicenceData(data);
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

        [HttpDelete("DeleteLicenceData")]
        public async Task<IActionResult> DeleteLicenceData(string id)
        {
            try
            {
                var result = await _licence.DeleteLicenceData(id);
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

        [HttpGet("GetLicenseData")]
        public async Task<IActionResult> GetLicenseData()
        {
            try
            {
                var result = await _licence.GetLicenseData();
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
        [HttpPost("CheckValidity")]
        public async Task<IActionResult> CheckValidity(LicenseValidity data)
        {
            try
            {
                var result = await _licence.CheckValidity(data);
                //var response = new
                //{
                //    status = 200,
                //    message = "Success",
                //    data = result
                //};
                return Ok(result);
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
