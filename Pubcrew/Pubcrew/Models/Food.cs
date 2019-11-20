using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pubcrew.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Display(Name = "Food")]
        public string foodName { get; set; }

        [Display(Name = "Product Line Name")]
        public string foodProductLineName { get; set; }

        [Display(Name = "Expiration")]
        public DateTime? foodExpirationDate { get; set; }
        [ForeignKey("Inventory")]
        public int inventoryId { get; set; }
        public Inventory Inventory { get; set; }



    }
}