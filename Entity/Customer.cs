using System.Text;
using System.Security.Cryptography;

namespace Entity
{
    public class Customer
    {
        public Customer(int customerId, string firstName, string lastName, string email, string phoneNumber, string address, string username, string password, DateTime registrationDate)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Username = username;
            Password = password;
            RegistrationDate = registrationDate;
        }

        public Customer()
        {

        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public bool Authenticate(string password)
        {
            return Password == password;
        }
    }
}
