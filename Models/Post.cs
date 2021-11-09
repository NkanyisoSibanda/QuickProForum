using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QuickPropForum.Models
{
    [Table("Post")]
    public partial class Post
    {
        [Key]
        public int Id { get; set; }
        [Column("ParentID")]
        public int ParentId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatePosted { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Posts")]
        public virtual User User { get; set; }
    }
}
