namespace SimpleBankingApp
{
    internal class CustomerAccount: Account
    {
        public string _name; 
        //public string _password; 
        public string _accountNumber;
        public double _startingBalance;
        public string _depositAmmount;
        public string _withdrawAmmount;
        public double _currentBalance;
        double withNum;



        public CustomerAccount(string name, /*string password,*/ string accountNumber, double startingBalance)
        {
            _name = name;
            //_password = password;
            _accountNumber = accountNumber;
            _startingBalance = startingBalance;
            _currentBalance = startingBalance;
        }

        public void AccountScreen()
        {
            accountBool = true;
            char userAccountAction;

            while (accountBool == true)
            {
                Console.Clear();
                Console.WriteLine("Please select the NUMBER from the following options:");
                Console.WriteLine("   1. Look up name\n   2. Look up current balance\n   3. Deposit\n   4. Withdraw");
                userAccountAction = Console.ReadKey().KeyChar;

                switch (userAccountAction)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine($"The name on the account is: {_name}");
                        accountBool = false;
                        AccountBool();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine($"Your current balance is: ${_currentBalance}");
                        accountBool = false;
                        AccountBool();
                        break;
                    case '3':
                        Console.Clear();
                        Deposit();
                        accountBool = false;
                        AccountBool();
                        break;
                    case '4':
                        Console.Clear();
                        Withdraw();
                        accountBool = false;
                        AccountBool();
                        break;
                    default: 
                        Console.WriteLine("\nThat is not a valid selection, please try again.\n");
                        break;
                }
               
            }
        }

        void Deposit()
        {
            double depositNum;

            Console.WriteLine("How much do you want to deposit: ");
            _depositAmmount = Console.ReadLine();
            while (!double.TryParse(_depositAmmount, out depositNum))
            {
                Console.WriteLine("That is not a valid value. Please enter a valid amount: ");
                _depositAmmount = Console.ReadLine();
            }
            if (depositNum > 0)
            {
                _currentBalance += depositNum;
                Console.WriteLine($"Your current balance is: ${_currentBalance}");
            }
            else 
            { 
                Console.WriteLine("Deposits must be a positive value");
            }
        }

        void Withdraw()
        {
            Console.WriteLine($"Your current balance is ${_currentBalance}, How much would you like to withdraw: ");
            AmmountWithdraw();
            while (_currentBalance - withNum <= 0)
            {
                Console.WriteLine("That ammount will overdraw your account. Please try again:");
                AmmountWithdraw();
            }

            if (_currentBalance - withNum >= 0)
            {
                _currentBalance -= withNum;
                Console.WriteLine($"You have withdrawn ${withNum}, your current balance is ${_currentBalance}");
            }

        }

        void AmmountWithdraw()
        {
            _withdrawAmmount = Console.ReadLine();
            while (!double.TryParse(_withdrawAmmount, out withNum))
            {
                Console.WriteLine("That is not a valid value. Please enter a valid amount: ");
                _withdrawAmmount = Console.ReadLine();
            }
        }

    }
}
