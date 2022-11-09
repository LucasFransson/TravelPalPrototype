using System;
using System.Linq;
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
        private UserManager userManager; // Declaration of userManager object
        private TravelManager travelManager = new(); // Creation of TravelManger object

        // Constructor for first opening of homewindow ( From Mainwindow/Login )
        public HomeWindow(UserManager userManager)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.userManager = userManager; // Reference from earlier usermanager to this usermanager

            StaticMethods.SignedInUser = userManager.SignedInUser;
            UpdateUI("Travels"); // Refresh the UI with username and list content ( if any )
        }

        // Constructor for later openingings of homewindow ( From other windows than Mainwindow/Login )
        public HomeWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            userManager = uManager;
            travelManager = tManager;
            UpdateUI("Travels"); // Refresh the UI with username and list content ( if any )
        }

        // Opens up the Add Travel Window
        private void btnOpenAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow(userManager, travelManager);
            addTravelWindow.Show();
            this.Close();
        }

        // Logic for displaying all Travels in the list
        private void btnShowTravels_Click(object sender, RoutedEventArgs e)
        {

            userManager.DisplayTravels(lvBookedTravels, travelManager);
            lblCurrentListview.Content = "Travels";

        }

        // Logic for displaying username
        public void RefreshUserNameLabel()
        {
            lblUserHeadline.Content = userManager.SignedInUser.Username.ToString();
        }

        // Logic for displaying all Trips in the list
        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {

            userManager.DisplayTrips(lvBookedTravels, travelManager);
            lblCurrentListview.Content = "Trips";

        }

        // Logic for displaying all Vacations in the list
        private void btnShowVacations_Click(object sender, RoutedEventArgs e)
        {

            userManager.DisplayVacations(lvBookedTravels, travelManager);
            lblCurrentListview.Content = "Vacations";

        }

        // Logic for updating UI
        public void UpdateUI(string displayTypeString)
        {

                RefreshUserNameLabel();
                userManager.Display(lvBookedTravels, travelManager, displayTypeString);

        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {

            string travelInfo = lvBookedTravels.SelectedItem.ToString();
            if (travelInfo != null)
            {
                travelManager.RemoveSelectedTravel(lvBookedTravels.SelectedItem.ToString());
                userManager.Display(lvBookedTravels,travelManager,lblListviewBackground.Content.ToString());
            }
            else { MessageBox.Show("You must select a travel plan to remove."); }

            //try
            //{
            //    var travel = travelManager.travels.FirstOrDefault(t => t.GetDisplayInfo() == lvBookedTravels.SelectedItem.ToString());
            //    if (travel != null)
            //    {
            //        travelManager.RemoveTravel(travel);
            //        UpdateUI();
            //    }
            //}
            //catch (NullReferenceException ex)
            //{ MessageBox.Show("You must select a travel plan to remove."); }
        }

        private void btnEditTravel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var travel = travelManager.travels.FirstOrDefault(x => x.GetDisplayInfo() == lvBookedTravels.SelectedItem.ToString());
                if (travel != null)
                {
                    AddTravelWindow addTravelWindow = new(travelManager,travel);
                    addTravelWindow.Show();
                    this.Close();
                }
            }
            catch (NullReferenceException ex)
            { MessageBox.Show("You must select a travel plan to remove."); }
        }


        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            userManager.SignedInUser = null;
            StaticMethods.SignedInUser = null;
           
            MainWindow mWindow = new();
            mWindow.Show();
            this.Close();
        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            var travel = travelManager.travels.FirstOrDefault(x => x.GetDisplayInfo() == lvBookedTravels.SelectedItem.ToString());
            TravelDetailsWindow travelDetailsWindow = new(travelManager,travel);
            travelDetailsWindow.Show();
            this.Close();

        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {

            UserDetailsWindow userDetailsWindow = new(userManager);
            userDetailsWindow.Show();
            this.Close();
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}