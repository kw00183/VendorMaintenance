using System;
using System.Collections.Generic;

namespace VendorMaintenance.Controller
{
    public class VendorController
    {
        #region Data Members

        private readonly VendorDB vendorDBSource;

        #endregion

        #region Constructors

        /// <summary>
        /// create a VendorController object
        /// </summary>
        public VendorController()
        {
            this.vendorDBSource = new VendorDB();
        }

        #endregion

        #region Methods

        /// <summary>
        /// method used to get/return the vendors
        /// </summary>
        /// <returns>a list of all the customer ids and names</returns>
        public Vendor GetVendor(int vendorID)
        {
            return this.vendorDBSource.GetVendor(vendorID);
        }

        /// <summary>
        /// method used to delete the vendors
        /// </summary>
        public bool DeleteVendor(Vendor vendor)
        {
            return this.vendorDBSource.DeleteVendor(vendor);
        }

        /// <summary>
        /// method used to add the vendors
        /// </summary>
        public int AddVendor(Vendor vendor)
        {
            return this.vendorDBSource.AddVendor(vendor);
        }

        /// <summary>
        /// method used to update the vendors
        /// </summary>
        public bool UpdateVendor(Vendor vendor, Vendor newVendor)
        {
            return this.vendorDBSource.UpdateVendor(vendor, newVendor);
        }

        #endregion
    }
}
