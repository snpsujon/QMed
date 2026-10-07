namespace QuickMedProtal.Infrastructure.Models
{
    public partial class Menu_Permission
    {
        public int Id { get; set; }

        public int? ParentMenuId { get; set; }

        public int? MenuId { get; set; }

        public string? RoleId { get; set; }

        public bool? IsView { get; set; }

        public bool? IsDetails { get; set; }

        public bool? IsAdd { get; set; }

        public bool? IsEdit { get; set; }

        public bool? IsDelete { get; set; }

        public bool? Active { get; set; }

        public bool? IsDeleted { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

}
