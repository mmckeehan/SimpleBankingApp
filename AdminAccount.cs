namespace SimpleBankingApp
{
    internal class AdminAccount: Account
    {
        public string _userName;
        public string _name;
        /*private string _password;*/

        public AdminAccount (string userName, string name/*,string password*/)
        {
            _userName = userName;
            _name = name;
            /*_password = password;*/
        }

        public static void AdminMenu()
        {
            accountBool = true;

            while (accountBool == true)
            {
                Console.Clear();
                Console.WriteLine("Please select the NUMBER from the following options:");
                Console.WriteLine("   1. Create User\n   2. Look up users");
                char userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        UserAccountCreation();
                        accountBool = false;
                        AccountBool();
                        break;
                    case '2':
                        AccountLookup();
                        accountBool = false;
                        AccountBool();
                        break;
                    default:
                        Console.WriteLine("\nThat is not a valid selection, please try again.\n");
                        break;
                }

            }
        }

        static void UserAccountCreation()
        {
            double _custStartBal = 0;
            /*string custName;
            string custAcctNum;*/

            Console.Clear();
            Console.WriteLine("What is the name of the customer: ");
            string custName = Console.ReadLine();
            while (custName == string.Empty)
            {
                Console.WriteLine("There needs to be a value for the name. Please enter a value:");
                custName = Console.ReadLine();
            }

            Console.WriteLine("What is the account number: ");
            string custAcctNum = Console.ReadLine();
            while (custAcctNum == string.Empty)
            {
                Console.WriteLine("There needs to be a value for the Account Number. Please enter a value:");
                custAcctNum = Console.ReadLine();
            }

            /*Console.WriteLine("What is the account Password: ");*/

            Console.WriteLine("What is the starting balance of the account: ");
            string custStartBal = Console.ReadLine();

            while (!double.TryParse(custStartBal, out _custStartBal) || _custStartBal < 0)
            {
                Console.WriteLine("That is not a valid value. Please enter a valid amount: ");
                custStartBal = Console.ReadLine();
            }

            BankingApp.AccountCreation(custName, custAcctNum, _custStartBal);
        }

        static void AccountLookup()
        {
            Console.Clear();
            Console.WriteLine("Here are the current users.\n\n");
            Console.WriteLine($"Name / Account:");
            foreach (CustomerAccount customerAccount in BankingApp.accounts)
            {
                Console.WriteLine($"{customerAccount._name} / {customerAccount._accountNumber}");
            }
        }
    }
}
