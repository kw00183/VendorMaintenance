using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to validate fields
    /// </summary>
    public class Validator
    {
        #region Data Members

        private static string title = "Entry Error";

        #endregion

        #region Methods

        /// <summary>
        /// getter/setter for title
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// method used to validate required fields have values
        /// </summary>
        /// <param name="control">control</param>
        /// <returns>returns boolean if field has value</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag.ToString() + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// method used to validate if field contains decimal
        /// </summary>
        /// <param name="textBox">texbox</param>
        /// <returns>returns boolean if field has decimal</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// method used to check if field contains integer
        /// </summary>
        /// <param name="textBox">textbox</param>
        /// <returns>returns boolean if field has integer</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// method used to validate state and zip
        /// </summary>
        /// <param name="textBox">textbox</param>
        /// <param name="firstZip">first zip</param>
        /// <param name="lastZip">last zip</param>
        /// <returns>returns boolean if field has zip code in range of first and last zip</returns>
        public static bool IsStateZipCode(TextBox textBox,
            int firstZip, int lastZip)
        {
            int zipCode = Convert.ToInt32(textBox.Text);
            if (zipCode <= firstZip || zipCode >= lastZip)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be within this range: " +
                    firstZip + " to " + lastZip + ".", Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// method used to validate the phone number
        /// </summary>
        /// <param name="textBox">textbox</param>
        /// <returns>returns boolean if field has phone in the right format</returns>
        public static bool IsPhoneNumber(TextBox textBox)
        {
            string phoneChars = textBox.Text.Replace(".", "");
            try
            {
                Convert.ToInt64(phoneChars);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be in this format: " +
                    "999.999.9999.", Title);
                textBox.Focus();
                return false;
            }
        }

        #endregion
    }
}
