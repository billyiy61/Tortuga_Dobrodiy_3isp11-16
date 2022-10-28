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
using static Tortuga_Dobrodiy_3isp11_16.Prods;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        List<String> tagsStr = new List<string>();
        public MenuPage()
        {
            InitializeComponent();

            this.DataContext = this;

            List<EF.vw_ProdTag> tags = context.vw_ProdTag.ToList();


            EF.vw_ProdTag[] tagsArr = new EF.vw_ProdTag[tags.Count()];
            tagsArr = tags.ToArray();

            for (int i = 0; i < tagsArr.Length; i++)
            {
                tagsStr.Add(tagsArr[i].TagTitle);
            }

            TagsCmbbx.ItemsSource = tagsStr;
            products = ClassEntities.context.Product.ToList();

            AllProducts.ItemsSource = products;
        }

        private void Filter()
        {
            products = ClassEntities.context.Product.ToList();

            products = products.Where(i => (i.Title.Contains(txtSearch.Text))).ToList();



            AllProducts.ItemsSource = products;

        }

        private void FilterTags()
        {
            products = ClassEntities.context.Product.ToList();

            if (TagsCmbbx.Text != null)
            {
                EF.Tag idTag = context.Tag.Where(k => k.Title == TagsCmbbx.Text).FirstOrDefault();
                int t = idTag.IDTag;

                EF.vw_ProdTag vw_ProdTag = context.vw_ProdTag.Where(k => k.TagTitle == TagsCmbbx.Text).FirstOrDefault();

                products = products.Where(i => i.IDProduct == vw_ProdTag.IDprod).ToList();
            }
            



            AllProducts.ItemsSource = products;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void AddProd(int v, EF.Product prd)
        {
           
            Prods prodForAdd = new Prods();

            EF.Order ord = new EF.Order();

            if (v == 1)
            {
                if (orders.Any(q => q.IDProduct == prd.IDProduct))
                {
                    orders.Find(r => r.IDProduct == prd.IDProduct).Qty += 1;
                    prods.Find(k => k.IDProduct == prd.IDProduct).Qty += 1;
                    products.Find(t => t.IDProduct == prd.IDProduct).Qty += 1;
                }
                else
                {

                    prodForAdd.IDProduct = prd.IDProduct;
                    prodForAdd.Cost = prd.Cost;
                    prodForAdd.Title = prd.Title;
                    prodForAdd.Qty = 1;
                    prods.Add(prodForAdd);

                    ord.IDProduct = prd.IDProduct;
                    ord.Qty = 1;
                    orders.Add(ord);
                    products.Find(t => t.IDProduct == prd.IDProduct).Qty = 1;
                }
            }
            else
            {
                if ((orders.Any(q => q.IDProduct == prd.IDProduct))&&(prd.Qty > 0))
                {
                    orders.Find(r => r.IDProduct == prd.IDProduct).Qty -= 1;
                    prods.Find(k => k.IDProduct == prd.IDProduct).Qty -= 1;
                    products.Find(t => t.IDProduct == prd.IDProduct).Qty -= 1;
                }
            }

            

        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new CartPage());
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AllProducts.SelectedItem != null)
            {
                Object obect = (Object)AllProducts.SelectedItem;
                EF.Product prod = (EF.Product)obect;
                EF.Product prd = products.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();
                AddProd(2, prd);
            }
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AllProducts.SelectedItem != null)
            {
                Object obect = (Object)AllProducts.SelectedItem;
                EF.Product prod = (EF.Product)obect;
                EF.Product prd = products.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();
                AddProd(1, prd);
            }
        }

        private void TagsCmbbx_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FilterTags();
        }
    }
}
