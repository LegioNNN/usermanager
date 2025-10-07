using MyProject.Entities;
namespace UserManagement.Entities
    using UserManagement.Entities;
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool MustChangePassword { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
using MyProject.Entities;
namespace UserManagement.Entities
{
    // ...
}
