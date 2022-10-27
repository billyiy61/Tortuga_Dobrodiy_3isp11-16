using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortuga_Dobrodiy_3isp11_16
{
    class productsForSale
    {
        public static List<EF.Product> products1 = new List<EF.Product>();

        //public static EF.vw_ProdSaleOrder cli1 = new EF.vw_ProdSaleOrder();
        public static List<EF.Order> orders = new List<EF.Order>();
        public static EF.ProductSale mainPS = new EF.ProductSale();

        public static int OrderID1 = 1; 


        public static double ClientDisc = 0;
        public static string ClientID1 = "client1";
        
    }
}
