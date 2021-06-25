using OxyPlot;
using RPNLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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
using ViewModel;

namespace RPN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private static Dictionary<int, double> AllResults=new Dictionary<int, double>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void GetResult(object sender, RoutedEventArgs e)
        {
            resultRPN.Text = new Transfer(inputData.Text).GetRPN();
            var values = new Results(int.Parse(step.Text), int.Parse(begin.Text),
                int.Parse(end.Text), inputData.Text).AllResults;
            allResultes.ItemsSource = values;
            AllResults = values;
            graph.Visibility = Visibility.Visible;
            DrawGraph();
        }

        private DataPoint[] testPoint;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public DataPoint[] TestPoints
        {
            get { return testPoint; }
            set
            {
                testPoint = value;
                OnPropertyChanged("TestPoints");
            }
        }
                    
        public void DrawGraph()
        {
            TestPoints = AllResults
                   .Select(x => new DataPoint(x.Key, x.Value))
                   .ToArray();
        }

    }
}
