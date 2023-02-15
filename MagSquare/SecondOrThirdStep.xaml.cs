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
using System.Windows.Shapes;

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для SecondOrThirdStep.xaml
    /// </summary>
    public partial class SecondOrThirdStep : Window
    {
        Random rnd = new Random();

        int hard_now = 0;
        bool flag = false;
        int plus_value= 0;
        bool third; //для того, чтобы уместить в одном типе окна и сложение и умножение, при том их различать
        bool first_type_continue = true; //отвечает за то, чтобы кнопка "проверить" по-разному работала для проверки первого и вторго квадрата

        Set_numbers set_Numbers = new Set_numbers();
        Set_numbers set_Numbers2 = new Set_numbers();
        public MainWindow dataWindow;
        public SecondOrThirdStep(MainWindow _dataWindow, bool _third)
        {
            InitializeComponent();

            dataWindow= _dataWindow;
            third = _third;

            Cl0_2.Visibility = Visibility.Hidden;
            Cl1_2.Visibility = Visibility.Hidden;
            Cl2_2.Visibility = Visibility.Hidden;
            Cl3_2.Visibility = Visibility.Hidden;
            Cl4_2.Visibility = Visibility.Hidden;
            Cl5_2.Visibility = Visibility.Hidden;
            Cl6_2.Visibility = Visibility.Hidden;
            Cl7_2.Visibility = Visibility.Hidden;
            Cl8_2.Visibility = Visibility.Hidden;

            Lvl_t.Text += dataWindow.hardness/2;
            Score_t.Text += dataWindow.score;

            hard_now = set_Numbers.get_hard_value(1);

            int p1 = 0, p2 = 0;
            p1 = (hard_now / 3) - 4;
            p2 = (hard_now / 3) + 4;
            Hint1.Text += p1 + " до " + p2 + ". Сумма квадрата равна " + hard_now;

            set_Numbers.set(hard_now);
            set_Numbers.show(ref Cl0, ref Cl1, ref Cl2, ref Cl3, ref Cl4, ref Cl5, ref Cl6, ref Cl7, ref Cl8);

            plus_value = rnd.Next(dataWindow.hardness, dataWindow.hardness + 2);
        }

        private void Leave_button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Resoults.txt", true))
            {
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                string date = Convert.ToString(dateT);
                string text = "------------------------------------------" + "\nИмя: " + dataWindow.name + "\nДата: " + date + "\n1 Этап: " + dataWindow.scores[0, 0] + " " + dataWindow.scores[0, 1] + " " + dataWindow.scores[0, 2] + " " + dataWindow.scores[0, 3] + "\n2 Этап: " + dataWindow.scores[1, 0] + " " + dataWindow.scores[1, 1] + " " + dataWindow.scores[1, 2] + " " + dataWindow.scores[1, 3] + "\n3 Этап: " + dataWindow.scores[2, 0] + " " + dataWindow.scores[2, 1] + " " + dataWindow.scores[2, 2] + " " + dataWindow.scores[2, 3] + "\n4 Этап: " + dataWindow.scores[3, 0] + " " + dataWindow.scores[3, 1] + " " + dataWindow.scores[3, 2] + " " + dataWindow.scores[3, 3];
                writer.WriteLineAsync(text);
            }
            Close();
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            SecondOrThirdStep sotStep = new SecondOrThirdStep(dataWindow, false);
            if (third)
            {
                sotStep.third = true;
            }
            sotStep.Show();
            Close();
        }

        private void Hard_button_Click(object sender, RoutedEventArgs e)          
        {
            dataWindow.score = 0;
            dataWindow.hardness += 2;
            SecondOrThirdStep sotStep = new SecondOrThirdStep(dataWindow, false);
            if (!third)
            {
                dataWindow.scores[1, dataWindow.hardness/2 - 1] = dataWindow.score;    
            }
            else
            {
                dataWindow.scores[2, dataWindow.hardness / 2 - 1] = dataWindow.score;
                sotStep.third = true;
            }
            Console.WriteLine(dataWindow.hardness + " -сложность");
            
            sotStep.Show();
            Close();
        }

        private void Step_button_Click(object sender, RoutedEventArgs e)
        {
            if (!third)
            {
                Tutorial3 t3 = new Tutorial3(dataWindow);
                t3.Show();
                Close();
            }
            else
            {
                Tutorial_4 t4 = new Tutorial_4(dataWindow);
                t4.Show();
                Close();
            }
            
        }

        private void True_button_Click(object sender, RoutedEventArgs e)
        {
            
            //---------------открытие кнопок-----------------
            if (first_type_continue)
            {
                if (set_Numbers.check(ref Cl0, ref Cl1, ref Cl2, ref Cl3, ref Cl4, ref Cl5, ref Cl6, ref Cl7, ref Cl8))
                {

                    Cl0.IsEnabled = false;
                    Cl1.IsEnabled = false;
                    Cl2.IsEnabled = false;
                    Cl3.IsEnabled = false;
                    Cl4.IsEnabled = false;
                    Cl5.IsEnabled = false;
                    Cl6.IsEnabled = false;
                    Cl7.IsEnabled = false;
                    Cl8.IsEnabled = false;

                    Cl0_2.Visibility = Visibility.Visible;
                    Cl1_2.Visibility = Visibility.Visible;
                    Cl2_2.Visibility = Visibility.Visible;
                    Cl3_2.Visibility = Visibility.Visible;
                    Cl4_2.Visibility = Visibility.Visible;
                    Cl5_2.Visibility = Visibility.Visible;
                    Cl6_2.Visibility = Visibility.Visible;
                    Cl7_2.Visibility = Visibility.Visible;
                    Cl8_2.Visibility = Visibility.Visible;

                    if(!third)
                    {
                        Hint2.Text = "Всё правильно! Теперь прибавь к каждой клетке квадрата число " + plus_value + " и заполни этими цифрами новый квадрат.";
                        Hint_plus_text.Text = "+ " + plus_value;
                        set_Numbers2 = set_Numbers;
                        for (int i = 0; i < 9; i++)
                        {
                            set_Numbers2.nums[i] += plus_value;
                        }
                    }
                    else
                    {
                        Hint2.Text = "Всё правильно! Теперь умножь каждую клетку квадрата на число " + plus_value + " и заполни этими цифрами новый квадрат.";
                        Hint_plus_text.Text = "* " + plus_value;
                        set_Numbers2 = set_Numbers;
                        for (int i = 0; i < 9; i++)
                        {
                            set_Numbers2.nums[i] *= plus_value;
                        }
                    }

                    first_type_continue = false;
                }
                else
                {
                    Hint2.Text = "Неверно. Попробуй ещё раз.";
                }
            }
            else
            {
                if(set_Numbers2.check(ref Cl0_2, ref Cl1_2, ref Cl2_2, ref Cl3_2, ref Cl4_2, ref Cl5_2, ref Cl6_2, ref Cl7_2, ref Cl8_2))
                {
                    Hint2.Text = "Всё правильно!";

                    Next_button.IsEnabled = true;
                    Next_button.Foreground = new SolidColorBrush(Colors.Black);

                    if (flag == false) //установка счёта после праильного ответа
                    {
                        dataWindow.score++;
                        Score_t.Text = "СЧ: " + dataWindow.score;
                        flag = true;

                    }

                    if (dataWindow.score >= 3) //включение кнопки усложнения при счете >=3
                    {
                        if (dataWindow.hardness == 8) //дальше 4 уровня сложности нельзя
                        {
                            Hard_button.Content = "Хаха, нет)";
                        }
                        else
                        {
                            Hard_button.IsEnabled = true;
                            Hard_button.Foreground = new SolidColorBrush(Colors.Black);
                        }


                        if (dataWindow.hardness >= 1) //ВРЕМЕННОЕ ЗНАЧЕНИЕ ДЛЯ ТЕСТОВ!
                        {
                            Step_button.IsEnabled = true;
                            Step_button.Foreground = new SolidColorBrush(Colors.Black);
                        }
                    }

                    if (!third)
                    {
                        dataWindow.scores[1, dataWindow.hardness / 2 - 1] = dataWindow.score; //делить на 2, так как сложности идут 2-4-6-8, нужно 0-1-2-3
                        Console.WriteLine(dataWindow.scores[1, dataWindow.hardness / 2 - 1] + " глобальный счёт");
                    }
                    else
                    {
                        dataWindow.scores[2, dataWindow.hardness / 2 - 1] = dataWindow.score; //делить на 2, так как сложности идут 2-4-6-8, нужно 0-1-2-3
                        Console.WriteLine(dataWindow.scores[2, dataWindow.hardness / 2 - 1] + " глобальный счёт");
                    }
                    
                }
                else
                {
                    Hint2.Text = "Неверно. Попробуй ещё раз.";
                }
            }
            
        }
    }
}
