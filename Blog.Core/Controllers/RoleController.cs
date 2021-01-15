using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        [Authorize(Roles = "Admin")]
        public async Task<int> CreateRole(string name)
        {
            Role role = new Role(name);
            role.CreateBy = 
            return 0;
        }
    }
}
