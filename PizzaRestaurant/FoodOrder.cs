//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaRestaurant
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodOrder
    {
        public int OrderID { get; set; }
        public string CustomerJMBG { get; set; }
        public Nullable<System.DateTime> DateOfOrder { get; set; }
        public decimal Price { get; set; }
        public string StatusOfOrder { get; set; }
    }
}
