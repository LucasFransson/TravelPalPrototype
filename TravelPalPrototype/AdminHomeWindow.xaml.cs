using System.Linq;
using System.Windows;
using TravelPalPrototype.Managers;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for AdminHomeWindow.xaml
    /// </summary>
    public partial class AdminHomeWindow : Window
    {
        private TravelManager travelManager = new();
        private UserManager userManager;
        private AdminController adminController;

        public AdminHomeWindow(UserManager uManager)
        {

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            userManager = uManager;
            adminController = new(travelManager,userManager);
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            travelManager.RemoveSelectedTravel(lvBookedTravels.SelectedItem.ToString());
        }

        private void btnOpenUserList_Click(object sender, RoutedEventArgs e)
        {
            adminController.ShowAllUsers(lvBookedTravels);
        }

        private void btnEditTravel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowTravels_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowVacations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}