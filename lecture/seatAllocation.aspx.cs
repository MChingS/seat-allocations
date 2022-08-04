using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class seatAllocation : System.Web.UI.Page
{
    OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["mchingis"].ConnectionString);

    Label[] labName = new Label[100];
    Label[] LabCap = new Label[100];
    Label[] labStruct = new Label[100];
    CheckBox[] labCheck = new CheckBox[100];
    CheckBox[] pcName = new CheckBox[800];
    int labTot = 0;
    DateTime tod = DateTime.Today;

    public static List<string> studNoList = new List<string>();
    public static List<string> pcStatusList = new List<string>();
    public static List<string> pcNamesList = new List<string>();
    public static List<string> upDatePCStat = new List<string>();
    public static List<string> pcNameUpdate = new List<string>();
    string usernamF = "";
    int empidF = 0;
    int maxCapLabs = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["AddedControl"] = false;
        Session["requested"] = (HttpContext.Current.Request.Url.AbsoluteUri);

        maxCapLabs = 0;
        if (spacingType.SelectedIndex < 0)
        {
            spacingType.SelectedIndex = 2;
        }
        if (Session["username"] == null || Session["role"] == null)
        {
            Response.Redirect("~/homepage.aspx");
        }
        else if (Session["role"].ToString() != "lectu")
        {
            Response.Redirect("~/unautorized.aspx");
        }
        else
        {
            Session["requested"] = null;
            usernamF = Session["username"].ToString();
            studUsername.Text = usernamF;
            warning.Visible = false;
            createLabs();
            warn1.Visible = false;

        }
        conn.Open();
        if (subjectList.Items.Count == 1)
        {
            string code = courseList.SelectedItem.ToString();
            String colect = "SELECT subjCode,e.empid,jobcode FROM tblsubj_emp se,tblemployee e WHERE empUsername = '" + usernamF + "' AND se.empid = e.empid";
            OdbcDataAdapter adapt = new OdbcDataAdapter(colect, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            //subjectList.Items.Clear();
            if (myTable.Rows.Count < 1)
            {
                subjectList.Items.Add("No subjects available");
            }
            else if (subjectList.Items.Count == 1)
            {

                foreach (DataRow dat in myTable.Rows)
                {
                    DataRow temp = dat;
                    string labN = temp["subjCode"].ToString();
                    Session["idNum"] = temp["empid"].ToString(); ;
                    //Convert.ToInt32(temp["empid"]);
                    subjectList.Items.Add(labN);
                }

            }
        }

        if (subjectList.SelectedIndex==0)
        {
            Label6.Visible = true;
        }
        else
        {
            Label6.Visible = false;

        }
        conn.Close();
        empidF = Convert.ToInt32(Session["idNum"]);
        studNo.Text = empidF.ToString();
        timeLoged.Text = DateTime.Now.ToString();
    }
    public void createLabs()
    {
        conn.Open();

        string colect = "SELECT * FROM tblvenue WHERE venDesc = 'lab' AND venStatus=1";
        OdbcDataAdapter adapt = new OdbcDataAdapter(colect, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];

        string labN;
        DataRow temp;
        int i = 0;
        foreach (DataRow dat in myTable.Rows)
        {
            temp = dat;
            labN = temp["venCode"].ToString();
            labName[i] = new Label();
            labName[i].Width = 100;
            labName[i].Text = labN;

            int numm = Convert.ToInt32(temp["venNumSeats"]);
            LabCap[i] = new Label();
            LabCap[i].Width = 100;
            LabCap[i].Text = numm.ToString();

            string stru = temp["venStructure"].ToString();

            labStruct[i] = new Label();
            labStruct[i].Width = 100;
            labStruct[i].Text = stru;

            labCheck[i] = new CheckBox();
            labCheck[i].Width = 100;
            labCheck[i].ID = labN;
            Label leftNu = new Label();
            leftNu.Width = 100;

            string d, m, y;

            string dd = slotDate.SelectedDate.ToString();
          /*  Response.Write(dd)*/;
            d = dd.Substring(0, 2);
            m = dd.Substring(3, 3);
            y = dd.Substring(7, 2);

            if (m == "Aug")
            {
                m = 08.ToString();
            }
            if (m == "Sep")
            {
                m = 09.ToString();
            }
            if (m == "Oct")
            {
                m = 10.ToString();
            }
            if (m == "Nov")
            {
                m = 11.ToString();
            }
            if (m == "Dec")
            {
                m = 12.ToString();
            }
            dd = y + "-" + m + "-" + d;
            int max = 0;
            if (spacingType.SelectedIndex == 2)
            {
                string colect1 = "SELECT COUNT(pcname) FROM tblseatallocation WHERE substr(pcname,1,5) = '" + labName[i].Text
            + "' AND seatallocDate = '" + slotDate1.Text + "' AND seatallocSlot = '" + slots.SelectedValue.ToString()
            + "'";
                adapt = new OdbcDataAdapter(colect1, conn);
                dts = new DataSet();
                adapt.Fill(dts);
                DataTable myTable1 = dts.Tables[0];
               
                foreach (DataRow data in myTable1.Rows)
                {
                    max = Convert.ToInt32(data["COUNT(pcname)"]);
                   
                    int leftNum = numm - max;
                    leftNu.Text = (leftNum).ToString();
                   // maxCapLabs = (numm - max);
                }
            }
            if (spacingType.SelectedIndex != 2)
            {
                int g = 1;
                if(spacingType.SelectedIndex ==0)
                {
                    g = 2;
                }
                    
                

                for (int x = g; x < numm + 1; x=x+2)
                {
                    string pcll = "";
                    if (x < 10)
                    {
                        pcll = labName[i].Text + "PC0" + x.ToString();
                    }
                    else
                    {
                        pcll = labName[i].Text + "PC" + x.ToString();
                    }
                    string colect1 = "SELECT COUNT(pcname) FROM tblseatallocation WHERE pcname = '" + pcll
                + "' AND seatallocDate = '" + slotDate1.Text + "' AND seatallocSlot = '" + slots.SelectedValue.ToString()
                + "'";
                    adapt = new OdbcDataAdapter(colect1, conn);
                    dts = new DataSet();
                    adapt.Fill(dts);
                    DataTable myTable1 = dts.Tables[0];

                    foreach (DataRow data in myTable1.Rows)
                    {
                        max = max + Convert.ToInt32(data["COUNT(pcname)"]);
                    }
                }

                numm = numm / 2;
                int leftNum = numm - max;
                leftNu.Text = (leftNum).ToString();

            }
            if (max != numm)

            {
                //if (max + 5 < numm)
                {
                    labControler.Controls.Add(labName[i]);
                    labControler.Controls.Add(LabCap[i]);
                    labControler.Controls.Add(leftNu);
                    labControler.Controls.Add(labStruct[i]);
                    labControler.Controls.Add(labCheck[i]);

                }
            }


            ViewState["AddedControl"] = false;
            labTot++;
            i++;
        }
        Label b = new Label();
        b.Width = 500;
        labControler.Controls.Add(b);
        Label lable = new Label();
        lable.Text = "\n YOU CAN CHANGE SPACING TYPE \n TO GET MORE SPACE";
        //labControler.Controls.Add(lable);

        colect = "SELECT * FROM tblcourse";
        adapt = new OdbcDataAdapter(colect, conn);
        dts = new DataSet();
        adapt.Fill(dts);
        myTable = dts.Tables[0];

        i = 0;
        if (courseList.Items.Count < 2)
        {
            foreach (DataRow dat in myTable.Rows)
            {
                temp = dat;
                labN = temp["courseCode"].ToString();
                courseList.Items.Add(labN);
            }
        }
        conn.Close();
        if (labControler.Controls.Count < 12)
        {
            // Label lable = new Label();
            lable.Text = "\n You Can Also Change Slot Or Date For More Space";
            labControler.Controls.Add(lable);
        }
        // Response.Write(maxCapLabs);

    }
    protected void courseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        labControler.Visible = false;
        nextToPc.Visible = false;
        Panel2.Visible = false;
        seatName.Visible = false;
        //numStudeUpdates.Visible = false;
        if (courseList.SelectedIndex != 0)
        {
            conn.Open();
            string code = courseList.SelectedItem.ToString();
            String colect = "SELECT * FROM tblsubject WHERE courseCode ='" + code + "' AND subPractical_Theory='Practical'; ";
            OdbcDataAdapter adapt = new OdbcDataAdapter(colect, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            subjectList.Items.Clear();
            if (myTable.Rows.Count < 1)
            {
                subjectList.Items.Add("No subjects available");
            }
            else
            {
                foreach (DataRow dat in myTable.Rows)
                {
                    DataRow temp = dat;
                    string labN = temp["subjCode"].ToString();
                    subjectList.Items.Add(labN);
                }
                checkdDup();
                Panel2.Visible = false;
                labControler.Controls.Clear();
                createLabs();
            }
            conn.Close();
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        checkAgain();
        
    }
    public void checkAgain()
    {

        Panel2.Visible = false;
        string check = "SELECT subjCode,subjVenSlot,subjVenDate";
        check += " FROM tblsubj_venue";
        check += " WHERE subjCode = '" + subjectList.SelectedItem.ToString() + "'";
        check += " AND subjVenSlot = '" + slots.SelectedItem.ToString() + "'";
        check += " AND subjVenDate = '" + slotDate1.Text + "'";
        OdbcDataAdapter adapt = new OdbcDataAdapter(check, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];
        if (myTable.Rows.Count > 0)
        {
            //ScriptManager.RegisterStartupScript(this,
            //  this.GetType(),
            // "script",
            // "confirm('The seatallocation already exist');", true);
            warning.Visible = true;
            warning.Text = "The seatallocation already exist";
            warn1.Visible = false;
            Panel1.Visible = false;
            labControler.Visible = false;
            nextToPc.Visible = false;
        }
        else
        {
            numStudeUpdates.Visible = false;
            seatName.Visible = false;
            if (slotDate.SelectedDate < DateTime.Today)
            {
                //ScriptManager.RegisterStartupScript(this,
                // this.GetType(),
                //"script",
                //"confirm('Date selected is invalid todays date will be selected');", true);
                warning.Visible = true;
                warning.Text = "Date selected is invalid todays date will be selected";
                slotDate.SelectedDate = DateTime.Today;
            }
            else
            {
                labControler.Visible = true;
                nextToPc.Visible = true;
                Panel1.Visible = true;
            }
        }
    }
    protected void nextToPc_Click(object sender, EventArgs e)
    {
        if (Label6.Visible == true)
        {
            seatName.Visible = false;
        }
        else
        {
            bool checkDupi = false;
            pcControlerBy3.Visible = true;
            pcControlerBy4.Visible = true;
            pcControlerBy5.Visible = true;


            string check = "SELECT subjCode,subjVenSlot,subjVenDate";
            check += " FROM tblsubj_venue";
            check += " WHERE subjCode = '" + subjectList.SelectedItem.ToString() + "'";
            check += " AND subjVenSlot = '" + slots.SelectedItem.ToString() + "'";
            check += " AND subjVenDate = '" + slotDate.SelectedDate.ToShortDateString() + "'";
            OdbcDataAdapter adapt = new OdbcDataAdapter(check, conn);
            DataSet dts = new DataSet();
            adapt.Fill(dts);
            DataTable myTable = dts.Tables[0];
            if (myTable.Rows.Count > 0)
            {
                //ScriptManager.RegisterStartupScript(this,
                //  this.GetType(),
                // "script",
                // "confirm('The seatallocation already exist');", true);
                warning.Visible = true;
                warning.Text = "The seatallocation already exist";
            }
            if (checkDupi == false)
            {

                createSeats();
                Panel2.Visible = true;
                numStudeUpdates.Visible = true;
                seatName.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
            }

            var loaded = numStudeUpdates.Text.Split(' ');
            if (loaded.Length > 0)
            {
                string allocated = loaded[0];
                string tot = loaded[5];
                //Response.Write(allocated + "\t" + tot);

                if (allocated == tot)
                {
                    saveToDB.Enabled = true;
                    labsNeed.Visible = false;
                }
                else
                {
                    saveToDB.Enabled = false;
                    labsNeed.Visible = true;
                }
            }

            pcControlerBy4.Visible = true;
        }
    }
    public void createSeats()
    {
        pcNamesList.Clear();
        //pcControlerBy3.Controls.Clear();
        //pcControlerBy4.Controls.Clear();
        //pcControlerBy5.Controls.Clear();

        if (subjectList.SelectedIndex != 0)
            pcControlerBy4.Visible = true;
        int sum;
        studNoList.Clear();
        List<string> studNoList2 = new List<string>();
        studNoList2.Clear();
        string getStud = "SELECT * from tblsubj_stud ss,tblstudent s where ss.studno=s.studno AND subjCode='"
            + subjectList.SelectedItem.ToString() + "'";
        conn.Open();
        string code = courseList.SelectedItem.ToString();
        OdbcDataAdapter adapt = new OdbcDataAdapter(getStud, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];

        foreach (DataRow data in myTable.Rows)
        {
            DataRow temp = data;
            studNoList.Add(temp["studNo"].ToString());
           // studNoList2.Add(temp["studNo"].ToString());
        }
        conn.Close();
        //Response.Write(studNoList.Count);
        sum = studNoList.Count;

        int labChecked = 0;
        String labNames = "";
        int heightLa = 1205;
        seatName.Text = "Seat Allocation For " + subjectList.SelectedItem.ToString();
        List<string> myRandom = new List<string>();
        
        for (int l = 0; l < labTot; l++)
        {
            if (labCheck[l].Checked == true)
            {
                labNames = labName[l].Text;
                labChecked++;
                string cap = LabCap[l].Text;
                int capInt = Convert.ToInt32(cap);
                //adding pc to pc controller
                int by4 = 4;
                int by3 = 0;
                int by6 = 0;
             
                for (int x = 1; x < capInt + 1; x++)
                {
                    int max = studNoList.Count;
                    int num = 0; int total = 0;
                    studNoList.Sort();
                    Random number = new Random();
                    num = number.Next(0, max);

                    string student;
                    bool removePc = true ;
                    if (studNoList.Count > 0)
                    {
                        total++;
                        //Response.Write(num + "\t" +total+"\t//");
                        student = studNoList[num].ToString();
                        string pcll="";
                        if (x < 10)
                        {
                            pcll = labNames + "PC0" + x.ToString();
                        }
                        else
                        {
                            pcll = labNames + "PC" + x.ToString();
                        }
                        string select1 = "SELECT studNo,pcName FROM tblseatallocation WHERE studNo =" +
                         student + " AND pcName = '" + pcll + "'";
                        OdbcDataAdapter adapt1 = new OdbcDataAdapter(select1, conn);
                        DataSet dts1 = new DataSet();
                        adapt1.Fill(dts1);
                        DataTable myTable1 = dts1.Tables[0];

                        while (myTable1.Rows.Count > 0 && max >1)
                        {
                            num = number.Next(0, max);
                            student = studNoList[num].ToString();
                             select1 = "SELECT studNo,pcName FROM tblseatallocation WHERE studNo =" +
                             student + " AND pcName = '" + pcll + "'";
                             adapt1 = new OdbcDataAdapter(select1, conn);
                             dts1 = new DataSet();
                            adapt1.Fill(dts1);
                             myTable1 = dts1.Tables[0];

                        }

                   }

                    else
                    {
                        break;
                        // or use 00000 to show no one is seated
                        student = "000000000";
                    }
                    //////////////////////////////////////
                    if (labStruct[l].Text == "4X4")
                    {
                      
                        if (x == 1)
                        {
                            Label xxx = new Label();
                            pcControlerBy4.Controls.Add(xxx);
                            xxx.Text = labNames;
                            xxx.Width = heightLa;

                            xxx.Height = 30;
                            xxx.Font.Bold = true;
                            xxx.Font.Size = 15;
                        }
                        if (by4 == 8)
                        {
                            Label lll = new Label();
                            pcControlerBy4.Controls.Add(lll);
                            by4 = 0;
                            lll.Width = 110;
                            heightLa = 995;
                        }
                        pcControlerBy4.Width = 990;
                        by4++;
                        String pcNameInuse = "";
                        pcName[x] = new CheckBox();
                        pcName[x].Width = 110;
                        // get pc sattus
                        if (x < 10)
                        {
                            pcName[x].Text = labNames + "PC0" + x.ToString();
                        }
                        else
                        {
                            pcName[x].Text = labNames + "PC" + x.ToString();
                        }
                        pcNameInuse = pcName[x].Text;
                        // pcNamesList.Add(pcName[x].Text.ToString());
                        getStud = "SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcBrocken";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcBrocken";
                            }
                            //pcName[x].Checked = true;
                            removePc = false;
                        }
                        else
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " " + student;
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " " + student;
                            }
                            //remove student number after adding it
                            removePc = true;
                        }
                        // check if pc is in use
                        getStud = "SELECT pcName,seatAllocDate,seatallocSlot,seatSpacing FROM tblSeatallocation WHERE pcName='" + pcNameInuse
                         + "' AND seatAllocDate = '" + slotDate1.Text + "' AND seatallocSlot='"
                         + slots.SelectedItem.ToString() + "'";// AND seatSpacing ='" + spacingType.SelectedValue.ToString() + "'";
                        //"SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcIsInUse";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcIsInUse";
                            }
                            // pcName[x].Checked = true;
                            removePc = false;
                        }
                        //check the spacing
                        if (spacingType.SelectedIndex == 0)
                        {
                            if (x % 2 == 0)
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy4.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                            else
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy4.Controls.Add(pcName[x]);
                            }

                        }
                        if (spacingType.SelectedIndex == 1)
                        {
                            if (x % 2 == 0)
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy4.Controls.Add(pcName[x]);
                            }
                            else
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy4.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                        }
                        if (spacingType.SelectedIndex == 2 || spacingType.SelectedIndex < 0)
                        {
                            pcNamesList.Add(labName[l].Text + pcName[x].Text);
                            pcName[x].TextAlign = TextAlign.Left;
                            pcControlerBy4.Controls.Add(pcName[x]);
                            if (removePc == true)
                            {
                                if (studNoList.Count > 0)
                                {
                                    studNoList.RemoveAt(num);
                                }
                            }
                        }

                        if (x == capInt)
                        {
                            Label lll = new Label();
                            lll.Width = 1205;
                            lll.Height = 15;
                            pcControlerBy4.Controls.Add(lll);
                        }
                    }
                    //////////////////////////////////////
                    if (labStruct[l].Text == "3X5X3")
                    {
                       // bool removePc = false;
                        heightLa = 1285;
                        if (x == 1)
                        {
                            Label xxx = new Label();
                            pcControlerBy3.Controls.Add(xxx);
                            xxx.Text = labNames;
                            xxx.Width = heightLa;
                            xxx.Height = 30;
                            xxx.Font.Bold = true;
                            xxx.Font.Size = 15;
                        }
                        if (by3 == 3 || by3 == 8)
                        {
                            Label xxx = new Label();
                            pcControlerBy3.Controls.Add(xxx);
                            if (by3 == 8)
                            {
                                by3 = -3;
                            }
                            xxx.Width = 35;
                        }
                        by3++;
                        pcControlerBy3.Width = 1290;

                        pcName[x] = new CheckBox();
                        pcName[x].Width = 110;
                        string pcNameInuse = "";
                        //pcName[x].Text = labNames + "PC" + x.ToString();
                        if (x < 10)
                        {
                            pcName[x].Text = labNames + "PC0" + x.ToString();
                        }
                        else
                        {
                            pcName[x].Text = labNames + "PC" + x.ToString();
                        }
                        pcNameInuse = pcName[x].Text;
                        getStud = "SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcBrocken";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcBrocken";
                            }
                           removePc = false;
                            // pcName[x].Checked = true;
                        }
                        else
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " " + student;
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " " + student;
                            }
                            //remove student number after adding it
                            removePc = true;
                        }
                        // check if pc is in use
                        getStud = "SELECT pcName,seatAllocDate,seatallocSlot FROM tblSeatallocation WHERE pcName='" + pcNameInuse
                         + "' AND seatAllocDate = '" + slotDate1.Text + "' AND seatallocSlot='" + slots.SelectedItem.ToString()
                         + "'";// AND seatSpacing ='" + spacingType.SelectedValue.ToString() + "'"; ;
                        //"SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcIsInUse";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcIsInUse";
                            }
                            //pcName[x].Checked = true;
                            removePc = false;
                        }
                        if (spacingType.SelectedIndex == 0)
                        {
                            if (x % 2 == 0)
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy3.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                            else
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy3.Controls.Add(pcName[x]);
                            }

                        }
                        if (spacingType.SelectedIndex == 1)
                        {
                            if (x % 2 == 0)
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy3.Controls.Add(pcName[x]);
                            }
                            else
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy3.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                        }
                        if (spacingType.SelectedIndex == 2 || spacingType.SelectedIndex < 0)
                        {
                            pcNamesList.Add(labName[l].Text + pcName[x].Text);
                            pcName[x].TextAlign = TextAlign.Left;
                            pcControlerBy3.Controls.Add(pcName[x]);
                            if (removePc == true)
                            {
                                if (studNoList.Count > 0)
                                {
                                    studNoList.RemoveAt(num);
                                }
                            }
                        }


                        if (x == capInt)
                        {
                            Label lll = new Label();
                            lll.Width = 1205;
                            lll.Height = 15;
                            pcControlerBy3.Controls.Add(lll);
                        }

                        Panel2.Visible = true;
                    }
                    /////////////////////////////////
                    if (labStruct[l].Text == "5X5")
                    {
                        //bool removePc = false;

                        heightLa = 1260;
                        if (x == 1)
                        {
                            Label xxx = new Label();
                            pcControlerBy5.Controls.Add(xxx);
                            xxx.Text = labNames;

                            xxx.Width = heightLa;
                            xxx.Height = 30;
                            xxx.Font.Bold = true;
                            xxx.Font.Size = 15;
                        }
                        if (by6 == 5)
                        {
                            Label xxx = new Label();
                            pcControlerBy5.Controls.Add(xxx);
                            if (by6 == 5)
                            {
                                by6 = -5;
                            }
                            xxx.Width = 100;
                        }
                        by6++;
                        pcControlerBy5.Width = 1260;
                        string pcNameInuse;
                        pcName[x] = new CheckBox();
                        pcName[x].Width = 110;
                        if (x < 10)
                        {
                            pcName[x].Text = labNames + "PC0" + x.ToString();
                        }
                        else
                        {
                            pcName[x].Text = labNames + "PC" + x.ToString();
                        }
                        pcNameInuse = pcName[x].Text;
                        getStud = "SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcBrocken";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcBrocken";
                            }
                            removePc = false;
                            // pcName[x].Checked = true;

                        }
                        else
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " " + student;
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " " + student;
                            }
                            //remove student number after adding it
                            removePc = true;
                        }
                        // check if pc is in use
                        getStud = "SELECT pcName,seatAllocDate,seatallocSlot FROM tblSeatallocation WHERE pcName='" + pcNameInuse
                         + "' AND seatAllocDate = '" + slotDate1.Text + "' AND seatallocSlot='"
                         + slots.SelectedItem.ToString() + "'";// AND seatSpacing ='" + spacingType.SelectedValue.ToString() + "'";
                        //"SELECT pcName FROM tblPc where pcName='" + pcName[x].Text.ToString() + "' and pcstatus='0'";
                        adapt = new OdbcDataAdapter(getStud, conn);
                        dts = new DataSet();
                        adapt.Fill(dts);
                        myTable = dts.Tables[0];
                        if (myTable.Rows.Count > 0)
                        {
                            if (x < 10)
                            {
                                pcName[x].Text = "PC0" + x.ToString() + " PcIsInUse";
                            }
                            else
                            {
                                pcName[x].Text = "PC" + x.ToString() + " PcIsInUse";
                            }
                            //pcName[x].Checked = true;
                            removePc = false;
                        }
                        //check the spacing
                        if (spacingType.SelectedIndex == 0)
                        {
                            if (x % 2 == 0)
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy5.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                            else
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy5.Controls.Add(pcName[x]);
                            }

                        }
                        if (spacingType.SelectedIndex == 1)
                        {
                            if (x % 2 == 0)
                            {
                                if (x < 10)
                                {
                                    pcName[x].Text = "PC0" + x.ToString() + " 000000000";
                                }
                                else
                                {
                                    pcName[x].Text = "PC" + x.ToString() + " 000000000";
                                }
                                //pcName[x].Checked = true;
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy5.Controls.Add(pcName[x]);
                            }
                            else
                            {
                                pcNamesList.Add(labName[l].Text + pcName[x].Text);
                                pcName[x].TextAlign = TextAlign.Left;
                                pcControlerBy5.Controls.Add(pcName[x]);
                                if (removePc == true)
                                {
                                    if (studNoList.Count > 0)
                                    {
                                        studNoList.RemoveAt(num);
                                    }
                                }
                            }
                        }
                        if (spacingType.SelectedIndex == 2 || spacingType.SelectedIndex < 0)
                        {
                            pcNamesList.Add(labName[l].Text + pcName[x].Text);
                            pcName[x].TextAlign = TextAlign.Left;
                            pcControlerBy5.Controls.Add(pcName[x]);
                            if (removePc == true)
                            {
                                if (studNoList.Count > 0)
                                {
                                    studNoList.RemoveAt(num);
                                }
                            }
                        }

                        if (x == capInt)
                        {
                            Label lll = new Label();
                            lll.Width = 1255;
                            lll.Height = 15;
                            //pcControlerBy5.Controls.Add(lll);
                        }
                        Panel2.Visible = true;
                    }
                    pcName[x].Enabled = false;
                }
            }
        }
        int used = 0;
        used = sum - studNoList.Count;
        numStudeUpdates.Text = used + " students allocated out of " + sum;
    }
    protected void exit_Click(object sender, EventArgs e)
    {
        Session["role"] = null;
        Session["username"] = null;
        Response.Redirect("~/homepage.aspx");
    }
    protected void subjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        subjectList.AutoPostBack = true;
        conn.Open();
        string nuStud = "SELECT count(s.studNo) FROM tblsubj_stud ss,tblstudent s where ss.studno = s.studno AND subjCode='"
            + subjectList.SelectedItem.ToString() + "';";
        OdbcDataAdapter adapt = new OdbcDataAdapter(nuStud, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];

        foreach (DataRow dat in myTable.Rows)
        {
            DataRow temp = dat;
            String labN = temp["count(s.studNo)"].ToString();
            numOfStud.Text = labN;

        }
        conn.Close();
        checkdDup();
        Panel2.Visible = false;
        labControler.Controls.Clear();
        createLabs();
        nextToLab.Visible = true;
    }
    protected void saveToDB_Click(object sender, EventArgs e)
    {
        //1
        if (spacingType.SelectedIndex < 0)
        {
            spacingType.SelectedIndex = 2;
        }
        //createSeats();
        //DateTime dd = Convert.ToDateTime(slotDate.SelectedDate.ToShortDateString());
        // Response.Write(dd);
        string dd = slotDate.SelectedDate.ToShortDateString();
        string d, m, y;
        d = dd.Substring(0, 2);
        m = dd.Substring(3, 3);
        y = dd.Substring(7, 2);
        //Response.Write(d + "-" + m + "-20" + y + "\t" + dd);
        dd = d + "-" + m + "-20" + y;
        dd = slotDate1.Text;
        conn.Open();
        // insert to tbl tblsubj_venue 
        for (int l = 0; l < labTot; l++)
        {
            if (labCheck[l].Checked == true)
            {
                string labNames = labName[l].Text;
                string addStud = "INSERT INTO tblsubj_venue (subjCode,venCode,subjvenSlot,subjvenDate,empid) values('"
                  + subjectList.SelectedItem.ToString() + "','" + labNames + "','" + slots.SelectedItem.ToString() + "','"
                  + dd + "','" + empidF + "')";
                OdbcCommand cmd = new OdbcCommand(addStud, conn);
                cmd.ExecuteNonQuery();
            }
        }

        for (int i = 0; i < pcNamesList.Count; i++)
        {
            string namPc = pcNamesList[i].Substring(0, 9);
            string studNoo = pcNamesList[i].Substring(10);
            int outPut;


            if (int.TryParse(studNoo, out outPut) && studNoo != "000000000")
            {
                string selec = "SELECT * FROM tblseatallocation WHERE studNo='" + studNoo + "' AND pcName='" + namPc
                    + "' AND subjCode='"
                    + subjectList.SelectedItem.ToString() + "' AND seatAllocDate='" + dd
                    + "'AND seatAllocSlot='" + slots.SelectedItem.ToString() + "'";
                OdbcDataAdapter adapt = new OdbcDataAdapter(selec, conn);
                DataSet dts = new DataSet();
                adapt.Fill(dts);
                DataTable myTable = dts.Tables[0];
                if (myTable.Rows.Count > 0)
                {

                }
                else
                {
                    //insert into seatallocation
                    string addStud = "INSERT INTO tblseatallocation (studNo,pcName,subjCode,seatAllocDate,seatAllocSlot,seatSpacing) values('"
                          + studNoo + "','" + namPc + "','" + subjectList.SelectedItem.ToString() + "','"
                          + dd + "','" + slots.SelectedItem.ToString() + "','" + spacingType.SelectedValue.ToString() + "')";
                    OdbcCommand cmd = new OdbcCommand(addStud, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        conn.Close();
        saveToDB.Enabled = false;
        pcNamesList.Clear();
        warn1.Visible = true;
        warn1.Text = "The seatallocation is successfully created";
        Panel2.Visible = false;
        pcControlerBy3.Visible = false;
        pcControlerBy4.Visible = false;
        pcControlerBy5.Visible = false;
        labControler.Visible = false;
        labControler.Controls.Clear();
        nextToPc.Visible = false;
        Panel1.Visible = false;
        slotDate.Controls.Clear();
    }
    protected void slots_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        nextToPc.Visible = false;
        Panel2.Visible = false;
        seatName.Visible = false;
        labControler.Visible = false;
        labControler.Controls.Clear();
        createLabs();
    }
    protected void slotDate_SelectionChanged(object sender, EventArgs e)
    {
        if (slotDate.SelectedDate < DateTime.Today)
        {
            warning.Visible = true;
            warning.Text = "Date selected is invalid todays date will be selected";
            slotDate.SelectedDate = DateTime.Today;
        }
        checkdDup();
        Panel2.Visible = false;
        labControler.Controls.Clear();
        createLabs();
    }
    public void checkdDup()
    {
        string check = "SELECT subjCode,subjVenSlot,subjVenDate";
        check += " FROM tblsubj_venue";
        check += " WHERE subjCode = '" + subjectList.SelectedItem.ToString() + "'";
        check += " AND subjVenSlot = '" + slots.SelectedItem.ToString() + "'";
        check += " AND subjVenDate = '" + slotDate.SelectedDate.ToShortDateString() + "'";
        OdbcDataAdapter adapt = new OdbcDataAdapter(check, conn);
        DataSet dts = new DataSet();
        adapt.Fill(dts);
        DataTable myTable = dts.Tables[0];
        if (myTable.Rows.Count > 0)
        {
            //ScriptManager.RegisterStartupScript(this,
            //  this.GetType(),
            // "script",
            // "confirm('The seatallocation already exist');", true);
            warning.Visible = true;
            warning.Text = "The seatallocation already exist";
            nextToPc.Visible = false;
            saveToDB.Enabled = false;
            pcControlerBy3.Visible = false;
            pcControlerBy4.Visible = false;
            pcControlerBy5.Visible = false;
            numStudeUpdates.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            labControler.Visible = false;
        }
    }
    protected void spacingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //createSeats();
        nextToPc.Visible = false;
        Panel2.Visible = false;
        seatName.Visible = false;
        labControler.Controls.Clear();
        createLabs();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/lecture/complexLectu.aspx");
    }

    protected void slotDate1_TextChanged(object sender, EventArgs e)
    {
        slotDate.SelectedDate = Convert.ToDateTime(slotDate1.Text);

        if (slotDate.SelectedDate < DateTime.Today)
        {
            warning.Visible = true;
            warning.Text = "Date selected has passed";
            slotDate.SelectedDate = DateTime.Today;
            slotDate1.Text = "";
        }
        checkAgain();


        checkdDup();
        Panel2.Visible = false;
        labControler.Controls.Clear();
        createLabs();

    }
}