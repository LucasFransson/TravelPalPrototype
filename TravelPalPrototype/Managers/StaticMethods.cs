using System;
using System.Collections.Generic;
using System.Windows.Controls;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public static class StaticMethods
    {
        public static IUser SignedInUser { get; set; }

        public static int GenerateGUID()
        {
            return Guid.NewGuid().GetHashCode();
        }

        public static int TryParse(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);
            if (!isNumber)
            {
                return 1; // If no traveller is added set the default traveller to 1
            }
            else return number;
        }

        public static List<Travel> FindAllTravelsByUserID(TravelManager travelManager,int userID)
        {
            return travelManager.travels.FindAll(t => t.TravelID == userID);
        }

        public static void CreateListViewPackingItem(ListView listView, IPackingListItem packItem)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = packItem;
            if (packItem is TravelDocument td)
            {
                listView.Items.Add(td.GetInfo());

                return;
            }
            else if(packItem is OtherItem oi)
            {
                listView.Items.Add(oi.GetInfo());
            }
        }

        public static void CreateAddListViewPackingItem(List<IPackingListItem> packList,ListView listView, IPackingListItem packItem)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = packItem;
            if (packItem is TravelDocument td)
            {
                item.Content = td.GetInfo();
                listView.Items.Add(td.GetInfo());
                packList.Add(td);
            }
            else if (packItem is OtherItem oi)
            {
                item.Content=oi.GetInfo();
                listView.Items.Add(oi.GetInfo());
                packList.Add(oi);
            }
        }

        public static void CreatePassportPackListItem(ListView listView, ListViewItem lvItem, IPackingListItem packItem)
        {
            lvItem.Tag = packItem;
            if (packItem is TravelDocument td)
            {
                listView.Items.Add(td.GetInfo());
                return;
            }
            listView.Items.Add(packItem.GetInfo());
        }
    }
}