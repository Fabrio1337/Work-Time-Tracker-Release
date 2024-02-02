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
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Threading;
using WorkTimeTracker.Properties;
using System.Net.NetworkInformation;
using System.Threading;
using System.Reflection.Emit;
using Microsoft.Win32;
using System.Diagnostics;

namespace WorkTimeTracker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //База данных
        Cont db;

        //счетчик времени
        private DispatcherTimer timer;
        private TimeSpan elapsedTime;
        private string targetProcessName = "";//нужное приложение

        //проверка кнопок
        private bool isHistoryOpened = false;
        private bool isInformationOpened = false;
        private bool isSignOpened = false;
        private bool isLogOpened = false;

        //данные для авторизации
        private static string AuthoName, AuthoPass;
        private int id;

        ////получение и проверка логина и пароля
        public void GetUser(string n, string p)
        {
            try
            {
                //получение входных данных
                AuthoName = n;
                AuthoPass = p;

                test2.Text = String.Empty;

                //работа с базой данных
                User authUser = null; 

                using(Cont context = new Cont())
                {
                    //проверка введеных данных
                    authUser = context.Users.Where(l => l.nameUser == AuthoName && l.passwordUser == AuthoPass).FirstOrDefault();
                    
                }


                //выполнение кода если данные верны
                if (authUser != null) 
                {
                    Sign.Visibility = Visibility.Collapsed;
                    Log.Visibility = Visibility.Collapsed;
                    Exit.Visibility = Visibility.Visible;
                    nameText.Text = "Name: " + n;
                }
                
            }
            catch (Exception)
            {

                test2.Text = "ебана";
                throw;
            }
        }

        //вносим данные регистрации
        public void SetUser(String n, String p)
        {
            try
            {
                User user = new User(n,p);
                db.Users.Add(user);
                db.SaveChanges(); 

                test2.Text = "Аккаунт зарегистрирован!";
            }
            catch (Exception)
            {

                test2.Text = "Pizdec";
                throw;
            }
        }

        //метод который срабатывает при нажатии кнопки Выйти
        private void OpenExit(Object sender, RoutedEventArgs e)
        {
            test2.Text = string.Empty;
            nameText.Text = string.Empty;
            Exit.Visibility = Visibility.Collapsed;
            Sign.Visibility = Visibility.Visible;
            Log.Visibility = Visibility.Visible;
        }

        //метод который срабатывает при нажатии Войти
        private void OpenLog(Object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (!isLogOpened)
            {
                LoginUserr logUs = new LoginUserr();
                logUs.Owner = this;
                logUs.Show();

                isLogOpened = true;
                count = 1;
            }
            if (count == 1)
            {
                LoginUserr logUs = new LoginUserr();
                logUs.Owner = this;
                if (!logUs.IsLoaded)
                {
                    isLogOpened = false;
                }
            }
        }
        //метод который срабатывает при нажатии кнопки История
        private void OpenHistory(object sender, RoutedEventArgs e)
        {
            int count = 0;

            //функция для того чтобы не открывалось больше одного окна
            if (!isHistoryOpened)
            {
                History history = new History();
                history.Owner = this;
                history.Show();

                isHistoryOpened = true;
                count = 1;
            }
            if (count == 1)
            {
                History history = new History();
                history.Owner = this;
                if (!history.IsLoaded)
                {
                    isHistoryOpened = false;
                }
            }
        }

        //метод который срабатывает при нажатии кнопки Информация
        private void OpenInformation(object sender, RoutedEventArgs e)
        {
            int count = 0;

            //функция для того чтобы не открывалось больше одного окна
            if (!isInformationOpened)
            {
                Information info = new Information();
                info.Owner = this;
                info.Show();

                isInformationOpened = true;
                count = 1;
            }
            if (count == 1)
            {
                Information info = new Information();
                info.Owner = this;
                if (!info.IsLoaded)
                {
                    isInformationOpened = false;
                }
            }

        }

        //метод который срабатывает при нажатии кнопки Зарегистрироваться
        public void OpenSign(object sender, RoutedEventArgs e)
        {
            int count = 0;

            //функция для того чтобы не открывалось больше одного окна
            if (!isSignOpened)
            {
                Registr reg = new Registr();
                reg.Owner = this;
                reg.Show();

                isSignOpened = true;
                count = 1;
            }
            if (count == 1)
            {
                Registr reg = new Registr();
                reg.Owner = this;
                if (!reg.IsLoaded)
                {
                    isSignOpened = false;
                }
            }
        }
        //private void pressCollect(object sender, RoutedEventArgs e)
        //{
        //    targetProcessName = Programma.Text;
        //    Programma.Text = String.Empty;
        //}
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Обновление elapsedTime при каждом тике таймера
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            UpdateTimerText();//обновляем отображение времени
        }

        private void UpdateTimerText()
        {
            timerApp.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        public MainWindow()
        {
            InitializeComponent();

            //объявление БД
            db = new Cont();

            timerName.Text = "Время в приложении";
            timerName.Height = 300;
            timerApp.Height = 250;


            // Инициализация таймера
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            timer.Start();

            //Начальное значение для elapsedTime
            elapsedTime = TimeSpan.Zero;
            UpdateTimerText();//Обновляем отображение времени при инициализации


            Registr reg = new Registr();

            // Устанавливаем владельца (owner) второго окна, если MainWindow уже показано
            if (IsLoaded)
            {
                reg.Owner = this;
            }
            else
            {
                Loaded += (sender, e) => reg.Owner = this;
            }



        }
    }

}


   