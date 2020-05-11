using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class AdminLogin
    {
        [Key]
        public int LoginID { get; set; }

        [Display (Name ="UserName")][Required(ErrorMessage ="Please insert {0} ")][MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please insert {0} ")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please insert {0} ")]
        [MaxLength(200)]
        public string Password { get; set; }
    }
}
