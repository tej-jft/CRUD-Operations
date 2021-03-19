using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operations
{
    public partial class CRUDHome : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                //Label1.Text = Session["id"].ToString();
                UpdateTable();
            }
        }
        public void UpdateTable()
        {
            try
            {
                lbltbl.InnerHtml = "";
                string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("SelectAllEmployees", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cn.Open();
                _ = cmd.ExecuteNonQuery();
                cn.Close();
                string htmlTable = "";
                int isd = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    isd++;
                    string name = dr["Name"].ToString();
                    string email = dr["email"].ToString();
                    string contact = dr["Contact"].ToString();
                    string salary = dr["Salary"].ToString();
                    string image = dr["image"].ToString();
                    htmlTable += "<tr><td class='col-md-1'>" + isd + "</td><td class='col-md-2'>" + name + "</td><td class='col-md-3'>" + email + "</td><td class='col-md-2'>" + contact + "</td><td class='col-md-1'>" + salary + "</td><td class='col-md-1'><input type='button' id='" + image + "' class='btn btn-success spcbtn btn-sm' onclick='showImage(this.id)' data-toggle='modal' data-target='#imageModal'  value='View Image' /></td><td class='col-md-1'><input type='button' value='Edit' id='" + Convert.ToInt32(dr["id"]) + "' class='btn btn-success spcbtn btn-sm' onclick='updateEmp(" + Convert.ToInt32(dr["id"]) + ")' data-toggle='modal' data-target='#editModal'  Text='Edit' /></td><td class='col-md-1'><input type='button' value='Delete' id='" + Convert.ToInt32(dr["id"]) + "' onclick='del(" + Convert.ToInt32(dr["id"]) + ")' class='btn btn-danger spcbtn btn-sm' data-toggle='modal' data-target='#deleteModal' runat='server' Text='Delete'/></td></tr>";
                }
                lbltbl.InnerHtml = htmlTable;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}

