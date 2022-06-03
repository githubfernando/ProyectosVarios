using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBfirst.Data
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsLocked { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
