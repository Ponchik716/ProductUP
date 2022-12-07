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
            OrderList.ItemsSource = DbConnect.db.Order.ToList();
        }
    }
}
