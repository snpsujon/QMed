using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _company;
        public CompanyController(ICompany company)
        {
            _company = company;
        }
        [HttpGet("GetCompanyListData")]
        public async Task<IActionResult> GetCompanyListData()
        {
            try
            {
                var result = await _company.GetCompanyListData();
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
        [HttpGet("SearchCompany")]
        public async Task<IActionResult> SearchCompany(string querystring)
        {
            try
            {
                var result = await _company.SearchCompany(querystring);

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

        [HttpPost("SaveCompanyData")]
        public async Task<IActionResult> SaveCompanyData(CompanyVM data)
        {

            try
            {
                var result = await _company.SaveCompanyData(data);
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

        [HttpDelete("DeleteCompanyData")]
        public async Task<IActionResult> DeleteCompanyData(string id)
        {
            try
            {
                var result = await _company.DeleteCompanyData(id);
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
