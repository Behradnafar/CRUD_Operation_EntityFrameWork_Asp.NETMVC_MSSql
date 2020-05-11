using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DataLayer
{       
                /// <summary>
                /// in this class we create all the table we want in DB
                /// </summary>
    public class MyCmsContext :DbContext  
    {
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }

    }
}
