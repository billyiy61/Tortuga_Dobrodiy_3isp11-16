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
            products.Clear();
            orders.Clear();
            prods.Clear();
            FinalTotalPrice = 0;
            FinalPageFrame.Navigate(new MenuPage());
        }
    }
}
