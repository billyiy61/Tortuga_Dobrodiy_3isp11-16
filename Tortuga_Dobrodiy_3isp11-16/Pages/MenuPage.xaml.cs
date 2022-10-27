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
using static Tortuga_Dobrodiy_3isp11_16.ClassEntities;
using Tortuga_Dobrodiy_3isp11_16.Win;
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        List<EF.Product> products = new List<EF.Product>();
        public MenuPage()
        {
            InitializeComponent();

            this.DataContext = this;


            AllProducts.ItemsSource = context.Product.ToList();
        }

        private void Filter()
        {
            products = ClassEntities.context.Product.ToList();

            products = products.Where(i => (i.Title.Contains(txtSearch.Text))).ToList();



            AllProducts.ItemsSource = products;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void AllProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Object obect = (Object)AllProducts.SelectedItem;
            EF.Product prod = (EF.Product)obect;
            EF.Product refrProd = products1.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();

            EF.Order ord = new EF.Order();



            if (orders.Any(q => q.IDProduct == prod.IDProduct))
            {
                orders.Find(r => r.IDProduct == prod.IDProduct).Qty += 1;

            }
            else
            {
                ord.IDProduct = prod.IDProduct;
                ord.Qty = 1;
                orders.Add(ord);

            }

            //this.Hide();
            //ProductSaleWindow productSaleWindow = new ProductSaleWindow();
            //productSaleWindow.ShowDialog();
            //this.Close();

        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new CartPage());
        }
    }
}
