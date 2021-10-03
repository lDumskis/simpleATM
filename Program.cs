using System;

namespace BankAcc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("********* Bankomatas *********");
            var active = true;
            var bankAccount = new SavingsAccount(100);

            while (active)
            {
                Console.WriteLine("Pasirinkite operaciją:");
                Console.WriteLine("#1 Pinigų įnešimas");
                Console.WriteLine("#2 Grynųjų pinigų išėmimas");
                Console.WriteLine("#3 Patikrinti sąskaitos likutį");
                var operation = Console.ReadLine().ToString();

                switch (operation.ToUpper())
                {
                    case "1":
                        Console.WriteLine("Įveskite pinigų kiekį:");
                        var moneyToDeposit = int.Parse(Console.ReadLine().ToString());
                        bankAccount.Deposit(moneyToDeposit);
                        Console.WriteLine($"Pinigų inešimo operacija sėkminga. Sąskaitos likutis: {bankAccount.CheckBalance()}");
                        Console.WriteLine("Ar norite tęsti (T/N)?");
                        active = ArTesti(Console.ReadLine().ToString());
                        break;

                    case "2":
                        Console.WriteLine("Įveskite pinigų kiekį:");
                        var moneyToWithdraw = int.Parse(Console.ReadLine().ToString());
                        bankAccount.Withdraw(moneyToWithdraw);
                        Console.WriteLine($"Pinigų išėmimo operacija sėkminga. Sąskaitos likutis: {bankAccount.CheckBalance()}");
                        Console.WriteLine("Ar norite tęsti (T/N)?");
                        active = ArTesti(Console.ReadLine().ToString());
                        break;

                    case "3":
                        var balance = bankAccount.CheckBalance();
                        Console.WriteLine($"Jūsų sąskaitoje yra: {balance}");
                        Console.WriteLine("Ar norite tęsti (T/N)?");
                        active = ArTesti(Console.ReadLine().ToString());
                        break;

                    default:
                        Console.WriteLine("Operacija nerasta. Ar norite tęsti (T/N)?");
                        active = ArTesti(Console.ReadLine().ToString());
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static bool ArTesti(string simbolis)
        {
            if (simbolis.ToUpper() == "T")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public abstract class Account
    {
        private decimal Balance { get; set; }

        public Account(decimal balance)
        {
            Balance = balance;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void AddToBalance(decimal balance)
        {
            Balance = Balance + balance;
        }

        public void RemoveFromBalance(decimal balance)
        {
            Balance = Balance - balance;
        }
    }

    public class CheckingAccount : Account
    {
        public CheckingAccount(decimal balance) : base(balance)
        {
        }

        public decimal CheckBalance()
        {
            return GetBalance();
        }
    }

    public class SavingsAccount : CheckingAccount
    {
        public SavingsAccount(decimal balance) : base(balance)
        {
        }

        public void Deposit(decimal balance)
        {
            AddToBalance(balance);
        }

        public void Withdraw(decimal balance)
        {
            RemoveFromBalance(balance);
        }
    }
}