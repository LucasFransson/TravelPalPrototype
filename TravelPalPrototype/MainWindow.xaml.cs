using System;
using System.Windows;
using System.Windows.Controls;
using TravelPalPrototype.Managers;
using TravelPalPrototype.Models;

namespace TravelPalPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new();

        public MainWindow()
        {
            InitializeComponent();
            userManager.PopulateTestUsers();
        }

        private bool hasUsernameBeenClicked;

        // Log in Logic

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            bool logInChecker = userManager.CheckLogin(tbxUserName.Text, pbxPassword.Password.ToString());
            if (logInChecker == true)
            {
                userManager.SignedInUser = userManager.FindIUserByUsername(tbxUserName.Text);
                if (userManager.SignedInUser is User user)
                {
                    HomeWindow homeWindow = new(userManager);
                    homeWindow.Show();
                    this.Close();
                }
                else if(userManager.SignedInUser is Admin admin)
                {
                    AdminHomeWindow adminHomeWindow = new(userManager);
                    adminHomeWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Input of Username or Password");
            }
        }

        // Open up Register Window

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWindow = new(userManager);
            regWindow.Show();
        }

        // Logic that replicates watermark feature in textboxes

        private void tbxUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasUsernameBeenClicked)
            {
                TextBox tbxUserName = sender as TextBox;
                tbxUserName.Text = String.Empty;
                hasUsernameBeenClicked = true;
            }
        }

        private void tbxUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUserName.Text == "")
            {
                tbxUserName.Text = "Enter Username";
                hasUsernameBeenClicked = false;
            }
        }

        private void pbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            tbxPasswordFacade.Visibility = Visibility.Hidden;  // Sets the facadetextbox overlapping the pbx to hidden visibility
        }

        private void tbxPasswordFacade_GotFocus(object sender, RoutedEventArgs e)
        {
            pbxPassword.Focus(); // if the user clicks on the facadetextbox this method sets the focus to the pbx behind the tbx
            tbxPasswordFacade.Visibility = Visibility.Hidden;
        }

        private void tbxPasswordFacade_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}