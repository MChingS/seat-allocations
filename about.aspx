<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    

    
    <div class="homeP">
    <h1>About theGreat Seat Allocation</h1>

        <div style="width:50%; margin-left: 25%;">

             Seat Allocation is a system used by lecturer to allocate student to pc and  ensure that a 
            student is not placed to same seat more than once in a semester, 
            and a student will see which seat is placed for a particular module, at what time and which date.
             The lab technician functions is to update pc and venue status accordingly (working or broken).
             Administrator's funtions is to approve accounts (lab technician's and lectutrer's acc)
             and also generate a report about the pc and venue status.
          
        </div>
      <div style="width:25%; float:left;">
    <h4>LECTURER</h4>
          <br />
          Select subject code, date for the test and the venue to allocate the students.
    </div>
        <div style="width:25%; float:left;">
    <h4>STUDENT</h4>
            <br />
            View the created seat allocation for the modules that a student is doing.
    </div>
            <div style="width:25%; float:left;">
    <h4>LAB TECHNICIAN</h4>
<br />
                Update PC and venue statuses to ensure there <br /> are no complications.
    </div>
         <div style="width:25%; float:left;">
    <h4>ADMINISTRATOR</h4>
             <br />
             Generate a report
             (created seat allocation, broken PC's, available venue
              and unavailable venue) to the management as PDF or Copy.
    </div>
    <br />
        </div>
</asp:Content>

