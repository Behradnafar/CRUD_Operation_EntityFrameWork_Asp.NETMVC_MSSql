using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "News")]
        [Required(ErrorMessage = "Please insert {0}")]
        public int PageId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please insert {0}")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "WebSite")]
        [MaxLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Please insert {0}")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Comment Date")]
        public DateTime CreateDate { get; set; }

        public virtual Page page { get; set; }
        public PageComment()
        {

        }
    }
}
