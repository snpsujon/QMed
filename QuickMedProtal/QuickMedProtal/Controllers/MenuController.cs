using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickMedProtal.Infrastructure.Models;
using QuickMedProtal.ServiceInterface;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenu _menu;

        public MenuController(IMenu menu)
        {
            _menu = menu;
        }

        [HttpGet]
        [Route("GetMenuByUserId")]
        public async Task<IActionResult> GetMenuByUserId(string userId, bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                var menu = await _menu.GetMenuByUserId(userId);
                return Ok(menu);
            }
            else
            {
                return Unauthorized(); // Returning a 401 Unauthorized status
            }
        }


        [HttpGet]
        [Route("GetPermissionByMenuId")]
        public async Task<IActionResult> GetPermissionByMenuId(string userId, int MenuId)
        {
            var menu = await _menu.GetPermissionByMenuId(userId, MenuId);
            return Ok(menu);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(bool isAuthenticated)
        {
            try
            {
                var data = await _menu.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("PostCreate")]
        public async Task<ActionResult<Menu>> PostCreate(Menu data)
        {
            try
            {
                if (ModelState.IsValid && data.IsAuthenticated)
                {
                    if (await _menu.Post(data))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else return BadRequest();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }
        [HttpPut]
        [Route("EditMenu/{id}")]
        public async Task<IActionResult> EditMenu(int id, Menu data)
        {
            try
            {
                if (ModelState.IsValid && data.IsAuthenticated)
                {
                    //if (id != data.Id)
                    //{
                    //	return BadRequest();
                    //}
                    if (await _menu.UpdateByAsync(data))
                    {
                        return Ok();
                    }
                    else
                        return BadRequest();
                }
                else return BadRequest();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetPermissionByRollId")]
        public async Task<IEnumerable<dynamic>> GetPermissionByRollId(string roleId)
        {
            return await _menu.GetPermissionByRollId(roleId);
        }
        [HttpPost("UpdatePermission")]
        public async Task<ActionResult> UpdatePermission(List<PermissionVM> data)
        {
            try
            {
                var res = await _menu.UpdatePermission(data);
                return res ? Ok(data) : BadRequest(500);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
