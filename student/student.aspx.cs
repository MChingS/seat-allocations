using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
    DataTable tb = new DataTable();
    string[] rownum = new string[50];
    DataRow dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["role"] == null)
        {
            Response.Redirect("~/homepage.aspx");
        }
        else if (Session["role"].ToString() != "student")
        {
            Response.Redirect("~/unautorized.aspx");
        }
        else
        {
            //createtable();
            string userN = Session["username"].ToString();
            string get = " SELECT s.studNo,coursecode,studname,studsurname ";
            get += " FROM tblstudent s";
            get += " WHERE s.studusername = '" + userN + "' ";
            //get += "AND s.studno = sa.studno";

            OdbcDataAdapter adapt = new OdbcDataAdapter(get, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];

            string usernamf = userN;
            string studnf = "";
            string namef = "";
            string surnamf = "";
            string courseCodef = "";
            string logTimf = DateTime.Now.ToLongTimeString();
            foreach (DataRow dat in myTable.Rows)
            {
                studnf = dat["studNo"].ToString();
                courseCodef = dat["coursecode"].ToString();
                namef = dat["studname"].ToString();
                surnamf = dat["studsurname"].ToString();

            }
            studUsername.Text = usernamf;
            studNo.Text = studnf;
            studName.Text = namef;
            studSurname.Text = surnamf;
            studCoursecod.Text = courseCodef;
            timeLoged.Text = logTimf;
        }
    }

    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/student/updateprofile.aspx");
    }
}