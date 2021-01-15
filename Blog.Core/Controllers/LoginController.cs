using Blog.Core.Application.Contracts;
using Blog.Core.Application.Contracts.Dtos;
using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Core.Common.Helper.JwtHelper;

namespace Blog.Core.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            this._userServices = userServices;
        }
        /// <summary>
        /// 登录获取jwt令牌
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> GetJwtStr(string name, string pass)
        {

            var userRole = await _userServices.GetUserRoleNameStr(name, pass);
            var user = (await _userServices.Query(t => t.Username == name && t.Password == pass)).FirstOrDefault();
            string jwtStr;
            if (!string.IsNullOrWhiteSpace(userRole))
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = user.Id, Role = userRole };
                jwtStr = IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
            }
            else
            {
                return new MessageModel<string>()
                {
                    Data = "login fail!",
                    Msg = "账号或密码错误"
                };
            }
            return new MessageModel<string>()
            {
                Data = jwtStr,
                Success = true
            };
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> Register(RegisterDto dto)
        {
            var user = new User(dto.Username, dto.Password);
            return "";
        }
    }
}
