using System.Windows;
using System.Windows.Controls;

namespace ProjectOfficeApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LoginBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public static readonly DependencyProperty PlaceholderProperty
                    = DependencyProperty.Register(
                  "Placeholder",
                  typeof(string),
                  typeof(CustomTextBox),
                  new PropertyMetadata(""));

        public static readonly DependencyProperty TextProperty
                    = DependencyProperty.Register(
                  "Text",
                  typeof(string),
                  typeof(CustomTextBox),
                  new PropertyMetadata(""));

        public CustomTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Text 
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        } 

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text.Length > 0)
                placeholderTextBlock.Visibility = Visibility.Collapsed;
            else
                placeholderTextBlock.Visibility = Visibility.Visible;
        }
    }
}
