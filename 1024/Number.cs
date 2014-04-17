using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace _1024
{
    public class Number
    {
        public uint Value { get; set; }
        public string ImagePath { get; set; }
        public TopLeft TopLeftPosition { get; set; }

        public Number(uint value, TopLeft topLeftPosition)
            : this(value)
        {
            this.TopLeftPosition = topLeftPosition;
        }

        public Number(uint value)
        {
            this.Value = value;
            this.ImagePath = ImageManager.getPathForNumber((int)value);
        }

        public void Show(Canvas cnvs, int cellsAndColumns)
        {
            Image img = new Image();

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(this.ImagePath, UriKind.Relative);
            bi.EndInit();

            img.Source = bi;
            // TODO: make a default value somewere
            img.Height = cnvs.Height / cellsAndColumns;
            img.Width = cnvs.Width / cellsAndColumns;
            
            Canvas.SetTop(img, this.TopLeftPosition.Top);
            Canvas.SetLeft(img, this.TopLeftPosition.Left);
            cnvs.Children.Add(img);

        }


        // Overriding methods and overload operatos
        public override bool Equals(object obj)
        {
            var other = obj as Number;
            if (this.Value == other.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            // TODO: override self getHashCode()
            return base.GetHashCode();
        }

    }
}
