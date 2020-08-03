using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PizzaRestaurant.Model
{
    class MenuItemModel
    {
        /// <summary>
        /// Gets all FoodMenu objects
        /// </summary>
        /// <returns>A list of all FoodMenu objects</returns>
        public List<FoodMenu> GetAllMenuItems()
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    List<FoodMenu> menu = new List<FoodMenu>();
                    menu = (from m in context.FoodMenus select m).ToList();
                    return menu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
