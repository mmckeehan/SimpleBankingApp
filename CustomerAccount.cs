using System.Diagnostics;

namespace SimpleBankingApp
{
    internal class CustomerAccount
    {
        public string _name; 
        //public string _password; 
        public string _accountNumber;
        public double _startingBalance;
        public string _depositAmmount;
        public string _withdrawAmmount;
        public double _currentBalance;
        private bool userAccountBool;



        public CustomerAccount(string name, /*string password,*/ string accountNumber, double startingBalance)
        {
            _name = name;
            //_password = password;
            _accountNumber = accountNumber;
            _startingBalance = startingBalance;
            _currentBalance = startingBalance;
        }

        public void AccountLogin()
        {
            userAccountBool = true;
            string userAccountAction;

            while (userAccountBool == true)
            {
                Console.WriteLine("Please select the NUMBER from the following options:");
                Console.WriteLine("   1. Look up name\n   2. Look up current balance\n   3. Deposit\n   4. Withdraw");
                userAccountAction = Console.ReadLine();

                switch (userAccountAction)
                {
                    case "1":
                        Console.WriteLine($"The name on the account is: {_name}");
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "2":
                        Console.WriteLine($"Your current balance is: ${_currentBalance}");
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "3":
                        Deposit();
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "4":
                        Withdraw();
                        userAccountBool = false;
                        UserAccountBool();
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
            double withNum;

            Console.WriteLine($"Your current balance is ${_currentBalance}, How much would you like to withdraw: ");
            _withdrawAmmount = Console.ReadLine();
            while (!double.TryParse(_withdrawAmmount, out withNum))
            {
                Console.WriteLine("That is not a valid value. Please enter a valid amount: ");
                _withdrawAmmount = Console.ReadLine();
            }

            if (_currentBalance - withNum <= 0)
            {
                Console.WriteLine("That ammount with overdraw your account. Please try again");
            }
            else
            {
                _currentBalance -= withNum;
                Console.WriteLine($"You have withdrawn ${withNum}, your current balance is ${_currentBalance}");
            }

        }

        void UserAccountBool()
        {
            while (userAccountBool == false)
            {
                Console.WriteLine("\nDo you wish to perform another transaction?\n   Press 'y' for yes, any other key for no.");
                char userInput = Console.ReadKey().KeyChar;
                if (userInput == 'y')
                {
                    Console.WriteLine("\n\n");
                    userAccountBool = true;
                }
                else
                {
                    Console.WriteLine("\n\nGoign back to login screen.\n\n");
                    BankingApp.LoginScreen();
                    break;
                }
            }
        }

    }
}
