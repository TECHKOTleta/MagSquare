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
    /// Логика взаимодействия для SecondStep.xaml
    /// </summary>
    public partial class SecondStep : Window
    {
        Random rnd = new Random();
        int[] cells = new int[9];


        int hardness_global = 0;
        int score_global = 0;
        string name_global;
        int[] global_scores = new int[4];


        int hard_now = 0;
        bool flag = false;
        public SecondStep(int hardness, int score, string name, int[] scores)
        {
            InitializeComponent();
        }

        int[] set_numbers(int hard)
        {
            int rander = 0;
            int rander_2 = 0; //временные хранилища данных


            int[] nums = new int[9];

            int[] test_nums = new int[4];
            test_nums[0] = 6;
            test_nums[1] = 8;
            test_nums[2] = 2;
            test_nums[3] = 4;

            //действительные координаты клеток:
            // 0 1 2
            // 3 4 5
            // 6 7 8

            rander = 2 * (rnd.Next(0, 4)) + 1; //случайная клетка из центров сторон (1, 3, 5, 7)
            nums[rander] = 1;
            nums[Math.Abs(8 - rander)] = 9; //Math.Abs(8 - rander) -  координата противоположную той клетке ..........хз, зачем модуль

            if (rander == 1 || rander == 7)
            {
                rander_2 = rnd.Next(0, 2);
                nums[rander - 1] = test_nums[rander_2];
                nums[rander + 1] = test_nums[Math.Abs(rander_2 - 1)];

                nums[Math.Abs(8 - rander) - 1] = test_nums[rander_2 + 2];
                nums[Math.Abs(8 - rander) + 1] = test_nums[Math.Abs(rander_2 - 1) + 2];

                nums[5] = 15 - nums[2] - nums[8];
                nums[3] = 15 - nums[0] - nums[6];
            }
            else
            {
                rander_2 = rnd.Next(0, 2);
                nums[rander - 3] = test_nums[rander_2];
                nums[rander + 3] = test_nums[Math.Abs(rander_2 - 1)];

                nums[Math.Abs(8 - rander) - 3] = test_nums[rander_2 + 2];
                nums[Math.Abs(8 - rander) + 3] = test_nums[Math.Abs(rander_2 - 1) + 2];

                nums[1] = 15 - nums[2] - nums[0];
                nums[7] = 15 - nums[8] - nums[6];
            }


            nums[4] = 5;

            rander = (hard / 3) - 5;
            for (int i = 0; i < 9; i++)
            {
                nums[i] += rander;
            }
            return nums;
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
