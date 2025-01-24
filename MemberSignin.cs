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
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(" Please enter your 4 digit pin:");
            Console.Write("     Pin # ");
            int pinNumber = int.Parse(Console.ReadLine());
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