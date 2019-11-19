using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pubcrew.Models
{
    public class Inventory
    {
        [Key]
        public int productId { get; set; }

        [Display(Name = "Product Name")]
        public string productName { get; set; }
        [Display(Name = "Product Description")]
        public string productDescription { get; set; }

        public int currentInventory { get; set; }

    }
}