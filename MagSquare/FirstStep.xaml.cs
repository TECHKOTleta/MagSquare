using System;
using System.Collections.Generic;
using System.IO;
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

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для FirstStep.xaml
    /// </summary>
    public partial class FirstStep : Window
    {
        Random rnd = new Random();
        int[] cells = new int[9];


        int hardness_global = 0;
        int score_global = 0;
        string name_global;
        int[] global_scores= new int[4];


        int hard_now = 0;
        bool flag = false;
        public FirstStep(int hardness, int score, string name, int[] scores)
        {
            InitializeComponent();

            //---------присовение знаечений для передачи--------
            hardness_global = hardness;
            score_global = score;
            name_global = name;

            Lvl_t.Text += hardness;
            Score_t.Text += score;
            global_scores = scores;

            //-------------установка суммы в зависимости от сложности--------

            if (hardness == 1)
            {
                hard_now = 3 * rnd.Next(4, 7);
            }
            else if (hardness == 2)
            {
                hard_now = 3 * rnd.Next(7, 11);
            }
            else if (hardness == 3)
            {
                hard_now = 3 * rnd.Next(11, 21);
            }
            else if (hardness == 4)
            {
                hard_now = 3 * rnd.Next(21, 34);
            }

            //--------------------отображение текста
            int p1 = 0, p2 = 0;
            p1 = (hard_now/3) - 4;
            p2 = (hard_now / 3) + 4;
            Hint1.Text += p1 + " до " + p2 + ". Сумма квадрата равна " + hard_now;

            cells = set_numbers(hard_now); //случайное допустимое расположение номеров

            shower(cells); //случайное допустимое показание номеров

        }

        //------------------------------------------------присваивание номеров-----------------------------------
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

            rander = 2*(rnd.Next(0, 4)) + 1; //случайная клетка из центров сторон (1, 3, 5, 7)
            nums[rander] = 1;
            nums[Math.Abs(8 - rander)] = 9; //Math.Abs(8 - rander) -  координата противоположную той клетке ..........хз, зачем модуль
            
            if (rander == 1 || rander == 7)
            {
                rander_2 = rnd.Next(0, 2);
                nums[rander - 1] = test_nums[rander_2];
                nums[rander + 1] = test_nums[Math.Abs(rander_2-1)];

                nums[Math.Abs(8 - rander) - 1] = test_nums[rander_2 + 2];
                nums[Math.Abs(8 - rander) + 1] = test_nums[Math.Abs(rander_2-1) + 2];

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
            for(int i = 0; i < 9; i++)
            {
                nums[i] += rander;
            }
            return nums;
        }

        //-------------------------------------------показ номеров---------------------------------
        void shower(int[] nums)
        {
            int storage = 0;
            storage = 2 * (rnd.Next(0, 4)) + 1;


            if(storage == 1)
            {
                Cl1.Text += nums[1];
                Cl6.Text += nums[6];
                Cl8.Text += nums[8];

                Cl1.IsEnabled = false;
                Cl6.IsEnabled = false;
                Cl8.IsEnabled = false;

                storage = 2*(rnd.Next(2, 4))-1;
                if (storage == 3)
                {
                    Cl3.Text += nums[3];
                    Cl3.IsEnabled= false;
                }
                else
                {
                    Cl5.Text += nums[5];
                    Cl5.IsEnabled = false;
                }

            }
            else if(storage== 3)
            {
                Cl3.Text += nums[3];
                Cl2.Text += nums[2];
                Cl8.Text += nums[8];

                Cl3.IsEnabled= false;
                Cl2.IsEnabled= false;
                Cl8.IsEnabled = false;

                storage = 2 * (rnd.Next(2, 4)) - 1;
                if (storage == 3)
                {
                    Cl1.Text += nums[1]; //вообще что там выдал рандом, он всё равно чисто для моего сокращения ифов
                    Cl1.IsEnabled= false;
                }
                else
                {
                    Cl7.Text += nums[7];
                    Cl7.IsEnabled = false;
                }
            }
            else if (storage == 5)
            {
                Cl5.Text += nums[5];
                Cl6.Text += nums[6];
                Cl0.Text += nums[0];

                Cl5.IsEnabled= false;
                Cl6.IsEnabled= false;
                Cl0.IsEnabled= false;

                storage = 2 * (rnd.Next(2, 4)) - 1;
                if (storage == 3)
                {
                    Cl1.Text += nums[1];
                    Cl1.IsEnabled= false;
                }
                else
                {
                    Cl7.Text += nums[7];
                    Cl7.IsEnabled = false;
                }

            }
            else if (storage == 7)
            {
                Cl7.Text += nums[7];
                Cl0.Text += nums[0];
                Cl2.Text += nums[2];

                Cl7.IsEnabled= false;
                Cl0.IsEnabled= false;
                Cl2.IsEnabled= false;

                storage = 2 * (rnd.Next(2, 4)) - 1;
                if (storage == 3)
                {
                    Cl3.Text += nums[3];
                    Cl3.IsEnabled = false;
                }
                else
                {
                    Cl5.Text += nums[5];
                    Cl5.IsEnabled = false;
                }
            }
        }

        private void True_button_Click(object sender, RoutedEventArgs e)
        {
            string[] plug = new string[9];

            for(int i = 0; i < 9; i++) //тупой перевод всего в стирнг, чтобы было удобнее сверять
            {
                int a = cells[i];
                plug[i] = a.ToString();
            }
            //---------------открытие кнопок-----------------
            if (Cl0.Text == plug[0] && Cl1.Text == plug[1] && Cl2.Text == plug[2] && Cl3.Text == plug[3] && Cl4.Text == plug[4] && Cl5.Text == plug[5] && Cl6.Text == plug[6] && Cl7.Text == plug[7] && Cl8.Text == plug[8])
            {
                Hint2.Text = "Всё правильно!";
                Next_button.IsEnabled= true;
                Next_button.Foreground = new SolidColorBrush(Colors.Black);

                if (flag == false) //установка счёта после праильного ответа
                {
                    score_global++;
                    Score_t.Text = "СЧ: " + score_global.ToString();
                    flag = true;

                }

                if (score_global >= 3 && hardness_global != 4) //включение кнопки усложнения при счете >=3
                {
                    Hard_button.IsEnabled = true;
                    Hard_button.Foreground= new SolidColorBrush(Colors.Black);

                    if (hardness_global >= 1)
                    {
                        Step_button.IsEnabled = true;
                        Step_button.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }

                if(hardness_global == 4) //дальше 4 уровня сложности нельзя
                {
                    Hard_button.Content = "Хаха, нет)";
                }

                global_scores[hardness_global - 1] = score_global;
                Console.WriteLine(global_scores[hardness_global - 1] + " глобальный счёт");
            }
            else
            {
                Hint2.Text = "Неверно. Попробуй ещё раз.";
            }

            //----------прибавление счета----------------
            

        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            FirstStep firstStep = new FirstStep(hardness_global, score_global, name_global, global_scores);
            firstStep.Show();
            Close();

        }

        private void Leave_button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Resoults.txt", true))
            {
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                string date = Convert.ToString(dateT);
                string text = "------------------------------------------" + "\nИмя: " + name_global + "\nДата: " + date + "\n1 Уровень: " + global_scores[0] + "\n2 Уровень: " + global_scores[1] + "\n3 Уровень: " + global_scores[2] + "\n4 Уровень: " + global_scores[3];
                writer.WriteLineAsync(text);
            }
            Close();
        }

        private void Hard_button_Click(object sender, RoutedEventArgs e)
        {
            global_scores[hardness_global - 1] = score_global;
            score_global = 0;
            hardness_global++;
            Console.WriteLine(hardness_global + " -сложность");
            FirstStep firstStep = new FirstStep(hardness_global, score_global, name_global, global_scores);
            firstStep.Show();
            Close();
        }

        private void Step_button_Click(object sender, RoutedEventArgs e)
        {
            Tutorial_2 t2 = new Tutorial_2(name_global);
            t2.Show();
            Close();
        }
    }

    

}


