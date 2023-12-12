using ProjectOfficeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

namespace ProjectOfficeApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;
            if (login.Length < 1 || password.Length < 1)
            {
                errorTextBlock.Text = "* Все поля должны быть заполнены";
                return;
            }

            try { 
            var user = await Connection.Client.GetFromJsonAsync<User>($"/user/{login}/{password}");
            }
            catch{ 
                errorTextBlock.Text = "* Неверный логин или пароль";
                return;
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
