using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.Models
{
    public class NewPostModel
    {        
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string PostContent { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public byte[] AuthorProfilePic { get; set; }
        public DateTime? DatePosted { get; set; }

        public PostListingsModel PostListingsModel { get; set; }

        public IEnumerable<SelectListItem> LstUsers { get; set; }
        public IEnumerable<Post> PostReplies { get; set; }
    }
}
