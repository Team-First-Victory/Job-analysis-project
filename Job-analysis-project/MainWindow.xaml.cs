using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Job_analysis_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Analyzer analyzer = new Analyzer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowChart()
        {
            analyzer.Analyze((int)DisplayChart.ActualWidth, (int)DisplayChart.ActualHeight);           
            DisplayChart.NavigateToString(analyzer.Chart.ChartHTML);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowChart();
        }
    }
}
