using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Nguyen_Quoc_Dat_5951071013.Models
{

    public class db
    {
        Sqlconnection con = new SqlConnection("Data Source=DAT-NGUYEN;Initial Catalog=DemoCRUID;Integrated Security=True ");

        public DataSet Empget(Employee emp, out String msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee,con");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Contry);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.Flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Ok";
                return ds;

            }
            catch (Exception ex)
            {

                msg = ex.Message;
                return ds;
            }




        }
        public String Empdml(Employee emp, out String msg)
        {
            msg = "";

            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee,con");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Contry);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.Flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Ok";
                return msg;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}