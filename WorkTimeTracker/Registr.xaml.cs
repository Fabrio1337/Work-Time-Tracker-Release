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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    
    public partial class Registr : Window
    {
        private  String Namee;
        private  String Passw;
        private void ButtonSign(Object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(Login.Text) && !String.IsNullOrEmpty(Pass.Password))
            {
                Namee = Login.Text;
                Passw = Pass.Password;
                
                Login.Text = string.Empty;
                Pass.Password = string.Empty;
                

                (Owner as MainWindow)?.SetUser(Namee, Passw);
                this.Close();
                
            }


        }
        public Registr()
        {
            InitializeComponent();

        }
    }
}
