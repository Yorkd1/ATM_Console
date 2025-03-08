using System;
using Microsoft.Data.SqlClient;

public class User
{
    string _firstName;
    string _lastName;
    int _accountNumber;
    int _pinNumber;
    double _balance;

    // Utilize a constructor and instantiate User variables
    public User(string firstName, string lastName, int accountNumber, int pinNumber, double balance) 
    {
        _firstName = firstName;
        _lastName = lastName;
        _accountNumber = accountNumber;
        _pinNumber = pinNumber;
        _balance = balance;
    }

    // Methods to get member variable values
    public string GetFirstName() => _firstName;
    public string GetLastName() => _lastName;
    public int GetAccountNumber() => _accountNumber;
    public int GetPinNumber() => _pinNumber;
    public double GetBalance() => _balance;

    // Methods to set member variables values
    public void SetFirstName(String fName)
    {
        _firstName = fName;
    }
    public void SetLastName(String lName)
    {
        _lastName = lName;
    }
    public void SetAccountNumber(int accountNum)
    {
        _accountNumber = accountNum;
    }
    public void SetPinNumber(int pinNum)
    {
        _pinNumber = pinNum;
    }
    public void SetBalance(double bal)
    {
        _balance = bal;
    }

    public static User GetUserByAccountNumber(int accountNumber)
    {
        string connectionString = "Server=DESKTOP-0Q9MU8N\\SQLEXPRESS;Database=ATM_UsersDB;Integrated Security=True;TrustServerCertificate=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT firstName, lastName, accountNumber, pinNumber, balance FROM Users WHERE accountNumber = @accountNumber";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
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
        return null;
    }
}