using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPropForum.Models
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string PostContent { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public byte[] AuthorProfilePic { get; set; }
        public DateTime? DatePosted { get; set; }

        public int PostId { get; set; }
    }
}
