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
using System.Xml.Linq;

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для Tutorial_4.xaml
    /// </summary>
    public partial class Tutorial_4 : Window
    {
        MainWindow dataWindow;
        public Tutorial_4(MainWindow _dataWindow)
        {
            InitializeComponent();

            dataWindow= _dataWindow;

            Cl1_3.Visibility = Visibility.Hidden;
            Cl2_3.Visibility = Visibility.Hidden;
            Cl3_3.Visibility = Visibility.Hidden;
            Cl4_3.Visibility = Visibility.Hidden;
            Cl5_3.Visibility = Visibility.Hidden;
            Cl6_3.Visibility = Visibility.Hidden;
            Cl7_3.Visibility = Visibility.Hidden;
            Cl8_3.Visibility = Visibility.Hidden;
            Cl9_3.Visibility = Visibility.Hidden;
            Hint1_text.Visibility = Visibility.Hidden;
            Hint_2_text.Visibility = Visibility.Hidden;
            Next_step_button.Visibility = Visibility.Hidden;
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            Cl1_3.Visibility = Visibility.Visible;
            Cl2_3.Visibility = Visibility.Visible;
            Cl3_3.Visibility = Visibility.Visible;
            Cl4_3.Visibility = Visibility.Visible;
            Cl5_3.Visibility = Visibility.Visible;
            Cl6_3.Visibility = Visibility.Visible;
            Cl7_3.Visibility = Visibility.Visible;
            Cl8_3.Visibility = Visibility.Visible;
            Cl9_3.Visibility = Visibility.Visible;
            Hint1_text.Visibility = Visibility.Visible;
            Hint_2_text.Visibility = Visibility.Visible;
            Next_step_button.Visibility = Visibility.Visible;
            Next_button.Visibility = Visibility.Hidden;
        }

        private void Next_step_button_Click(object sender, RoutedEventArgs e)
        {
            int hard = 1;
            Console.WriteLine(hard);
            FourthStep fourthStep = new FourthStep(dataWindow);
            fourthStep.Show();
            Close();
        }
    }
}
