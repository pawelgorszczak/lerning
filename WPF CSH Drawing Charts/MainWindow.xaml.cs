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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChartLibrary;

namespace WPF_CSH_Drawing_Charts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WriteableBitMapChart _chartLibrary;
        public WriteableBitMapChart ChartLibrary { get { return _chartLibrary; } }
        public MainWindow()
        {
            InitializeComponent();
            _chartLibrary = new WriteableBitMapChart(640,400);
            _chartLibrary.GenerateChart();
            x.Source = _chartLibrary.ChartBitMap;
        }
    }
}
