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
using static System.Net.Mime.MediaTypeNames;

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {

        int[] scores = new int[4];
        MainWindow dataWindow = new MainWindow();
        public Tutorial(string name)
        {
            InitializeComponent();

            dataWindow.name = name;

            Cl1_2.Visibility = Visibility.Hidden;
            Cl2_2.Visibility = Visibility.Hidden;
            Cl3_2.Visibility = Visibility.Hidden;
            Cl4_2.Visibility = Visibility.Hidden;
            Cl5_2.Visibility = Visibility.Hidden;
            Cl6_2.Visibility = Visibility.Hidden;
            Cl7_2.Visibility = Visibility.Hidden;
            Cl8_2.Visibility = Visibility.Hidden;
            Cl9_2.Visibility = Visibility.Hidden;


            Cl1_S.Visibility = Visibility.Hidden;
            Cl2_S.Visibility = Visibility.Hidden;
            Cl3_S.Visibility = Visibility.Hidden;
            Te2.Visibility = Visibility.Hidden;

            Next2.Visibility = Visibility.Hidden;
        }

        private void Next1_Click(object sender, RoutedEventArgs e)
        {
            Cl1_2.Visibility = Visibility.Visible;
            Cl2_2.Visibility = Visibility.Visible;
            Cl3_2.Visibility = Visibility.Visible;
            Cl4_2.Visibility = Visibility.Visible;
            Cl5_2.Visibility = Visibility.Visible;
            Cl6_2.Visibility = Visibility.Visible;
            Cl7_2.Visibility = Visibility.Visible;
            Cl8_2.Visibility = Visibility.Visible;
            Cl9_2.Visibility = Visibility.Visible;

            Cl1_S.Visibility = Visibility.Visible;
            Cl2_S.Visibility = Visibility.Visible;
            Cl3_S.Visibility = Visibility.Visible;

            Te2.Visibility = Visibility.Visible;

            Next2.Visibility = Visibility.Visible;


        }

        private void Next2_Click(object sender, RoutedEventArgs e)
        {
            int hard = 1;
            Console.WriteLine(hard);
            FirstStep firstStep = new FirstStep(dataWindow);
            firstStep.Show();
            Close();
        }

    }
}
