using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Stop_task
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool stop = false;
        bool stop2 = false;
        bool stop3 = false;
        private void Btn_start_1_Click(object sender, RoutedEventArgs e)
        {

            if (stop)
                stop = false;
           Task.Factory.StartNew(()=> Dowork(100, 1000, Lbl_count_1));
           
        }

      

        private void Dowork(int max, int delay, Label lbl)
        {
            for (int i = 0; i < max; i++)
            {
                Dispatcher.Invoke(() => Update(i,lbl));
                Thread.Sleep(delay);

                if (stop)
                    break;

                if (stop2)
                    break;

                if (stop3)
                    break;
            }
        }

        private void Btn_start_2_Click(object sender, RoutedEventArgs e)
        {
            if (stop2)
                stop2 = false;
            int max = Convert.ToInt32(Txt_max.Text);
            int delay = Convert.ToInt32(Txt_Delay.Text);
            Task.Factory.StartNew(() => Dowork(max, delay, Lbl_count_2));
        }

        private void Btn_start_3_Click(object sender, RoutedEventArgs e)
        {
            if (stop3)
                stop3 = false;
            int max = Convert.ToInt32(Txt_max.Text);
            int delay = Convert.ToInt32(Txt_Delay.Text);
            Task.Factory.StartNew(() => Dowork(max, delay, Lbl_count_3));
        }

       

        private static void Update(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }

        private void Btn_stop_1_Click_1(object sender, RoutedEventArgs e)
        {
            stop = true;
        }

        private void Btn_stop_2_Click(object sender, RoutedEventArgs e)
        {
            stop2 = true;
        }

        private void Btn_stop_3_Click(object sender, RoutedEventArgs e)
        {
            stop3 = true;
        }

        
    }
}
