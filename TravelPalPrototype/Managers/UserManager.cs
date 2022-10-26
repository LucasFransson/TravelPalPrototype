using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public class UserManager
    {
        public IUser SignedInUser { get; set; }
        public List<IUser> allUsers = new();
        public List<Customer> customers = new();
        public List<Admin> admins = new();

        // Methods

        // Creating Methods
        public void PopulateTestUsers()
        {
            Admin newAdmin = new("admin", "admin");
            AddUserToList(newAdmin);
            Customer customer = new("Lucas", "Fransson", "LucasFransson", "123", Countries.Sweden);
            AddUserToList(customer);
        }
        public Admin CreateNewAdim(string username, string password) 
        {
            Admin newAdmin = new(username, password);
            AddUserToList(newAdmin);
            return newAdmin;
        }
        public void CreateNewUser(string firstName,string lastName, string username, string password, Countries location)
        {
            Customer newCustomer = new(firstName, lastName, username, password, location);
            AddUserToList(newCustomer);
        }
        public bool ValidateUserName(string username)
        {
            var lookForDuplicate = allUsers.FirstOrDefault(un => un.Username == username);
            if (lookForDuplicate != null)
            {
                return false;
            }
            else return true;
        }
        public void AddUserToList(IUser user)
        {
            allUsers.Add(user);
            if (user is Customer)
            {
                Customer customer = (Customer)user;
                customers.Add(customer);
            }
            else if (user is Admin)
            {
                Admin admin = (Admin)user; 
                admins.Add(admin);
            }
        }
        // Booking Methods
        public void CheckBookingRequest(IUser user)
        { 
        }
        public void ConfirmBooking(string password)
        {     
        }
        public void BookTravel(IUser user)
        {
        }
        public void RemoveTravel()
        {

        }
        // Log-in Methods
        public bool CheckLogin(string inputUsername, string inputPassword)
        {
            IUser user = FindUserByUsername(inputUsername);

            if (CheckUsernameAndPassword(user, inputUsername, inputPassword) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckUsernameAndPassword(IUser? user, string username, string password)
        {
            if(user != null)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        // Searching Methods

        public IUser FindUserByUsername(string searchUsername)
        {
            return allUsers.FirstOrDefault(user => user.Username == searchUsername);
        }
        //public IUser FindUserByUsername(string searchUsername) => allUsers.Where(u => u.Username == searchUsername).FirstOrDefault();

        public IUser FindUserByID(int searchID)
        {
            return allUsers.FirstOrDefault(user => user.UserID == searchID);
        }
        public Admin FindAdminByUsername(string searchUsername)
        {
            return admins.FirstOrDefault(admin => admin.Username == searchUsername);
        }
        public Admin FindAdminByID(int searchID)
        {
            return admins.FirstOrDefault(admin => admin.UserID == searchID);
        }

        public Customer FindCustomerByUsername(string searchUsername)
        {
            return customers.FirstOrDefault(customer => customer.Username == searchUsername);
        }
        public Customer FindCustomerByID(int searchID)
        {
            return customers.FirstOrDefault(customer => customer.UserID == searchID);
        }

    }
}
