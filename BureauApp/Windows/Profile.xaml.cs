using System.Linq;
using System.Windows;

namespace BureauApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            login.Text = User.Login;
            switch (User.Role)
            {
                case "user":
                    role.Text = "Пользователь";
                    break;
                case "worker":
                    role.Text = "Работник отдела учета квартир БТИ";
                    break;
                case "admin":
                    role.Text = "Администратор";
                    break;
            }
            
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            User.Login = string.Empty;
            MainWindow authorizationWindow = new MainWindow();

            var windows = (Application.Current.Windows);
            foreach (var wnd in windows.OfType<Window>())
            {
                if (wnd == authorizationWindow) continue;
                wnd.Close();
            }
            authorizationWindow.ShowDialog();
        }
    }
}
