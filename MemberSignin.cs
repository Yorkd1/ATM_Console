using System.Threading;

public class MemberSignInScreen
{
    public void MemberSignIn()
    {
        int maxAttempts = 3;
        int attempts = 0;
        bool isAuthenticated = false;

        while (attempts < maxAttempts && !isAuthenticated)
        {
            // Creates Signin screen for user indicatng they are already members.
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ******************************** ");
            Console.WriteLine(" Please enter your 8 digit account number: ");
            Console.Write("    Account # ");

            // Verify if account number is valid
            int accountNumber = 0;
            bool isValidAccount = false;
            while (!isValidAccount)
            {
                string accountInput = Console.ReadLine();
                if (int.TryParse(accountInput, out accountNumber) && accountNumber.ToString().Length == 8)
                {
                    isValidAccount = true;
                }
                else
                {
                    Console.WriteLine("Invalid account number. Please enter a valid 8 digit account number: ");
                }
            }

            Console.WriteLine(" Please enter your 4 digit pin:");
            Console.Write("     Pin # ");

            // Verify if pin number is valid
            int pinNumber = 0;
            bool isValidPin = false;
            while (!isValidPin)
            {
                string pinInput = Console.ReadLine();
                if (int.TryParse(pinInput, out pinNumber) && pinNumber.ToString().Length == 4)
                {
                    isValidPin = true;
                }
                else
                {
                    Console.WriteLine("Invalid pin. Please enter a valid 4 digit pin number: ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(" ******************************** ");

            // Check if the account exists and if the pin matches
            // Iterate through the list of users and check for a match
            foreach (var user in NewUserAccount.users)
            {
                if (user.GetAccountNumber() == accountNumber && user.GetPinNumber() == pinNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome back, {user.GetFirstName()} {user.GetLastName()}!");
                    isAuthenticated = true;
                    Thread.Sleep(3000);
                    PostSignInScreen postSignIn = new PostSignInScreen();
                    postSignIn.PostSignIn(user);
                    break;
                }
            }

            // If authentication fails, increment the attempt counter
            if (!isAuthenticated)
            {
                attempts++;
                if (attempts < maxAttempts)
                {
                    Console.WriteLine("Invalid account number or pin. Please try again.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have exceeded the maximum number of attempts. Returning to Main Menu.");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
