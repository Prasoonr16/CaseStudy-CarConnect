using System;
using System.Security.Cryptography;
using System.Text;


namespace Entity
{
    public class Admin
    {
        public Admin(int adminID, string firstName, string lastName, string email, string phoneNumber, string username, string password, string role, DateTime joinDate)
        {
            AdminID = adminID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Username = username;
            Password = password;
            Role = role;
            JoinDate = joinDate;
        }

        public Admin() { }
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }

        public byte[] Authenticate(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
