<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            border-radius: 5px 5px 5px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    
    <div align="center" class="myleft1">
        <h4>&nbsp;</h4>
        <h4>&nbsp;</h4>
        <h4>Types Of Report</h4>
            <asp:Button ID="Button6" runat="server" Text="Summary" OnClick="Button6_Click" />
            <br />
        <br />
            <asp:Button ID="Button5" runat="server" Text="Detailed Reports" OnClick="Button5_Click" />
    </div>
    <div id="myview" align="center" class="myright1">
         <asp:Panel ID="Panel1" align="Center" CssClass="button" runat="server">
            <asp:Button ID="Button1" CssClass="auto-style1" runat="server" Text="Seat Allocations" OnClick="Button1_Click" Width="118px" />
            <asp:Button ID="Button2" CssClass="auto-style1" runat="server" Text="Available Computers" OnClick="Button2_Click" Width="145px" />
            <asp:Button ID="Button3" CssClass="auto-style1" runat="server" Text="Unavailable Computers" OnClick="Button3_Click" Width="144px" />
            <asp:Button ID="Button4" CssClass="auto-style1" runat="server" Text="Venues " OnClick="Button4_Click" Width="93px" />
        </asp:Panel>
        <br />
         <asp:Panel ID="Panel4" runat="server" align="Center" CssClass="button">
            <asp:Button ID="Button7" runat="server" CssClass="auto-style1"  Text="Lab Summary" OnClick="Button7_Click" Width="118px" />
            <asp:Button ID="Button8" runat="server" CssClass="auto-style1" Text="Test Summary" OnClick="Button8_Click" Width="117px" />
        </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="350px" ScrollBars="Vertical">
       <div id="mchingis"class="newDev">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Subjecet Code,Venue,Slot" DataSourceID="getReport" Visible="False">
            
            <Columns>
                <asp:BoundField DataField="Subjecet Code" HeaderText="Subjecet Code" ReadOnly="True" SortExpression="Subjecet Code" />
                <asp:BoundField DataField="Venue" HeaderText="Venue" ReadOnly="True" SortExpression="Venue" />
                <asp:BoundField DataField="Slot" HeaderText="Slot" ReadOnly="True" SortExpression="Slot" />
                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
            </Columns>
            
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="getPcWorking">
          
            <Columns>
                <asp:BoundField DataField="Venue" HeaderText="Venue" ReadOnly="True" SortExpression="Venue" />
                <asp:BoundField DataField="Pc Number" HeaderText="Pc Number" ReadOnly="True" SortExpression="Pc Number" />
                <asp:BoundField DataField="Pc Status" HeaderText="Pc Status" SortExpression="Pc Status" />
            </Columns>
          
        </asp:GridView>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="pcName" DataSourceID="getPcNotWorkong">
            <Columns>
                <asp:BoundField DataField="pcName" HeaderText="Pc Name" ReadOnly="True" SortExpression="pcName" />
                <asp:BoundField DataField="venCode" HeaderText="Venue Code" SortExpression="venCode" />
                <asp:BoundField DataField="pcNo" HeaderText="Pc Number" SortExpression="pcNo" />
                <asp:BoundField DataField="pcStatus" HeaderText="Pc Status" SortExpression="pcStatus" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="venCode" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="venCode" HeaderText="Venue Code" ReadOnly="True" SortExpression="venCode" />
                <asp:BoundField DataField="venDesc" HeaderText="Venue Desc" SortExpression="venDesc" />
                <asp:BoundField DataField="venNumSeats" HeaderText="Venue NumSeats" SortExpression="venNumSeats" />
                <asp:BoundField DataField="venStatus" HeaderText="Venue Status" SortExpression="venStatus" />
                <asp:BoundField DataField="venRows" HeaderText="Venue Rows" SortExpression="venRows" />
                <asp:BoundField DataField="venBlocks" HeaderText="Venue Blocks" SortExpression="venBlocks" />
                <asp:BoundField DataField="venPcRows" HeaderText="Venue Columns" SortExpression="venPcRows" />
                <asp:BoundField DataField="venStructure" HeaderText="Venue Structure" SortExpression="venStructure" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT * FROM tblvenue
WHERE venDesc='lab'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="getPcNotWorkong" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT * FROM tblPc WHERE pcStatus=0"></asp:SqlDataSource>
        <asp:SqlDataSource ID="getPcWorking" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT substr(pcName,1,5) AS Venue,substr(pcName,6,9) AS 'Pc Number',pcStatus AS 'Pc Status' FROM tblPc WHERE pcStatus=1"></asp:SqlDataSource>
    
   
       
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="venCode" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="venCode" HeaderText="Venue Code" ReadOnly="True" SortExpression="venCode" />
                <asp:BoundField DataField="venNumSeats" HeaderText="Number of Seats" SortExpression="venNumSeats" />
                <asp:BoundField DataField="NumPcWorking" HeaderText="Number of Pc Working" ReadOnly="True" SortExpression="NumPcWorking" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="venCode" HeaderText="Venue Code" SortExpression="venCode" />
                <asp:BoundField DataField="venNumSeats" HeaderText="Number of Seats" SortExpression="venNumSeats" />
                <asp:BoundField DataField="seatallocslot" HeaderText="Slot" SortExpression="seatallocslot" />
                <asp:BoundField DataField="seatallocdate" HeaderText="Date" SortExpression="seatallocdate" />
                <asp:BoundField DataField="subjCode" HeaderText="Subject Code" SortExpression="subjCode" />
                <asp:BoundField DataField="Count(pcName)" HeaderText="Number f Seats Used" ReadOnly="True" SortExpression="Count(pcName)" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT v.venCode,v.venNumSeats,s.seatallocslot, Date_Format(seatallocdate,'%Y-%m-%d') as seatallocdate,subjCode,Count(pcName)
FROM tblseatallocation s,tblvenue v
WHERE v.venCode = SUBSTR(pcName, 1, 5)
GROUP BY s.seatallocslot,s.seatallocdate,vencode
ORDER BY subjCode,s.seatallocdate"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT v.venCode, v.venNumSeats, COUNT(p.pcNo) AS NumPcWorking FROM tblvenue v, tblpc p WHERE v.venCode = p.venCode AND (p.pcStatus = 1) GROUP BY v.venCode, v.venNumSeats"></asp:SqlDataSource>
        </div> </asp:Panel>
        <br />
        
    <br />
           <p align="center"><button id="SAVE" onclick="printo()">Save/Print</button>
</p>
   </div>
     
    <asp:SqlDataSource ID="getReport" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT  subjCode AS 'Subjecet Code',venCode AS Venue, subjvenSlot AS Slot,Date_Format(subjvendate,'%Y-%m-%d') as Date FROM tblSubj_Venue 
"></asp:SqlDataSource>
    <p align="right" style="font-size: x-large; font-weight: bolder;">
        <asp:Button ID="exit" runat="server" Text="LOGOUT" Width="66px" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" OnClick="exit_Click" CssClass="button1" />
        &nbsp;
    </p>
     <script>

        function printo() {
            var printContents = document.getElementById("mchingis").innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;

            return true;
        }
    </script>
</asp:Content>

