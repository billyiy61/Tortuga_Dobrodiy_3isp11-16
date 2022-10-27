using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortuga_Dobrodiy_3isp11_16
{
    class Calculation
    {
        public static double CostCalc(double d){
            int c = productsForSale.products1.Count();
            EF.Product[] p = new EF.Product[c];
            p = productsForSale.products1.ToArray();

            double sum = 0;

            for (int i = 0; i < p.Length; i++)
            {
                EF.Product o = p[i];
                //if (o.Qty > 1)
                //{
                //    sum = sum + Convert.ToDouble(o.Qty) * Convert.ToDouble(o.Cost);
                //}
                //else{
                //    sum += Convert.ToDouble(o.Cost);
                //}
            }
           
            sum = (sum * (1 - d));
            return sum;
        }
    }
}
