﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FoodOrderAppBaseEntities1 : DbContext
    {
        public FoodOrderAppBaseEntities1()
            : base("name=FoodOrderAppBaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FoodMenu> FoodMenus { get; set; }
        public virtual DbSet<FoodOrder> FoodOrders { get; set; }
    }
}
