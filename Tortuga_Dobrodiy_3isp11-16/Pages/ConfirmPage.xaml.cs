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
using Tortuga_Dobrodiy_3isp11_16.Pages;
using Tortuga_Dobrodiy_3isp11_16.Win;
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;
using static Tortuga_Dobrodiy_3isp11_16.ClassEntities;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConfirmPage.xaml
    /// </summary>
    public partial class ConfirmPage : Page
    {
        public ConfirmPage()
        {
            InitializeComponent();

            EF.Order ord = new Order();


            EF.ProductSale check = new ProductSale();
            check.SaleDate = DateTime.Now;
            //check.ClientName = ;
            //check.IDEmployee = ClassEntities.IDEmployee;
            //check.TotalPrice = Convert.ToDecimal(FinalCosttxt.Text);

            context.ProductSale.Add(check);
            context.SaveChanges();

            int n = products1.Count();

            EF.Product[] arr = new Product[n];

            arr = products1.ToArray();

            for (int i = 0; i < n; i++)
            {
                EF.Product p = arr[i];

                ord.IDProduct = arr[i].IDProduct;
                //ord.IDProductSale = check.IDProductSale;
                //ord.Qty = productsForSale.products1.Find(t => t.IDProduct == p.IDProduct).Qty;

                context.Order.Add(ord);
                context.SaveChanges();

            }




            //txtIDClient.Text = Convert.ToString(1);

            //productsForSale.products1.Clear();

            //AllProdForSale.ItemsSource = productsForSale.products1.ToList();
            //FinalCosttxt.Text = Convert.ToString(Calculation.CostCalc(ClientDisc));

            MessageBox.Show("Заказ оплачен");
            //foreach (var item in productsForSale.products1)
            //{



        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtIDClient_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtIDClient_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtIDClient_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtDiscountNew_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDiscountNew_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtDiscountNew_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
