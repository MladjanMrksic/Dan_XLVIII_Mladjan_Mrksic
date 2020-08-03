using PizzaRestaurant.Model;
using PizzaRestaurant.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PizzaRestaurant.Validation
{
    class LoginValidation
    {
        FoodOrderModel fom = new FoodOrderModel();
        /// <summary>
        /// This method validates login information and opens new windows depending on the results
        /// </summary>
        /// <param name="username">Username parameter</param>
        /// <param name="password">Password parameter</param>
        /// <param name="main">Window that needs to be closed if validation is successfull</param>
        public void Login(string username, string password, MainWindow main)
        {
            List<FoodOrder> orderList = fom.GetAllFoodOrders();
            //Admin login
            if (username == "Employee" && password == "Employee")
            {
                AdminView av = new AdminView();
                main.Close();
                av.Show();
            }
            //Guest login
            else if (orderList.Contains((from o in orderList where o.CustomerJMBG == username select o).FirstOrDefault()) && password == "Guest")
            {               
                FoodOrder fo;
                using (FoodOrderAppBaseEntities1 context = new FoodOrderAppBaseEntities1())
                {                    
                    fo = (from o in context.FoodOrders where o.CustomerJMBG == username select o).FirstOrDefault();
                }
                //Guest loging with FoodOrder on Ready status
                if (fo.StatusOfOrder == "READY")
                {
                    AutoClosingMessageBox.Show("You order is ready!\nEnjoy your meal.", "Bon Appétit", 2000);
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
                //Guest loging with FoodOrder on Processing status
                else if (fo.StatusOfOrder == "PROCESSING")
                {
                    MessageBox.Show("You order is still processing.\nThank you for your patience.", "Almost there...", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                //Guest loging with FoodOrder on Rejected status
                else if (fo.StatusOfOrder == "REJECTED")
                {
                    AutoClosingMessageBox.Show("You order is rejected.\nPlease try again.", "Rejected", 2000);
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
                //Guest loging with no existing FoodOrder
                else if (fo == null)
                {
                    CustomerView cv = new CustomerView(username);
                    main.Close();
                    cv.Show();
                }
            }
            //Wrong credentials
            else
            {
                MessageBox.Show("Username or Password was incorrect ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
