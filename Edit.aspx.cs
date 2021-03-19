using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CRUD_Operations
{
    public partial class Edit : System.Web.UI.Page
    {
        string name, email, contact, salary, id,image;
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
                    image = Request.QueryString["image"].ToString();
                    deleteFile(Convert.ToInt32(id));
                    string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection cn = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("EditEmployee", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.Parameters.AddWithValue("@image",image);
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

        public  void deleteFile(int id)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection cn = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("getfilename", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            cn.Open();
            _ = cmd.ExecuteNonQuery();
            cn.Close();
            string deleteFileName = dt.Rows[0]["image"].ToString();
            string path = Server.MapPath("~/Images/" + deleteFileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
        }

    }
}