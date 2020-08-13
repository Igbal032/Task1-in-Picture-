using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Extension
    {
        public static string calculate(double x, double y)
        {
            string result = "";
            string error = "Biraz Sonra Cehd Edin";

            if (x < 0 && y < 0)
            {
                x = -x;
                y = -y;
                result = "X equals to " + x.ToString() + " and Y equals to " + y.ToString();
                return result;
            }
            else if ((x < 0 && y > 0) || (x > 0 && y < 0))
            {
                x = x + 0.5;
                y = y + 0.5;

                result = "X equals to " + x.ToString() + " and Y equals to " + y.ToString();
                return result;
            }
            else if ((x > 0 && y > 0) && ((x < 0.5 || x > 2.0) && (y < 0.5 || y > 2.0)))
            {
                x = x / 10;
                y = y / 10;

                result = "X equals to " + x.ToString() + " and Y equals to " + y.ToString();
                return result;
            }
            return error;

        }
    }
}
