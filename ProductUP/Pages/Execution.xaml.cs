using ProductUP.Componets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для Execution.xaml
    /// </summary>
    public partial class Execution : Page
    {
        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(Execution));


        public ObservableCollection<Product> ProductsAddOrder
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsAddOrderProperty); }
            set { SetValue(ProductsAddOrderProperty, value); }
        }

        public static readonly DependencyProperty ProductsAddOrderProperty =
            DependencyProperty.Register("ProductsAddOrder", typeof(ObservableCollection<Product>), typeof(Execution));



        public Execution()
        {
            DbConnect.db.Product.Load();
            Products = new ObservableCollection<Product> (DbConnect.db.Product.Local);
            ProductsAddOrder = new ObservableCollection<Product>();

            InitializeComponent();
        }

        private void ButtonAddProductOrderClick(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem == null)
                return;

            Product product = ProductList.SelectedItem as Product;

            Products.Remove(product);
            ProductsAddOrder.Add(product);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            decimal totalCost = 0;

            foreach (var item in ProductsAddOrder)
                totalCost += (decimal)item.Cost;

            Order order = new Order()
            {
                EmployeeId = 4, 
                ClientId = Navigation.AuthUser.Id, //
                StatusId = 1,
                OrderDate = DateTime.Now,
                TotalCost = totalCost
            };

            DbConnect.db.Order.Add(order);

            foreach (var item in ProductsAddOrder)
            {
                ProductOrder product = new ProductOrder()
                {
                    OrderId = order.Id,
                    Product = item,
                    Count = item.Count
                };

                DbConnect.db.ProductOrder.Add(product);
            }

            DbConnect.db.SaveChanges();
            Navigation.NextPage(new Nav(new OrderListPAge()));
        }
    }
}
