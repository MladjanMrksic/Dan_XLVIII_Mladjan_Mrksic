using PizzaRestaurant.ViewModel;
using System.Windows;

namespace PizzaRestaurant.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            DataContext = new AdminViewModel(this);
        }
    }
}
