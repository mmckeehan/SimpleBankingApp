using System.Diagnostics;

namespace SimpleBankingApp
{
    internal class CustomerAccount
    {
        public string _name; 
        public string _password; 
        public string _accountNumber;
        public double _startingBalance;
        public string _depositAmmount;
        public double _currentBalance;
        public string userAccountAction;
        private bool userAccountBool;
        private string userInput;


        public CustomerAccount(string name, string password, string accountNumber, double startingBalance)
        {
            _name = name;
            _password = password;
            _accountNumber = accountNumber;
            _startingBalance = startingBalance;
            _currentBalance = startingBalance;
        }

/*
        Should this be split into multiple methods? One for each action you can take?
            --- The AccountLogin meathod would then have a loop to have an action until the user is completed with their transaction.*/
        public void AccountLogin()
        {
            userAccountBool = true;


            while (userAccountBool == true)
            {
                Console.WriteLine("Please select the NUMBER from the following options:");
                Console.WriteLine("   1. Look up name\n   2. Look up current balance\n   3. Deposit\n   4. Withdraw");
                userAccountAction = Console.ReadLine();

                switch (userAccountAction)
                {
                    case "1":
                        Console.WriteLine(_name);
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "2":
                        Console.WriteLine($"${_currentBalance}");
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "3":
                        Deposit();
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    case "4":
                        Console.WriteLine("Withdraw");
                        userAccountBool = false;
                        UserAccountBool();
                        break;
                    default: 
                        Console.WriteLine("\nThat is not a valid selection, please try again.\n");
                        break;
                }
               
            }
        }

        void UserAccountBool()
        {
            while (userAccountBool == false)
            {
                Console.WriteLine("\nDo you wish to perform another transaction?\n   Press 'y' for yes, any other key for no.");
                userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    userAccountBool = true;
                }
                else
                {
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
        }

    }
}
