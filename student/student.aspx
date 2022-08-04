<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    student
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div id="first" class="wreper11">
   
    <div class="myleft">
        <asp:Image ID="Image1" CssClass="image" runat="server" ImageUrl="~/images/admin.png" />
        <br />
        <br />
         <table align="center" class="mytable">
             <tr>
        <td><asp:Label ID="Label1" runat="server" Text=" Username :"></asp:Label></td>
         <td><asp:Label ID="studUsername" runat="server" Text="current user"></asp:Label></td>
        </tr>
             <tr>
        <td><asp:Label ID="Label3" runat="server" Text=" Student No :"></asp:Label></td>
       <td>  <asp:Label ID="studNo" runat="server" Text="current stud"></asp:Label></td>
        </tr>
        <tr>
           <td> <asp:Label ID="Label5" runat="server" Text=" Name : "></asp:Label></td>
        <td> <asp:Label ID="studName" runat="server" Text="current name"></asp:Label></td>
        </tr>
              <tr>
         <td><asp:Label ID="Label7" runat="server" Text=" Surname : "></asp:Label></td>
         <td> <asp:Label ID="studSurname" runat="server" Text="current stud"></asp:Label></td>
        </tr>
        <tr>
       <td>  <asp:Label ID="Label9" runat="server" Text=" Course Code : "></asp:Label></td>
        <td>  <asp:Label ID="studCoursecod" runat="server" Text=" code"></asp:Label></td>
         </tr>
        <tr>
        <td class="auto-style1"> <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label></td>
        <td class="auto-style1">  <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label></td>
            </tr>
            </table>
        <asp:Button ID="Button1" runat="server" Text="ADD SUBJECT" OnClick="Button1_Click" />
    </div>
    <div class="myright">
        <h3 align="center">Your Seat Allocation</h3>
        <br />
        <asp:GridView ID="GridView1" class="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="subjCode,seatallocdate,seatallocslot" DataSourceID="SqlDataSource1" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="subjCode" HeaderText="Subject" ReadOnly="True" SortExpression="Subject" />
                <asp:BoundField DataField="substr(pcname,1,5)" HeaderText="Venue" ReadOnly="True" SortExpression="Venue" />
                <asp:BoundField DataField="substr(pcname,6)" HeaderText="Pc No" ReadOnly="True" SortExpression="Pc No" />
                <asp:BoundField DataField="seatallocdate" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                <asp:BoundField DataField="seatallocslot" HeaderText="Slot" ReadOnly="True" SortExpression="Slot" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT subjCode,substr(pcname,1,5),substr(pcname,6),Date_Format(seatallocdate,'%d-%M-%Y') AS seatallocdate,seatallocslot
FROM tblseatallocation
WHERE studno =?">
            <SelectParameters>
                <asp:ControlParameter ControlID="studNo" Name="?" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />

        
    </div>
</div>
    <p align="right" style="font-size: x-large; font-weight: bolder;">
        <asp:Button ID="exit" runat="server" Text="LOGOUT" Width="66px" OnClick="exit_Click" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" />
        &nbsp;
    </p>
</asp:Content>

