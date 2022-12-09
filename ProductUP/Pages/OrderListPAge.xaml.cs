using ProductUP.Componets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductUP.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderListPAge.xaml
    /// </summary>
    public partial class OrderListPAge : Page
    {
        public OrderListPAge()
        {
            InitializeComponent();
            OrdersList.ItemsSource = DbConnect.db.Order.ToList();
        }

        private void ExecutionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Navigation.role == 1 && Navigation.role == 3 && Navigation.role == 2)
            {
                Navigation.NextPage(new Nav(new Execution()));
            }
            else
                MessageBox.Show("Отказано в доступе");
            
        }

        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var selSection = (sender as Button).DataContext as ProductOrder;
            DbConnect.db.ProductOrder.Remove(selSection);
            DbConnect.db.SaveChanges(); 
        }
    }
}
