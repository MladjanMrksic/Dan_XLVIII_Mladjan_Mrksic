using PizzaRestaurant.Command;
using PizzaRestaurant.Model;
using PizzaRestaurant.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class CustomerViewModel : ViewModelBase
    {
        CustomerView view;
        MenuItemModel mim = new MenuItemModel();
        string jmbg;        
        FoodOrderModel fom = new FoodOrderModel();

        #region Constructor
        public CustomerViewModel(CustomerView newView, string JMBG)
        {
            view = newView;
            menuItems = mim.GetAllMenuItems();
            TotalPrice = 0;
            jmbg = JMBG;
        }
        #endregion

        #region Properties
        private List<FoodMenu> menuItems;
        public List<FoodMenu> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                menuItems = value;
                OnPropertyChanged("MenuItems");
            }
        }

        private FoodMenu menuItem;
        public FoodMenu MenuItem
        {
            get
            {
                return menuItem;
            }
            set
            {
                menuItem = value;
                OnPropertyChanged("MenuItem");
            }
        }

        private decimal totalPrice;
        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        #endregion

        #region Commands
        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddExecute(), param => CanAddExecute());
                }
                return add;
            }
        }
        private void AddExecute()
        {
            TotalPrice += MenuItem.Price;
            OnPropertyChanged("TotalPrice");
        }
        private bool CanAddExecute()
        {
            if (MenuItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            MainWindow logout = new MainWindow();
            view.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand checkout;
        public ICommand Checkout
        {
            get
            {
                if (checkout == null)
                {
                    checkout = new RelayCommand(param => CheckoutExecute(), param => CanCheckoutExecute());
                }
                return checkout;
            }
        }
        private void CheckoutExecute()
        {
            FoodOrder order = new FoodOrder();
            order.CustomerJMBG = jmbg;
            order.DateOfOrder = DateTime.Now;
            order.Price = TotalPrice;
            order.StatusOfOrder = "PROCESSING";
            fom.AddFoodOrder(order);
            MessageBox.Show("Your order is placed and is being processed.", "Order sucessfull!", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow logout = new MainWindow();
            view.Close();
            logout.Show();
        }
        private bool CanCheckoutExecute()
        {
            if (TotalPrice == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
