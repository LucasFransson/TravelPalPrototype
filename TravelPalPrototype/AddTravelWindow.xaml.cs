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
        public ListViewItem passport = new();
        public List<IPackingListItem> currentPackingList = new();
        private bool hasPackPass = false;
        private TravelDocument pass;
        public Travel travel;
        private TravelManager travelManager;
        private UserManager userManager;
        private bool isTravelTrip = false;
        private bool isTravelVacation = false;

        // Constructor for opening of Add travel window from home
        public AddTravelWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dtpEnd.BlackoutDates.AddDatesInPast();
            dtpStart.BlackoutDates.AddDatesInPast();
            travelManager = tManager;
            userManager = uManager;
            cboCountryDestination.ItemsSource = Enum.GetNames(typeof(Countries));
            cboTripChoice.ItemsSource = Enum.GetNames(typeof(TripTypes));
            cboTripOrVacation.Items.Add("Vacation");
            cboTripOrVacation.Items.Add("Trip");
        }

        // Constructor for opening edit travel
        public AddTravelWindow(TravelManager tManager,Travel t)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dtpEnd.BlackoutDates.AddDatesInPast();
            dtpStart.BlackoutDates.AddDatesInPast();
            travelManager = tManager;
            travel = t;
            cboCountryDestination.ItemsSource = Enum.GetNames(typeof(Countries));
            cboTripChoice.ItemsSource = Enum.GetNames(typeof(TripTypes));
            cboTripOrVacation.Items.Add("Vacation");
            cboTripOrVacation.Items.Add("Trip");

            tbxDestination.Text = travel.Destination;
            cboCountryDestination.SelectedItem = travel.Country;
            tbxTravelers.Text = travel.NumberOfTravellers.ToString();
            dtpStart.Text = travel.StartDate.ToString();
            dtpEnd.Text = travel.EndDate.ToString();

            if (travel is Vacation vacation)
            {
                cboTripOrVacation.Text = "Vacation";
                cbxAllInclusive.Visibility = Visibility.Hidden;
                cbxAllInclusive.Content = vacation.IsAllInClusive;
            }
            else if (travel is Trip trip)
            {
                cboTripOrVacation.Text = "Trip";
                cboTripChoice.Visibility = Visibility.Visible;
                cboTripChoice.SelectedItem = trip.Type;
            }
        }

        // Logic for saving travels
        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {

            if (dtpStart.SelectedDate == null || dtpEnd.SelectedDate == null || tbxDestination.Text==null || cboCountryDestination.SelectedItem==null)
            {
                MessageBox.Show("One or more input fields were empty. Please try again and make sure all the required information is correctly filled in.");
            }
            else
            {
                if (isTravelTrip)
                {
                    travelManager.CreateTrip(tbxDestination.Text,
                    TravelManager.ParseStringCountryToEnum(cboCountryDestination.SelectedItem.ToString()),
                    StaticMethods.TryParse(tbxTravelers.Text),
                    travelManager.ParseStringTtypeToEnum(cboTripChoice.SelectedItem.ToString()),
                    dtpStart.SelectedDate, dtpEnd.SelectedDate, currentPackingList);

                    MessageBox.Show("Trip Plan successfully Created!");

                    HomeWindow home = new(userManager, travelManager);
                    home.Show();
                    this.Close();
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
                        TravelManager.ParseStringCountryToEnum(cboCountryDestination.SelectedItem.ToString()),
                        StaticMethods.TryParse(tbxTravelers.Text),
                        isAllInclusive,
                        dtpStart.SelectedDate, dtpEnd.SelectedDate, currentPackingList);

                    MessageBox.Show("Vacation Plan successfully Created!");

                    HomeWindow home = new(userManager, travelManager);
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Input. You have to pick Trip/Vacation");
                }
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
            if (travelManager.CheckIfPassportIsNeeded(TravelManager.ParseStringCountryToEnum(cboCountryDestination.SelectedItem.ToString())) && hasPackPass != true)
            {
                pass = travelManager.CreateTravelDocumentForList("Passport", true);
                StaticMethods.CreatePassportPackListItem(lvPack, passport, pass);
                currentPackingList.Add(pass);
                hasPackPass = true;
            }
            else
            {
                if (hasPackPass)
                {
                    lvPack.Items.Remove(pass);
                    currentPackingList.Remove(pass);
                    travelManager.UpdatePackingListView(lvPack, currentPackingList);
                    hasPackPass = false;
                }
            }
        }

        private void btnPackAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbxIsDocument.IsChecked == true)
            {
                TravelDocument td = travelManager.CreateTravelDocumentForList(tbxPackInput.Text, (bool)cbxIsItemRequired.IsChecked);
                StaticMethods.CreateAddListViewPackingItem(currentPackingList, lvPack, td);
                
            }
            else if (cbxIsDocument.IsChecked == false)
            {
                OtherItem oi = travelManager.CreateOtherItem(tbxPackInput.Text, StaticMethods.TryParse(tbxQtyInput.Text));
                StaticMethods.CreateAddListViewPackingItem(currentPackingList, lvPack, oi);
            }
        }

        private void cbxIsDocument_Click(object sender, RoutedEventArgs e)
        {
            if (cbxIsDocument.IsChecked == true)
            {
                cbxIsItemRequired.Visibility = Visibility.Visible;
                tbxQtyInput.Visibility = Visibility.Hidden;
            }
            else
            {
                cbxIsItemRequired.Visibility = Visibility.Hidden;
                tbxQtyInput.Visibility = Visibility.Visible;
            }
        }

        private void btnRemovePack_Click(object sender, RoutedEventArgs e)
        {

            string? listViewInfo = lvPack.SelectedItem.ToString();
            if (listViewInfo != null)
            {
                IPackingListItem itemToRemove = currentPackingList.Find(i => i.GetInfo() == listViewInfo);
                currentPackingList.Remove(itemToRemove);
                lvPack.Items.Remove(lvPack.SelectedItem);
                travelManager.UpdatePackingListView(lvPack, currentPackingList);
            }
            else
            {
                MessageBox.Show("You must select an item to remove.");
            }

        }
            
        private void lvPack_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                //here is your ProblemsListItem item           
                var actualItem = (IPackingListItem)item.Content;
                currentPackingList.Remove(actualItem);
                travelManager.UpdatePackingListView(lvPack, currentPackingList);
            }
        }
    
    }
}