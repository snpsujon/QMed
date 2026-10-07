using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IGeneric _generic;
        public GenericController(IGeneric generic)
        {
            _generic = generic;
        }

        [HttpGet("GetGenericListData")]
        public async Task<IActionResult> GetGenericListData()
        {
            try
            {
                var result = await _generic.GetGenericListData();
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

        [HttpPost("SaveGenericData")]
        public async Task<IActionResult> SaveGenericData(GenericVM data)
        {

            try
            {
                var result = await _generic.SaveGenericData(data);
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
        [HttpGet("SearchGeneric")]
        public async Task<IActionResult> SearchGeneric(string querystring)
        {
            try
            {
                var result = await _generic.SearchGenerics(querystring);
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

        [HttpDelete("DeleteGenericData")]
        public async Task<IActionResult> DeleteGenericData(string id)
        {
            try
            {
                var result = await _generic.DeleteGenericData(id);
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
