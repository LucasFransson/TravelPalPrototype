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
            var travel = travelManager.travels.FirstOrDefault(x => x.GetDisplayInfo() == lvBookedTravels.SelectedItem.ToString());
            if (travel != null)
            {
                AddTravelWindow addTravelWindow = new(travelManager, travel);
                addTravelWindow.Show();
                this.Close();
            }
            else { MessageBox.Show("You must select a travel plan to edit."); }
        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            var travel = travelManager.travels.FirstOrDefault(x => x.GetDisplayInfo() == lvBookedTravels.SelectedItem.ToString());
            TravelDetailsWindow travelDetailsWindow = new(travelManager, travel);
            travelDetailsWindow.Show();
            this.Close();
        }

        private void btnShowTravels_Click(object sender, RoutedEventArgs e)
        {
            userManager.DisplayTravels(lvBookedTravels, travelManager);
        }

        private void btnShowVacations_Click(object sender, RoutedEventArgs e)
        {
            userManager.DisplayVacations(lvBookedTravels, travelManager);
        }

        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {
            userManager.DisplayTrips(lvBookedTravels, travelManager);
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Information");
        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager);
            userDetailsWindow.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            StaticMethods.SignedInUser = null;
            userManager.SignedInUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}