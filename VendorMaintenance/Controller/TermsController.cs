using System;
using System.Collections.Generic;
using VendorMaintenance.DAL;

namespace VendorMaintenance.Controller
{
    public class TermsController
    {
        #region Data Members

        private readonly TermsDB termsDBSource;

        #endregion

        #region Constructors

        /// <summary>
        /// create a TermsController object
        /// </summary>
        public TermsController()
        {
            termsDBSource = new TermsDB();
        }

        #endregion

        #region Methods

        /// <summary>
        /// method used to get/return iist of term objects
        /// </summary>
        /// <returns>a list of term objects</returns>
        public List<Terms> GetTermsList()
        {
            return termsDBSource.GetTermsList();
        }

        #endregion
    }
}
