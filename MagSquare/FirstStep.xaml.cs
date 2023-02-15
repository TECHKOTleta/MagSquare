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

        int hard_now = 0;
        bool flag = false;

        Set_numbers set_Numbers = new Set_numbers();
        public MainWindow dataWindow ;
        public FirstStep(MainWindow _dataWindow)
        {
            InitializeComponent();

            dataWindow= _dataWindow;

            Lvl_t.Text += dataWindow.hardness;
            Score_t.Text += dataWindow.score;

            //-------------установка суммы в зависимости от сложности--------

            hard_now = set_Numbers.get_hard_value(dataWindow.hardness);

            //--------------------отображение текста
            int p1 = 0, p2 = 0;
            p1 = (hard_now/3) - 4;
            p2 = (hard_now / 3) + 4;
            Hint1.Text += p1 + " до " + p2 + ". Сумма квадрата равна " + hard_now;


            
            set_Numbers.set(hard_now);
            set_Numbers.show(ref Cl0, ref Cl1, ref Cl2, ref Cl3, ref Cl4, ref Cl5, ref Cl6, ref Cl7, ref Cl8);

        }


        private void True_button_Click(object sender, RoutedEventArgs e)
        {
            string[] plug = new string[9];

            for(int i = 0; i < 9; i++) //тупой перевод всего в стирнг, чтобы было удобнее сверять
            {
                int a = set_Numbers.nums[i];
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
                    dataWindow.score++;
                    Score_t.Text = "СЧ: " + dataWindow.score.ToString();
                    flag = true;

                }

                if (dataWindow.score >= 3) //включение кнопки усложнения при счете >=3
                {
                    if (dataWindow.hardness == 4) //дальше 4 уровня сложности нельзя
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

                

                dataWindow.scores[0, dataWindow.hardness - 1] = dataWindow.score; //-1 так как сложности идут 1-2-3-4
                Console.WriteLine(dataWindow.scores[0, dataWindow.hardness - 1] + " глобальный счёт");
            }
            else
            {
                Hint2.Text = "Неверно. Попробуй ещё раз.";
            }

            //----------прибавление счета----------------
            

        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            FirstStep firstStep = new FirstStep(dataWindow);
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
                string text = "------------------------------------------" + "\nИмя: " + dataWindow.name + "\nДата: " + date + "\n1 Этап: " + dataWindow.scores[0, 0] + " " + dataWindow.scores[0, 1] + " " + dataWindow.scores[0, 2] + " " + dataWindow.scores[0, 3] + "\n2 Этап: " + dataWindow.scores[1, 0] + " " + dataWindow.scores[1, 1] + " " + dataWindow.scores[1, 2] + " " + dataWindow.scores[1, 3] + "\n3 Этап: " + dataWindow.scores[2, 0] + " " + dataWindow.scores[2, 1] + " " + dataWindow.scores[2, 2] + " " + dataWindow.scores[2, 3] +"\n4 Этап: " + dataWindow.scores[3, 0] + " " + dataWindow.scores[3, 1] + " " + dataWindow.scores[3, 2] + " " + dataWindow.scores[3, 3];
                writer.WriteLineAsync(text);
            }
            Close();
        }

        private void Hard_button_Click(object sender, RoutedEventArgs e)
        {
            dataWindow.scores[0, dataWindow.hardness - 1] = dataWindow.score;
            dataWindow.score = 0;
            dataWindow.hardness++;
            Console.WriteLine(dataWindow.hardness + " -сложность");
            FirstStep firstStep = new FirstStep(dataWindow);
            firstStep.Show();
            Close();
        }

        private void Step_button_Click(object sender, RoutedEventArgs e)
        {
            Tutorial2 t2 = new Tutorial2(dataWindow); 
            t2.Show();
            Close();
        }
    }

    

}


