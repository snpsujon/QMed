using System.ComponentModel.DataAnnotations.Schema;

namespace QuickMedProtal.Infrastructure.Models
{
    public partial class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool? Active { get; set; }

        public string? MenuUrl { get; set; }

        public int? MenuPriority { get; set; }

        public int? MenuOrder { get; set; }

        public int? ParentId { get; set; }

        public bool? IsDeleted { get; set; }

        public string? MenuIcon { get; set; }

        public bool? Expandable { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }
        [NotMapped]
        public bool IsAuthenticated { get; set; }
        [NotMapped]
        public bool IsView { get; set; }
        [NotMapped]
        public bool IsDetails { get; set; }
        [NotMapped]
        public bool IsEdit { get; set; }
        [NotMapped]
        public bool IsAdd { get; set; }
        [NotMapped]
        public bool IsDelete { get; set; }
    }

    public class PermissionVM
    {
        public int PermissionId { get; set; }

        public int? MenuId { get; set; }
        public string? MenuName { get; set; }

        public string? RoleId { get; set; }
        public string? RoleName { get; set; }

        public bool? IsView { get; set; }

        public bool? IsDetails { get; set; }

        public bool? IsAdd { get; set; }

        public bool? IsEdit { get; set; }

        public bool? IsDelete { get; set; }
    }

}
