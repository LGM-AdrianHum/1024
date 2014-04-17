using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024
{
    // This represent a key/value pair for numbers and their sources in the file system
    // e.g. 2 -> imgs/2.png as returned result
    // Returns the powered 2^number
    // e.g. number=2 -> return 4
    public static class ImageManager
    {
        private static Dictionary<uint, string> numsPair = new Dictionary<uint, string>();

        public static void LoadImages()
        {
            numsPair.Add(0, "imgs/zero.png");
            numsPair.Add(2, "imgs/2.png");
            numsPair.Add(4, "imgs/4.png");
            numsPair.Add(8, "imgs/8.png");
            numsPair.Add(16, "imgs/16.png");
            numsPair.Add(32, "imgs/32.png");
            numsPair.Add(64, "imgs/64.png");
            numsPair.Add(128, "imgs/128.png");
        }

        public static string getPathForNumber(int number)
        {
            // TODO: read all paths from .txt file or other..
            // TODO: check the Logaritm (math.Log()) for the values that are 2,4,8, 16 ....
            // So hardcoded ;)

            if (number < 0 || (!numsPair.ContainsKey((uint)number)))
            {
                throw new ArgumentOutOfRangeException("Invalid index for key/value pair for numbers and their sources in the file system!");
            }
            else
            {
                return numsPair[(uint)number];
            }
        }
    }
}
