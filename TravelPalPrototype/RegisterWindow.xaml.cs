using System;
using System.Windows;
using System.Windows.Controls;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Managers;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;

        public RegisterWindow(UserManager uManager)
        {
            userManager = uManager;
            InitializeComponent();

            cboCountries.ItemsSource = Enum.GetNames(typeof(Countries));
        }

        private bool hasFirstNameBeenClicked = false;
        private bool hasLastNameBeenClicked = false;
        private bool hasUserNameBeenClicked = false;
        private bool hasPasswordOneBeenClicked = false;
        private bool hasPasswordTwoBeenClicked = false;

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            userManager.CreateNewUser(
                tbxFirstName.Text,
                tbxLastName.Text,
                tbxUserName.Text,
                tbxPasswordTwo.Text,

                (Countries)cboCountries.SelectedItem);

            Close();
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