using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QuickPropForum.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [MaxLength(50)]
        public byte[] ProfilePic { get; set; }

        [InverseProperty(nameof(Post.User))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
