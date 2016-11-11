using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace ChartLibrary
{
    public class WriteableBitMapChart : INotifyPropertyChanged
    {

        private int _bitMapWidth;
        private int _bitMapHeight;

        private WriteableBitmap _chartBitMap;
        public WriteableBitmap ChartBitMap
        {
            get { return _chartBitMap; }
            set
            {
                _chartBitMap = value;
                OnPropertyChanged();
            }
        }
        private Bitmap _bitMap;

        public Bitmap BitMap
        {
            get { return _bitMap; }
            set
            {
                _bitMap = value;
                OnPropertyChanged();
            }
        }


        public WriteableBitMapChart(int bitMapWidth, int bitMapHeigh)
        {
            _bitMapWidth = bitMapWidth;
            _bitMapHeight = bitMapHeigh;
        }
        public class Point
        {
            public int X;
            public int Y;
        }
        public void GenerateChart()
        {

            WriteableBitmap chartBitMap = BitmapFactory.New(_bitMapWidth, _bitMapHeight);


            using (chartBitMap.GetBitmapContext())
            {

                var rec1StartPoin = new Point()
                {
                    X = 2,
                    Y = 2
                };
                var rec1EndPoint = new Point()
                {
                    X = _bitMapWidth - 3,
                    Y = _bitMapHeight - 3
                };
                // Clear the WriteableBitmap with white color
                chartBitMap.Clear(Colors.Black);
                chartBitMap.DrawRectangle(rec1StartPoin.X, rec1StartPoin.Y, rec1EndPoint.X, rec1EndPoint.Y, Colors.White);

                chartBitMap.DrawLine(8, 8, 8, _bitMapHeight - 8, Colors.White);
                chartBitMap.DrawLine(8, 8, 8, _bitMapHeight - 8, Colors.White);
                chartBitMap.DrawLine(8, 8 + (_bitMapHeight - 8) / 2, _bitMapWidth - 8, 8 + (_bitMapHeight - 8) / 2, Colors.White);

                var minValue = 8;
                var maxValue = _bitMapHeight - 8;
                var zeroValue = 8 + (_bitMapHeight - 8) / 2;
                var minArgument = 8;
                var maxArgument = _bitMapWidth - 8;
                var tempValue = new int();
                var ValueScale = zeroValue - minValue;
                var ArgumentScale = (maxArgument - minArgument) / 20;
                var tempPoint = new Point() { X = 8, Y = zeroValue };
                for (int i = minArgument; i < maxArgument; i++)
                {
                    tempValue = (int)((double)(ValueScale - 8) * Math.Sin((double)(i - 8) / (double)ArgumentScale));
                    //chartBitMap.SetPixel(i,zeroValue-tempValue,Colors.Red);
                    chartBitMap.DrawLine(tempPoint.X, tempPoint.Y, i, zeroValue - tempValue, Colors.Red);
                    tempPoint.X = i;
                    tempPoint.Y = zeroValue - tempValue;
                }
            }


            ChartBitMap = chartBitMap;

        }

        public void GenerateBigColoredBitmap1(int actualWidth, int actualHeight)
        {
            WriteableBitmap bitMap = BitmapFactory.New(actualWidth, actualHeight);
            bitMap.Clear(Colors.Black);

            ChartBitMap = bitMap;
        }

        Random xRandom= new Random();
        public void GenerateTestChart(int bitMapWidth, int bitMapHeight)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteableBitmap chartBitMap = BitmapFactory.New(bitMapWidth, bitMapHeight);

            chartBitMap.Clear(Colors.Black);

            int numberOfRegtancgles = _bitMapWidth/15;
            int tempx, tempy;
            for (int i = 0; i < numberOfRegtancgles; i++)
            {
                tempx = xRandom.Next(bitMapWidth - 1);
                tempy = xRandom.Next(bitMapHeight - 1);
                chartBitMap.DrawRectangle(tempx,tempy,tempx +20,tempy +20,Colors.Red);
            }

            ChartBitMap = chartBitMap;

            sw.Stop();
            Console.WriteLine("Chart redrawn in " + sw.ElapsedMilliseconds + " ms. (" + sw.ElapsedTicks.ToString() + " ticks).");
        }
        public void DrawPoint(int X, int Y)
        {
            _chartBitMap.DrawLine(0, 0, X, Y, Colors.Red);
            OnPropertyChanged(nameof(ChartBitMap));
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion

        public void GenerateTestChart2(int bitMapWidth, int bitMapHeight)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //WriteableBitmap chartBitMap = BitmapFactory.New(bitMapWidth, bitMapHeight);
            
            Bitmap b = new Bitmap(bitMapWidth, bitMapHeight);



            BitmapData bitmapData = b.LockBits(new Rectangle(0, 0, bitMapWidth, bitMapHeight), ImageLockMode.ReadWrite,
                b.PixelFormat);

            /* GetBitsPerPixel just does a switch on the PixelFormat and returns the number */
            byte bitsPerPixel = GetBitsPerPixel(bitmapData.PixelFormat);

            /*the size of the image in bytes */
            int size = bitmapData.Stride * bitmapData.Height;
            
            /*Allocate buffer for image*/
            byte[] data = new byte[size];

            Marshal.Copy(bitmapData.Scan0,data,0,size);
            for (int i = 0; i < size; i += bitsPerPixel / 8)
            {
                data[i] = 255;
                data[i + 1] = 255;
                data[i + 2] = 255;
            }
            Marshal.Copy(data,0,bitmapData.Scan0,data.Length);
            b.UnlockBits(bitmapData);
/*

            int numberOfRegtancgles = _bitMapWidth / 15;
            int tempx, tempy;
            for (int i = 0; i < numberOfRegtancgles; i++)
            {
                tempx = xRandom.Next(bitMapWidth - 1);
                tempy = xRandom.Next(bitMapHeight - 1);
                chartBitMap.DrawRectangle(tempx, tempy, tempx + 20, tempy + 20, Colors.Red);
            }

            ChartBitMap = chartBitMap;
*/          
           // b.Save("x");
            BitMap = b;

            sw.Stop();
            Console.WriteLine("Chart redrawn in " + sw.ElapsedMilliseconds + " ms. (" + sw.ElapsedTicks.ToString() + " ticks).");
        }
        private byte GetBitsPerPixel(System.Drawing.Imaging.PixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                    return 24;
                    break;
                case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                case System.Drawing.Imaging.PixelFormat.Format32bppPArgb:
                case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                    return 32;
                    break;
                default:
                    throw new ArgumentException("Only 24 and 32 bit images are supported");

            }
        }


        public void GenerateBigColoredBitmap2(int width, int height)
        {
            int amoutOfBlocks = 5;
            var widthTemp =width/amoutOfBlocks;
            var heightTemp = height/amoutOfBlocks;
            //WriteableBitmap[,] bitMapsMap = new WriteableBitmap[heightTemp, widthTemp];
            WriteableBitmap[,] bitMapsMap = new WriteableBitmap[amoutOfBlocks, amoutOfBlocks];
            WaitCallback x = w => { };
            Action<int, int,WriteableBitmap> generate = (x2, y2, writeBmp) =>
            {
                writeBmp = BitmapFactory.New(10, 10);
                Console.WriteLine("{0} , {1}", x2, y2);
            };
            var tasksList = new List<Task>();
            for (int i = 0; i < amoutOfBlocks ; i++)
            {
                Parallel.For(0, amoutOfBlocks, (g) =>
                {
                    bitMapsMap[i, g] = BitmapFactory.New(widthTemp, heightTemp);
                    bitMapsMap[i, g].Clear(Colors.Red);
                });
                /*for (int j = 0; j < widthTemp-1; j++)
                {
                 
                    //bitMapsMap[i, j] = BitmapFactory.New(10, 10);
                    var t = new Task(() => generate(i,j, bitMapsMap[i, j]));
                    t.Start();
                    tasksList.Add(t);
                    /*Task.Factory.StartNew(async ()=> { bitMapsMap[i,j] = await BitmapFactory.New(10, 10)
                        ; Console.WriteLine(" {0} {1}", i, j);
                    } );#1#
                    //bitMapsMap[i, j].Clear(Colors.Red);
                    
                }
*/                
            }
            Task.WaitAll(tasksList.ToArray());

        }


        public UIElement GenerateBitMapPartly(int width, int height)
        {
            double amoutOfBlocks = 5;
            
            int widthTemp = (int)Math.Ceiling(width / amoutOfBlocks);
            int heightTemp = (int)Math.Ceiling(height / amoutOfBlocks);
            var tempBitMap = BitmapFactory.New(widthTemp, heightTemp);
            tempBitMap.Clear(Colors.Aquamarine);
            //WriteableBitmap[,] bitMapsMap = new WriteableBitmap[heightTemp, widthTemp];
            WriteableBitmap[,] bitMapsMap = new WriteableBitmap[(int)amoutOfBlocks, (int)amoutOfBlocks];
            WaitCallback x = w => { };
            Action<int, int> generate = (x2, y2) =>
            {
                //bitMapsMap[x2, y2] = BitmapFactory.New(widthTemp,heightTemp);
                bitMapsMap[x2, y2] = tempBitMap;
                //bitMapsMap[x2, y2].Clear(Colors.Red);
                Console.WriteLine("{0} , {1}", x2, y2);
            };
            var tasksList = new List<Task>();
            for (int i = 0; i < amoutOfBlocks; i++)
            {
                /*for (int j = 0; j < amoutOfBlocks; j++)
                {
                    //bitMapsMap[i, j] = BitmapFactory.New(widthTemp, heightTemp);
                    //bitMapsMap[i, j].Clear(Colors.Red);
                    var i1 = i;
                    var j1 = j;
                    var t = new Task(() => generate(i1,j1));
                    t.Start();
                    tasksList.Add(t);
                }*/
                Parallel.For(0, (int)amoutOfBlocks, (g) =>
                {
                     bitMapsMap[i, g] = BitmapFactory.New(widthTemp, heightTemp);
                     bitMapsMap[i, g].Clear(Colors.Red);
                    //bitMapsMap[i, g] = tempBitMap;
                });
                /*for (int j = 0; j < widthTemp-1; j++)
                {
                 
                    //bitMapsMap[i, j] = BitmapFactory.New(10, 10);
                    var t = new Task(() => generate(i,j, bitMapsMap[i, j]));
                    t.Start();
                    tasksList.Add(t);
                    /*Task.Factory.StartNew(async ()=> { bitMapsMap[i,j] = await BitmapFactory.New(10, 10)
                        ; Console.WriteLine(" {0} {1}", i, j);
                    } );#1#
                    //bitMapsMap[i, j].Clear(Colors.Red);
                    
                }
*/
            }
            //Task.WaitAll(tasksList.ToArray());

            

            Grid nGrid = new Grid();
            for (int i = 0; i < amoutOfBlocks; i++)
            {
                nGrid.RowDefinitions.Add(new RowDefinition());
                nGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < amoutOfBlocks; i++)
            {
                for (int j = 0; j < amoutOfBlocks; j++)
                { 
                /*Parallel.For(0, amoutOfBlocks, (g) =>
                */
                    Image tempImage = new Image() {Source = bitMapsMap[i, j]};
                    Grid.SetRow(tempImage, i);
                    Grid.SetColumn(tempImage, j);
                    nGrid.Children.Add(tempImage);
                }
            }


            return nGrid;
        }
    }
}
