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


namespace Tortuga_Dobrodiy_3isp11_16.Win
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        
        public EmployeeWindow()
        {
            InitializeComponent();

            //List<PSs> pss = new List<PSs>();

            //EF.ProductSale[] productSales = new ProductSale[context.ProductSale.Count()];
            //productSales = context.ProductSale.ToArray();

            //for (int i = 0; i < productSales.Length; i++)
            //{
            //    PSs ps = new PSs();
            //    EF.ProductSale ps1 = productSales[i];
            //    ps.ClientName = ps1.ClientName;
            //    ps.dateTime = Convert.ToString(ps1.SaleDate);
            //    ps.TableNumber = ps1.TableNum;
            //    ps.Payment = context.PaymentType.Where(k => k.IDPayment == ps1.IDPayment).FirstOrDefault().Title;
            //    pss.Add(ps);
            //}

            this.DataContext = this;
            AllProducts.ItemsSource = context.vw_pss.Where(k => k.IsActive != false).ToList(); ;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartWindow startWindow = new StartWindow();
            startWindow.ShowDialog();
            this.Close();
        }

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {
            Object obj = (Object)AllProducts.SelectedItem;
            EF.vw_pss pss = (EF.vw_pss)obj;

            context.ProductSale.Where(k => k.IDProductSale == pss.IDProductSale).FirstOrDefault().IsActive = false;
            context.SaveChanges();
            AllProducts.ItemsSource = context.vw_pss.Where(k => k.IsActive != false).ToList();
        }

        private void AllProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Object obj = (Object)AllProducts.SelectedItem;
            EF.vw_pss pss = (EF.vw_pss)obj;

            IdPS = pss.IDProductSale;

            ProductSaleInfo productSaleInfo = new ProductSaleInfo();
            productSaleInfo.ShowDialog();

        }
    }
}
