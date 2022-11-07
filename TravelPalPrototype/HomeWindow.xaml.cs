using System.Windows;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        UserManager userManager; // Declaration of userManager object
        private TravelManager travelManager = new(); // Creation of TravelManger object
     


        // Constructor for first opening of homewindow ( From Mainwindow/Login )
        public HomeWindow(UserManager userManager)
        {
        
            InitializeComponent();
  
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.userManager = userManager; // Reference from earlier usermanager to this usermanager
            
            StaticMethods.SignedInUser = userManager.SignedInUser;
            UpdateUI(); // Refresh the UI with username and list content ( if any )
        }

        // Constructor for later openingings of homewindow ( From other windows than Mainwindow/Login )
        public HomeWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            userManager = uManager;
            travelManager = tManager;
            UpdateUI(); // Refresh the UI with username and list content ( if any )
        }

        // Opens up the Add Travel Window
        private void btnOpenAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow(userManager, travelManager);
            addTravelWindow.Show();
        }

        // Logic for displaying all Travels in the list
        private void btnShowTravels_Click(object sender, RoutedEventArgs e)
        {
            lvBookedTravels.Items.Clear();  // Clearing the listview 
            foreach (var travel in travelManager.travels)
            {
                lvBookedTravels.Items.Add(travel.GetInfo());
                lvTrips.Items.Add(travel.GetInfo());
            }
        }

        // Logic for displaying username 
        public void RefreshUserNameLabel()
        {
            lblUserHeadline.Content = userManager.SignedInUser.Username.ToString();
        }

        // Logic for displaying all Trips in the list
        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {
            lvBookedTravels.Items.Clear(); // Clearing the listview 
            foreach (Trip trip in travelManager.travels)
            {
                lvBookedTravels.Items.Add(trip.GetInfo());
            }
        }
        // Logic for displaying all Vacations in the list
        private void btnShowVacations_Click(object sender, RoutedEventArgs e)
        { 
            lvBookedTravels.Items.Clear();  // Clearing the listview 
            foreach (Vacation vac in travelManager.travels)
            {
                lvBookedTravels.Items.Add(vac.GetInfo());
            }
        }

        // Logic for updating UI
        public void UpdateUI()
        {
            if (userManager.SignedInUser != null) // Failsafe ( Maybe remove this, a crash is easier to find and fix than a logical error )
            {
                RefreshUserNameLabel();
                lvBookedTravels.Items.Clear();  // Clearing the listview 
                foreach (var travel in travelManager.travels)
                {
                    lvBookedTravels.Items.Add(travel.GetInfo());
                }
            }
        }
    }
}