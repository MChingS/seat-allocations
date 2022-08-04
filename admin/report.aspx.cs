using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["role"] == null)
        {
            Response.Redirect("~/homepage.aspx");
        }
        else if (Session["role"].ToString() != "admin")
        {
            Response.Redirect("~/unautorized.aspx");
        }
        else
        {
            GridView1.Visible = false;
            GridView5.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView6.Visible = false;

            if(Panel1.Visible ==true)
            {
                GridView1.Visible = true;
                Panel4.Visible = false;
            }
            if (Panel4.Visible == true)
            {
                Panel1.Visible = false;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = true;
        GridView3.Visible = false;
        GridView4.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = true;
        GridView4.Visible = false;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = true;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel4.Visible = false;
        GridView1.Visible = true;
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        Panel1.Visible = false;
        GridView5.Visible = true;
        GridView1.Visible = false;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        GridView5.Visible = true;
        GridView6.Visible = false;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        GridView5.Visible = false;
        GridView6.Visible = true;
    }

    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }
}