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
        FoodCustomerModel fcm = new FoodCustomerModel();
        public void Login(string username, string password, MainWindow main)
        {
            List<FoodCustomer> customersList = fcm.GetAllFoodCustomers();
            if (username == "Employee" && password == "Employee")
            {
                AdminView av = new AdminView();
                main.Close();
                av.Show();
            }
            else if (customersList.Contains((from c in customersList where c.JMBG == username select c).FirstOrDefault()) && password == "Guest")
            {
                FoodCustomer fc;
                FoodOrder fo;
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    fc = (from c in context.FoodCustomers where c.JMBG == username select c).FirstOrDefault();
                    fo = (from o in context.FoodOrders where o.FoodCustomer.JMBG == fc.JMBG select o).FirstOrDefault();
                }
                if (fo == null)
                {
                    CustomerView cv = new CustomerView(fc);
                    main.Close();
                    cv.Show();
                }
                else if (fo.StatusOfOrder == "READY")
                {
                    AutoClosingMessageBox.Show("You order is ready!\nEnjoy your meal.", "Bon Appétit", 2000);
                    CustomerView cv = new CustomerView(fc);
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
                    CustomerView cv = new CustomerView(fc);
                    main.Close();
                    cv.Show();
                }
            }
            else if (!customersList.Contains((from c in customersList where c.JMBG == username select c).FirstOrDefault()) && password == "Guest")
            {
                FoodCustomer fc = new FoodCustomer();
                fc.JMBG = username;
                fcm.AddFoodCustomer(fc);
                CustomerView cv = new CustomerView(fc);
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
