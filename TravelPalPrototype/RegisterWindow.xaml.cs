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
using TravelPalPrototype.Enums;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UserManager userManager;
        public RegisterWindow(UserManager uManager)
        {
            InitializeComponent();

            userManager = uManager;

            var enumList = Enum.GetValues(typeof(Countries));
            foreach (var e in enumList)
            {
                cboCountries.Items.Add(e);
            }
        }

        bool hasFirstNameBeenClicked = false;
        bool hasLastNameBeenClicked = false;
        bool hasUserNameBeenClicked = false;
        bool hasPasswordOneBeenClicked = false;
        bool hasPasswordTwoBeenClicked = false;

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            userManager.CreateNewUser( tbxFirstName.Text, tbxLastName.Text, tbxUserName.Text, tbxPasswordTwo.Text, (Countries)cboCountries.SelectedItem);
            this.Close();
        }

        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasFirstNameBeenClicked)
            {
                TextBox tbxFirstName = sender as TextBox;
                tbxFirstName.Text = String.Empty;
                hasFirstNameBeenClicked = true;
            }
        }

        private void tbxFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxFirstName.Text == "")
            {
                tbxFirstName.Text = "First Name";
                hasFirstNameBeenClicked = false;
            }
        }

        private void tbxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasLastNameBeenClicked)
            {
                TextBox tbxLastName = sender as TextBox;
                tbxLastName.Text = String.Empty;
                hasLastNameBeenClicked = true;
            }
        }

        private void tbxLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxLastName.Text == "")
            {
                tbxLastName.Text = "Last Name";
                hasLastNameBeenClicked = false;
            }
        }

        private void cboCountries_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void cboCountries_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void tbxUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasUserNameBeenClicked)
            {
                TextBox tbxUserName = sender as TextBox;
                tbxUserName.Text = String.Empty;
                hasUserNameBeenClicked = true;
            }
        }

        private void tbxUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUserName.Text == "")
            {
                tbxUserName.Text = "New User Name";
                hasUserNameBeenClicked = false;
            }
        }

        private void tbxPasswordOne_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasPasswordOneBeenClicked)
            {
                TextBox tbxPasswordOne = sender as TextBox;
                tbxPasswordOne.Text = String.Empty;
                hasPasswordOneBeenClicked = true;
            }
        }

        private void tbxPasswordOne_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPasswordOne.Text == "")
            {
                tbxPasswordOne.Text = "New Password";
                hasPasswordOneBeenClicked = false;
            }
        }

        private void tbxPasswordTwo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasPasswordTwoBeenClicked)
            {
                TextBox tbxPasswordTwo = sender as TextBox;
                tbxPasswordTwo.Text = String.Empty;
                hasPasswordTwoBeenClicked = true;
            }
        }

        private void tbxPasswordTwo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPasswordTwo.Text == "")
            {
                tbxPasswordTwo.Text = "Re-type New Password";
                hasPasswordTwoBeenClicked = false;
            }
        }
    }
}
