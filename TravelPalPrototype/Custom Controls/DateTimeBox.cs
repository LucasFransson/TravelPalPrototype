using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TravelPalPrototype.Custom_Controls
{
    public class DateTimeBox : TextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            this.MaxLength = 8;  // Sets the max length of this textbox to 8 chars (YYYY/MM/DD)
        }

        // Runs the Logic for checking characters before accepting the char into the textbox
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);

            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }

        // Logic that Checks if the input characters are only digits
        private bool AreAllValidNumericChars(string str)
        {
            bool ret = true;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }
            return ret;
        }
    }
}