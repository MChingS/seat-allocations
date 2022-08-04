using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class passreset : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] == null)
        //{
        //    Response.Redirect("~/unautorized.aspx");
        //}

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string update = "UPDATE tblemployee SET empPassword ='" + cornPass.Text.ToString()
            + "' WHERE empusername ='" + username.Text.ToString().ToUpper() + "'";
        conn.Open();
        OdbcCommand cmd = new OdbcCommand(update, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("login.aspx");
    }
}