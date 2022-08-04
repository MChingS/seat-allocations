using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkSeatAlloc : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
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
        studUsername.Text = Session["username"].ToString();
        studNo.Text = Session["userid"].ToString();
        timeLoged.Text = DateTime.Now.ToString();
        if (GridView2.Rows.Count < 1)
        {
            Session["date1"] = dateList.SelectedValue;
        }
       
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write(GridView1.SelectedIndex);
    }

    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/lecture/complexLectu.aspx");
    }

    protected void subjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        getDates();
    }

    protected void dateList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        subjectList.Items.Clear();
        string select = "SELECT subjCode FROM tblsubj_emp se, tblemployee e WHERE empusername ='" +
            Session["username"].ToString() + "'AND e.empid = se.empid";

        DbDataAdapter adapt = new OdbcDataAdapter(select, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];
        if (myTable.Rows.Count > 0)
        {
            foreach (DataRow bb in myTable.Rows)
            {
                string dd = Convert.ToString(bb["subjCode"]);
                subjectList.Items.Add(dd);
            }
            getDates();
        }
        Panel2.Visible = true;
        Button2.Visible = false;
        
    }


    public void getDates()
    {
        string select = " SELECT Date_Format(seatAllocDate,'%Y-%m-%d') as seatAllocDate FROM tblseatallocation WHERE subjCode ='"
          + subjectList.Text.ToString() + "' GROUP BY seatAllocDate";
        DbDataAdapter adapt = new OdbcDataAdapter(select, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];

        if (myTable.Rows.Count > 0)
        {
            dateList.Items.Clear();
            //dateList.Items.Add("Select date");
            foreach (DataRow bb in myTable.Rows)
            {
                string dd = Convert.ToString(bb["seatAllocDate"]);
                dateList.Items.Add(dd);
            }
        }
        else
        {
            dateList.Items.Clear();
            dateList.Items.Add("No Test available");
        }
    }
}