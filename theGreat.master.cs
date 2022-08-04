using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class theGreat : System.Web.UI.MasterPage
{
    int x = 0;
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            login.Text = "Logout " + Session["username"].ToString();
            Button1.Visible = false;
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() == "lectu")
                {
                    DropDownList1.Visible = true;
                    if (DropDownList1.Items.Count < 1)
                    {
                        DropDownList1.Items.Add("Select A Function");
                        DropDownList1.Items.Add("Create Seat Allocation");
                        DropDownList1.Items.Add("Check Seat Allocation");
                    }
                }
                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() == "student")
                    {
                        studDrop.Visible = true;
                    }
                }
            }
        }
        conn.Open();

        string dat = DateTime.Now.ToShortDateString();

        //string d, m, y;
        //string dd = dat.ToString();
        //d = dd.Substring(0, 2);
        //m = dd.Substring(3, 3);
        //y = dd.Substring(7, 2);
        //if (m == "Aug")
        //{
        //    m = 08.ToString();
        //}
        //if (m == "Sep")
        //{
        //    m = 09.ToString();
        //}
        //if (m == "Oct")
        //{
        //    m = 10.ToString();
        //}
        //if (m == "Nov")
        //{
        //    m = 11.ToString();
        //}
        //if (m == "Dec")
        //{
        //    m = 12.ToString();
        //}
        //dat = y + "-" + m + "-" + d;

        //string dele = "DELETE FROM tblseatallocation WHERE seatAllocDate < date('" + dat + "')";
        //OdbcCommand cmd = new OdbcCommand(dele, conn);
        //cmd.ExecuteNonQuery();
        //dele = "DELETE FROM tblsubj_venue WHERE subjvenDate < date('" + dat + "')";
        //cmd = new OdbcCommand(dele, conn);
        //cmd.ExecuteNonQuery();
        //conn.Close();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 1)
        {
            Response.Redirect("~/lecture/seatAllocation.aspx");
        }
        if (DropDownList1.SelectedIndex == 2)
        {
            Response.Redirect("~/lecture/checkSeatAlloc.aspx");
        }
        DropDownList1.SelectedIndex = DropDownList1.SelectedIndex;
    }

    protected void studDrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(studDrop.SelectedIndex == 1)
        {
            Response.Redirect("~/student/student.aspx");
        }
        if(studDrop.SelectedIndex==2)
        {
            Response.Redirect("~/student/updateProfile.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/registration.aspx");
    }
}
