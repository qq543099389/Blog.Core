using Blog.Core.Model.Models.RootKey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Core.Model.Models
{
    public class UserRole:RootEntityTkey<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Role> Roles { get; set; }
        /// <summary>
        /// 获取用户角色名
        /// </summary>
        /// <returns></returns>
        public string GetRolesName()
        {
            var RoleNames = Roles.Where(t=>t.IsDeleted == false).Select(t => t.Name);
            return string.Join(',', RoleNames.ToArray());
        }
    }
}
