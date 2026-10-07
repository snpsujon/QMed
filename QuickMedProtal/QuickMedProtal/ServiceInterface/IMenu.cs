using QuickMedProtal.Infrastructure.Models;
using QuickMedProtal.ServiceInterface.BaseInterface;

namespace QuickMedProtal.ServiceInterface
{
    public interface IMenu : IBaseInterface<Menu>
    {
        Task<bool> Post(Menu data);
        Task<dynamic> GetMenuByUserId(string userId);
        Task<dynamic> GetPermissionByMenuId(string userId, int MenuId);
        Task<IEnumerable<dynamic>> GetPermissionByRollId(string RoleId);
        Task<bool> UpdatePermission(List<PermissionVM> data);
    }
}
