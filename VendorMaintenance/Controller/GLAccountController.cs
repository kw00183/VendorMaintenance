using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendorMaintenance.Controller
{
    public class GLAccountController
    {
        #region Data Members

        private readonly GLAccountDB accountDBSource;

        #endregion

        #region Constructors

        /// <summary>
        /// create a GLAccountController object
        /// </summary>
        public GLAccountController()
        {
            accountDBSource = new GLAccountDB();
        }

        #endregion

        #region Methods

        /// <summary>
        /// method used to get/return iist of account objects
        /// </summary>
        /// <returns>a list of account objects</returns>
        public List<GLAccount> GetGLAccountList()
        {
            return accountDBSource.GetGLAccountList();
        }

        #endregion
    }
}
