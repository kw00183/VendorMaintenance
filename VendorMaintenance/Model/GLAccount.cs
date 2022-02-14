using System;
using System.Collections.Generic;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to create GLAaccount object
    /// </summary>
    public class GLAccount
    {
        #region Data Members

        private int accountNo;
        private string description;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor
        /// </summary>
        public GLAccount() { }

        #endregion

        #region Methods

        /// <summary>
        /// getter/setter for account number
        /// </summary>
        public int AccountNo
        {
            get
            {
                return accountNo;
            }
            set
            {
                accountNo = value;
            }
        }
        
        /// <summary>
        /// getter/setter for description
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        #endregion
    }
}
