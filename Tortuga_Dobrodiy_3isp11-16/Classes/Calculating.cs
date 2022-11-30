using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortuga_Dobrodiy_3isp11_16
{
    public static class Calculating
    {
        public static double TotalPrice(Prods[] pA, DateTime today) {
            double TotalPrice = 0;
            DateTime day = System.DateTime.Now;
            int saturdays = 0;
            int dayNumber = 0;
            for (int i = 0; i < System.DateTime.DaysInMonth(today.Year, today.Month); i++)
            {
                day = new DateTime(today.Year, today.Month , (i + 1), 16, 22, 56);
                if (((int) day.DayOfWeek) == 6)
                {
                    saturdays++;
                    dayNumber = i + 1;
                }
            }

            for (int i = 0; i<pA.Length; i++)
            {
                Prods p = pA[i];
                TotalPrice += Convert.ToDouble(p.Qty* p.Cost);
            }


            if ((saturdays == 5)&&(today.Day == dayNumber))
            {
                TotalPrice = TotalPrice * 0.89;
            }

            return TotalPrice;
        }

    }
}
