using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendorMaintenance.Controller
{
    public class StateController
    {
        #region Data Members

        private readonly StateDB stateDBSource;

        #endregion

        #region Constructors

        /// <summary>
        /// create a StateController object
        /// </summary>
        public StateController()
        {
            stateDBSource = new StateDB();
        }

        #endregion

        #region Methods

        /// <summary>
        /// method used to get/return iist of state objects
        /// </summary>
        /// <returns>a list of state objects</returns>
        public List<State> GetStateList()
        {
            return stateDBSource.GetStateList();
        }

        #endregion
    }
}
