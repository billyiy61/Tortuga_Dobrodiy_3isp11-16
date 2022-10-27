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
using Tortuga_Dobrodiy_3isp11_16.EF;
using static Tortuga_Dobrodiy_3isp11_16.ClassEntities;
using static Tortuga_Dobrodiy_3isp11_16.Calculation;
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        List<Product> prod = new List<Product>();
        public CartPage()
        {
            InitializeComponent();
            int l = orders.Count();
            Order[] arrOrd = new Order[l];
            arrOrd = orders.ToArray();
            int y = arrOrd.Length;


            double TotalPrice = 0;

            for (int i = 0; i < y; i++)
            {
                Order o = arrOrd[i];
                Product p = context.Product.Where(k => k.IDProduct == o.IDProduct).FirstOrDefault();
                prod.Add(context.Product.Where(j => j.IDProduct == o.IDProduct).FirstOrDefault());
                TotalPrice += Convert.ToDouble(o.Qty * p.Cost);
            }

           
            AllProducts.ItemsSource = prod;

            CostTxb.Text = Convert.ToString(TotalPrice);
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CartFrame.Navigate(new MenuPage());
        }

        private void AllProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
