using Microsoft.Win32;
using System.IO;
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
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Page
    {
        Product product;
        public ProductAdd( Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
        }

        private void SeaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (product.Id == 0)
            {
                DbConnect.db.Product.Add(product);
            }
            DbConnect.db.SaveChanges();
            MessageBox.Show("Все успешно");
            Navigation.NextPage(new Nav(new ProductListPage()));
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|.jpeg|*.jpeg|*.jpg|*.jpg",

            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                product.Photo =  File.ReadAllBytes(openFileDialog.FileName);
                S63AMG.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }
    }
}
