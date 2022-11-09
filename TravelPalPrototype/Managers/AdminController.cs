using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public class AdminController
    {
        TravelManager travelManager;
        UserManager userManager;

        public AdminController(TravelManager tManager, UserManager uManager)
        {
            travelManager = tManager;
            userManager = uManager;
        }


        public void ShowAllUsers(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach(var user in userManager.users)
            {
                lvDisplay.Items.Add(user.Username);
            }
        }
        public List<Travel> FindAllTravelsByUserID(int userID)
        {
            return travelManager.travels.FindAll(t => t.BookedByUserID == userID);
        }

        public List<Travel> FindAllTravelsByUsername(string username)
        {
            User user = FindUserByUsername(username);
            return travelManager.travels.FindAll(t => t.TravelID == user.UserID);
        }

        public  List<Travel> FindAllConnectedTravelsByTravel(Travel travel)
        {
            User user = FindUserByTravel(travel);
            return travelManager.travels.FindAll(t => t.TravelID == user.UserID);
        }

        public User FindUserByTravel(Travel travel) => FindUserByTravelID(travel.TravelID);

        public User FindUserByUserID(int searchUserID) => userManager.users.Where(u => u.UserID == searchUserID).FirstOrDefault();

        public User FindUserByUsername(string searchUsername) => userManager.users.Where(u => u.Username == searchUsername).FirstOrDefault();

        public string FindUsernameByTravel(Travel travel) => FindUserByTravelID(travel.TravelID).Username;

        public User FindUserByTravelID(int searchTravelID)
        {
            var travel = FindTravelByTravelID(searchTravelID);
            foreach (User user in userManager.users)
            {
                return userManager.users.Find(x => x.bookedTravelIDs.Contains(travel.TravelID));
                //var foundUser = UserManager.users.Where(x=>x.bookedTravels.Contains(travel)); // ICE
                // return foundUser;
            }
            return null;
        }

        public void AdminSortUserByUser(ListView lv, User user)
        {
            lv.Items.Clear();
            lv.ItemsSource = FindAllTravelsByUserID(user.UserID);
        }

        public void AdminSortUserByUsername(ListView lv, string username)
        {
            lv.Items.Clear();
            lv.ItemsSource = FindAllTravelsByUsername(username);
        }

        public void AdminSortUserByUserID(ListView lv, User user)
        {
            lv.Items.Clear();
            lv.ItemsSource = FindAllTravelsByUserID(user.UserID);
        }

        public  void AdminSortUserByTravel(ListView lv, Travel travel)
        {
            lv.Items.Clear();
            lv.ItemsSource = FindAllConnectedTravelsByTravel(travel);
        }

        public Travel FindTravelByUsername(int searchUserID) => travelManager.travels.Where(t => t.TravelID == searchUserID).FirstOrDefault();

        public Travel FindTravelByUser(User user) => travelManager.travels.Where(t => t.TravelID == user.UserID).FirstOrDefault();

        public Travel FindTravelByTravelID(int searchTravelID) => travelManager.travels.Where(t => t.TravelID == searchTravelID).FirstOrDefault();
    }
}

