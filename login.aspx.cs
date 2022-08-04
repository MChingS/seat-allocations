using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        warning.Visible = false;
        Session["username"] = null;
        Session["role"] = null;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        string select = "SELECT empuserName,empPassword,empid,jobCode FROM tblemployee WHERE empuserName='"
                         + TextBox7.Text.ToUpper() + "' AND empPassword='" + TextBox13.Text.ToString() + "' ";
        OdbcDataAdapter adapt = new OdbcDataAdapter(select, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];
        string username = null;
        string cod = null;
        string id =null;
        if (myTable.Rows.Count > 0)
        {
            foreach (DataRow vk in myTable.Rows)
            {
                cod = vk["jobCode"].ToString();
                username = vk["empuserName"].ToString();
                id= vk["empid"].ToString();
            }

            Session["username"] = username;
            Session["role"] = cod;
            Session["userid"]  = id;

            //if (Session["requested"]!=null)
            //{
            //    Response.Redirect(Session["requested"].ToString());
            //}
           
            if (cod == "admin")
            {
                Response.Redirect("admin/report.aspx");
            }
            if (cod == "lectu")
            {
                Response.Redirect("lecture/complexLectu.aspx");
            }
            if (cod == "labTe")
            {
                Response.Redirect("labtech/labtec.aspx");
            }

        }
        select = "SELECT * FROM tblstudent WHERE studUsername='"
                         + TextBox7.Text.ToUpper() + "' AND studPassword='" + TextBox13.Text.ToString() + "'";
        adapt = new OdbcDataAdapter(select, conn);
        dts = new DataSet();
        adapt.Fill(dts);
        myTable = dts.Tables[0];
        username = null;
        cod = null;
        if (myTable.Rows.Count > 0)
        {
            Response.Write("Good");
            foreach (DataRow vk in myTable.Rows)
            {
                username = vk["studUsername"].ToString();
                Session["Name"] = vk["studName"].ToString();
            }
           
            cod = "student";
            Session["username"] = username;
            Session["role"] = cod;
            Response.Redirect("student/student.aspx");
        }
        else
        {
            warning.Visible = true;
        }

    }
}