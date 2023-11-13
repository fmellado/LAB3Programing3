using System.Windows;

namespace Login
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = $"Username: {LoginControl.UserName}\nPassword: {LoginControl.Password}";
        }
    }
}
