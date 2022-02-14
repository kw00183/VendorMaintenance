using System;
using System.Collections.Generic;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to create terms object
    /// </summary>
    public class Terms
    {
        #region Data Members

        private int termsID;
        private string description;
        private int dueDays;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor
        /// </summary>
        public Terms() { }

        #endregion

        #region Methods

        /// <summary>
        /// getter/setter for termsID
        /// </summary>
        public int TermsID
        {
            get
            {
                return termsID;
            }
            set
            {
                termsID = value;
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

        /// <summary>
        /// getter/setter for due days
        /// </summary>
        public int DueDays
        {
            get
            {
                return dueDays;
            }
            set
            {
                dueDays = value;
            }
        }

        #endregion
    }
}
