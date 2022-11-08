using System;
using System.Collections.Generic;
using System.Linq;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public class UserManager
    {
        public IUser SignedInUser { get; set; }
        public List<IUser> allUsers = new();
        public List<User> users = new();
        public List<Admin> admins = new();

        // Methods

        // Creating Methods
        public void PopulateTestUsers()
        {
            Admin newAdmin = new("Admin", "Admin");
            User user = new("Gandalf", "Efternamnsson", "Gandalf", "password", Countries.Afghanistan);
            AddUserToList(newAdmin);
            User newUser = new("Lucas", "Fransson", "LucasFransson", "123", Countries.Sweden);
            AddUserToList(user);
            AddUserToList(newUser);
        }

        public Admin CreateNewAdim(string username, string password)
        {
            Admin newAdmin = new(username, password);
            AddUserToList(newAdmin);
            return newAdmin;
        }

        public void CreateNewUser(string firstName, string lastName, string username, string password, Countries location)
        {
            User newUser = new(firstName, lastName, username, password, location);
            AddUserToList(newUser);
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

        public void AddUserToList(IUser iuser)
        {
            allUsers.Add(iuser);
            if (iuser is User)
            {
                User user = (User)iuser;
                users.Add(user);
            }
            else if (iuser is Admin)
            {
                Admin admin = (Admin)iuser;
                admins.Add(admin);
            }
        }

        public IUser FindIUserByUsername(string searchUsername)
        {
            return allUsers.FirstOrDefault(user => user.Username == searchUsername);
        }

        public User FindUserByUsername(string searchUsername)
        {
            return users.FirstOrDefault(user => user.Username == searchUsername);
        }

        // Log-in Methods

        public bool CheckLogin(string inputUsername, string inputPassword)
        {
            IUser user = FindIUserByUsername(inputUsername);

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
            if (user != null)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckUsernameRequirements(string username)
        {
            if (username.Length >= 3)
            {
                return true;
            }
            return false;
        }

        public bool CheckPasswordRequirements(string password)
        {
            if (password.Length >= 5)
            {
                return true;
            }
            return false;
        }

        public Countries ParseStringCountryToEnum(string stringToParse)
        {
            return (Countries)Enum.Parse(typeof(Countries), stringToParse);
        }

        public static void ChangePassword(User user, string s)
        {
            user.Password = s;
        }

        public static void ChangeLocation(User user, string s)
        {
            user.Location = TravelManager.ParseStringCountryToEnum(s);             // Detta känns bättre än att kasta in en travelManager i konstruktorn. Borde inte typ allt i Manager vara static egentligen?
        }

        public static void ChangeLastName(User user, string s)
        {
            user.LastName = s;
        }

        public static void ChangeFirstName(User user, string s)
        {
            user.FirstName = s;
        }

        public static void ChangeUsername(User user, string s)
        {
            user.Username = s;
        }

        public void RemoveIUser(IUser user)
        {
            allUsers.Remove(user);
        }

        public void RemoveUser(IUser user)
        {
            allUsers.Remove(user);
        }

        public void RemoveAdmin(Admin admin)
        {
            allUsers.Remove(admin);
        }
    }
}