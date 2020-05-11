using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int OageId { get; set; }

        [Display(Name = "Group Id")]                        //Name
        [Required(ErrorMessage = "Please Insert {0}.")]     //Esential field - Null not allowed
        public int GroupId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(250)]                                    //Maximum Length
        public string Title { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]                  // Multiline TextBox
        public string ShortDescription { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string PageText { get; set; }

        [Display(Name = "Number of View")]
        public int Visit { get; set; }

        [Display(Name = "Image")]
        public string ImageName { get; set; }

        [Display(Name = "Slider")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "Date of Create")]
        [DisplayFormat(DataFormatString ="{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name ="Key Words")]
        public string Tags { get; set; }
        public virtual PageGroup PageGroups { get; set; }

        public Page ()
        {

        }

        public virtual List<PageComment> PageComments { get; set; }

    }
}
