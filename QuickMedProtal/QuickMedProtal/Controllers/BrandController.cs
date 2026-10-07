using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrand _brand;
        public BrandController(IBrand brand)
        {
            _brand = brand;
        }
        [HttpGet("SearchBrand")]
        public async Task<IActionResult> SearchQuery([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return BadRequest("Search query cannot be empty.");
                }
                var res = await _brand.SearchQuery(query);

                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("GetDataById")]
        public async Task<IActionResult> GetDataById(string id)
        {
            try
            {
                var res = await _brand.GetDataById(id);

                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("GetBrandListData")]
        public async Task<IActionResult> GetBrandListData()
        {
            try
            {
                var result = await _brand.GetBrandListData();
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

        [HttpPost("SaveBrandData")]
        public async Task<IActionResult> SaveBrandData(BrandVM data)
        {

            try
            {
                var result = await _brand.SaveBrandData(data);
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

        [HttpDelete("DeleteBrandData")]
        public async Task<IActionResult> DeleteBrandData(string id)
        {
            try
            {
                var result = await _brand.DeleteBrandData(id);
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
