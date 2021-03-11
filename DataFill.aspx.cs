using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Operations
{
    public partial class DataFill : System.Web.UI.Page
    {
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
                    string id = Request.QueryString["id"].ToString();
                    DataTable dt = new DataTable();
                    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeCRUD_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    SqlCommand cmd = new SqlCommand("select * from dbo.Employees where id=" + Convert.ToInt32(id), con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    int isd = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        isd++;
                        string name = dr["Name"].ToString();
                        string email = dr["email"].ToString();
                        string contact = dr["Contact"].ToString();
                        string salary = dr["Salary"].ToString();
                        Response.Write(name+"|"+email + "|" + contact + "|" + salary+"|");
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
        }
    }
}