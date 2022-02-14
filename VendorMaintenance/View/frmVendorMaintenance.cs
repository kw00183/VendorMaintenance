using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PayablesData;

namespace VendorMaintenance
{
    public partial class frmVendorMaintenance : Form
    {
        public frmVendorMaintenance()
        {
            InitializeComponent();
        }

        Vendor vendor;

        private void btnGetVendor_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtVendorID) &&
                Validator.IsInt32(txtVendorID))
            {
                int vendorID = Convert.ToInt32(txtVendorID.Text);
                this.GetVendor(vendorID);
            }
        }

        private void GetVendor(int vendorID)
        {
            try
            {
                vendor = VendorDB.GetVendor(vendorID);
                if (vendor == null)
                    MessageBox.Show("No vendor found with this ID. " +
                        "Please try again.", "Vendor Not Found");
                else
                    this.DisplayVendor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayVendor()
        {
            txtName.Text = vendor.Name;
            txtAddress1.Text = vendor.Address1;
            txtAddress2.Text = vendor.Address2;
            txtCity.Text = vendor.City;
            txtState.Text = vendor.State;
            txtZipCode.Text = vendor.ZipCode;
            btnModify.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyVendor addModifyVendorForm = new frmAddModifyVendor();
            addModifyVendorForm.addVendor = true;
            DialogResult result = addModifyVendorForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                vendor = addModifyVendorForm.vendor;
                txtVendorID.Text = vendor.VendorID.ToString();
                this.DisplayVendor();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyVendor addModifyVendorForm = new frmAddModifyVendor();
            addModifyVendorForm.addVendor = false;
            addModifyVendorForm.vendor = vendor;
            DialogResult result = addModifyVendorForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                vendor = addModifyVendorForm.vendor;
                this.DisplayVendor();
            }
            else if (result == DialogResult.Retry)
            {
                this.ClearControls();
                this.GetVendor(vendor.VendorID);
            }
        }

        private void ClearControls()
        {
            txtName.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            btnModify.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
