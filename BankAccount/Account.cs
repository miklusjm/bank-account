using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    abstract class Account
    {
        protected string name;
        protected long number;
        protected decimal balance;
        protected string acctType;

        public string ClientName
        {
            get { return "Client Name: " + name; }
        }

        public string AccountNumber
        {
            get { return String.Format("Account Number: {0}", number); }
        }

        public string AccountBalance
        {
            get { return String.Format("Balance: {0:C}", balance); }
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
            Console.WriteLine(String.Format("\nYou deposited {0:C} into {1}.", amount, acctType));
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void Withdrawal(decimal amount)
        {
            if (this.balance > amount)
            {
                this.balance -= amount;
                Console.WriteLine(String.Format("\nYou withdrew {0:C} from {1}.", amount, acctType));
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nNot enough funds available.");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
        }
    }

    class Checking : Account
    {
        bool overdraftProtection;
        bool freeATMs;

        public Checking(string client, long acct)
        {
            this.acctType = "checking";
            this.name = client;
            this.number = acct;
            this.balance = 0;
            this.overdraftProtection = true;
            this.freeATMs = true;
        }

        public string Overdraft
        {
            get
            {
                if (overdraftProtection == true)
                    return "This account has overdraft protection.";
                else
                    return "This account does not have overdraft protection.";
            }
        }

        public string ATMs
        {
            get
            {
                if (freeATMs == true)
                    return "This account has free ATMs.";
                else
                    return "This account does not have free ATMs.";
            }
        }
    }

    class Reserve : Account
    {
        //I don't really know what a reserve account is, so I'm winging it
        string type;
        string purpose;

        public Reserve(string client, long acct)
        {
            this.acctType = "reserve";
            this.name = client;
            this.number = acct;
            this.balance = 0;
            this.type = "Personal";
            this.purpose = "Rainy day fund";
        }

        public string AccountType
        {
            get { return "Account Type: " + type; }
        }

        public string AccountPurpose
        {
            get { return "Account Purpose: " + purpose; }
        }
    }

    class Savings : Account
    {
        double interest;
        string grade;

        public Savings(string client, long acct)
        {
            this.acctType = "savings";
            this.name = client;
            this.number = acct;
            this.balance = 0;
            this.interest = 0.025;
            this.grade = "Bronze";
        }

        public string InterestRate
        {
            get { return "Interest Rate: " + (interest * 100) + "%"; }
        }

        public string AccountGrade
        {
            get { return "This is a " + grade + " level account."; }
        }
    }
}
