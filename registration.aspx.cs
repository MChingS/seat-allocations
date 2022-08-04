using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;






public partial class _Default : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        warning.Visible = false;
        
        conn.Open();
        if (DropDownList1.SelectedIndex != 2)
        {
            string getnumber = "SELECT MAX(empId) FROM tblemployee";
            OdbcDataAdapter adapt = new OdbcDataAdapter(getnumber, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            panel1.Visible = false;
            string num = "";
            int maxNum = 0;
            foreach (DataRow dat in myTable.Rows)
            {
                num = dat["MAX(empId)"].ToString();
                maxNum = Convert.ToInt32(num) + 1;
            }
            if (empid.Text.Length != 5 )
            {
                empid.Text = maxNum.ToString();
            }
        }
        else
        {
            string getnumber = "SELECT MAX(studNo) FROM tblstudent";
            OdbcDataAdapter adapt = new OdbcDataAdapter(getnumber, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            panel1.Visible = true;
           string num = "";
            int maxNum = 0;
            foreach (DataRow dat in myTable.Rows)
            {
                num = dat["MAX(studNo)"].ToString();
                maxNum = Convert.ToInt32(num) + 1;
            }
            if (empid.Text.Length != 9)
            {
                empid.Text = maxNum.ToString();
            }
        }

        conn.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        conn.Open();
        bool duplicates = false;
        if (DropDownList1.SelectedIndex < 2)
        {
            string getnumber = "SELECT empUsername FROM tblemployee WHERE empUsername='" + TextBox7.Text.ToUpper() + "'";
            OdbcDataAdapter adapt = new OdbcDataAdapter(getnumber, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                warning.Visible = true;
                duplicates = true;
            }
            getnumber = "SELECT studUsername FROM tblStudent WHERE studUsername='" + TextBox7.Text.ToUpper() + "'";
            adapt = new OdbcDataAdapter(getnumber, conn);
            dts = new DataSet();
            adapt.Fill(dts);
            myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                warning.Visible = true;
                duplicates = true;
            }

            getnumber = "SELECT empid FROM tblemployee WHERE empid='" + empid.Text + "'";
            adapt = new OdbcDataAdapter(getnumber, conn);
            dts = new DataSet();
            adapt.Fill(dts);
            myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                warning.Text = "employee number already exist";
                warning.Visible = true;
                duplicates = true;
            }

            if(duplicates == false)
            {
                string jobcode = "";
                if (DropDownList1.SelectedIndex == 0)
                {
                    jobcode = "labTe";
                }
                if (DropDownList1.SelectedIndex == 1)
                {
                    jobcode = "lectu";
                }
                string insert = "INSERT INTO tblemployee(empid,jobCode,empUsername,empPassword) values(" + Convert.ToInt32(empid.Text)
                    + ",'" + jobcode + "','" + TextBox7.Text.ToUpper() + "','" + TextBox13.Text + "')";
                OdbcCommand cmd = new OdbcCommand(insert, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("login.aspx");
            }
        }
        ////////////
        if (DropDownList1.SelectedIndex == 2)
        {
            string getnumber = "SELECT studUsername FROM tblStudent WHERE studUsername='" + TextBox7.Text.ToUpper() + "'";
            OdbcDataAdapter adapt = new OdbcDataAdapter(getnumber, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                warning.Text = "Username already exist";
                warning.Visible = true;
                duplicates = true;
            }

           
            getnumber = "SELECT empUsername FROM tblemployee WHERE empUsername='" + TextBox7.Text.ToUpper() + "'";
            adapt = new OdbcDataAdapter(getnumber, conn);
            dts = new DataSet();
            adapt.Fill(dts);
            myTable = dts.Tables[0];

            if (myTable.Rows.Count > 0)
            {
                warning.Text = "Username already exist";
                warning.Visible = true;
                duplicates = true;
            }
            getnumber = "SELECT studno FROM tblStudent WHERE studno='" + empid.Text + "'";
            adapt = new OdbcDataAdapter(getnumber, conn);
            dts = new DataSet();
            adapt.Fill(dts);
            myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                warning.Text = "student number already exist";
                warning.Visible = true;
                duplicates = true;
            }
            if(duplicates == false)
            {
                string insert = "INSERT INTO tblStudent (studNo,studUsername,studPassword,coursecode,studSurname,studName,studIDNo) values('" + Convert.ToInt32(empid.Text)
                    + "','" + TextBox7.Text.ToUpper() + "','" + TextBox13.Text + "','"+courseCode.SelectedValue.ToString()+"','"+
                   surname.Text+"','"+name.Text+"','"+idNo.Text+"')";
                OdbcCommand cmd = new OdbcCommand(insert, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("login.aspx");

            }
        }
        conn.Close();

    }
}