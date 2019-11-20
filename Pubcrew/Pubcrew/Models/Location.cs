using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Pubcrew.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Display(Name = "Location Name")]
        public string locationName { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

    }
}