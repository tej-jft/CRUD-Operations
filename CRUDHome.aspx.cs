using System;
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
                updateTable();
            }
        }
        protected void AddRecord(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeCRUD_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string insert = "insert into dbo.employees(Name,email,Contact,Salary) values ('" +ename.Value + "','" + email.Value + "','" + econtact.Value + "','" + esalary.Value + "')";
            SqlCommand cmd = new SqlCommand(insert, con);
            int m = cmd.ExecuteNonQuery();
            if (m != 0)
            {
                Response.Write("<script> alert('Data Inserted !!') </ script >");
                updateTable();
            }
            else
            {
                Response.Write("< script > alert('Data Didn't Inserted !!') </ script >");
            }
            con.Close();
            updateTable();
        }
        public  void updateTable()
        {
            try
            {
                lbltbl.InnerHtml = "";
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeCRUD_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("select * from dbo.Employees", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                string htmlTable = "";
                int isd = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    isd++;
                    string name = dr["Name"].ToString();
                    string email = dr["email"].ToString();
                    string contact = dr["Contact"].ToString();
                    string salary = dr["Salary"].ToString();
                    htmlTable += "<tr><td>" + isd + "</td><td>" + name + "</td><td>" + email + "</td><td>" + contact + "</td><td>" + salary + "</td><td><input type='button' value='Edit' id='" + Convert.ToInt32(dr["id"]) + "' class='btn btn-warning spcbtn' onclick='updateEmp(" + Convert.ToInt32(dr["id"]) + ")' data-toggle='modal' data-target='#editModal'  Text='Edit' /><input type='button' value='delete' id='" + Convert.ToInt32(dr["id"]) + "' onclick='del(" + Convert.ToInt32(dr["id"]) + ")' class='btn btn-danger spc-btn' data-toggle='modal' data-target='#deleteModal' runat='server' Text='Delete'/></td></tr>";
                }
                lbltbl.InnerHtml = htmlTable;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}

