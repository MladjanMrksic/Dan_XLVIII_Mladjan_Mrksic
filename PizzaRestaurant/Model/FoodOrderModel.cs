using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.Model
{
    class FoodOrderModel
    {
        public List<FoodOrder> GetAllFoodOrders()
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    List<FoodOrder> orders = new List<FoodOrder>();
                    orders = (from o in context.FoodOrders select o).ToList();
                    return orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public FoodOrder GetFoodOrder(string jmbg)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodOrder fo = new FoodOrder();
                    fo = (from o in context.FoodOrders where o.FoodCustomer.JMBG == jmbg select o).FirstOrDefault();
                    return fo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteFoodOrder(int orderID)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodOrder order = (from o in context.FoodOrders where o.OrderID == orderID select o).FirstOrDefault();
                    context.FoodOrders.Remove(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddFoodOrder(FoodOrder order)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    context.FoodOrders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateFoodOrder(FoodOrder updatedOrder)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodOrder order = (from o in context.FoodOrders where o.OrderID == updatedOrder.OrderID select o).FirstOrDefault();
                    order.StatusOfOrder = updatedOrder.StatusOfOrder;
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
