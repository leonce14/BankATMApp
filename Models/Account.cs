namespace BankATMApp.Models
{
    public class Account
    {
        
        public int AccountID { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance{ get; private set;}

        public string PIN { get; set; }

        public Account()
        {
        }
        public Account(string accountHolder, string pin)
        {
            
            AccountHolder = accountHolder;
            PIN = pin;
        }

        public bool CheckPIN(string pin)
        {
            return PIN == pin; 
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                return true;
            }
            else return false;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void WithdrawCash(decimal amount)
        {
            if (amount < 0)
            {
              throw new ArgumentException("Withdraw amount must be positive.");
            }
            if (Balance < amount)
            {
              throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }

        public void DepositCash(decimal amount)
        {
            Balance += amount;
        }

    }
}