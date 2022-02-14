using System;
using System.Collections.Generic;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to create vendor object
    /// </summary>
    public class Vendor
    {
        #region Data Members

        private int vendorID;
        private string name;
        private string address1;
        private string address2;
        private string city;
        private string state;
        private string zipCode;
        private string phone;
        private string contactLName;
        private string contactFName;
        private int defaultTermsID;
        private int defaultAccountNo;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor
        /// </summary>
        public Vendor() { }

        #endregion

        #region Methods

        /// <summary>
        /// getter/setter for vendorID
        /// </summary>
        public int VendorID
        {
            get
            {
                return vendorID;
            }
            set
            {
                vendorID = value;
            }
        }

        /// <summary>
        /// getter/setter for name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// getter/setter for address1
        /// </summary>
        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }

        /// <summary>
        /// getter/setter for address2
        /// </summary>
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }

        /// <summary>
        /// getter/setter for city
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        /// <summary>
        /// getter/setter for state
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        /// <summary>
        /// getter/setter for zip code
        /// </summary>
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
            }
        }

        /// <summary>
        /// getter/setter for phone
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        /// <summary>
        /// getter/setter for contact list
        /// </summary>
        public string ContactLName
        {
            get
            {
                return contactLName;
            }
            set
            {
                contactLName = value;
            }
        }

        /// <summary>
        /// getter/setter for contact first name
        /// </summary>
        public string ContactFName
        {
            get
            {
                return contactFName;
            }
            set
            {
                contactFName = value;
            }
        }

        /// <summary>
        /// getter/setter for default termsID
        /// </summary>
        public int DefaultTermsID
        {
            get
            {
                return defaultTermsID;
            }
            set
            {
                defaultTermsID = value;
            }
        }

        /// <summary>
        /// getter/setter for default account number
        /// </summary>
        public int DefaultAccountNo
        {
            get
            {
                return defaultAccountNo;
            }
            set
            {
                defaultAccountNo = value;
            }
        }

        #endregion
    }
}
