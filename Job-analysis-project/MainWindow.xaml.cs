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
using System.Windows.Forms;
using System.Threading;

namespace Job_analysis_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Analyzer analyzer = new Analyzer();
        Loading_Screen ls = new Loading_Screen();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowChart()
        {
            analyzer.Analyze((int)DisplayChart.ActualWidth, (int)DisplayChart.ActualHeight);           
            DisplayChart.NavigateToString(analyzer.Chart.ChartHTML);
        }

        [STAThread]
        private void Loading()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(ls);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Thread ld = new Thread(Loading);
            ld.Start();
            ShowChart();
            ld.Abort();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
