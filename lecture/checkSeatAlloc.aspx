<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="checkSeatAlloc.aspx.cs" Inherits="checkSeatAlloc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            float: left;
            border-radius: 5px 5px 5px 5px;
            width: 59%;
            align-content: stretch;
            align-items: stretch;
            min-height: 300px;
            height: 100%;
        }
        .auto-style2 {
            width: 87px;
             min-height: 300px;
             height: 100%;
        }
        .auto-style3 {
            float: left;
            border-radius: 5px 5px 5px 5px;
            width: 59%;
            align-content: stretch;
            align-items: stretch;
            /*min-height: 300px;*/
            height: 100%;
        }
        .auto-style4 {
            border-radius: 5px 5px 5px 5px;
        }
        .auto-style5 {
            border-radius: 5px 5px 5px 5px;
            align-content: stretch;
            align-content:center;
            width:39%;
            float:left;
            height: 280px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="auto-style3">
        <asp:Button ID="Button1" runat="server" Text="BACK" OnClick="Button1_Click" Visible="False" />
            <h3 align="center">Available Seat Allocations</h3>
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT subjCode
FROM tblsubj_emp se,tblemployee e
WHERE empusername = ?
AND e.empid = se.empid">
        <SelectParameters>
            <asp:SessionParameter Name="?" SessionField="username" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" align="center" CellSpacing="7" CellPadding="7" DataSourceID="SqlDataSource1" 
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True"></asp:GridView>
    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" 
        SelectCommand="SELECT subjCode AS 'Subject Code',subjvenslot AS Slot, Date_Format(subjvenDate,'%Y-%m-%d') as Date
FROM tblsubj_venue sv,tblemployee e
WHERE empusername =?
AND sv.empId = e.empid
GROUP BY subjCode,subjvenDate
ORDER BY subjvenDate" >
        <SelectParameters>
            <asp:SessionParameter Name="?" SessionField="username" />
        </SelectParameters>
     
    </asp:SqlDataSource>
        <p align="center">
            &nbsp;
        <asp:Button ID="Button2" runat="server" Text="VIEW SEAT ALLOCATION LIST" OnClick="Button2_Click" />
        </p>

        </div>
     
    <div id="det" class="auto-style5">
         
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
        <asp:Image ID="Image1" CssClass="image" runat="server" ImageUrl="~/images/admin.png" />
        <br />
        <br />
         <table align="center" class="mytable">
             <tr>
        <td><asp:Label ID="Label1" runat="server" Text=" Username :"></asp:Label></td>
         <td class="auto-style2"><asp:Label ID="studUsername" runat="server" Text="current user"></asp:Label></td>
        </tr>
             <tr>
        <td><asp:Label ID="Label5" runat="server" Text=" Stuff No :"></asp:Label></td>
       <td class="auto-style2">  <asp:Label ID="studNo" runat="server" Text="current stud"></asp:Label></td>
        </tr>
        
        <tr>
        <td> <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label></td>
        <td class="auto-style2">  <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label></td>
            </tr>
            </table>
        <p align="center">
            &nbsp;</p>
       
    </div>
   <asp:Panel ID="Panel2" Visible="false" runat="server">
     <div class="auto-style1">
         <p align="center">
                <br />
                <asp:DropDownList ID="subjectList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="subjectList_SelectedIndexChanged" CssClass="drop">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dateList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dateList_SelectedIndexChanged" CssClass="drop">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT  Date_Format(seatAllocDate,'%Y-%m-%d') as seatAllocDate,seatAllocDate  as dd  FROM tblseatallocation WHERE subjCode = ? GROUP BY seatAllocDate">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="subjectList" Name="?" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT studNo AS &quot;Student  Number&quot;,pcName AS &quot;PC Number&quot;,subjCode AS &quot;Subject Code&quot;,Date_Format(seatAllocDate,'%Y-%m-%d') AS &quot;Date&quot;,seatAllocSlot AS &quot;Slot&quot; FROM tblseatallocation WHERE subjCode =? AND  seatAllocDate= ? ORDER BY pcName">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="subjectList" Name="?" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="dateList" Name="?" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </p>
        &nbsp;&nbsp;&nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="303px" ScrollBars="Vertical">
        <div id="myview">
            
            <asp:GridView ID="GridView2" align="Center" runat="server" DataSourceID="SqlDataSource4" CellPadding="5" ShowHeaderWhenEmpty="True"></asp:GridView>
            <br />
         </div>
            
        </asp:Panel>

            <p align="center">
                <button id="SAVE" onclick="printo()">
                    Save/Print</button>
            </p>

    </div>
    </asp:Panel>
     <p align="right">
            &nbsp;
     
                  <asp:Button ID="exit" runat="server"  Text="LOGOUT" Width="66px" OnClick="exit_Click" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" PostBackUrl="~/homepage.aspx" CssClass="auto-style4" />
            </p>
       <script>

        function printo() {
            var printContents = document.getElementById("myview").innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;

            return true;
        }
    </script>

</asp:Content>


