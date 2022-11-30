using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tortuga_Dobrodiy_3isp11_16;
using static Tortuga_Dobrodiy_3isp11_16.Calculating;
using static Tortuga_Dobrodiy_3isp11_16.Prods;

namespace TotalPriceTest
{
    [TestClass]
    public class TotalPriceTest
    {
        [TestMethod]
        public void TotalPrice_DayWithoutDiscount_800()
        {
            //Arrange

            DateTime day = new DateTime(2022, 11, 14, 16, 22, 56);
            List<Prods> prodsList = new List<Prods>();
            for (int i = 0; i < 2; i++)
            {
                Prods pr = new Prods();
                pr.IDProduct = i + 1;
                pr.Qty = 1;
                pr.Cost = 800;
                prodsList.Add(pr);
            }
            Prods[] prods = new Prods[prodsList.Count];
            prods = prodsList.ToArray();

            double ex = Convert.ToDouble(900);
            //Act
            double res = Calculating.TotalPrice(prods, day);
            //Asset
            Assert.AreEqual(ex, res);
        }

        [TestMethod]
        public void TotalPrice_DayWithDiscount_712()
        {
            //Arrange

            DateTime day = new DateTime(2022, 12, 31, 16, 22, 56);
            List<Prods> prodsList = new List<Prods>();
            for (int i = 0; i < 2; i++)
            {
                Prods pr = new Prods();
                pr.IDProduct = i + 1;
                pr.Qty = 1;
                pr.Cost = 400;
                prodsList.Add(pr);
            }
            Prods[] prods = new Prods[prodsList.Count];
            prods = prodsList.ToArray();

            double ex = Convert.ToDouble(800 * 0.89);
            //Act
            double res = Calculating.TotalPrice(prods, day);
            //Asset
            Assert.AreEqual(ex, res);
        }
    }
}
