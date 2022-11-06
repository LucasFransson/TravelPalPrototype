using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPalPrototype.Managers;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for AdminHomeWindow.xaml
    /// </summary>
    public partial class AdminHomeWindow : Window
    {
        private TravelManager travelManager = new();
        private UserManager userManager = new();

        public AdminHomeWindow()
        {
            InitializeComponent();
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            string travelInfo = lvBookedTravels.SelectedItem.ToString();
            var travel = travelManager.travels.FirstOrDefault(travel => travel.GetDisplayInfo() == travelInfo);

            travelManager.RemoveTravel(travel);
        }

        private void btnOpenUserList_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}