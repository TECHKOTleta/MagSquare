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
using System.Windows.Shapes;

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для ForthStep.xaml
    /// </summary>
    public partial class FourthStep : Window
    {
        Random rnd = new Random();

        int[] cells1 = new int[9];
        int[] cells2 = new int[9];

        Set_numbers set_Numbers1 = new Set_numbers();
        Set_numbers set_Numbers2 = new Set_numbers();

        MainWindow dataWindow = new MainWindow();
        

        int hard_now = 0;
        bool flag = false;
        public FourthStep(MainWindow _dataWindow)
        {
            InitializeComponent();

            dataWindow = _dataWindow;

            hard_now = set_Numbers1.get_hard_value(dataWindow.hardness);

            set_Numbers1.set(hard_now); 
            set_Numbers2.set(hard_now);

            set_Numbers1.show(ref Cl1, ref Cl2, ref Cl3, ref Cl4, ref Cl5, ref Cl6, ref Cl7, ref Cl8, ref Cl9);
            set_Numbers2.show(ref Cl1_2, ref Cl2_2, ref Cl3_2, ref Cl4_2, ref Cl5_2, ref Cl6_2, ref Cl7_2, ref Cl8_2, ref Cl9_2);
        }

        private void True_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Leave_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hard_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Step_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
