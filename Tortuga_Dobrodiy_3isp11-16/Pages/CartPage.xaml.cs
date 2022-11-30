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
using static Tortuga_Dobrodiy_3isp11_16.Calculating;

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
            //int l = orders.Count();
            //Order[] arrOrd = new Order[l];
            //arrOrd = orders.ToArray();
            //int y = arrOrd.Length;


            Prods[] pArr = new Prods[productsForSale.prods.Count];
            pArr = productsForSale.prods.ToArray();




            DateTime today = System.DateTime.Now;

            AllProducts.ItemsSource = productsForSale.prods.ToList();
            FinalTotalPrice = Calculating.TotalPrice(pArr, today); 
            CostTxb.Text = Convert.ToString(Calculating.TotalPrice(pArr, today));
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            Prods[] pArr = new Prods[productsForSale.prods.Count()];
            if (pArr.Length != 0)
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
                Prods prod = (Prods)obect;
                Prods prd = productsForSale.prods.Where(k => k.IDProduct == prod.IDProduct).FirstOrDefault();

                if ((productsForSale.prods.Any(q => q.IDProduct == prd.IDProduct)) && (prd.Qty > 0))
                {
                    productsForSale.prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault().Qty -= 1;
                    //products.Find(t => t.IDProduct == prd.IDProduct).Qty -= 1;
                }
                else if ((productsForSale.prods.Any(q => q.IDProduct == prd.IDProduct)) && (prd.Qty < 1))
                {
                    productsForSale.prods.Remove(productsForSale.prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault());
                }
            }
        }
    }
}
