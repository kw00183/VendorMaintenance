using System;
using System.Collections.Generic;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to create the state object
    /// </summary>
    public class State
    {
        #region Data Members

        private string stateCode;
        private string stateName;
        private int firstZipCode;
        private int lastZipCode;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor
        /// </summary>
        public State() { }

        #endregion

        #region Methods

        /// <summary>
        /// getter/setter for state code
        /// </summary>
        public string StateCode
        {
            get
            {
                return stateCode;
            }
            set
            {
                stateCode = value;
            }
        }

        /// <summary>
        /// getter/setter for state name
        /// </summary>
        public string StateName
        {
            get
            {
                return stateName;
            }
            set
            {
                stateName = value;
            }
        }

        /// <summary>
        /// getter/setter for first zip code
        /// </summary>
        public int FirstZipCode
        {
            get
            {
                return firstZipCode;
            }
            set
            {
                firstZipCode = value;
            }
        }

        /// <summary>
        /// getter/setter for last zip code
        /// </summary>
        public int LastZipCode
        {
            get
            {
                return lastZipCode;
            }
            set
            {
                lastZipCode = value;
            }
        }

        #endregion
    }
}
