<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    theGreatHomePage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
       <br />
    <div align="center">
        <h1>Seat allocation</h1>

         <div style="width:50%;">

            Seat Allocation is a system used by lecturer to allocate student to pc and  ensure that a 
            student is not placed to same seat more than once in a semester, 
            and a student will see which seat is placed for a particular module, at what time and which date.
             The lab technician functions is to update pc and venue status accordingly (working or broken).
             Administrator's funtions is to approve accounts (lab technitian's and lectutrer's acc)
             and also generate a report about the pc and venue status.
          
        </div>
        <br />
         <div style="width:30%; min-height:150px; float:left;">
             <h3>Picture loading .....</h3>
             </div>
        <div style="width:30%; min-height:50px; float:left;">
      <h3>Picture loading .....</h3>
             </div>
        <div style="width:30%; min-height:50px; float:left;">
           <h3>Picture loading .....</h3>
             </div>

        </div>



</asp:Content>

