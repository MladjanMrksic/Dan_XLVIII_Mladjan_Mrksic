using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.Model
{
    class FoodCustomerModel
    {
        public List<FoodCustomer> GetAllFoodCustomers()
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    List<FoodCustomer> customers = new List<FoodCustomer>();
                    customers = (from c in context.FoodCustomers select c).ToList();
                    return customers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public FoodCustomer GetFoodCustomer(int id)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodCustomer fc = new FoodCustomer();
                    fc = (from c in context.FoodCustomers where c.CustomerID == id select c).FirstOrDefault();
                    return fc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteFoodCustomer(int customerID)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodCustomer customer = (from c in context.FoodCustomers where c.CustomerID == customerID select c).FirstOrDefault();
                    context.FoodCustomers.Remove(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddFoodCustomer(FoodCustomer customer)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    context.FoodCustomers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
