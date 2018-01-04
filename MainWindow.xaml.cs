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

namespace WPFBath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BathSolutions b;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string s = "Nyomogassa az alábbi lehetséges \ngombokat az eredmény megismeréséhez";
            lbl.Content = s;
            
            btnStart.IsEnabled = false;
            btnT1.IsEnabled = true;
        }

        private void BtnT1_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "1. feladat\nAdatok beolvasása ...";
            lbl.Content = s;
            //btnT1.IsEnabled = false;
            btnT2.IsEnabled = true;
        }

        private void BtnT2_Click(object sender, RoutedEventArgs e)
        {
           
                b = new BathSolutions();
                string s = "2. feladat\n";
                lbl.Content = s + b.Task2();
                //btnT2.IsEnabled = false;
                btnT3.IsEnabled = true;
           
        }

        private void BtnT3_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "3. feladat\n";
            lbl.Content = s + b.Task3();
            //btnT3.IsEnabled = false;
            btnT4.IsEnabled = true;
        }

        private void BtnT4_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "4. feladat\n";
            lbl.Content = s + b.Task4();
            //btnT4.IsEnabled = false;
            btnT5.IsEnabled = true;
        }

        private void BtnT5_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "5. feladat\n";
            lbl.Content = $"{s} {b.Task5(6, "8:59:59")}\n{b.Task5(9, "15:59:59")}\n{b.Task5(16, "20:00:00")}";
            //btnT5.IsEnabled = false;
            btnT6.IsEnabled = true;
        }

        private void BtnT6_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "6. feladat\n";
            lbl.Content = s + b.Task6();
            //btnT6.IsEnabled = false;
            btnT7.IsEnabled = true;
        }

        private void BtnT7_Click(object sender, RoutedEventArgs e)
        {
            b = new BathSolutions();
            string s = "7. feladat\n";
            lbl.Content = $"{s} {b.Task7(1)}\n{b.Task7(2)}\n{b.Task7(3)}\n{b.Task7(4)}";
            //btnT7.IsEnabled = false;
            
        }
    }
}
