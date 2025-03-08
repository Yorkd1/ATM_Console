using System;
using System.Threading;
using Microsoft.Data.SqlClient;
public class MemberSignInScreen
{
    private string _connectionString;

    public MemberSignInScreen(string connectionString)
    {
        _connectionString = connectionString;
    }
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

            // Get user from database
            User user = GetUserFromDatabase(accountNumber, pinNumber);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"Welcome back!");
                Thread.Sleep(3000);
                
                // Proceed to the post-sign-in menu
                PostSignInScreen postSignIn = new PostSignInScreen();
                postSignIn.PostSignIn(user);
                break;
            }

            // If authentication fails, increment attempt counter
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

        // Retrieve the user from the database using the account number and PIN.
        private User GetUserFromDatabase(int accountNumber, int pinNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "SELECT firstName, lastName, accountNumber, pinNumber, balance FROM Users WHERE accountNumber = @accountNumber AND pinNumber = @pinNumber";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                        cmd.Parameters.AddWithValue("@pinNumber", pinNumber.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User(
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetInt32(2),   
                                    int.Parse(reader.GetString(3)),
                                    Convert.ToDouble(reader["balance"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            return null;
        }
}

