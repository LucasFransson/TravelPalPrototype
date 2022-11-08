using System;
using System.Text;
using System.Windows;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private TravelManager travelManager;
        private Travel travel;

        public TravelDetailsWindow(TravelManager tManager, Travel t)
        {
            InitializeComponent();
            travel = t;
            lvTravelSelected.Items.Add(travel.GetDisplayInfo());

            string travelInformation = travel.GetInfo();
            StringBuilder sb = new StringBuilder(travelInformation);
            tbxTravelInfo.Clear();

            //sb.Prepend(Environment.NewLine);
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine($"Destination: {travel.Destination}");
            if (travel is Trip trip)
            {
                sb.AppendLine("Trip");
                sb.AppendLine($"Type: {trip.Type}");
            }
            else if (travel is Vacation vacation)
            {
                sb.AppendLine("Vacation");
                sb.AppendLine($"All Inclusive: {vacation.IsAllInClusive}");
            }

            sb.AppendLine($"Destination Country: {travel.Country}");
            sb.AppendLine($"Number Of Travellers: {travel.NumberOfTravellers}");
            sb.AppendLine($"StartDate: {travel.StartDate}");
            sb.AppendLine($"EndDate: {travel.EndDate}");
            sb.AppendLine($"Duration: {travel.TravelDuration} days");

            tbxTravelInfo.Text = sb.ToString();


            foreach(var item in t.PackingList)
            {
                lvTravelPackList.Items.Add(item.GetInfo());
            }
            //lvTravelPackList.ItemsSource = t.PackingList;
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            travelManager.RemoveTravel(travel);
            MessageBox.Show("Travel Plan succesfully removed!");
            this.Close();
        }

        private void btnChangeTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(travel);
            addTravelWindow.Show();
            this.Close();
        }

        private void btnEditTravel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}