using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosageController : ControllerBase
    {
        private readonly IDosage _dosage;
        public DosageController(IDosage dosage)
        {
            _dosage = dosage;
        }
        [HttpGet("GetDosageListData")]
        public async Task<IActionResult> GetDosageListData()
        {
            try
            {
                var result = await _dosage.GetDosageListData();
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
        [HttpGet("SearchDosage")]
        public async Task<IActionResult> SearchDosage(string querystring)
        {
            try
            {
                var result = await _dosage.SearchDosage(querystring);

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

        [HttpPost("SaveDosageData")]
        public async Task<IActionResult> SaveDosageData(DosageVM data)
        {

            try
            {
                var result = await _dosage.SaveDosageData(data);
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

        [HttpDelete("DeleteDosageData")]
        public async Task<IActionResult> DeleteDosageData(string id)
        {
            try
            {
                var result = await _dosage.DeleteDosageData(id);
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
