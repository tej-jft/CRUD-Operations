using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Operations
{
    public partial class Edit : System.Web.UI.Page
    {
        string name, email, contact, salary,id;
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
                    id = Request.QueryString["id"].ToString();

                    string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection cn = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("EditEmployee", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch(Exception ex)
                {
                    ex.Message.ToString();
                }
                
            }
        }

    }
}