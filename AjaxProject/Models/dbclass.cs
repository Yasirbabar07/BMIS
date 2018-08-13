using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace AjaxProject.Models
{
    public class dbclass
    {
        public static string ConString()
        {

             string str = "Data Source=YASIR-PC;Initial Catalog=EmployeeDB; user id=sa;password =123";
            //string str = "Data Source=.\\sqlexpress;Initial Catalog=360Taxi;user id=yasir;password=Khybertech@0071";
            return str;
        }
       
        public  string DataProcessor(DataKeeper[] data, string action)
        {
            String messag = string.Empty;
            SqlConnection con = null;
            try
            {
                if (HttpContext.Current.Session["Id"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                            cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["Id"].ToString());
                            cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            messag = cmd.Parameters["@Response"].Value.ToString();
                            con.Close();
                        }
                        return messag;
                }
            }
                else
                {
                    return "SessionNull";
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }

        }

      

      
        public string DataProcessor1(DataKeeper[] data, int colms, ArrayDetails[] Details, string action)
        {
            String messag = string.Empty;
            SqlConnection con = null;
            try
            {
                if (HttpContext.Current.Session["Id"] != null)
                {
                    DataTable dt = new DataTable();
                    for (int i = 0; i < colms; i++)
                    {
                        dt.Columns.Add("Column" + i, typeof(string));
                    }
                    foreach (ArrayDetails Det in Details)
                    {
                        dt.Rows.Add(Det.Parm1, Det.Parm2, Det.Parm3, Det.Parm4);
                    }
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                            cmd.Parameters.AddWithValue("@List", dt);
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["Id"].ToString());
                            cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                            cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            messag = cmd.Parameters["@Response"].Value.ToString();
                            con.Close();

                            return messag;
                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public class Dt
        {
            public DataTable dt1 { get; set; }
            public DataTable dt2 { get; set; }
            public DataTable dt3 { get; set; }
            public DataTable dt4 { get; set; }
            public DataTable dt5 { get; set; }
        }
      
        public string DataSelector(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            DataTable dt2 = null;
            DataTable dt3 = null;
            DataTable dt4 = null;
            DataTable dt5 = null;
            SqlConnection con = null;
            string rows = string.Empty;

            Dictionary<string, string> para = new Dictionary<string, string>();
            try
            {
                if (HttpContext.Current.Session["Id"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["Id"].ToString());
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                dt1 = new DataTable();
                                dt1.Load(dr);
                                dt2 = new DataTable();
                                dt2.Load(dr);
                                dt3 = new DataTable();
                                dt3.Load(dr);
                                dt4 = new DataTable();
                                dt4.Load(dr);
                                dt5 = new DataTable();
                                dt5.Load(dr);
                            }
                            con.Close();
                            Dt AllData = new Dt
                            {
                                dt1 = dt1,
                                dt2 = dt2,
                                dt3 = dt3,
                                dt4 = dt4,
                                dt5 = dt5
                            };
                            rows = JsonConvert.SerializeObject(AllData);
                            return rows;

                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }

        }
        
        public string DataSelectorLess(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;

            //Dictionary<string, string> para = new Dictionary<string, string>();
            try
            {
                if (HttpContext.Current.Session["Id"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["Id"].ToString());
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                dt1 = new DataTable();
                                dt1.Load(dr);

                            }
                            con.Close();

                            rows = JsonConvert.SerializeObject(dt1);
                            return rows;

                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }

        }
        
       
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
        public static string RemoveSpecialChars(string str)
        {

            string[] chars = new string[] { "=", "/", "!", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", "|", "[", "]" };
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], " ");
                }
            }
            return str;
        }

        public  string LoginSelector(DataKeeper[] data,  string action)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;
          


            try
            {

                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (DataKeeper nvp in data)
                        {
                            string Newvalue = RemoveSpecialChars(nvp.value);
                            cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                        }
                       

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            dt1 = new DataTable();
                            dt1.Load(dr);

                        }
                        con.Close();
                        if (dt1.Rows.Count > 0)
                        {
                            HttpContext.Current.Session["Id"] = dt1.Rows[0][0].ToString();
                            
                            rows = "Home/Main";
                            return rows;
                        }
                        else
                        {
                            rows = "Incorrect";
                            return rows;
                        }
                       

                    }

                }


            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }
        }

        
    }
    public class DataKeeper
    {
        public string name { get; set; }
        public string value { get; set; }

    }
    public class ArrayDetails
    {
        public string Parm1 { get; set; }
        public string Parm2 { get; set; }
        public string Parm3 { get; set; }
        public string Parm4 { get; set; }
    }
}