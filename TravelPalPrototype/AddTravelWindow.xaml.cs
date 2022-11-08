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

            travelManager = tManager;
            userManager = uManager;
            cboCountryDestination.ItemsSource = Enum.GetNames(typeof(Countries));
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
                    TravelManager.ParseStringCountryToEnum(cboCountryDestination.SelectedItem.ToString()),
                    StaticMethods.TryParse(tbxTravelers.Text),
                    travelManager.ParseStringTtypeToEnum(cboTripChoice.SelectedItem.ToString()),
                    dtpStart.SelectedDate, dtpEnd.SelectedDate);

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
                        dtpStart.SelectedDate, dtpEnd.SelectedDate);

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

            //ListViewItem item = lvPack.SelectedItem as ListViewItem;
            //if (item != null)
            //{
            //    if (item.Tag ==)
            //}

            //IPackingListItem item = lvPack.SelectedItem.tag as IPackingListItem;
            //currentPackingList.Remove(item);

            //ListViewItem item = lvPack.SelectedItem. as ListViewItem;
            //IPackingListItem ip = (IPackingListItem)item.Tag.GetType();
            //ip
   
            string listViewInfo = lvPack.SelectedItem.ToString();
            IPackingListItem itemToRemove = currentPackingList.Find(i=>i.GetInfo()==listViewInfo);
            currentPackingList.Remove(itemToRemove);
            lvPack.Items.Remove(lvPack.SelectedItem);
            travelManager.UpdatePackingListView(lvPack,currentPackingList);



            //ListView listView = sender as ListView;
            //Driver selectedDriver = listView.SelectedItem;
            //ListViewItem item = (ListViewItem)
            //    listView.ItemContainerGenerator.ContainerFromItem(selectedDriver);


            //IPackingListItem selectedItem;
            //ListViewItem selectedItem = (ListViewItem)lvPack.SelectedItems;
            //// = (IPackingListItem)lvPack.SelectedItem;

            //if (selectedItem != null)
            //{   
            //    //ListViewItem lvi = selectedItem as ListViewItem;
            //    IPackingListItem listViewInfo = selectedItem.Tag as IPackingListItem;
            //    currentPackingList.Remove(listViewInfo);

            //    //if(selectedItem is TravelDocument td)
            //    //{
            //    //    TravelDocument listViewInfo = td.Tag as TravelDocument;
            //    //    currentPackingList.Remove(listViewInfo);
            //    //}


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