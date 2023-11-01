namespace SimpleBankingApp
{
    internal class Account
    {
        public static bool accountBool;

        public static void AccountBool()
        {
            while (accountBool == false)
            {
                Console.WriteLine("\n\nDo you wish to perform another transaction?\n   Press 'y' for yes, any other key for no.");
                char userInput = Console.ReadKey().KeyChar;
                if (userInput == 'y')
                {
                    Console.Clear();
                    accountBool = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\nGoign back to login screen.\n\n");
                    int milliseconds = 2000;
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    BankingApp.LoginScreen();
                    break;
                }
            }
        }
    }
}
