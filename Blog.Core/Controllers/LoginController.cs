using Blog.Core.AuthHelper;
using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;
using static Blog.Core.AuthHelper.JwtHelper;

namespace Blog.Core.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IFreeSql _freeSql;

        public LoginController(IFreeSql freeSql)
        {
            this._freeSql = freeSql;
        }
        [HttpPost]
        public object GetJwtStr(string name, string pass)
        {
            bool suc = false;

            // 获取用户的角色名，请暂时忽略其内部是如何获取的，可以直接用 var userRole="Admin"; 来代替更好理解。
            //var userRole = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
            string userRole = "Admin";
            string jwtStr;
            if (userRole != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = userRole };
                
                jwtStr = IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }
            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
    }
}
