using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static Tortuga_Dobrodiy_3isp11_16.ClassEntities;
using static Tortuga_Dobrodiy_3isp11_16.productsForSale;

namespace Tortuga_Dobrodiy_3isp11_16.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        List<EF.Product> products = new List<EF.Product>();
        List<EF.Tag> tgs = context.Tag.ToList();
        List<String> tgsStr = new List<string>();
        public MenuPage()
        {
            
            InitializeComponent();

            this.DataContext = this;

            EF.Tag[] tgsArr = new EF.Tag[tgs.Count()];
            tgsArr = tgs.ToArray();
 
            for (int i = 0; i < tgsArr.Length; i++)
            {
                tgsStr.Add(tgsArr[i].Title);
            }
            tgsStr.Add("Все");
            TagsCmbbx.ItemsSource = tgsStr;

            products = ClassEntities.context.Product.ToList();

            //if ((context.vw_prods.Count() != 0))
            //{
            //    EF.vw_prods[] pr = context.vw_prods.ToArray();

            //    for (int i = 0; i < pr.Length; i++)
            //    {
            //        EF.vw_prods p = pr[i];
            //        context.Product.Where(k => k.IDProduct == p.IDProduct).FirstOrDefault().Qty = p.Qty;
            //        AllProducts.ItemsSource = context.Product.ToList();
            //    }
            //}
            //else
            //{
            //    AllProducts.ItemsSource = context.Product.ToList();
            //}

            AllProducts.ItemsSource = context.Product.ToList();
        }

        private void Filter()
        {
            products = ClassEntities.context.Product.ToList();

            products = products.Where(i => (i.Title.Contains(txtSearch.Text))).ToList();



            AllProducts.ItemsSource = context.Product.ToList();

        }

        private void FilterTags()
        {
            products = ClassEntities.context.Product.ToList();
            List<EF.vw_ProdTag> prTag = new List<EF.vw_ProdTag>();
            prTag = context.vw_ProdTag.ToList();

            if ((TagsCmbbx.Text != null) && (TagsCmbbx.Text != "Все"))
            {
                EF.Tag idTag = context.Tag.Where(k => k.Title == TagsCmbbx.Text).FirstOrDefault();
                int t = idTag.IDTag;

                prTag = prTag.Where(i => i.IDtag == t).ToList();

                EF.vw_ProdTag[] vw_ProdArr = new EF.vw_ProdTag[prTag.Count()];
                vw_ProdArr = prTag.ToArray();

                List<EF.Product> TempPR = new List<EF.Product>();

                EF.Product[] pArr = new EF.Product[products.Count()]; 
                for (int i = 0; i < vw_ProdArr.Length; i++)
                {
                    EF.vw_ProdTag prt = vw_ProdArr[i];
                    pArr[i] = context.Product.Where(k => k.IDProduct == prt.IDprod).FirstOrDefault();
                    if (prt.IDprod != 0)
                    {
                        TempPR.Add(pArr[i]);
                    }
                }

                
                products = TempPR.ToList();
                AllProducts.ItemsSource = products;
            } else if (TagsCmbbx.Text == "Все") 
            {
                products = context.Product.ToList();
                AllProducts.ItemsSource = context.Product.ToList();
            }

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


            if (v == 1)
            {
                if (prods.Any(q => q.IDProduct == prd.IDProduct))
                {
                    productsForSale.prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault().Qty += 1;
                    context.Product.Where(t => t.IDProduct == prd.IDProduct).FirstOrDefault().Qty += 1;
                }
                else
                {

                    prodForAdd.IDProduct = prd.IDProduct;
                    prodForAdd.Cost = prd.Cost;
                    prodForAdd.Title = prd.Title;
                    prodForAdd.Qty = 1;
                    prodForAdd.PhotoPath = prd.PhotoPath;
                    productsForSale.prods.Add(prodForAdd);

                    context.Product.Where(t => t.IDProduct == prd.IDProduct).FirstOrDefault().Qty = 1;
                }
            }
            else
            {
                if ((productsForSale.prods.Any(q => q.IDProduct == prd.IDProduct)) && (prd.Qty > 0))
                {
                    productsForSale.prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault().Qty -= 1;
                    context.Product.Where(t => t.IDProduct == prd.IDProduct).FirstOrDefault().Qty -= 1;
                }
                else if ((productsForSale.prods.Any(q => q.IDProduct == prd.IDProduct)) && (prd.Qty <= 0))
                {
                    productsForSale.prods.Remove(prods.Where(k => k.IDProduct == prd.IDProduct).FirstOrDefault());
                }
            }


            AllProducts.ItemsSource = context.Product.ToList();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new CartPage());
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as EF.Product;

            if (dish == null)
            {
                return;
            }
            //Object obect = (Object)AllProducts.SelectedItem;
            //EF.Product prod = (EF.Product)obect;
            //EF.Product prd = context.Product.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();
            EF.Product pr = new EF.Product();
            pr = context.Product.Where(k => k.Title == dish.Title).FirstOrDefault();
            AddProd(2, pr);

        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            //Button button = sender as Button;
            //if (button == null)
            //{
            //    return;
            //}
            //var dish = button.DataContext as EF.Product;

            //if (dish == null)
            //{
            //    return;
            //}
            MessageBox.Show(" ");
            //Object obect = (Object)AllProducts.SelectedItem;
            //EF.Product prod = (EF.Product)obect;
            //EF.Product prd = context.Product.Where(r => r.IDProduct == prod.IDProduct).FirstOrDefault();
            //EF.Product pr = new EF.Product();
            //pr = context.Product.Where(k => k.Title == dish.Title).FirstOrDefault();
            //AddProd(1, dish);

        }

        private void TagConfBtn_Click(object sender, RoutedEventArgs e)
        {
            FilterTags();
        }
    }
}
