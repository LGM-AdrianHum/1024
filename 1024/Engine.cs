using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1024
{
    public class Engine
    {
        // Playfield size, and the size of the working matrix
        private readonly int size;
        private Random rnd;
        // The playng grid
        public Number[,] Grid { get; protected set; }
        public ulong Score { get; set; }
        public IControler controler;
        public int SizeInPixels { get; protected set; }

        public int Size
        {
            get { return size; }
        }

        public Engine(int size, int sizeInPixels, IControler controlerInterface)
        {
            if (size >= 3)
            {
                this.size = size;
                this.Grid = new Number[size, size];
                this.rnd = new Random();
                this.Score = 0;
                this.controler = controlerInterface;
                this.SizeInPixels = sizeInPixels;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Size should be greater than 3");
            }
        }

        // Initializing
        public void Initialize()
        {
            ImageManager.LoadImages();

            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    Grid[i, j] = new Number(0, new TopLeft(i * (uint)(SizeInPixels / Size), j * (uint)(SizeInPixels / Size)));
                }
            }

            // Creating the first 2 numbers
            GetRandomNumber();
            GetRandomNumber();
        }

        // Returns number that is 2^somePower
        private uint getNumber(uint power = 1)
        {
            return Statics.Power(2, power);
        }

        // Get a random place for some number
        private TopLeft getRandomPosition(Number[,] arr, Random rnd)
        {

            int top = rnd.Next(0, arr.GetLength(0));
            int left = rnd.Next(0, arr.GetLength(1));

            if (!(arr[top, left].Equals(new Number(0))))
            {
                getRandomPosition(arr, rnd);
            }

            return new TopLeft((uint)top * (uint)(SizeInPixels / Size), (uint)left * (uint)(SizeInPixels / Size));
        }

        // Get random placed, random valued number
        // optional value=1 e.g. 2^1 = 2
        public void GetRandomNumber(uint numberValue = 1)
        {
            Number someRandNum = new Number(getNumber(numberValue), getRandomPosition(Grid, rnd));
            // The positions in the array is the Pixel position devided by AllWindowPixels devide by Grid size ;)
            Grid[someRandNum.TopLeftPosition.Top / (uint)(SizeInPixels / Size), someRandNum.TopLeftPosition.Left / (uint)(SizeInPixels / Size)] = someRandNum;
        }

        public void Update()
        {
            if (this.controler.ShouldMove)
            {
                switch (this.controler.CurrentDirection)
                {
                    case Direction.Left:
                        {
                            for (int k = 0; k < size; k++)
                            {
                                // Rows
                                for (int i = 0; i < Grid.GetLength(0); i++)
                                {
                                    // Cols
                                    for (int j = 1 ; j < Grid.GetLength(1); j++)
                                    {
                                        // If current is not zero
                                        if (Grid[i, j].Value != 0)
                                        {
                                            // If next to left is empty
                                            var currentNumber = Grid[i, j];
                                            if (Grid[i, j - 1].Equals(new Number(0)))
                                            {
                                                // Make a Zero
                                                Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                // And switch the numbers and positions
                                                currentNumber.TopLeftPosition = new TopLeft(Grid[i, j - 1].TopLeftPosition.Top, Grid[i, j - 1].TopLeftPosition.Left);
                                                Grid[i, j - 1] = currentNumber;
                                            }
                                            else
                                            {
                                                // Check for selfies ;) and sum them
                                                if (currentNumber.Equals(Grid[i, j - 1]))
                                                {
                                                    Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                    Grid[i, j - 1] = new Number(Grid[i, j - 1].Value *= 2, Grid[i, j - 1].TopLeftPosition);
                                                    // Increase score
                                                    Score += Grid[i, j - 1].Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Right:
                        {
                            for (int k = 0; k < size; k++)
                            {
                                // Rows
                                for (int i = 0; i < Grid.GetLength(0); i++)
                                {
                                    // Cols
                                    for (int j = Grid.GetLength(1) - 2; j >= 0; j--)
                                    {
                                        // If current is not zero
                                        if (Grid[i, j].Value != 0)
                                        {
                                            // TODO: Do this 6 times if size is 6
                                            // If next to right is empty
                                            var currentNumber = Grid[i, j];
                                            if (Grid[i, j + 1].Equals(new Number(0)))
                                            {
                                                // Make a Zero
                                                Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                // And switch the numbers and positions
                                                currentNumber.TopLeftPosition = new TopLeft(Grid[i, j + 1].TopLeftPosition.Top, Grid[i, j + 1].TopLeftPosition.Left);
                                                Grid[i, j + 1] = currentNumber;
                                            }
                                            else
                                            {
                                                // Check for selfies ;) and sum them
                                                if (currentNumber.Equals(Grid[i, j + 1]))
                                                {
                                                    Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                    Grid[i, j + 1] = new Number(Grid[i, j + 1].Value *= 2, Grid[i, j + 1].TopLeftPosition);
                                                    // Increase score
                                                    Score += Grid[i, j + 1].Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Top:
                        {
                            for (int k = 0; k < size; k++)
                            {
                                // Rows
                                for (int i = 1; i < Grid.GetLength(0); i++)
                                {
                                    // Cols
                                    for (int j = 0; j < Grid.GetLength(1); j++)
                                    {
                                        // If current is not zero
                                        if (Grid[i, j].Value != 0)
                                        {
                                            // If next to left is empty
                                            var currentNumber = Grid[i, j];
                                            if (Grid[i - 1, j].Equals(new Number(0)))
                                            {
                                                // Make a Zero
                                                Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                // And switch the numbers and positions
                                                currentNumber.TopLeftPosition = new TopLeft(Grid[i - 1, j].TopLeftPosition.Top, Grid[i - 1, j].TopLeftPosition.Left);
                                                Grid[i -1 , j] = currentNumber;
                                            }
                                            else
                                            {
                                                // Check for selfies ;) and sum them
                                                if (currentNumber.Equals(Grid[i - 1, j]))
                                                {
                                                    Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                    Grid[i - 1, j] = new Number(Grid[i - 1, j].Value *= 2, Grid[i -1, j].TopLeftPosition);
                                                    // Increase score
                                                    Score += Grid[i - 1, j].Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Direction.Bottom:
                        for (int k = 0; k < size; k++)
                        {
                            // Rows
                            for (int i = Grid.GetLength(0) - 2; i >= 0; i--)
                            {
                                // Cols
                                for (int j = 0; j < Grid.GetLength(1); j++)
                                {
                                    // If current is not zero
                                    if (Grid[i, j].Value != 0)
                                    {
                                        // If next to left is empty
                                        var currentNumber = Grid[i, j];
                                        if (Grid[i + 1, j].Equals(new Number(0)))
                                        {
                                            // Make a Zero
                                            Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                            // And switch the numbers and positions
                                            currentNumber.TopLeftPosition = new TopLeft(Grid[i + 1, j].TopLeftPosition.Top, Grid[i + 1, j].TopLeftPosition.Left);
                                            Grid[i + 1, j] = currentNumber;
                                        }
                                        else
                                        {
                                            // Check for selfies ;) and sum them
                                            if (currentNumber.Equals(Grid[i + 1, j]))
                                            {
                                                Grid[i, j] = new Number(0, Grid[i, j].TopLeftPosition);
                                                Grid[i + 1, j] = new Number(Grid[i + 1, j].Value *= 2, Grid[i + 1, j].TopLeftPosition);
                                                // Increase score
                                                Score += Grid[i + 1, j].Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                // After moving, release the state of moving to static
                this.controler.ShouldMove = false;
                // Get another random number affter each movment
                GetRandomNumber();
            }

        }

        // TESTING
        public void ShowAllNumbers(Canvas cnvs)
        {
            // Clear everything on the screen
            cnvs.Children.Clear();

            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    Grid[i, j].Show(cnvs, Size);
                }
            }
        }

    }
}
