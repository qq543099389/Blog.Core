using Blog.Core.Application.Contracts.Dtos;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Application.Contracts
{
    public interface IUserServices:IBaseServices<User>
    {
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
