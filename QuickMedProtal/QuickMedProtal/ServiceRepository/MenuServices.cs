using Dapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.Infrastructure.Models;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using System.Data;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace QuickMedProtal.ServiceRepository
{
    public class MenuServices : BaseRepository<Menu>, IMenu
    {
        
        

        public MenuServices(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetMenuByUserId(string userId)
        {
            try
            {
                var query = from rp in _context.Menu_Permissions.Where(x => x.IsView == true)
                            join m in _context.Menus.Where(x=>x.Active.Equals(true)) on rp.MenuId equals m.Id
                            
                            orderby m.MenuPriority, m.MenuOrder
                            select new Menu
                            {
                                Id = m.Id,
                                Name = m.Name,
                                ParentId = m.ParentId,
                                MenuIcon = m.MenuIcon,
                                MenuUrl = m.MenuUrl,
                                MenuPriority = m.MenuPriority,
                                MenuOrder = m.MenuOrder,
                                IsView = rp.IsView ?? false,
                                IsDetails = rp.IsDetails ?? false,
                                IsEdit = rp.IsEdit ?? false,
                                IsAdd = rp.IsAdd ?? false,
                                IsDelete = rp.IsDelete ?? false

                            };

                var MenuList = await query.GroupBy(x => x.Id).Select(g => g.First()).ToListAsync();

                return MenuList;

                //var parameters = new DynamicParameters();
                //parameters.Add("@Flag", 3);
                //parameters.Add("@RoleIds", roleIdsString);

                //using (var _dp = _dapperContext.CreateConnection())
                //{
                //    var query = await _dp.QueryAsync<dynamic>("SP_UserManager", parameters, commandType: CommandType.StoredProcedure);
                //    var menuList = query.GroupBy(x => x.Id).Select(g => g.First()).ToList();
                //    return query;

                //}

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Task<dynamic> GetPermissionByMenuId(string userId, int MenuId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<dynamic>> GetPermissionByRollId(string RoleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(Menu data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePermission(List<PermissionVM> data)
        {
            throw new NotImplementedException();
        }
    }
}
