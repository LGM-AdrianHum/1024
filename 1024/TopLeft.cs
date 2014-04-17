using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024
{
    public struct TopLeft
    {
        public uint Top;
        public uint Left;

        public TopLeft(uint top, uint left)
        {
            if (top >= 0 && left >= 0)
            {
                this.Top = top;
                this.Left = left;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid parameters for TopLeft constructor!");
            }
        }
    }
}
