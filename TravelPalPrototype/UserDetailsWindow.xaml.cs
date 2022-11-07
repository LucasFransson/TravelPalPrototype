using System;
using System.Windows;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        private User user;

        public UserDetailsWindow(UserManager uManger)
        {
            InitializeComponent();
            if (userManager.SignedInUser is User u)
            {
                user = u;
            }

            tbxFirstName.Text = userManager.SignedInUser.FirstName;
            tbxLastName.Text = userManager.SignedInUser.LastName;
            tbxUsername.Text = userManager.SignedInUser.Username;
            tbxLocation.Text = userManager.SignedInUser.Location.ToString();
            tbxFirstName.Text = userManager.SignedInUser.FirstName;

            cboLocation.ItemsSource = Enum.GetNames(typeof(EUCountries));
        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            lblChangeInfo.Content = "Change Username";
            lblChangeInfo.Visibility = Visibility.Visible;
            ToggleInputElementsOn();
        }

        private void btnChangeFirstName_Click(object sender, RoutedEventArgs e)
        {
            lblChangeInfo.Content = "Change First Name";
            ToggleInputElementsOn();
        }

        private void btnChangeLastName_Click(object sender, RoutedEventArgs e)
        {
            lblChangeInfo.Content = "Change Last Name";
            ToggleInputElementsOn();
        }

        private void btnChangeLocation_Click(object sender, RoutedEventArgs e)
        {
            lblChangeInfo.Content = "Change Location";
            ToggleInputElementsComboboxOn();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            lblChangeInfo.Content = "Change Password";
            ToggleInputElementsOn();
        }

        private void btnSetNewInfo_Click(object sender, RoutedEventArgs e)
        {
            switch (lblChangeInfo.Content)
            {
                case "Change Username":
                    {
                        if (userManager.ValidateUserName(tbxNewInfoOne.Text) && (userManager.CheckUsernameRequirements(tbxNewInfoOne.Text)))
                        {
                            UserManager.ChangeUsername(user, tbxNewInfoOne.Text);
                            MessageBox.Show("Username Successfully Changed!");
                            ToggleInputElementsOff();
                            break;
                        }
                        MessageBox.Show("An User with that username already exists!");
                        break;
                    }
                case "Change First Name":
                    {
                        UserManager.ChangeFirstName(user, tbxNewInfoOne.Text);
                        MessageBox.Show("First Name Successfully Changed!");
                        ToggleInputElementsOff();
                        break;
                    }
                case "Change Last Name":
                    {
                        UserManager.ChangeLastName(user, tbxNewInfoOne.Text);
                        MessageBox.Show("Last Name Successfully Changed!");
                        ToggleInputElementsOff();
                        break;
                    }
                case "Change Location":
                    {
                        UserManager.ChangeLocation(user, cboLocation.SelectedItem.ToString());
                        MessageBox.Show("Location Successfully Changed!");
                        ToggleInputElementsComboboxOff();
                        break;
                    }
                case "Change Password":
                    {
                        if (userManager.CheckPasswordRequirements(tbxNewInfoOne.Text))
                        {
                            UserManager.ChangePassword(user, tbxNewInfoOne.Text);
                            MessageBox.Show("Password Successfully Changed!");
                            ToggleInputElementsOff();

                            break;
                        }
                        else
                        {
                            MessageBox.Show("Password does not meet the requirements. Password needs to be atleast 5 characters long.");
                            break;
                        }
                    }
                default:
                    {
                        
                        MessageBox.Show("Invalid Input");
                        ToggleInputElementsOff();
                        break;
                    }
            }
        }

        public void ToggleInputElementsComboboxOff()
        {
            tbxNewInfoOne.Visibility = Visibility.Hidden;
            tbxNewInfoTwo.Visibility = Visibility.Hidden;
            btnSetNewInfo.Visibility = Visibility.Hidden;
        }

        public void ToggleInputElementsComboboxOn()
        {
            tbxNewInfoOne.Visibility = Visibility.Visible;
            tbxNewInfoTwo.Visibility = Visibility.Visible;
            btnSetNewInfo.Visibility = Visibility.Visible;
        }

        public void ToggleInputElementsOff()
        {
            tbxNewInfoOne.Visibility = Visibility.Hidden;
            tbxNewInfoTwo.Visibility = Visibility.Hidden;
            btnSetNewInfo.Visibility = Visibility.Hidden;
        }

        public void ToggleInputElementsOn()
        {
            tbxNewInfoOne.Visibility = Visibility.Visible;
            tbxNewInfoTwo.Visibility = Visibility.Visible;
            btnSetNewInfo.Visibility = Visibility.Visible;
        }
    }
}