using System;
using System.Threading;

public class PostSignInScreen
{
    // Create the main atm feature screen for user members
    public void PostSignIn(User signedInUser)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ******************************** ");
            Console.WriteLine("| What can I help you with today? |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("| 1. Withdrawal                   |");
            Console.WriteLine("| 2. Deposit                      |");
            Console.WriteLine("| 3. Balance                      |");
            Console.WriteLine("| 4. Logout                       |");
            Console.WriteLine("|                                 |");
            Console.WriteLine(" ******************************** ");

            Console.Write("Please select an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Withdrawal(signedInUser);
                    break;
                case "2":
                    Deposit(signedInUser);
                    break;
                case "3":
                    DisplayBalance(signedInUser);
                    break;
                case "4":
                    Console.WriteLine("Thank you for using our service. Goodbye!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    // Withdrawal method for users to take out money from their account
    private void Withdrawal(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Withdrawal                      |");
        Console.WriteLine(" ******************************** ");
        Console.Write("Enter the amount to withdraw: $");
        
        double amount;
        bool isValidWithdrawal = false;

        while (!isValidWithdrawal)
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out amount) && amount > 0 && amount <= user.GetBalance())
            {
                isValidWithdrawal = true;
                // Deduct the amount from the user's balance
                double newBalance = user.GetBalance() - amount;
                Console.WriteLine($"Withdrawal successful! Your new balance is: ${newBalance:F2}");
                user.SetBalance(newBalance);
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient balance. Please enter a valid amount.");
            }
        }
        Console.ReadLine();
    }

    // Deposit method for users to put money into their account
    private void Deposit(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Deposit                         |");
        Console.WriteLine(" ******************************** ");
        Console.Write("Enter the amount to deposit: $");
        
        double amount;
        bool isValidDeposit = false;

        while (!isValidDeposit)
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out amount) && amount > 0)
            {
                isValidDeposit = true;
                // Add the amount to the user's balance
                double newBalance = user.GetBalance() + amount;
                Console.WriteLine($"Deposit successful! Your new balance is: ${newBalance:F2}");
                user.SetBalance(newBalance);
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive amount.");
            }
        }
        Console.ReadLine();
    }

    // Displays user's balance
    private void DisplayBalance(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Account Balance                 |");
        Console.WriteLine(" ******************************** ");
        Console.WriteLine($"Your current balance is: ${user.GetBalance():F2}");
        Console.ReadLine();
    }
}
