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
    /// Логика взаимодействия для Tutorial3.xaml
    /// </summary>
    public partial class Tutorial3 : Window
    {
        MainWindow dataWindow;
        public Tutorial3(MainWindow _dataWindow)
        {
            InitializeComponent();

            dataWindow = _dataWindow;

            Cl1_Copy.Visibility = Visibility.Hidden;
            Cl2_Copy.Visibility = Visibility.Hidden;
            Cl3_Copy.Visibility = Visibility.Hidden;
            Cl4_Copy.Visibility = Visibility.Hidden;
            Cl5_Copy.Visibility = Visibility.Hidden;
            Cl6_Copy.Visibility = Visibility.Hidden;
            Cl7_Copy.Visibility = Visibility.Hidden;
            Cl8_Copy.Visibility = Visibility.Hidden;
            Cl9_Copy.Visibility = Visibility.Hidden;
            GoToStep_button.Visibility = Visibility.Hidden;
            Three_text.Visibility = Visibility.Hidden;
            Hint2_text.Visibility = Visibility.Hidden;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Cl1_Copy.Visibility = Visibility.Visible;
            Cl2_Copy.Visibility = Visibility.Visible;
            Cl3_Copy.Visibility = Visibility.Visible;
            Cl4_Copy.Visibility = Visibility.Visible;
            Cl5_Copy.Visibility = Visibility.Visible;
            Cl6_Copy.Visibility = Visibility.Visible;
            Cl7_Copy.Visibility = Visibility.Visible;
            Cl8_Copy.Visibility = Visibility.Visible;
            Cl9_Copy.Visibility = Visibility.Visible;
            GoToStep_button.Visibility = Visibility.Visible;
            Three_text.Visibility = Visibility.Visible;
            Hint2_text.Visibility = Visibility.Visible;

            Next_button.Visibility = Visibility.Hidden;
        }

        private void GoToStep_button_Click(object sender, RoutedEventArgs e)
        {
            dataWindow.score = 0;
            dataWindow.hardness = 2;
            SecondOrThirdStep step2_3 = new SecondOrThirdStep(dataWindow, true);
            step2_3.Show();
            Close();
        }
    }
}
