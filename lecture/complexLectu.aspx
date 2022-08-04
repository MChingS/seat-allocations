<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="complexLectu.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
   seat allocation menu
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {}
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div align="center">
        <h2>Seat Allocation Menu</h2>
           <ul>
        <li>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="119px" ImageUrl="~/images/WHAT.jpg" Width="136px" OnClick="ImageButton1_Click" /> Create Seats Allocation
        </li>
               <br />
        <li>
        <asp:ImageButton ID="ImageButton2" runat="server" Height="119px" ImageUrl="~/images/WHAT.jpg" OnClick="ImageButton2_Click" Width="136px" /> Check Seats Allocation
        </li>
      </ul>
           <p>
               &nbsp;</p>
           <p>
           <asp:Button ID="exit" runat="server"  Text="LOGOUT" Width="66px" OnClick="exit_Click" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" PostBackUrl="~/homepage.aspx" CssClass="auto-style4" />
        
           </p>
    </div>
    <br />
        
</asp:Content>

