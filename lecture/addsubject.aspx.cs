using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addsubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void exit_Click1(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }
}