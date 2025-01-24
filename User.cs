public class User
{
    String _firstName;
    String _lastName;
    int _accountNumber;
    int _pinNumber;
    double _balance;

    // Utilize a constructor and instantiate User variables
    public User(String firstName, String lastName, int accountNumber, int pinNumber, double balance) 
    {
        _firstName = firstName;
        _lastName = lastName;
        _accountNumber = accountNumber;
        _pinNumber = pinNumber;
        _balance = balance;
    }

    // Methods to get member variable values
    public String GetFirstName() => _firstName;
    public String GetLastName() => _lastName;
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
}