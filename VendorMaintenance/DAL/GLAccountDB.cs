using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendorMaintenance.DAL;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to connect to the GL Account DAL
    /// </summary>
    public class GLAccountDB
    {
        #region Methods

        /// <summary>
        /// method used to get accounts in list
        /// </summary>
        /// <returns>list of accounts</returns>
        public List<GLAccount> GetGLAccountList()
        {
            List<GLAccount> accountList = new List<GLAccount>();
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string selectStatement =
                "SELECT AccountNo, Description " +
                "FROM GLAccounts " +
                "ORDER BY Description";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    GLAccount account = new GLAccount
                    {
                        AccountNo = (int)reader["AccountNo"],
                        Description = reader["Description"].ToString()
                    };
                    accountList.Add(account);
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
            return accountList;
        }

        #endregion
    }
}
