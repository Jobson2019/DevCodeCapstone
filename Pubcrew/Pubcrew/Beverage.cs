//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pubcrew
{
    using System;
    using System.Collections.Generic;
    
    public partial class Beverage
    {
        public int beverageId { get; set; }
        public string brandName { get; set; }
        public string bevProductLineName { get; set; }
        public int BusinessId { get; set; }
    
        public virtual Inventory Inventory { get; set; }
    }
}