using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace CRUD_Operations
{
    public partial class Add : System.Web.UI.Page
    {
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

                    string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection cn = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("AddEmployee", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Salary", salary);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
        }
    }
}