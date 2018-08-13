using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace AjaxProject.Models
{
    public class EmployeeDB
    {
        //declare connection string
       // string cs =  ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
       // public string str = "Data Source=DESKTOP-0NKTVBC\asaac;Initial Catalog=FFDS; Integrated Security=true";
        //public string str = "Persist Security Info=False;Integrated Security=true;Initial Catalog=FFDS;server=(local)";
        public string cs = "Data Source=YASIR-PC;Initial Catalog=EmployeeDB;user Id=sa;password=123";
        //public string str = "Persist Security Info=False;Integrated Security=true;Initial Catalog=FFDS;server=(local)";
        
        public string LoginFiled(LoginCredien Details)
        {
           
            try
            {
                
                string rows = String.Empty;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    con.Open();
                    SqlCommand com = new SqlCommand("LoginEmployee", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@username", Details.username);
                    com.Parameters.AddWithValue("@password", Details.password);

                    DataTable dt = new DataTable();
                    using (SqlDataReader dr = com.ExecuteReader())
                    {

                     
                        dt.Load(dr);

                    }
                    if (dt.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["User"] = dt.Rows[0][0].ToString();
                    }
                    con.Close();
                    rows = JsonConvert.SerializeObject(dt);
                    return rows;
                }
            }
            catch
            {
                return "eRROR";
            
            }
        }
        //Return list of all Employees
        public List<Employee> ListAll(string procedureName)
        {
            List<Employee> lst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(rdr["EmployeeId"]),
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        State = rdr["State"].ToString(),
                        Country = rdr["Country"].ToString(),
                    });
                }
                con.Close();
                return lst;
            }
        }
        //Method for Adding an Employee
        public string Add(Employee emp)
        {
            string messag = string.Empty;
            SqlConnection con = null;
            using (con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertUpdateEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", emp.EmployeeID);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Age", emp.Age);
                    cmd.Parameters.AddWithValue("@State", emp.State);
                    cmd.Parameters.AddWithValue("@Country", emp.Country);
                    cmd.Parameters.AddWithValue("@Action", "Insert");

                    cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    messag = cmd.Parameters["@Response"].Value.ToString();
                    con.Close();
                }
                return messag;
            }

        }
        //Method for Updating Employee record
        public string Update(Employee emp)
        {
            string messag = string.Empty;
            SqlConnection con = null;
            using (con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertUpdateEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", emp.EmployeeID);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Age", emp.Age);
                    cmd.Parameters.AddWithValue("@State", emp.State);
                    cmd.Parameters.AddWithValue("@Country", emp.Country);
                    cmd.Parameters.AddWithValue("@Action", "Update");

                    cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    messag = cmd.Parameters["@Response"].Value.ToString();
                    con.Close();
                }
                return messag;
            }

        }
        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}