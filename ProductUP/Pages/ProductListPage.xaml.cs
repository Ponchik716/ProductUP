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
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = DbConnect.db.Product.ToList();

        }

        private void Refresh()
        {
            IEnumerable<Product> filter = DbConnect.db.Product;
            if (Sort.SelectedIndex > 0)
            {
                if (Sort.SelectedIndex == 1)
                    filter = filter.OrderBy(x => x.Name);
                else if (Sort.SelectedIndex == 2)
                    filter = filter.OrderByDescending(x => x.Name);
                else if (Sort.SelectedIndex == 3)
                    filter = filter.OrderBy(x => x.DateAdd);
                else if (Sort.SelectedIndex == 4)
                    filter = filter.OrderByDescending(x => x.DateAdd);
            }
            ////
            if (SearchBox.Text.Length > 0)
            {
                filter = filter.Where(x => x.Name.ToLower().StartsWith(SearchBox.Text.ToLower()) || x.Discription.ToLower().StartsWith(SearchBox.Text.ToLower()));
            }

            ProductList.ItemsSource = filter.ToList();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
