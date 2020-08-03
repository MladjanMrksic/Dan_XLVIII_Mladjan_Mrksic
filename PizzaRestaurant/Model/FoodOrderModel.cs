using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PizzaRestaurant.Model
{
    class FoodOrderModel
    {
        /// <summary>
        /// This method gets all FoodOrders from Database
        /// </summary>
        /// <returns>A list of all FoodOrders</returns>
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
        /// <summary>
        /// Gets a specific FoodOrder
        /// </summary>
        /// <param name="jmbg">jmbg is a search parameter by which FoodOrders are searched</param>
        /// <returns>Returns a single instance of FoodOrder</returns>
        public FoodOrder GetFoodOrder(string jmbg)
        {
            try
            {
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    FoodOrder fo = new FoodOrder();
                    fo = (from o in context.FoodOrders where o.CustomerJMBG == jmbg select o).FirstOrDefault();
                    return fo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        /// <summary>
        /// Deletes a food order with matching parameter
        /// </summary>
        /// <param name="orderID">Deletes FoodOrder with given ID</param>
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
        /// <summary>
        /// Adds new instance of FoodOrder class
        /// </summary>
        /// <param name="order">FoodOrder class being added</param>
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
                MessageBox.Show("FOM Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Updated FoodOrder class object
        /// </summary>
        /// <param name="updatedOrder">New FoodOrder with changes already made</param>
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
