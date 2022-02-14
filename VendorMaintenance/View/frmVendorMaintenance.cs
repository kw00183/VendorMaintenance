using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using VendorMaintenance;
using VendorMaintenance.Controller;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to create vendor maintenance form
    /// </summary>
    public partial class frmVendorMaintenance : Form
    {
        #region Data members

        private readonly VendorController vendorController;
        private Vendor vendor;

        #endregion

        #region Constructors

        public frmVendorMaintenance()
        {
            InitializeComponent();
            this.vendorController = new VendorController();
            
        }

        #endregion

        #region Methods

        private void BtnGetVendor_Click(object sender, EventArgs e)
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
                vendor = this.vendorController.GetVendor(vendorID);
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
            btnDelete.Enabled = true;
        }

        private void BtnModify_Click(object sender, EventArgs e)
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

        private void BtnAdd_Click(object sender, EventArgs e)
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

        private void ClearControls()
        {
            txtName.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + vendor.Name + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!(this.vendorController.DeleteVendor(vendor)))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that vendor.", "Database Error");
                        this.ClearControls();
                        this.GetVendor(vendor.VendorID);
                    }
                    else
                    {
                        txtVendorID.Text = "";
                        this.ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        #endregion
    }
}
