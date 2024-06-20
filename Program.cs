using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BankATMApp.Models;
using Microsoft.IdentityModel.Tokens;
using BankATMApp;

internal class Program
{

    private static readonly BankContext _context = new BankContext();
    private static readonly ATMOperations _atmOperations = new ATMOperations(_context);
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the ATM!");

        Console.WriteLine("Enter your Account ID: ");
        int accountID = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your PIN: ");
        string pin = Console.ReadLine();

        if (!_atmOperations.ValidatePIN(accountID, pin))
            {
                Console.WriteLine("Invalid account ID or PIN. Exiting.");
                return;
            }
            Console.WriteLine($"Current Balance: {_atmOperations.CheckBalance(accountID)}");


            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    Console.WriteLine("Enter amount to withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        try
                        {
                            decimal newBalance = _atmOperations.Withdraw(accountID, withdrawAmount);
                            Console.WriteLine($"Withdrawal successful. New Balance: {newBalance}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter an amount to deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        decimal newBalance1 = _atmOperations.Deposit(accountID,depositAmount);
                        Console.WriteLine($"Deposit successfull. New Balance: {newBalance1}");
                        break;
                    case "3":
                        Console.WriteLine("Exiting ATM. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        
    }
}

        //BankContext entityFramework = new BankContext();
        //Account testAccount = new Account("Jana Jonoska", "9539");
        //entityFramework.Add(testAccount);
        //entityFramework.SaveChanges();
