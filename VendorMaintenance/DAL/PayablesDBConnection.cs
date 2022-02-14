using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VendorMaintenance.DAL
{
    /// <summary>
    /// class for DB connection to Payables
    /// </summary>
    public static class PayablesDBConnection
    {
        #region Methods

        /// <summary>
        /// method used to connect to the database
        /// </summary>
        /// <returns>connection to database</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source=localhost;Initial Catalog=Payables;" +
                "Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        #endregion
    }
}
