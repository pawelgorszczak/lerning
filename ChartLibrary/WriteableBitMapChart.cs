using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

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
                    X=_bitMapWidth - 3,
                    Y = _bitMapHeight -3
                };
                // Clear the WriteableBitmap with white color
                chartBitMap.Clear(Colors.Black);
                chartBitMap.DrawRectangle(rec1StartPoin.X, rec1StartPoin.Y, rec1EndPoint.X, rec1EndPoint.Y, Colors.White);

                chartBitMap.DrawLine(8,8,8,_bitMapHeight-8,Colors.White);
                chartBitMap.DrawLine(8, 8, 8, _bitMapHeight - 8, Colors.White);
                chartBitMap.DrawLine(8, 8 + (_bitMapHeight - 8)/2, _bitMapWidth-8, 8 + (_bitMapHeight - 8) / 2, Colors.White);
                
                var minValue = 8 ;
                var maxValue = _bitMapHeight - 8;
                var zeroValue = 8 + (_bitMapHeight - 8) / 2;
                var minArgument = 8;
                var maxArgument = _bitMapWidth - 8;
                var tempValue = new int();
                var ValueScale = zeroValue - minValue;
                var ArgumentScale = (maxArgument - minArgument)/20;
                var tempPoint = new Point() {X=8,Y=zeroValue};
                for (int i = minArgument; i < maxArgument; i++)
                {
                    tempValue = (int)((double)(ValueScale-8) *Math.Sin((double)(i-8)/(double)ArgumentScale));
                    //chartBitMap.SetPixel(i,zeroValue-tempValue,Colors.Red);
                    chartBitMap.DrawLine(tempPoint.X,tempPoint.Y,i, zeroValue - tempValue, Colors.Red);
                    tempPoint.X = i;
                    tempPoint.Y = zeroValue - tempValue;
                }
            }
            ChartBitMap = chartBitMap;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName= "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion
    }
}
