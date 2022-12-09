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
using System.Data.Common;

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
            ProdCountryCB.ItemsSource = DbConnect.db.Country.ToList();
            ProdCountryCB.DisplayMemberPath = "Name";
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

        private void DelCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            var selCountry = CountryList.SelectedItem as ProductCountry;
            if (selCountry == null)
            {
                MessageBox.Show("Не выбрана страна", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var countryProductItem = DbConnect.db.ProductCountry.ToList().Find(x => x.CountryId == selCountry.CountryId && x.ProductId == selCountry.ProductId);
                if (countryProductItem != null)
                {
                    DbConnect.db.ProductCountry.Remove(countryProductItem);
                    DbConnect.db.SaveChanges();
                    CountryList.ItemsSource = DbConnect.db.ProductCountry.ToList().Where(x => x.ProductId == product.Id);
                }
                else
                {
                    MessageBox.Show("Ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (product.Id != 0)
            {
                var selCountry = ProdCountryCB.SelectedItem as Country;
                if (selCountry != null)
                {
                    var selCountry1 = DbConnect.db.ProductCountry.ToList().Find(x => x.CountryId == selCountry.Id && x.ProductId == product.Id);
                    if (selCountry1 != null && selCountry.Id == selCountry1.CountryId)
                    {
                        MessageBox.Show("Данная страна уже есть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        ProductCountry productCountry = new ProductCountry()
                        {
                            ProductId = product.Id,
                            CountryId = selCountry.Id
                        };
                        product.ProductCountry.Add(productCountry);
                        DbConnect.db.SaveChanges();
                        CountryList.ItemsSource = DbConnect.db.ProductCountry.ToList().Where(x => x.ProductId == product.Id);
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрана страна", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Сначала создайте продукт, не прикрепляя стран", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}


