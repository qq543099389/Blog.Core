using Blog.Core.Model.Models.RootKey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model.Models
{
    public class UserRole:RootEntityTkey<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
