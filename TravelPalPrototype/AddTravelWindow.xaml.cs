using System;
using System.Windows;
using System.Windows.Controls;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private bool hasPackPass = false;
        private TravelDocument pass;
        private Travel travel;
        private TravelManager travelManager;
        private UserManager userManager;
        private bool isTravelTrip = false;
        private bool isTravelVacation = false;

        public AddTravelWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();

            travelManager = tManager;
            userManager = uManager;
            cboCountryDeparting.ItemsSource = Enum.GetNames(typeof(Countries));
            cboTripChoice.ItemsSource = Enum.GetNames(typeof(TripTypes));
            cboTripOrVacation.Items.Add("Vacation");
            cboTripOrVacation.Items.Add("Trip");
        }

        public AddTravelWindow(Travel t)
        {
            InitializeComponent();
            travel = t;
        }

        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dStart = null;
            DateTime? dEnd = null;
            try { dStart = travelManager.ParseStringToDateTime(tbxDateStartInput.ToString()); }
            catch (FormatException) { MessageBox.Show("Start Date was not in the correct format. Please enter the information again with the format YYYY/MM/DD"); }
            try { dEnd = travelManager.ParseStringToDateTime(tbxDateEndInput.ToString()); }
            catch (FormatException) { MessageBox.Show("Start Date was not in the correct format. Please enter the information again with the format YYYY/MM/DD"); }

            if (isTravelTrip)
            {
                travelManager.CreateTrip(tbxDestination.Text,
                TravelManager.ParseStringCountryToEnum(cboCountryDeparting.SelectedItem.ToString()),
                int.Parse(tbxTravelers.Text),
                travelManager.ParseStringTtypeToEnum(cboTripChoice.SelectedItem.ToString()),
                dStart, dEnd);
                MessageBox.Show("Trip Plan successfully Created!");
                this.Close();
                HomeWindow home = new(userManager, travelManager);
            }
            else if (isTravelVacation)
            {
                bool isAllInclusive = false;

                if (cbxAllInclusive.IsChecked == true)
                {
                    isAllInclusive = true;
                }
                travelManager.CreateVacation
                    (tbxDestination.Text,
                    TravelManager.ParseStringCountryToEnum(cboCountryDeparting.SelectedItem.ToString()),
                    int.Parse(tbxTravelers.Text),
                    isAllInclusive,
                    dStart, dEnd);
                MessageBox.Show("Vacation Plan successfully Created!");
                this.Close();
                HomeWindow home = new(userManager, travelManager);
            }
            else
            {
                MessageBox.Show("Invalid Input. You have to pick Trip/Vacation");
            }
        }

        private void cboTripOrVacation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cboTripOrVacation.SelectedItem.ToString())
            {
                case "Vacation":
                    cboTripChoice.Visibility = Visibility.Hidden;
                    cbxAllInclusive.Visibility = Visibility.Visible;
                    isTravelVacation = true;
                    isTravelTrip = false;
                    break;

                case "Trip":
                    cboTripChoice.Visibility = Visibility.Visible;
                    cbxAllInclusive.Visibility = Visibility.Hidden;
                    isTravelVacation = false;
                    isTravelTrip = true;
                    break;
            }
        }

        private void cboCountryDeparting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (travelManager.CheckIfPassportIsNeeded(TravelManager.ParseStringCountryToEnum(cboCountryDeparting.SelectedItem.ToString())) && hasPackPass != true)
            {
                pass = travelManager.CreateTravelDocumentForList("Passport", true);
                lvPack.Items.Add(pass.Name);
                hasPackPass = true;
            }
            else
            {
                if (hasPackPass)
                {
                    lvPack.Items.Clear(); // tar även bort allt annt så dont do this. testar bara
                    lvPack.Items.Remove(pass);
                    hasPackPass = false;
                }
            }
        }

        private void btnPackAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}