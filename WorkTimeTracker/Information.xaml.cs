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

namespace WorkTimeTracker
{
    /// <summary>
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
            Inform.Text = "Это мое первое приложение, мой первый pet - project. Данное приложение будет со временем совершенствоваться, пока что это так сказать alpha версия. Все обновления можете найти в этом телеграм канале:t.me/Fabrio_Dev";
            Inform.FontSize = 15;
        }
    }
}
