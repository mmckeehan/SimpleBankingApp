using System.Diagnostics;

namespace SimpleBankingApp;

class BankingApp
{
    static void Main(string[] args)
    {
        int loginAttempt = 1;
        bool correctAcct = false;


        CustomerAccount account1 = new CustomerAccount("John", "123abc", "12345", 100.00);

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

                if (userAcctInput == account1._accountNumber)
                {
 // Main loop for the app
                    correctAcct = true;
                    account1.AccountLogin();
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
