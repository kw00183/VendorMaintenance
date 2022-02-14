﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VendorMaintenance.DAL;

namespace PayablesData
{
    public static class VendorDB
    {
        public static Vendor GetVendor(int vendorID)
        {
            Vendor vendor = new Vendor();
            SqlConnection connection = PayablesDBConnection.GetConnection();
            string selectStatement =
                "SELECT VendorID, Name, Address1, Address2, City, State, " +
                    "ZipCode, Phone, ContactFName, ContactLName, " +
                    "DefaultAccountNo, DefaultTermsID " +
                "FROM Vendors " +
                "WHERE VendorID = @VendorID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@VendorID", vendorID);
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
            insertCommand.Parameters.AddWithValue("@Name", vendor.Name);
            insertCommand.Parameters.AddWithValue("@Address1", vendor.Address1);
            if (vendor.Address2 == "")
                insertCommand.Parameters.AddWithValue("@Address2", DBNull.Value);
            else
                insertCommand.Parameters.AddWithValue("@Address2",
                    vendor.Address2);
            insertCommand.Parameters.AddWithValue("@City", vendor.City);
            insertCommand.Parameters.AddWithValue("@State", vendor.State);
            insertCommand.Parameters.AddWithValue("@ZipCode", vendor.ZipCode);
            if (vendor.Phone == "")
                insertCommand.Parameters.AddWithValue("@Phone", DBNull.Value);
            else
                insertCommand.Parameters.AddWithValue("@Phone", vendor.Phone);
            if (vendor.ContactFName == "")
                insertCommand.Parameters.AddWithValue("@ContactFName",
                    DBNull.Value);
            else
                insertCommand.Parameters.AddWithValue("@ContactFName",
                    vendor.ContactFName);
            if (vendor.ContactLName == "")
                insertCommand.Parameters.AddWithValue("@ContactLName",
                    DBNull.Value);
            else
                insertCommand.Parameters.AddWithValue("@ContactLName",
                    vendor.ContactLName);
            insertCommand.Parameters.AddWithValue("@DefaultTermsID",
                vendor.DefaultTermsID);
            insertCommand.Parameters.AddWithValue("@DefaultAccountNo",
                vendor.DefaultAccountNo);
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
            updateCommand.Parameters.AddWithValue("@NewName", newVendor.Name);
            updateCommand.Parameters.AddWithValue("@NewAddress1", newVendor.Address1);
            if (newVendor.Address2 == "")
                updateCommand.Parameters.AddWithValue("@NewAddress2", DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@NewAddress2",
                    newVendor.Address2);
            updateCommand.Parameters.AddWithValue("@NewCity", newVendor.City);
            updateCommand.Parameters.AddWithValue("@NewState", newVendor.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", newVendor.ZipCode);
            if (newVendor.Phone == "")
                updateCommand.Parameters.AddWithValue("@NewPhone", DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@NewPhone", newVendor.Phone);
            if (newVendor.ContactFName == "")
                updateCommand.Parameters.AddWithValue("@NewContactFName",
                    DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@NewContactFName",
                    newVendor.ContactFName);
            if (newVendor.ContactLName == "")
                updateCommand.Parameters.AddWithValue("@NewContactLName",
                    DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@NewContactLName",
                    newVendor.ContactLName);
            updateCommand.Parameters.AddWithValue("@NewDefaultTermsID",
                newVendor.DefaultTermsID);
            updateCommand.Parameters.AddWithValue("@NewDefaultAccountNo",
                newVendor.DefaultAccountNo);

            updateCommand.Parameters.AddWithValue("@OldVendorID", oldVendor.VendorID);
            updateCommand.Parameters.AddWithValue("@OldName", oldVendor.Name);
            updateCommand.Parameters.AddWithValue("@OldAddress1", oldVendor.Address1);
            if (oldVendor.Address2 == "")
                updateCommand.Parameters.AddWithValue("@OldAddress2", DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@OldAddress2",
                    oldVendor.Address2);
            updateCommand.Parameters.AddWithValue("@OldCity", oldVendor.City);
            updateCommand.Parameters.AddWithValue("@OldState", oldVendor.State);
            updateCommand.Parameters.AddWithValue("@OldZipCode", oldVendor.ZipCode);
            if (oldVendor.Phone == "")
                updateCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@OldPhone", oldVendor.Phone);
            if (oldVendor.ContactFName == "")
                updateCommand.Parameters.AddWithValue("@OldContactFName",
                    DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@OldContactFName",
                    oldVendor.ContactFName);
            if (oldVendor.ContactLName == "")
                updateCommand.Parameters.AddWithValue("@OldContactLName",
                    DBNull.Value);
            else
                updateCommand.Parameters.AddWithValue("@OldContactLName",
                    oldVendor.ContactLName);
            updateCommand.Parameters.AddWithValue("@OldDefaultTermsID",
                oldVendor.DefaultTermsID);
            updateCommand.Parameters.AddWithValue("@OldDefaultAccountNo",
                oldVendor.DefaultAccountNo);

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
    }
}
