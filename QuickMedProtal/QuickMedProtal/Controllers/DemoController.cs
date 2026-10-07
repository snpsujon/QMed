using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using System.Security.Claims;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemo _demo;
        public DemoController(IDemo demo)
        {
            _demo = demo;
        }

        [HttpGet("GetDemoData")]
        public async Task<IActionResult> GetDemoData()
        {
            try
            {
                var result = await _demo.GetDemoData();
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
