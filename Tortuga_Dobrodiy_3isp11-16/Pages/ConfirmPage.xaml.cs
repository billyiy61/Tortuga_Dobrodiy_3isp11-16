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
        List<EF.PaymentType> ptList = new List<PaymentType>();
        
        public ConfirmPage()
        {
            InitializeComponent();
            FinalCosttxt.Text = Convert.ToString(productsForSale.FinalTotalPrice);

            List<String> ptListStr = new List<string>();

            ptList = context.PaymentType.ToList();

            EF.PaymentType[] paymentTypes = new PaymentType[ptList.Count()];
            paymentTypes = ptList.ToArray();
            for (int i = 0; i < paymentTypes.Length; i++)
            {
                ptListStr.Add(paymentTypes[i].Title);
            }
            

            PaymentTypeCmbbx.ItemsSource = ptListStr;
            AllProducts.ItemsSource = productsForSale.prods.ToList();

            
           
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (productsForSale.prods.Count() != 0)
                {
                    EF.Order ord = new Order();
                    EF.ProductSale check = new ProductSale();
                    check.SaleDate = DateTime.Now;
                    check.TableNum = Convert.ToInt32(txtTableNum.Text);
                    check.IDPayment = ptList.Find(x => x.Title == PaymentTypeCmbbx.Text).IDPayment;
                    check.ReadyTime = DateTime.Now;
                    check.ClientName = txtClientName.Text;
                    check.Price = Convert.ToDecimal(FinalCosttxt.Text);
                    check.IsActive = true;

                    context.ProductSale.Add(check);
                    context.SaveChanges();

                    int n = productsForSale.prods.Count();

                    Prods[] prods1 = new Prods[productsForSale.prods.Count()];
                    prods1 = productsForSale.prods.ToArray();

                    for (int i = 0; i < n; i++)
                    {
                        ord.IDProduct = prods1[i].IDProduct;
                        ord.IDProductSale = check.IDProductSale;
                        ord.Qty = prods1[i].Qty;

                        context.Order.Add(ord);
                        context.SaveChanges();

                    }
                    MessageBox.Show("Заказ оплачен");
                    ConfirmFrame.Navigate(new FinalPage());
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
                throw;
            }
            
        }

        private void txtClientName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtClientName.Text == "Имя")
            {
                txtClientName.Text = "";
            }
        }

        private void txtClientName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtClientName.Text == "")
            {
                txtClientName.Text = "Имя";
            }
        }

        private void txtTableNum_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtTableNum.Text == "***")
            {
                txtTableNum.Text = "";
            }
        }

        private void txtTableNum_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTableNum.Text == "")
            {
                txtTableNum.Text = "***";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ConfirmFrame.Navigate(new CartPage());
        }
    }
}
