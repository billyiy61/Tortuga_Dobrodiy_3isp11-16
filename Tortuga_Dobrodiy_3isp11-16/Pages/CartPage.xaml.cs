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
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;
using static Tortuga_Dobrodiy_3isp11_16.Prods;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        
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
                Prods p = prods.Where(r => r.IDProduct == o.IDProduct).FirstOrDefault();
                TotalPrice += Convert.ToDouble(o.Qty * p.Cost);
            }

           
            AllProducts.ItemsSource = prods;
            FinalTotalPrice = TotalPrice;
            CostTxb.Text = Convert.ToString(TotalPrice);
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productsForSale.products != null)
            {
                CartFrame.Navigate(new ConfirmPage());
            }
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CartFrame.Navigate(new MenuPage());
        }

        private void AllProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AllProducts.SelectedItem != null)
            {
                Object obect = (Object)AllProducts.SelectedItem;
                EF.Product prod = (EF.Product)obect;
                EF.Product prd = products.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();

                Prods pr = prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault();
                EF.Order or = orders.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault();

                if ((orders.Any(q => q.IDProduct == prd.IDProduct)) && (prd.Qty > 0))
                {
                    orders.Find(r => r.IDProduct == prd.IDProduct).Qty -= 1;
                    prods.Find(k => k.IDProduct == prd.IDProduct).Qty -= 1;
                    products.Find(t => t.IDProduct == prd.IDProduct).Qty -= 1;
                }
                else 
                {
                    prods.Remove(pr);
                    orders.Remove(or);
                }
            }
        }
    }
}
