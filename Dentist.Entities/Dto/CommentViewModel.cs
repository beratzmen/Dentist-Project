using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Entities.Dto
{
    public class CommentUIViewModel
    {
        public int Id { get; set; }
        public int? ReplyId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CommentUIViewModel> Comments { get; set; }
    }
}
