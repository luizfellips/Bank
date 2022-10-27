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
namespace Bank
{
    /// <summary>
    /// Lógica interna para LogInScreen.xaml
    /// </summary>
    public partial class LogInScreen : Window
    {
        private List<BankAccount> BankSystem = new List<BankAccount>();
        public LogInScreen(List<BankAccount> BankList)
        {
            this.BankSystem = BankList;
            InitializeComponent();
        }
        private async Task DefaultMessage()
        {
            await Task.Delay(1000);
            LogInButton.Content = "Log-In";
        }
        private async void LogIn_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                String name = UserBox.Text;
                String password = PassBox.Password;
                if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
                {
                   BankAccount account = BankSystem.Find(x => x.Name == name && x.Password == password);
                    if(account == null)
                    {
                        LogInButton.Content = "Failed";
                        UserBox.Clear();
                        PassBox.Clear();
                        await DefaultMessage();
                        return;
                    }
                    MainSystem p = new MainSystem(account);
                    this.Close();
                    p.Show();
                }

            }
            catch
            {
                LogInButton.Content = "Failed";
            }
        }
    }
}
