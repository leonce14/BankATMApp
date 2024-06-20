using System;
using System.Linq;


namespace BankATMApp.Models
{
    public class ATMOperations
    {
        private readonly BankContext _context;

        public ATMOperations(BankContext context)
        {
            _context = context;
        }

        public decimal Withdraw(int accountid, decimal amount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountid);

            if (account == null)
            {
                throw new Exception("Account not found. ");
            }
            else if (account.Balance < amount)
            {
                throw new Exception("Insufficient funds!. ");
            }
            account.WithdrawCash(amount);
            _context.SaveChanges();
            return account.Balance;
        }

        public decimal CheckBalance (int accountid)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountid);

            if (account == null)
            {
                throw new Exception ("Account not found. ");
            }
            return account.Balance;
        }

        public bool ValidatePIN(int accountid, string pin)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountid);

            if (account == null)
            {
                Console.WriteLine("Account not found. ");
                return false;
            }
            
            if (pin != account.PIN)
            {
                Console.WriteLine("Invalid PIN. Please try again. ");
                return false;
            }
            return true;
        }

        public decimal Deposit(int accountid, decimal amount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountid);

            if (account == null)
            {
                throw new Exception ("Account not found. ");
            }
            account.DepositCash(amount);
            _context.SaveChanges();
            return account.Balance;
        }
    }
}