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
        private UserManager userManager;  // Creating the Usermanager object

        public RegisterWindow(UserManager uManager)
        {
            userManager = uManager;
            InitializeComponent();

            cboCountries.ItemsSource = Enum.GetNames(typeof(Countries));
        }

        // bools for watermark feature in textboxes

        private bool hasFirstNameBeenClicked = false;
        private bool hasLastNameBeenClicked = false;
        private bool hasUserNameBeenClicked = false;
        private bool hasPasswordOneBeenClicked = false;
        private bool hasPasswordTwoBeenClicked = false;

        // Logic for User registration

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            if (userManager.CheckUsernameRequirements(tbxUserName.Text)==true)
            {
                if(userManager.CheckPasswordRequirements(tbxPasswordTwo.Text)==true)
                {
                    if(userManager.ValidateUserName(tbxUserName.Text))
                    {
                        userManager.CreateNewUser(
                                    tbxFirstName.Text,
                                    tbxLastName.Text,
                                    tbxUserName.Text,
                                    tbxPasswordTwo.Text,

                                    (Countries)cboCountries.SelectedItem);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("An User with that Username is already registered. Please choose another name.");
                    }
                }
                else
                {
                    MessageBox.Show("Your password does not meet the requirement. Please choose a password that is atleast 5 characters long.");
                }
            }
            else
            {
                MessageBox.Show("Your Username does not meet the requirements. Please choose a Username that is atleast 3 characters long.");
            }


        }

        // Logic that replicates watermark feature in textboxes

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