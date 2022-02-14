using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendorMaintenance.DAL;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to connect to state DAL
    /// </summary>
    public static class StateDB
    {
        #region Methods

        /// <summary>
        /// method used to generate list of state objects
        /// </summary>
        /// <returns>list of states</returns>
        public static List<State> GetStateList()
        {
            List<State> stateList = new List<State>();
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string selectStatement =
                "SELECT StateCode, StateName, FirstZipCode, LastZipCode " +
                "FROM States " +
                "ORDER BY StateName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    State state = new State
                    {
                        StateCode = reader["StateCode"].ToString(),
                        StateName = reader["StateName"].ToString(),
                        FirstZipCode = (int)reader["FirstZipCode"],
                        LastZipCode = (int)reader["LastZipCode"]
                    };
                    stateList.Add(state);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return stateList;
        }

        #endregion
    }
}
