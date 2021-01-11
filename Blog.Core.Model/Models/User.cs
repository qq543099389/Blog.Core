using Blog.Core.Model.Models.RootKey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model.Models
{
    public class User: RootEntityTkey<int>
    {
        public User()
        {
        }
        public User(string username,string password)
        {
            Username = username;
            Password = password;
            LastLoginTime = DateTime.Now;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            ErrorCount = 0;
            IsDeleted = false;
        }
        /// <summary>
        /// 用户名(登录)
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码(MD5)
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 错误次数
        /// </summary>
        public int ErrorCount { get; set; }
        /// <summary>
        /// 性别：0：女，1：男
        /// </summary>
        public int Sex { get; set; } = 1;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 上次登录IP地址
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
