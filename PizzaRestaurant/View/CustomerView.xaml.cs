using PizzaRestaurant.ViewModel;
using System.Windows;

namespace PizzaRestaurant.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        public CustomerView(string JMBG)
        {
            InitializeComponent();
            DataContext = new CustomerViewModel(this,JMBG);
        }
    }
}
