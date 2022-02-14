using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendorMaintenance.DAL;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to connect to Terms DAL
    /// </summary>
    public static class TermsDB
    {
        #region Methods

        /// <summary>
        /// method used to build terms object list
        /// </summary>
        /// <returns>list of terms objects</returns>
        public static List<Terms> GetTermsList()
        {
            List<Terms> termsList = new List<Terms>();
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string selectStatement =
                "SELECT TermsID, Description, DueDays " +
                "FROM Terms " +
                "ORDER BY Description";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Terms term = new Terms
                    {
                        TermsID = (int)reader["TermsID"],
                        Description = reader["Description"].ToString(),
                        // Couldn't unbox with (int); don't know why
                        DueDays = Convert.ToInt32(reader["DueDays"])
                    };
                    termsList.Add(term);
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
            return termsList;
        }

        #endregion
    }
}
