using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using ChartLibrary;




namespace WPF_CSH_Drawing_Charts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WriteableBitMapChart _chartLibrary;

        public WriteableBitMapChart ChartLibrary
        {
            get { return _chartLibrary; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _chartLibrary = new WriteableBitMapChart(640, 400);
            //_chartLibrary.GenerateChart();
            //x.Source = _chartLibrary.ChartBitMap;
            
        }

        private void X_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            /*Point getPoint = e.GetPosition(x);
            _chartLibrary.DrawPoint((int) getPoint.X, (int) getPoint.Y);*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 20; i++)
            {
                _chartLibrary.GenerateBigColoredBitmap1(1000, 500);
                // _chartLibrary.GenerateTestChart((int) x.ActualWidth, (int) x.ActualHeight);
            }
            
            stopwatch.Stop();
            Console.WriteLine("Generate bitmap 100 times = " + stopwatch.ElapsedMilliseconds + " ms.");
        }

        private void X_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //_chartLibrary.GenerateTestChart((int) x.ActualWidth, (int) x.ActualHeight);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //for (int i = 0; i < 20; i++)
            //{
                _chartLibrary.GenerateBigColoredBitmap2((int)GridX.ActualWidth, (int)GridX.ActualHeight);
                //_chartLibrary.GenerateTestChart2((int) x.ActualWidth, (int) x.ActualHeight);
            //}
            stopwatch.Stop();
            Console.WriteLine("Generate bitmap2 100 times = " + stopwatch.ElapsedMilliseconds + " ms.");
            GridX.Children.Add(_chartLibrary.GenerateBitMapPartly((int)GridX.ActualWidth,(int)GridX.ActualHeight));
        }

        private void Image2_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //_chartLibrary.GenerateTestChart2((int)x.ActualWidth, (int)x.ActualHeight);
        }
    }
}