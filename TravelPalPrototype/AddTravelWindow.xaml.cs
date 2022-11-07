using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {

        private List<IPackingListItem> currentPackingList = new();
        private bool hasPackPass = false;
        private TravelDocument pass;
        private Travel travel;
        private TravelManager travelManager;
        private UserManager userManager;
        private bool isTravelTrip = false;
        private bool isTravelVacation = false;

        // Constructor for opening of Add travel window from home
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
        // Constructor for opening edit travel 
        public AddTravelWindow(Travel t)
        {
            InitializeComponent();
            travel = t;
        }

        // Logic for saving travels
        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dStart;
            DateTime? dEnd;
            try
            {
                try { dStart = dtpStart.SelectedDate; }
                catch (FormatException) { MessageBox.Show("The Start date picked was not available/correct. Please try again"); }
                try { dEnd = dtpEnd.SelectedDate; }
                catch (FormatException) { MessageBox.Show("The End Date picked was not available/correct. Please try again"); }

                if (isTravelTrip)
                {
                    travelManager.CreateTrip(tbxDestination.Text,
                    TravelManager.ParseStringCountryToEnum(cboCountryDeparting.SelectedItem.ToString()),
                    StaticMethods.TryParse(tbxTravelers.Text),
                    //int.Parse(tbxTravelers.Text),
                    travelManager.ParseStringTtypeToEnum(cboTripChoice.SelectedItem.ToString()),
                    dtpStart.SelectedDate, dtpEnd.SelectedDate);

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
                        StaticMethods.TryParse(tbxTravelers.Text),
                        isAllInclusive,
                        dtpStart.SelectedDate, dtpEnd.SelectedDate);

                    MessageBox.Show("Vacation Plan successfully Created!");
                    this.Close();
                    HomeWindow home = new(userManager, travelManager);
                }


                else
                {
                    MessageBox.Show("Invalid Input. You have to pick Trip/Vacation");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error saving your travel plan. Please try again and make sure all the fields are entered correctly.");
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
                StaticMethods.CreatePassportPackListItem(lvPack, pass);
                //lvPack.Items.Add(pass.Name);
                hasPackPass = true;
            }
            else
            {
                if (hasPackPass)
                {
                    ListViewItem pass = new ListViewItem();
                    pass = (ListViewItem)lvPack.SelectedItem;

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