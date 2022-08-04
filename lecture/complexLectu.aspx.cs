using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["requested"] = (HttpContext.Current.Request.Url.AbsoluteUri);

        if (Session["username"] == null || Session["role"] == null)
        {
            Response.Redirect("~/homepage.aspx");
        }
        else if (Session["role"].ToString() != "lectu")
        {
            Response.Redirect("~/unautorized.aspx");
        }
        Session["requested"] = null;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/lecture/checkSeatAlloc.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/lecture/seatAllocation.aspx");
    }

    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }
}