using System.Windows.Controls;

namespace Login
{
    public partial class LoginUserControl : UserControl
    {
        public string UserName
        {
            get { return UserNameTextBox.Text; }
        }

        public string Password
        {
            get { return PasswordTextBox.Text; }
        }

        public LoginUserControl()
        {
            InitializeComponent();
        }
    }
}
