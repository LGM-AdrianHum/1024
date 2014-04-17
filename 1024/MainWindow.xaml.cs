using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 1024 Game
    /// 
    /// Created by Martin Marinov aka sirjordan
    /// 
    /// The brick numbers moved follow the presed direction until they reach the boundary or other number brick
    /// If two bricks are in the same direction and has the same value, the sum their values and crate a new brick number
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Engine engine;

        public MainWindow()
        {
            InitializeComponent();
            // This will make a 6x6 matrix
            // Declare the interface witch is in use
            engine = new Engine(9, (int)playngField.Height, new KeyboardInterface());

            engine.Initialize();
            engine.ShowAllNumbers(playngField);
        }

        // On pressed the keyboard arrows
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                engine.controler.Move(Direction.Left);
            }
            if (e.Key == Key.Right)
            {
                engine.controler.Move(Direction.Right);
            }
            if (e.Key == Key.Up)
            {
                engine.controler.Move(Direction.Top);
            }
            if (e.Key == Key.Down)
            {
                engine.controler.Move(Direction.Bottom);
            }

            // Update the game engine
            engine.Update();
            engine.ShowAllNumbers(playngField);
            // Update score
            displayedScore.Text = engine.Score.ToString();
        }

    }
}
