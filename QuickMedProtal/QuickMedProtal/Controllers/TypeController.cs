using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IType _Type;
        public TypeController(IType Type)
        {
            _Type = Type;
        }
        [HttpGet("GetTypeListData")]
        public async Task<IActionResult> GetTypeListData()
        {
            try
            {
                var result = await _Type.GetTypeListData();
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
        [HttpGet("SearchType")]
        public async Task<IActionResult> SearchType(string querystring)
        {
            try
            {
                var result = await _Type.SearchType(querystring);

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

        [HttpPost("SaveTypeData")]
        public async Task<IActionResult> SaveTypeData(TypeVM data)
        {

            try
            {
                var result = await _Type.SaveTypeData(data);
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

        [HttpDelete("DeleteTypeData")]
        public async Task<IActionResult> DeleteTypeData(string id)
        {
            try
            {
                var result = await _Type.DeleteTypeData(id);
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
