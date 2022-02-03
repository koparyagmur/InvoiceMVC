using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InvoinceProject.Models
{
    /// <summary>
    /// Invoice data access layer class. Does what an ordinary data access layer class does.
    /// Responsible for CRUD operations.
    /// </summary>
    public class InvoicesDAL
    {
        string connectionString = "Server=.;Database=InvoiceDB;Integrated Security=true;";

        /// <summary>
        /// To Get all Invoicess details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Invoice> GetAllInvoices()
        {
            List<Invoice> lstInvoices = new List<Invoice>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllInvoices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Invoice AnInvoice = new Invoice();
                    AnInvoice.Id = Convert.ToInt32(sdr["Id"]);
                    AnInvoice.ProductCode = sdr["ProductCode"].ToString();
                    AnInvoice.ProductName = sdr["ProductName"].ToString();
                    AnInvoice.UnitPrice = (decimal)sdr["UnitPrice"];
                    AnInvoice.Quantity = Convert.ToInt16(sdr["Quantity"]);
                    AnInvoice.Amount = (decimal)sdr["Amount"];
                    lstInvoices.Add(AnInvoice);
                }
                con.Close();
            }
            return lstInvoices;
        }

        /// <summary>
        /// To Add a new Invoice record
        /// </summary>
        /// <param name="AnInvoice">An invoice object to be inserted to DB</param>
        public void AddInvoice(Invoice AnInvoice)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCode", AnInvoice.ProductCode);
                cmd.Parameters.AddWithValue("@ProductName", AnInvoice.ProductName);
                cmd.Parameters.AddWithValue("@UnitPrice", AnInvoice.UnitPrice);
                cmd.Parameters.AddWithValue("@Quantity", AnInvoice.Quantity);
                cmd.Parameters.AddWithValue("@Amount", AnInvoice.Amount);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// To Update the records of a particluar Invoice    
        /// </summary>
        /// <param name="AnInvoice">An invoice object to be updated</param>
        public void UpdateInvoice(Invoice AnInvoice)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", AnInvoice.Id);
                cmd.Parameters.AddWithValue("@ProductCode", AnInvoice.ProductCode);
                cmd.Parameters.AddWithValue("@ProductName", AnInvoice.ProductName);
                cmd.Parameters.AddWithValue("@UnitPrice", AnInvoice.UnitPrice);
                cmd.Parameters.AddWithValue("@Quantity", AnInvoice.Quantity);
                cmd.Parameters.AddWithValue("@Amount", AnInvoice.Amount);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Get the details of a particular Invoice 
        /// </summary>
        /// <param name="id">DB id of required invoice to be obtained</param>
        /// <returns></returns>
        public Invoice GetInvoice(int? id)
        {
            Invoice AnInvoice = new Invoice();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_GetInvoiceByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    AnInvoice.Id = Convert.ToInt32(sdr["Id"]);
                    AnInvoice.ProductCode = sdr["ProductCode"].ToString();
                    AnInvoice.ProductName = sdr["ProductName"].ToString();
                    AnInvoice.UnitPrice = (decimal)sdr["UnitPrice"];
                    AnInvoice.Quantity = Convert.ToInt16(sdr["Quantity"]);
                    AnInvoice.Amount = (decimal)sdr["Amount"];
                }
            }
            return AnInvoice;
        }

        /// <summary>
        /// To Delete the record on a particular Invoice
        /// </summary>
        /// <param name="id">DB id of required invoice to be deleted</param>
        public void DeleteInvoice(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

