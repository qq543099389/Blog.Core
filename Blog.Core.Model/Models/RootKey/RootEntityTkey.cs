using FreeSql.DataAnnotations;
using System;

namespace Blog.Core.Model.Models.RootKey
{
    public class RootEntityTkey<Tkey> where Tkey : IEquatable<Tkey>
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Tkey Id { get; set; }
    }
}
