<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="addsubject.aspx.cs" Inherits="addsubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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
        <td><asp:Label ID="Label3" runat="server" Text="User No :"></asp:Label></td>
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
        <td class="auto-style1"> <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label></td>
        <td class="auto-style1">  <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label></td>
            </tr>
            </table>
    </div>
    <div class="myright">
        <h3 align="center">
            Select Subject To Teach
        </h3>
        <br />
        <br />

        
            <div style="width:80%;height:80%; align-content:center; align-items:center;align-self:center; float:right;margin-right:10%;background-color:rgb(128, 128, 128);" __designer:mapid="44">
            <asp:CheckBoxList ID="subjectList" style="display: table-cell;width:70%;" runat="server" DataSourceID="SqlDataSource1" DataTextField="subjCode" DataValueField="subjCode" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT * FROM tblsubject"></asp:SqlDataSource>
                <br __designer:mapid="46" />
            <br __designer:mapid="47" />
            <asp:Button ID="Button1" runat="server" Text="Add Subject" CssClass="button1" OnClick="Button1_Click"  />
            </div>

        
    </div>
            <br />
            <br />
</div>
    <p align="right" style="font-size: x-large; font-weight: bolder;">
        <asp:Button ID="exit" runat="server" Text="LOGOUT" Width="66px"  OnClientClick="return confirm('Are you sure you want to LOGOUT?');" OnClick="exit_Click1" />
        &nbsp;
    </p>
    
</asp:Content>

