using PizzaRestaurant.Command;
using PizzaRestaurant.Model;
using PizzaRestaurant.View;
using System.Collections.Generic;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        public AdminView view;
        FoodOrderModel fom = new FoodOrderModel();

        #region Constructor
        public AdminViewModel(AdminView av)
        {
            view = av;
            foodOrders = fom.GetAllFoodOrders();

        }
        #endregion

        #region Properties
        public string SelectedStatus
        {
            get { return FOrder.StatusOfOrder; }
            set
            {
                FOrder.StatusOfOrder = value;
                OnPropertyChanged("SelectedStatus");
            }
        }

        private List<FoodOrder> foodOrders;
        public List<FoodOrder> FoodOrders
        {
            get
            {
                return foodOrders;
            }
            set
            {
                foodOrders = value;
                OnPropertyChanged("FoodOrders");
            }
        }

        private FoodOrder fOrder;
        public FoodOrder FOrder
        {
            get
            {
                return fOrder;
            }
            set
            {
                fOrder = value;
                OnPropertyChanged("FOrder");
            }
        }
        #endregion

        #region Commands
        private ICommand deleteFoodOrder;
        public ICommand DeleteFoodOrder
        {
            get
            {
                if (deleteFoodOrder == null)
                {
                    deleteFoodOrder = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }
                return deleteFoodOrder;
            }
        }
        private void DeleteEmployeeExecute()
        {
            fom.DeleteFoodOrder(FOrder.OrderID);
            foodOrders = fom.GetAllFoodOrders();

        }
        private bool CanDeleteEmployeeExecute()
        {
            if (FOrder == null)
            {
                return false;
            }
            else if (FOrder.StatusOfOrder.ToUpper() == "READY" || FOrder.StatusOfOrder.ToUpper() == "REJECTED")
            {
                return true;
            }
            return false;
        }

        private ICommand updateFoodOrder;
        public ICommand UpdateFoodOrder
        {
            get
            {
                if (updateFoodOrder == null)
                {
                    updateFoodOrder = new RelayCommand(param => UpdateFoodOrderExecute(), param => CanUpdateFoodOrderExecute());
                }
                return updateFoodOrder;
            }
        }
        private void UpdateFoodOrderExecute()
        {
            fom.UpdateFoodOrder(FOrder);
            foodOrders = fom.GetAllFoodOrders();
        }
        private bool CanUpdateFoodOrderExecute()
        {
            return true;
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
        #endregion
    }
}
