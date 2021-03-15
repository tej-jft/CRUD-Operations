using System;

namespace CRUD_Operations
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["id"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            else
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
        }
    }
}