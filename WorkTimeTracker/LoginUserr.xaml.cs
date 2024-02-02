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
    /// Логика взаимодействия для LoginUserr.xaml
    /// </summary>
    public partial class LoginUserr : Window
    {
        private string Namee, Passw;
        private void ButtonLogin(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(Log.Text) && !String.IsNullOrEmpty(Pass.Password))
            {
                Namee = Log.Text;
                Passw = Pass.Password;
                Log.Text = string.Empty;
                Pass.Password = string.Empty;
                

                (Owner as MainWindow)?.GetUser(Namee, Passw);
                this.Close();
            }
            
        }


        public LoginUserr()
        {
            InitializeComponent();
        }
    }
}
