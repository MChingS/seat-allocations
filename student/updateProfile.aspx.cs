using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class updateProfile : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
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
        }
        string userN = Session["username"].ToString();
        studUsername.Text = userN;
        string get = " SELECT s.studNo,coursecode,studname,studsurname ";
        get += " FROM tblstudent s ";
        get += " WHERE s.studusername = '" + userN + "' ";
        
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

    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int max = subjectList.Items.Count;
        for (int i = 0; i < subjectList.Items.Count; i++)
        {

            if (subjectList.Items[i].Selected)
            {
                string insert = "INSERT INTO tblsubj_stud(studno,subjCode,substudsemcode) values('" +
                  studNo.Text + "','" + subjectList.Items[i].Value.ToString() + "','" + studCoursecod.Text + "9')";
                Response.Write(insert+ "<br>");
                conn.Open();
                OdbcCommand cmd = new OdbcCommand(insert, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
            }
        }
        Response.Redirect("~/student/updateprofile.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int max = delete1.Items.Count;
        string semCode = studCoursecod.Text.ToString() + "9";
        for (int i = 0; i < delete1.Items.Count; i++)
        {

            if (delete1.Items[i].Selected)
            {
                string insert = "DELETE FROM tblsubj_stud WHERE studno ='" + studNo.Text + "' AND subjCode = '" 
                    + delete1.Items[i].Value.ToString() + "' AND substudsemcode = '" + semCode + "'";
                conn.Open();
                OdbcCommand cmd = new OdbcCommand(insert, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        Response.Redirect("~/student/updateprofile.aspx");
    }
}