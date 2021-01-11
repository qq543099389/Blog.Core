using Blog.Core.Model.Models.RootKey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model.Models
{
    public class Role:RootEntityTkey<int>
    {
        public Role()
        {
        }
        public Role(string name)
        {
            Name = name;
            CreateTime = DateTime.Now;
            IsDeleted = false;
        }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
