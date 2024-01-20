using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class discount
    {
        DayOfWeek[] promotionDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday };
        public discount(double val)
        {
            _value = val;
        }

        private double _value = 0;
        public double Value { get { return _value; } }

        public double GetDiscountedPrice(int sum)
        {
            if (promotionDays.Contains(DateTime.Now.DayOfWeek))
                return sum - sum * _value;
            return sum;
        }
    }
}
