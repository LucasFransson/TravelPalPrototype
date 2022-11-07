using System;
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
                return 0;
            }
            else return number;
        }
        //public static void CreatePassportPackListItem(ListView listView, IPackingListItem packItem)
        //{
        //    ListViewItem item = new ListViewItem();
        //    item.Tag = packItem;
        //    if (packItem is TravelDocument td)
        //    {
        //        listView.Items.Add(td.GetBooleanInfo(td.IsRequired));
        //        return;
        //    }
        //    listView.Items.Add(packItem.GetInfo());
        //}
        public static void CreatePassportPackListItem(ListView listView,ListViewItem lvItem, IPackingListItem packItem)
        {
            
            lvItem.Tag = packItem;
            if (packItem is TravelDocument td)
            {
                listView.Items.Add(td.GetBooleanInfo(td.IsRequired));
                return;
            }
            listView.Items.Add(packItem.GetInfo());
        }
    }
}