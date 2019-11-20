using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pubcrew.Models
{
    public class Amenity
    {
        [Key]
        public int amenityId { get; set; }

        [Display(Name = "Supply Name")]
        public string supplyName { get; set; }

        [Display(Name = "Product Line Name")]
        public string amProductLineName { get; set; }

        [ForeignKey("Inventory")]
        public int locationId { get; set; }
        public Inventory Inventory { get; set; }
    }
}