using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024
{
    public static class Statics
    {
        // Power method for integers
        public static uint Power(uint x, uint y)
        {
            // Return x^y
            uint result = 1;
            if (y != 0)
            {
                for (int i = 0; i < y; i++)
                {
                    result = result * x;
                }
            }
            else
            {
                result = 1;
            }
            return result;
        }

    }
}
