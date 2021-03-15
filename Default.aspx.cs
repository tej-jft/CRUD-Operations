using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CRUD_Operations
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            SqlConnection cn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SelectUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("password", TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Open();
            _= cmd.ExecuteNonQuery();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = TextBox1.Text;
                Response.Redirect("Home.aspx");
            }
            else
            {
                Label1.Text = "Your username and Password is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}