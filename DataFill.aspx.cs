using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                    string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection cn = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("SelectEmployee", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cn.Close();
                    int isd = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        isd++;
                        string name = dr["Name"].ToString();
                        string email = dr["email"].ToString();
                        string contact = dr["Contact"].ToString();
                        string salary = dr["Salary"].ToString();
                        Response.Write(name + "|" + email + "|" + contact + "|" + salary + "|");
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