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
        private TravelManager travelManager = new();
        private UserManager userManager = new();


        public HomeWindow(UserManager userManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.userManager = userManager;
            UpdateUI();
        }

        public HomeWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //WindowState = WindowState.Maximized;
            userManager = uManager;
            travelManager = tManager;
            UpdateUI();
        }

        private void btnOpenAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow(userManager, travelManager);
            addTravelWindow.Show();
        }

        private void btnShowTravels_Click(object sender, RoutedEventArgs e)
        {
            lvBookedTravels.Items.Clear();
            foreach (var travel in travelManager.travels)
            {
                lvBookedTravels.Items.Add(travel.GetInfo());
                lvTrips.Items.Add(travel.GetInfo());
            }
        }

        public void RefreshUserNameLabel()
        {
            lblUserHeadline.Content = userManager.SignedInUser.Username.ToString();
        }

        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {
            lvBookedTravels.Items.Clear();
            foreach (Trip trip in travelManager.travels)
            {
                lvBookedTravels.Items.Add(trip.GetInfo());
            }
        }

        private void btnShowVacations_Click(object sender, RoutedEventArgs e)
        {
            lvBookedTravels.Items.Clear();
            foreach (Vacation vac in travelManager.travels)
            {
                lvBookedTravels.Items.Add(vac.GetInfo());
            }
        }

        public void UpdateUI()
        {
            if (userManager.SignedInUser != null)
            {
                lblUserHeadline.Content = userManager.SignedInUser;
                lvBookedTravels.Items.Clear();
                foreach (var travel in travelManager.travels)
                {
                    lvBookedTravels.Items.Add(travel.GetInfo());
                }
            }
        }
    }
}