using System.Windows;
using System.Windows.Controls;

namespace ProjectOfficeApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Password { get; set; } = "";

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
            if (Password.Length > 0)
                placeholderTextBlock.Visibility = Visibility.Collapsed;
            else
                placeholderTextBlock.Visibility = Visibility.Visible;
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = passwordTextBox.Text;
            if (Password.Length > 0)
                placeholderTextBlock.Visibility = Visibility.Collapsed;
            else
                placeholderTextBlock.Visibility = Visibility.Visible;
        }

        private void VisiblePasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(visiblePasswordCheckBox.IsChecked == true)
            {
                passwordBox.Visibility = Visibility.Collapsed;
                passwordTextBox.Visibility = Visibility.Visible;
                passwordTextBox.Text = Password;
            }
            else
            {
                passwordBox.Visibility= Visibility.Visible;
                passwordBox.Password = Password;
                passwordTextBox.Visibility= Visibility.Collapsed;
            }
        }
    }
}
