using Blog.Core.Application.Contracts;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        private readonly IBaseServices<UserRole> _userRole;

        public UserServices(IBaseServices<UserRole> userRole)
        {
            this._userRole = userRole;
        }
        public async Task<string> GetUserRoleNameStr(string loginName, string loginPwd)
        {
            var user = (await base.Query(t => t.Username == loginName && t.Password == loginPwd)).FirstOrDefault();
            if(user != null)
            {
                var userRole = await _userRole.QueryById(user.Id);
                return userRole.GetRolesName();
            }
            return "";
        }
    }
}
