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
    /// Lógica interna para MainSystem.xaml
    /// </summary>
    public partial class MainSystem : Window
    {
        private BankAccount Account = new BankAccount();
        public MainSystem(BankAccount account)
        {
            InitializeComponent();
            this.Account = account;
            NameBox.Content = Account.Name;
            BalanceBox.Content = $"R${Account.Balance}";
        }

        private void Withdraw_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(WithdrawAmount.Text);
                Account.WithdrawMoney(amount);
                BalanceBox.Content = $"R${Account.Balance}";
                WithdrawAmount.Clear();
            }

            catch { return; }
        }

        private void Deposit_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(DepositAmount.Text);
                Account.DepositMoney(amount);
                BalanceBox.Content = $"R${Account.Balance}";
                DepositAmount.Clear();
            }

            catch { return; }
        }
    }
}
