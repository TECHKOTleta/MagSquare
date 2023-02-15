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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MagSquare
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string name;
        public int hardness;
        public int[,] scores;
        public int score;
        public MainWindow()
        {
            InitializeComponent();
            hardness = 1;
            score = 0;
            scores = new int[4,4];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    scores[i,j] = 0;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = Name_t.Text;
            Tutorial TWindow = new Tutorial(name);
            TWindow.Show();
            Close();
        }
    }
}
