using PizzaRestaurant.Model;
using PizzaRestaurant.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.Validation
{
    class LoginValidation
    {
        FoodOrderModel fom = new FoodOrderModel();
        public void Login(string username, string password, MainWindow main)
        {
            List<FoodOrder> orderList = fom.GetAllFoodOrders();
            if (username == "Employee" && password == "Employee")
            {
                AdminView av = new AdminView();
                main.Close();
                av.Show();
            }
            else if (orderList.Contains((from o in orderList where o.CustomerJMBG == username select o).FirstOrDefault()) && password == "Guest")
            {               
                FoodOrder fo;
                using (FoodOrderAppBaseEntities1 context = new FoodOrderAppBaseEntities1())
                {                    
                    fo = (from o in context.FoodOrders where o.CustomerJMBG == username select o).FirstOrDefault();
                }
                if (fo.StatusOfOrder == "READY")
                {
                    AutoClosingMessageBox.Show("You order is ready!\nEnjoy your meal.", "Bon Appétit", 2000);
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
                else if (fo.StatusOfOrder == "PROCESSING")
                {
                    MessageBox.Show("You order is still processing.\nThank you for your patience.", "Almost there...", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else if (fo.StatusOfOrder == "REJECTED")
                {
                    AutoClosingMessageBox.Show("You order is rejected.\nPlease try again.", "Rejected", 2000);
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
                else if (fo == null)
                {
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
            }
            else if (!orderList.Contains((from c in orderList where c.CustomerJMBG == username select c).FirstOrDefault()) && password == "Guest")
            {                
                CustomerView cv = new CustomerView(username);
                main.Close();
                cv.Show();
            }
            else
            {
                MessageBox.Show("Username or Password was incorrect ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
