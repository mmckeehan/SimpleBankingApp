using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SimpleBankingApp;

class BankingApp
{
    static List<CustomerAccount> accounts = new List<CustomerAccount>();



    static void Main(string[] args)
    {
        AccountCreation("John", /*"123abc",*/ "12345", 100.00);
        AccountCreation("Alice", /*"456def",*/ "67890", 200.00);
        LoginScreen();
    }

    static void AccountCreation(string name, /*string password,*/ string accountNumber, double startingBalance)
    {
        CustomerAccount account = new CustomerAccount(name, /*password,*/ accountNumber, startingBalance);
        accounts.Add(account);

    }
    public static void LoginScreen()
    {
        int loginAttempt = 1;
        bool correctAcct = false;

        if (loginAttempt >= 5)
        {
            Console.WriteLine("Sorry, that was too many login attempts. Please start over");
        }
        else
        {
            while (correctAcct == false && loginAttempt <= 5)
            {
                Console.WriteLine("What is your Account Number?: ");
                string userAcctInput = Console.ReadLine();

                // Iterate through the list of accounts to find a matching account
                CustomerAccount matchedAccount = accounts.Find(account => account._accountNumber == userAcctInput);

                if (matchedAccount != null)
                {
                    correctAcct = true;
                    matchedAccount.AccountLogin();
                }
                else if (loginAttempt == 5)
                {
                    Console.WriteLine("Sorry, that was too many login attempts. Please start over\n\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid account number. Please try again.\n \n");
                    loginAttempt++;
                    Debug.WriteLine(loginAttempt);
                }
            }
        }
    }
}