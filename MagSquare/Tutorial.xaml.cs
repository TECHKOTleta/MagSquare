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
        string name_global;
        int[] scores = new int[4];
        
        public Tutorial(string name)
        {
            InitializeComponent();

            name_global= name;
            scores[0] = 0;
            scores[1] = 0;
            scores[2] = 0;
            scores[3] = 0;

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
            soft_show();
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
            FirstStep firstStep = new FirstStep(hard, 0, name_global, scores);
            firstStep.Show();
            Close();
        }

        void soft_show()
        {

        }
    }
}
