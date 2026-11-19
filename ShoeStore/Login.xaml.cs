
using System.Windows;
using ShoeStore.Models; 

namespace ShoeStore
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
           
            string login = txtLogin.Text.Trim();

           
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Поле логина не может быть пустым.\nПожалуйста, введите ваш логин.",
                                "Ошибка авторизации",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var db = new ShoeStoreContext())
            {
                
                var user = db.Users.FirstOrDefault(u => u.Login == login);

                
                if (user == null)
                {
                    MessageBox.Show($"Пользователь с логином «{login}» не найден.\n\n" +
                                    "Проверьте правильность написания логина или обратитесь к администратору.",
                                    "Ошибка авторизации",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                
                var mainWindow = new MainWindow(user);
                mainWindow.Show();

                
                this.Close();
            }
        }
    }
}