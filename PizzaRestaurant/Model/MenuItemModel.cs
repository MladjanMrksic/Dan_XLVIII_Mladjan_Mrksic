using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.Model
{
    class MenuItemModel
    {
        public List<FoodMenu> GetAllMenuItems()
        {
            try
            {
                using (FoodOrderAppBaseEntities1 context = new FoodOrderAppBaseEntities1())
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
