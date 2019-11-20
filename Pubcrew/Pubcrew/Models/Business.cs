using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pubcrew.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        [Display(Name = "Business Name")]
        public string businessName { get; set; }

        


    }
}