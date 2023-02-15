using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MagSquare
{
    //класс массива магического квадрата, способный его собрать, выдать и показать в указанные клетки
    internal class Set_numbers
    {
        Random rnd = new Random();
        public int[] nums = new int[9];

        public int get_hard_value(int hard) //-------------------------------------сложность---------------------------------
        {
            if (hard == 1)
            {
                hard = 3 * rnd.Next(4, 7);
            }
            else if (hard == 2)
            {
                hard = 3 * rnd.Next(7, 11);
            }
            else if (hard == 3)
            {
                hard = 3 * rnd.Next(11, 21);
            }
            else if (hard == 4)
            {
                hard = 3 * rnd.Next(21, 34);
            }

            return hard;
        }
        public void set(int hard) //------------------------------------------------сеттер--------------------------------
        {
            

            int rander = 0;
            int rander_2 = 0; //временные хранилища данных 

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
        }

        public int[] get() //-------------------------------------------------------геттер----------------------------------------------
        {
            return nums;
        }

        //----------------------------------------------------------------------душ----------------------------------------
        public void show(ref TextBox Cl0, ref TextBox Cl1, ref TextBox Cl2, ref TextBox Cl3, ref TextBox Cl4, ref TextBox Cl5, ref TextBox Cl6, ref TextBox Cl7, ref TextBox Cl8)
        {
            int storage = 0;
            storage = 2 * (rnd.Next(0, 4)) + 1;


            if (storage == 1)
            {
                Cl1.Text += nums[1];
                Cl6.Text += nums[6];
                Cl8.Text += nums[8];

                Cl1.IsEnabled = false;
                Cl6.IsEnabled = false;
                Cl8.IsEnabled = false;

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
            else if (storage == 3)
            {
                Cl3.Text += nums[3];
                Cl2.Text += nums[2];
                Cl8.Text += nums[8];

                Cl3.IsEnabled = false;
                Cl2.IsEnabled = false;
                Cl8.IsEnabled = false;

                storage = 2 * (rnd.Next(2, 4)) - 1;
                if (storage == 3)
                {
                    Cl1.Text += nums[1]; //вообще что там выдал рандом, он всё равно чисто для моего сокращения ифов
                    Cl1.IsEnabled = false;
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

                Cl5.IsEnabled = false;
                Cl6.IsEnabled = false;
                Cl0.IsEnabled = false;

                storage = 2 * (rnd.Next(2, 4)) - 1;
                if (storage == 3)
                {
                    Cl1.Text += nums[1];
                    Cl1.IsEnabled = false;
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

                Cl7.IsEnabled = false;
                Cl0.IsEnabled = false;
                Cl2.IsEnabled = false;

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

        public bool check(ref TextBox Cl0, ref TextBox Cl1, ref TextBox Cl2, ref TextBox Cl3, ref TextBox Cl4, ref TextBox Cl5, ref TextBox Cl6, ref TextBox Cl7, ref TextBox Cl8)
        {
            string[] plug = new string[9];

            for (int i = 0; i < 9; i++) //тупой перевод всего в стирнг, чтобы было удобнее сверять
            {
                int a = nums[i];
                plug[i] = a.ToString();
            }
            if (Cl0.Text == plug[0] && Cl1.Text == plug[1] && Cl2.Text == plug[2] && Cl3.Text == plug[3] && Cl4.Text == plug[4] && Cl5.Text == plug[5] && Cl6.Text == plug[6] && Cl7.Text == plug[7] && Cl8.Text == plug[8])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
