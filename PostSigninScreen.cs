using System;
using System.Threading;
using Microsoft.Data.SqlClient;

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
            Console.WriteLine("| 5. Delete Account               |");
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
                case "5":
                DeleteUser(signedInUser);
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
                user.SetBalance(newBalance);
                UpdateUserBalance(user);
                Console.WriteLine($"Withdrawal successful! Your new balance is: ${newBalance:F2}");
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
                user.SetBalance(newBalance);
                UpdateUserBalance(user);
                Console.WriteLine($"Deposit successful! Your new balance is: ${newBalance:F2}");
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

    // Update user balance on the database side. 
    private void UpdateUserBalance(User user)
    {
        string connectionString = "Server=DESKTOP-0Q9MU8N\\SQLEXPRESS;Database=ATM_UsersDB;Integrated Security=True;TrustServerCertificate=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "UPDATE Users SET balance = @balance WHERE accountNumber = @accountNumber";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@balance", user.GetBalance());
                cmd.Parameters.AddWithValue("@accountNumber", user.GetAccountNumber());

                cmd.ExecuteNonQuery();
            }
        }
    }

    // Deletes a user on the database side
    private void DeleteUser(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Delete Account                   |");
        Console.WriteLine(" ******************************** ");
        Console.Write("Are you sure you want to delete your account? (yes/no): ");

        string confirmation = Console.ReadLine().ToLower();
        if (confirmation == "yes")
        {
            string connectionString = "Server=DESKTOP-0Q9MU8N\\SQLEXPRESS;Database=ATM_UsersDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Users WHERE accountNumber = @accountNumber";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@accountNumber", user.GetAccountNumber());
                    cmd.ExecuteNonQuery();
                }
            }
            
            Console.WriteLine("Your account has been deleted. We're sad to see you go!");
        }
        else
        {
            Console.WriteLine("Account deletion avoided. Whew!");
        }
        Console.ReadLine();
    }
}
