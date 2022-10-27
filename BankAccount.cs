using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        public String Name { get; set; }
        public String Password { get; }
        public double Balance = 100;
        public BankAccount()
        {

        }
        public BankAccount(String name, String password)
        {
            Name = name;
            Password = password;
        }
        public void DepositMoney(double amount)
        {
            Balance += amount;
        }
        public void WithdrawMoney(double amount)
        {
            Balance -= amount;
        }
    }
}
