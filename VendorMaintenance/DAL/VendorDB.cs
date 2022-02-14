using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VendorMaintenance.DAL;

namespace VendorMaintenance
{
    /// <summary>
    /// class used to connect to Vendor DAL
    /// </summary>
    public static class VendorDB
    {
        #region Methods

        /// <summary>
        /// method used to get vendor objects
        /// </summary>
        /// <param name="vendorID">vendorID</param>
        /// <returns>vendor object</returns>
        public static Vendor GetVendor(int vendorID)
        {
            Vendor vendor = new Vendor();
            SqlConnection connection = PayablesDBConnection.GetConnection();
            //string selectStatement =
            //    "SELECT VendorID, Name, Address1, Address2, City, State, " +
            //        "ZipCode, Phone, ContactFName, ContactLName, " +
            //        "DefaultAccountNo, DefaultTermsID " +
            //    "FROM Vendors " +
            //    "WHERE VendorID = @VendorID";
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = connection,
                CommandText = "spGetVendor",
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@VendorID", SqlDbType.Int);
            selectCommand.Parameters["@VendorID"].Value = vendorID;
            try
            {
                connection.Open();
                SqlDataReader reader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    vendor.VendorID = (int)reader["VendorID"];
                    vendor.Name = reader["Name"].ToString();
                    vendor.Address1 = reader["Address1"].ToString();
                    vendor.Address2 = reader["Address2"].ToString();
                    vendor.City = reader["City"].ToString();
                    vendor.State = reader["State"].ToString();
                    vendor.ZipCode = reader["ZipCode"].ToString();
                    vendor.Phone = reader["Phone"].ToString();
                    vendor.ContactLName = reader["ContactLName"].ToString();
                    vendor.ContactFName = reader["ContactFName"].ToString();
                    vendor.DefaultAccountNo = (int)reader["DefaultAccountNo"];
                    vendor.DefaultTermsID = (int)reader["DefaultTermsID"];
                }
                else
                {
                    vendor = null;
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
            return vendor;
        }

        /// <summary>
        /// method used to add vendor object
        /// </summary>
        /// <param name="vendor">vendor object</param>
        /// <returns>integer of vendorID</returns>
        public static int AddVendor(Vendor vendor)
        {
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string insertStatement =
                "INSERT Vendors " +
                  "(Name, Address1, Address2, City, State, ZipCode, Phone, " +
                  "ContactFName, ContactLName, DefaultTermsID, DefaultAccountNo) " +
                "VALUES (@Name, @Address1, @Address2, @City, @State, @ZipCode, " +
                  "@Phone, @ContactFName, @ContactLName, @DefaultTermsID, " +
                  "@DefaultAccountNo)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.Add("@Name", SqlDbType.VarChar);
            insertCommand.Parameters["@Name"].Value = vendor.Name;

            insertCommand.Parameters.Add("@Address1", SqlDbType.VarChar);
            insertCommand.Parameters["@Address1"].Value = vendor.Address1;

            if (vendor.Address2 == "")
            {
                insertCommand.Parameters.Add("@Address2", SqlDbType.VarChar);
                insertCommand.Parameters["@Address2"].Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@Address2", SqlDbType.VarChar);
                insertCommand.Parameters["@Address2"].Value = vendor.Address2;
            }

            insertCommand.Parameters.Add("@City", SqlDbType.VarChar);
            insertCommand.Parameters["@City"].Value = vendor.City;

            insertCommand.Parameters.Add("@State", SqlDbType.Char);
            insertCommand.Parameters["@State"].Value = vendor.State;

            insertCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar);
            insertCommand.Parameters["@ZipCode"].Value = vendor.ZipCode;


            if (vendor.Phone == "")
            {
                insertCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                insertCommand.Parameters["@Phone"].Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                insertCommand.Parameters["@Phone"].Value = vendor.Phone;
            }

            if (vendor.ContactFName == "")
            {
                insertCommand.Parameters.Add("@ContactFName", SqlDbType.VarChar);
                insertCommand.Parameters["@ContactFName"].Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@ContactFName", SqlDbType.VarChar);
                insertCommand.Parameters["@ContactFName"].Value = vendor.ContactFName;
            }

            if (vendor.ContactLName == "")
            {
                insertCommand.Parameters.Add("@ContactLName", SqlDbType.VarChar);
                insertCommand.Parameters["@ContactLName"].Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@ContactLName", SqlDbType.VarChar);
                insertCommand.Parameters["@ContactLName"].Value = vendor.ContactLName;
            }

            insertCommand.Parameters.Add("@DefaultTermsID", SqlDbType.Int);
            insertCommand.Parameters["@DefaultTermsID"].Value = vendor.DefaultTermsID;

            insertCommand.Parameters.Add("@DefaultAccountNo", SqlDbType.Int);
            insertCommand.Parameters["@DefaultAccountNo"].Value = vendor.DefaultAccountNo;

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Vendors') FROM Vendors";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int vendorID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return vendorID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// method used to delete vendor
        /// </summary>
        /// <param name="vendor">vendor object</param>
        /// <returns>boolean of if vendor was deleted</returns>
        public static bool DeleteVendor(Vendor vendor)
        {
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string deleteStatement =
                "DELETE FROM Vendors " +
                "WHERE VendorID = @VendorID " +
                  "AND Name = @Name " +
                  "AND Address1 = @Address1 " +
                  "AND (Address2 = @Address2 " +
                     "OR Address2 IS NULL AND @Address2 IS NULL) " +
                  "AND City = @City " +
                  "AND State = @State " +
                  "AND ZipCode = @ZipCode " +
                  "AND (Phone = @Phone " +
                      "OR Phone IS NULL AND @Phone IS NULL) " +
                  "AND (ContactFName = @ContactFName " +
                      "OR ContactFName IS NULL AND @ContactFName IS NULL) " +
                  "AND (ContactLName = @ContactLName " +
                      "OR ContactLName IS NULL AND @ContactLName IS NULL) " +
                  "AND DefaultTermsID = @DefaultTermsID " +
                  "AND DefaultAccountNo = @DefaultAccountNo";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.Add("@Name", SqlDbType.VarChar);
            deleteCommand.Parameters["@Name"].Value = vendor.Name;

            deleteCommand.Parameters.Add("@Address1", SqlDbType.VarChar);
            deleteCommand.Parameters["@Address1"].Value = vendor.Address1;

            if (vendor.Address2 == "")
            {
                deleteCommand.Parameters.Add("@Address2", SqlDbType.VarChar);
                deleteCommand.Parameters["@Address2"].Value = DBNull.Value;
            }
            else
            {
                deleteCommand.Parameters.Add("@Address2", SqlDbType.VarChar);
                deleteCommand.Parameters["@Address2"].Value = vendor.Address2;
            }

            deleteCommand.Parameters.Add("@City", SqlDbType.VarChar);
            deleteCommand.Parameters["@City"].Value = vendor.City;

            deleteCommand.Parameters.Add("@State", SqlDbType.Char);
            deleteCommand.Parameters["@State"].Value = vendor.State;

            deleteCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar);
            deleteCommand.Parameters["@ZipCode"].Value = vendor.ZipCode;


            if (vendor.Phone == "")
            {
                deleteCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                deleteCommand.Parameters["@Phone"].Value = DBNull.Value;
            }
            else
            {
                deleteCommand.Parameters.Add("@Phone", SqlDbType.VarChar);
                deleteCommand.Parameters["@Phone"].Value = vendor.Phone;
            }

            if (vendor.ContactFName == "")
            {
                deleteCommand.Parameters.Add("@ContactFName", SqlDbType.VarChar);
                deleteCommand.Parameters["@ContactFName"].Value = DBNull.Value;
            }
            else
            {
                deleteCommand.Parameters.Add("@ContactFName", SqlDbType.VarChar);
                deleteCommand.Parameters["@ContactFName"].Value = vendor.ContactFName;
            }

            if (vendor.ContactLName == "")
            {
                deleteCommand.Parameters.Add("@ContactLName", SqlDbType.VarChar);
                deleteCommand.Parameters["@ContactLName"].Value = DBNull.Value;
            }
            else
            {
                deleteCommand.Parameters.Add("@ContactLName", SqlDbType.VarChar);
                deleteCommand.Parameters["@ContactLName"].Value = vendor.ContactLName;
            }

            deleteCommand.Parameters.Add("@DefaultTermsID", SqlDbType.Int);
            deleteCommand.Parameters["@DefaultTermsID"].Value = vendor.DefaultTermsID;

            deleteCommand.Parameters.Add("@DefaultAccountNo", SqlDbType.Int);
            deleteCommand.Parameters["@DefaultAccountNo"].Value = vendor.DefaultAccountNo;

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// method used to update vendor object
        /// </summary>
        /// <param name="oldVendor">old vendor object</param>
        /// <param name="newVendor">new vendor object</param>
        /// <returns>boolean if vendor was updated</returns>
        public static bool UpdateVendor(Vendor oldVendor, Vendor newVendor)
        {
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string updateStatement =
                "UPDATE Vendors SET " +
                  "Name = @NewName, " +
                  "Address1 = @NewAddress1, " +
                  "Address2 = @NewAddress2, " +
                  "City = @NewCity, " +
                  "State = @NewState, " +
                  "ZipCode = @NewZipCode, " +
                  "Phone = @NewPhone, " +
                  "ContactFName = @NewContactFName, " +
                  "ContactLName = @NewContactLName, " +
                  "DefaultTermsID = @NewDefaultTermsID, " +
                  "DefaultAccountNo = @NewDefaultAccountNo " +
                "WHERE VendorID = @OldVendorID " +
                  "AND Name = @OldName " +
                  "AND Address1 = @OldAddress1 " +
                  "AND (Address2 = @OldAddress2 " +
                     "OR Address2 IS NULL AND @OldAddress2 IS NULL) " +
                  "AND City = @OldCity " +
                  "AND State = @OldState " +
                  "AND ZipCode = @OldZipCode " +
                  "AND (Phone = @OldPhone " +
                      "OR Phone IS NULL AND @OldPhone IS NULL) " +
                  "AND (ContactFName = @OldContactFName " +
                      "OR ContactFName IS NULL AND @OldContactFName IS NULL) " +
                  "AND (ContactLName = @OldContactLName " +
                      "OR ContactLName IS NULL AND @OldContactLName IS NULL) " +
                  "AND DefaultTermsID = @OldDefaultTermsID " +
                  "AND DefaultAccountNo = @OldDefaultAccountNo";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.Add("@NewName", SqlDbType.VarChar);
            updateCommand.Parameters["@NewName"].Value = newVendor.Name;

            updateCommand.Parameters.Add("@NewAddress1", SqlDbType.VarChar);
            updateCommand.Parameters["@NewAddress1"].Value = newVendor.Address1;

            if (newVendor.Address2 == "")
            {
                updateCommand.Parameters.Add("@NewAddress2", SqlDbType.VarChar);
                updateCommand.Parameters["@NewAddress2"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@NewAddress2", SqlDbType.VarChar);
                updateCommand.Parameters["@NewAddress2"].Value = newVendor.Address2;
            }

            updateCommand.Parameters.Add("@NewCity", SqlDbType.VarChar);
            updateCommand.Parameters["@NewCity"].Value = newVendor.City;

            updateCommand.Parameters.Add("@NewState", SqlDbType.Char);
            updateCommand.Parameters["@NewState"].Value = newVendor.State;

            updateCommand.Parameters.Add("@NewZipCode", SqlDbType.VarChar);
            updateCommand.Parameters["@NewZipCode"].Value = newVendor.ZipCode;


            if (newVendor.Phone == "")
            {
                updateCommand.Parameters.Add("@NewPhone", SqlDbType.VarChar);
                updateCommand.Parameters["@NewPhone"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@NewPhone", SqlDbType.VarChar);
                updateCommand.Parameters["@NewPhone"].Value = newVendor.Phone;
            }

            if (newVendor.ContactFName == "")
            {
                updateCommand.Parameters.Add("@NewContactFName", SqlDbType.VarChar);
                updateCommand.Parameters["@NewContactFName"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@NewContactFName", SqlDbType.VarChar);
                updateCommand.Parameters["@NewContactFName"].Value = newVendor.ContactFName;
            }

            if (newVendor.ContactLName == "")
            {
                updateCommand.Parameters.Add("@NewContactLName", SqlDbType.VarChar);
                updateCommand.Parameters["@NewContactLName"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@NewContactLName", SqlDbType.VarChar);
                updateCommand.Parameters["@NewContactLName"].Value = newVendor.ContactLName;
            }

            updateCommand.Parameters.Add("@NewDefaultTermsID", SqlDbType.Int);
            updateCommand.Parameters["@NewDefaultTermsID"].Value = newVendor.DefaultTermsID;

            updateCommand.Parameters.Add("@NewDefaultAccountNo", SqlDbType.Int);
            updateCommand.Parameters["@NewDefaultAccountNo"].Value = newVendor.DefaultAccountNo;

            updateCommand.Parameters.Add("@OldVendorID", SqlDbType.Int);
            updateCommand.Parameters["@OldVendorID"].Value = oldVendor.VendorID;

            updateCommand.Parameters.Add("@OldName", SqlDbType.VarChar);
            updateCommand.Parameters["@OldName"].Value = oldVendor.Name;

            updateCommand.Parameters.Add("@OldAddress1", SqlDbType.VarChar);
            updateCommand.Parameters["@OldAddress1"].Value = oldVendor.Address1;

            if (oldVendor.Address2 == "")
            {
                updateCommand.Parameters.Add("@OldAddress2", SqlDbType.VarChar);
                updateCommand.Parameters["@OldAddress2"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@OldAddress2", SqlDbType.VarChar);
                updateCommand.Parameters["@OldAddress2"].Value = oldVendor.Address2;
            }

            updateCommand.Parameters.Add("@OldCity", SqlDbType.VarChar);
            updateCommand.Parameters["@OldCity"].Value = oldVendor.City;

            updateCommand.Parameters.Add("@OldState", SqlDbType.Char);
            updateCommand.Parameters["@OldState"].Value = oldVendor.State;

            updateCommand.Parameters.Add("@OldZipCode", SqlDbType.VarChar);
            updateCommand.Parameters["@OldZipCode"].Value = oldVendor.ZipCode;


            if (oldVendor.Phone == "")
            {
                updateCommand.Parameters.Add("@OldPhone", SqlDbType.VarChar);
                updateCommand.Parameters["@OldPhone"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@OldPhone", SqlDbType.VarChar);
                updateCommand.Parameters["@OldPhone"].Value = oldVendor.Phone;
            }

            if (oldVendor.ContactFName == "")
            {
                updateCommand.Parameters.Add("@OldContactFName", SqlDbType.VarChar);
                updateCommand.Parameters["@OldContactFName"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@OldContactFName", SqlDbType.VarChar);
                updateCommand.Parameters["@OldContactFName"].Value = oldVendor.ContactFName;
            }

            if (oldVendor.ContactLName == "")
            {
                updateCommand.Parameters.Add("@OldContactLName", SqlDbType.VarChar);
                updateCommand.Parameters["@OldContactLName"].Value = DBNull.Value;
            }
            else
            {
                updateCommand.Parameters.Add("@OldContactLName", SqlDbType.VarChar);
                updateCommand.Parameters["@OldContactLName"].Value = oldVendor.ContactLName;
            }

            updateCommand.Parameters.Add("@OldDefaultTermsID", SqlDbType.Int);
            updateCommand.Parameters["@OldDefaultTermsID"].Value = oldVendor.DefaultTermsID;

            updateCommand.Parameters.Add("@OldDefaultAccountNo", SqlDbType.Int);
            updateCommand.Parameters["@OldDefaultAccountNo"].Value = oldVendor.DefaultAccountNo;

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion
    }
}
