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
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;
using static Tortuga_Dobrodiy_3isp11_16.ClassEntities;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        public FinalPage()
        {
            InitializeComponent();
        }

        private void backToStartBtn_Click(object sender, RoutedEventArgs e)
        {
            //List<EF.Product> productsNew = new List<EF.Product>();
            //products = productsNew;
            trys += 1;
            Prods[] pArr = new Prods[prods.Count()];
            pArr = prods.ToArray();
            for (int i = 0; i < pArr.Length; i++)
            {
                Prods p = pArr[i];
                context.Product.Where(k => k.IDProduct == p.IDProduct).FirstOrDefault().Qty = 0;
            }

            prods.Clear();


            FinalTotalPrice = 0;
            FinalPageFrame.Navigate(new MenuPage());
        }
    }
}
