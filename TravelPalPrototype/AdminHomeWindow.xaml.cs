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
            userManager = uManager;
            adminController = new(travelManager,userManager);
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            string travelInfo = lvBookedTravels.SelectedItem.ToString();
            travelManager.RemoveSelectedTravel(travelInfo);
            //var travel = travelManager.travels.FirstOrDefault(travel => travel.GetDisplayInfo() == travelInfo);

            //travelManager.RemoveTravel(travel);
        }

        private void btnOpenUserList_Click(object sender, RoutedEventArgs e)
        {
            adminController.ShowAllUsers(lvBookedTravels);
        }
    }
}