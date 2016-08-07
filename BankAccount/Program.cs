using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter CheckingLog = new StreamWriter("CheckingLog.txt");
            StreamWriter ReserveLog = new StreamWriter("ReserveLog.txt");
            StreamWriter SavingsLog = new StreamWriter("SavingsLog.txt");

            Checking UserChecking = new Checking("Joseph Miklus", 123456);
            Reserve UserReserve = new Reserve("Joseph Miklus", 234567);
            Savings UserSavings = new Savings("Joseph Miklus", 345678);

            CheckingLog.WriteLine("Checking Account Information");
            CheckingLog.WriteLine("\n******************************\n");
            CheckingLog.WriteLine(UserChecking.ClientName);
            CheckingLog.WriteLine(UserChecking.AccountNumber);
            CheckingLog.WriteLine(UserChecking.ATMs);
            CheckingLog.WriteLine(UserChecking.Overdraft);
            CheckingLog.WriteLine();

            ReserveLog.WriteLine("Reserve Account Information");
            ReserveLog.WriteLine("\n******************************\n");
            ReserveLog.WriteLine(UserReserve.ClientName);
            ReserveLog.WriteLine(UserReserve.AccountNumber);
            ReserveLog.WriteLine(UserReserve.AccountType);
            ReserveLog.WriteLine(UserReserve.AccountPurpose);
            ReserveLog.WriteLine();

            SavingsLog.WriteLine("Savings Account Information");
            SavingsLog.WriteLine("\n******************************\n");
            SavingsLog.WriteLine(UserSavings.ClientName);
            SavingsLog.WriteLine(UserSavings.AccountNumber);
            SavingsLog.WriteLine(UserSavings.AccountGrade);
            SavingsLog.WriteLine(UserSavings.InterestRate);
            SavingsLog.WriteLine();

            bool loop = true;
            while (loop == true)
            {
                int control = 0;
                Console.Clear();
                Console.WriteLine("Welcome to C#Bank Online Banking");
                Console.WriteLine("\n**********************************\n");
                Console.WriteLine("1.) View Client Information");
                Console.WriteLine("2.) View Account Information");
                Console.WriteLine("3.) Deposit Funds");
                Console.WriteLine("4.) Withdraw Funds");
                Console.WriteLine("5.) Exit\n");
                Console.Write("Enter your selection: ");
                try
                {
                    control = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    //No output is provided here because control stays equal to zero
                    //and this is handled in the output below
                }

                //This output is awkward but I thought it was the most meaningful
                //and logical way to get the data from the objects
                if (control == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Client Information\n");
                    Console.WriteLine("Checking");
                    Console.WriteLine(UserChecking.ClientName);
                    Console.WriteLine(UserChecking.AccountNumber);
                    Console.WriteLine();
                    Console.WriteLine("Reserve");
                    Console.WriteLine(UserReserve.ClientName);
                    Console.WriteLine(UserReserve.AccountNumber);
                    Console.WriteLine();
                    Console.WriteLine("Savings");
                    Console.WriteLine(UserSavings.ClientName);
                    Console.WriteLine(UserSavings.AccountNumber);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();

                }
                else if (control == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Which account to get information for?");
                    Console.WriteLine("\n***************************************\n");
                    Console.WriteLine("1.) Checking");
                    Console.WriteLine("2.) Reserve");
                    Console.WriteLine("3.) Savings\n");
                    Console.Write("Enter your selection: ");
                    try
                    {
                        control = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        control = 0;
                    }

                    Console.Clear();
                    if (control == 1)
                    {
                        Console.WriteLine("Checking Account Information");
                        Console.WriteLine("\n******************************\n");
                        Console.WriteLine(UserChecking.ClientName);
                        Console.WriteLine(UserChecking.AccountNumber);
                        Console.WriteLine(UserChecking.ATMs);
                        Console.WriteLine(UserChecking.Overdraft);
                        Console.WriteLine(UserChecking.AccountBalance);
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else if (control == 2)
                    {
                        Console.WriteLine("Reserve Account Information");
                        Console.WriteLine("\n******************************\n");
                        Console.WriteLine(UserReserve.ClientName);
                        Console.WriteLine(UserReserve.AccountNumber);
                        Console.WriteLine(UserReserve.AccountType);
                        Console.WriteLine(UserReserve.AccountPurpose);
                        Console.WriteLine(UserReserve.AccountBalance);
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else if (control == 3)
                    {
                        Console.WriteLine("Savings Account Information");
                        Console.WriteLine("\n******************************\n");
                        Console.WriteLine(UserSavings.ClientName);
                        Console.WriteLine(UserSavings.AccountNumber);
                        Console.WriteLine(UserSavings.AccountGrade);
                        Console.WriteLine(UserSavings.InterestRate);
                        Console.WriteLine(UserSavings.AccountBalance);
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid selection. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                else if (control == 3)
                {
                    decimal amount = 0;
                    Console.Clear();
                    Console.WriteLine("Deposit into which account?");
                    Console.WriteLine("\n***************************************\n");
                    Console.WriteLine("1.) Checking");
                    Console.WriteLine("2.) Reserve");
                    Console.WriteLine("3.) Savings\n");
                    Console.Write("Enter your selection: ");
                    try
                    {
                        control = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the deposit amount: ");
                        amount = decimal.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        control = 0;
                    }

                    if (control == 1)
                    {
                        UserChecking.Deposit(amount);
                        CheckingLog.Write(DateTime.Now);
                        CheckingLog.Write(String.Format(" +{0:C} ", amount));
                        CheckingLog.WriteLine(UserChecking.AccountBalance);
                    }
                    else if (control == 2)
                    {
                        UserReserve.Deposit(amount);
                        ReserveLog.Write(DateTime.Now);
                        ReserveLog.Write(String.Format(" +{0:C} ", amount));
                        ReserveLog.WriteLine(UserReserve.AccountBalance);
                    }
                    else if (control == 3)
                    {
                        UserSavings.Deposit(amount);
                        SavingsLog.Write(DateTime.Now);
                        SavingsLog.Write(String.Format(" +{0:C} ", amount));
                        SavingsLog.WriteLine(UserSavings.AccountBalance);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Press any key to continue.");
                        Console.ReadKey();
                    }
                    
                }
                else if (control == 4)
                {
                    decimal amount = 0;
                    Console.Clear();
                    Console.WriteLine("Withdraw from which account?");
                    Console.WriteLine("\n***************************************\n");
                    Console.WriteLine("1.) Checking");
                    Console.WriteLine("2.) Reserve");
                    Console.WriteLine("3.) Savings\n");
                    Console.Write("Enter your selection: ");
                    try
                    {
                        control = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the withdrawal amount: ");
                        amount = decimal.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        control = 0;
                    }

                    if (control == 1)
                    {
                        UserChecking.Withdrawal(amount);
                        CheckingLog.Write(DateTime.Now);
                        CheckingLog.Write(String.Format(" -{0:C} ", amount));
                        CheckingLog.WriteLine(UserChecking.AccountBalance);
                    }
                    else if (control == 2)
                    {
                        UserReserve.Withdrawal(amount);
                        ReserveLog.Write(DateTime.Now);
                        ReserveLog.Write(String.Format(" -{0:C} ", amount));
                        ReserveLog.WriteLine(UserReserve.AccountBalance);
                    }
                    else if (control == 3)
                    {
                        UserSavings.Withdrawal(amount);
                        SavingsLog.Write(DateTime.Now);
                        SavingsLog.Write(String.Format(" -{0:C} ", amount));
                        SavingsLog.WriteLine(UserSavings.AccountBalance);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Press any key to continue.");
                        Console.ReadKey();
                    }

                }
                else if (control == 5)
                {
                    loop = false;
                    CheckingLog.Close();
                    ReserveLog.Close();
                    SavingsLog.Close();
                }
                else
                {
                    Console.WriteLine("\nInvalid selection. Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
    }
}
