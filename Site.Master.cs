using System;
using System.Web.UI;

namespace CRUD_Operations
{
    public partial class SiteMaster : MasterPage
    {

        public void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["id"] == null)
            {
                link1.Style.Add("display", "none");
                adbtn.Style.Add("display", "none");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Remove("id");
            Response.Redirect("Default.aspx");
        }
    }
}