using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BankAccount> BankList = new List<BankAccount>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task DefaultMessage()
        {
            await Task.Delay(1000);
            
            StatusContent.Content = "";
        }
        private async void Register_ButtonClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                String name = NameBox.Text;
                String password = PassBox.Password ;
                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
                {
                    BankAccount account = new BankAccount(name,password);
                    BankList.Add(account);
                    StatusContent.Content = "Success!";
                    NameBox.Clear();
                    PassBox.Clear();
                    await DefaultMessage();
                }
                else
                {
                    StatusContent.Content = "Invalid Input";
                    NameBox.Clear();
                    PassBox.Clear();
                    await DefaultMessage();
                }
            }
            catch
            {
                StatusContent.Content = "Failed";
                NameBox.Clear();
                PassBox.Clear();
                await DefaultMessage();
            }

        }

        private void Display_ButtonClick(object sender, RoutedEventArgs e)
        {
            if(BankList.Count < 1)
            {
                return;
            }
            else
            {
                foreach (BankAccount acc in BankList)
                {
                    if(!lstBankNames.Items.Contains(acc.Name))
                    {
                        lstBankNames.Items.Add(acc.Name);
                    }
                    
                }
            }
            
        }

        private void LogIn_ButtonClick(object sender, RoutedEventArgs e)
        {
            LogInScreen p = new LogInScreen(BankList);
            p.Show();
        }

        private void Form_OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter){ Register_ButtonClick(this, new RoutedEventArgs()); }
        }
    }
}
