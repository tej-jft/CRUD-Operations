﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Operations
{
    public partial class Edit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeCRUD_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string name, email, contact, salary;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (System.Web.HttpContext.Current.Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                try
                {
                    name = Request.QueryString["name"].ToString();
                    email = Request.QueryString["email"].ToString();
                    contact = Request.QueryString["contact"].ToString();
                    salary = Request.QueryString["salary"].ToString();
                    string id = Request.QueryString["id"].ToString();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update dbo.Employees set Name='" + name + "',email='" + email + "',Contact='" + contact + "',Salary='" + salary + "' where id=" + Convert.ToInt32(id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    ex.Message.ToString();
                }
                
            }
        }

    }
}