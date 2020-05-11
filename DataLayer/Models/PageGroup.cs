using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]    //Primary Key
        public int GroupId { get; set; }


        [Display (Name ="Group Title")]    //صفت
        [Required (ErrorMessage ="Please Insert {0}.")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }

        //Navigation Property  رابطه گروه با پیج برقرار شد
        public virtual List<Page> Pages { get; set; }

        public PageGroup()
        {

        }
    }
}
