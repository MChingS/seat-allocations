<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="seatAllocation.aspx.cs" Inherits="seatAllocation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    seatAllocation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 159px;
        }

        .auto-style2 {
            border-radius: 5px 0 0 5px;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            margin-top: 0px;
        }
        .auto-style3 {
            float: left;
            background-color: rgb(214, 207, 207);
            border-radius: 5px 5px 5px 5px;
            width: 75%;
            min-height: 500px;
            height:100%;
        }
        .auto-style4 {
            float: right;
            background-color: rgb(214, 207, 207);
            border-radius: 5px 5px 5px 5px;
            width: 24%;
            height: 603px;
        }
        .auto-style5 {
            color: #FF0000;
        }
        .auto-style6 {
            border-radius: 5px 0 0 5px;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            margin-top: 0px;
            width: 278px;
        }
        .auto-style7 {
            width: 278px;
        }
        .auto-style8 {
            width: 159px;
            height: 14px;
        }
        .auto-style10 {
            height: 14px;
        }
        .auto-style11 {
            color: lime;
        }
    </style>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="details" class="auto-style3">
       <asp:Button ID="Button1" runat="server" Text="BACK" OnClick="Button1_Click" CssClass="button1" Visible="False" />
    <p align="center" style="font-size: x-large; font-weight: bolder;">
        <asp:Label ID="pageName" align="center" runat="server" Text="Create Seat Allocation"></asp:Label>
    </p>
    <p align="center" style="font-size: x-large; font-weight: bolder;">
        &nbsp;
    </p>
    <h3 align="center">Course and Subject selection</h3>
    <table align="center">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style6">
                <asp:DropDownList ID="courseList" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="courseList_SelectedIndexChanged" Height="2.5em" Width="100%">
                    <asp:ListItem>Select course</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
           
        </tr>
        <tr>
            <td class="auto-style1">Subject Code
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="subjectList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectList_SelectedIndexChanged" Height="2.5em" Width="100%">
                    <asp:ListItem>Select subject</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
             <td>
                 <strong>
                <asp:Label ID="Label6" runat="server" Text="Choose Subject" CssClass="auto-style5"></asp:Label>
                 </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="numOfStud0" runat="server" Text="Number of students"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Label ID="numOfStud" runat="server" Text="null"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">Choose Date
            </td>
            
            <td class="auto-style10">
                <asp:TextBox ID="slotDate1" runat="server" CssClass="drop" TextMode="Date" AutoPostBack="True" OnTextChanged="slotDate1_TextChanged" Width="100%" Height="2em"></asp:TextBox>
                <strong>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="slotDate1" ErrorMessage="Date selected is invalid" CssClass="auto-style5">Fieled Is Requied</asp:RequiredFieldValidator>
        <br />
                    <asp:Label ID="warning" Style="color: red;" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </strong>
                 </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Choose a slot
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="slots" runat="server" AutoPostBack="true" Height="2.5em" OnSelectedIndexChanged="slots_SelectedIndexChanged" Width="100%">
                    <asp:ListItem>Slot 1</asp:ListItem>
                    <asp:ListItem>Slot 2</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>Choose spacing type
            </td>
            <td class="auto-style7">
                <asp:RadioButtonList ID="spacingType" runat="server" CssClass="drop" TextAlign="Right" AutoPostBack="true" OnSelectedIndexChanged="spacingType_SelectedIndexChanged">
                    <asp:ListItem >Even Number Spacing</asp:ListItem>
                    <asp:ListItem>Odd Number Spacing</asp:ListItem>
                    <asp:ListItem>No Spacing</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>

    <br />
    <p align="center">
        <strong>
        <asp:Label ID="warn1" runat="server" Font-Size="X-Large" CssClass="auto-style11"></asp:Label>
        </strong>
    </p>
    
       </div>
    
    <div id="det" class="auto-style4">
         
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
        <asp:Image ID="Image1" CssClass="image" runat="server" ImageUrl="~/images/admin.png" />
        <br />
        <br />
         <table align="center" class="mytable">
             <tr>
        <td><asp:Label ID="Label1" runat="server" Text=" Username :"></asp:Label></td>
         <td><asp:Label ID="studUsername" runat="server" Text="current user"></asp:Label></td>
        </tr>
             <tr>
        <td><asp:Label ID="Label5" runat="server" Text=" Stuff No :"></asp:Label></td>
       <td>  <asp:Label ID="studNo" runat="server" Text="current stud"></asp:Label></td>
        </tr>
        
        
        <tr>
        <td> <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label></td>
        <td>  <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label></td>
            </tr>
            </table>
  
        <br />
                <asp:Calendar ID="slotDate" Visible="false" runat="server" CssClass="auto-style2" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" OnSelectionChanged="slotDate_SelectionChanged">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>

    </div>
    <p align="center" style="font-size: x-large; font-weight: bolder;">
        <asp:Button ID="nextToLab" runat="server" Visible="false" Text="NEXT" OnClick="Button2_Click" CssClass="button1" />
    </p>
    <asp:Panel ID="Panel1" Width="500" Visible="false" HorizontalAlign="Left" runat="server">
        <h3 align="center">Venue selection</h3>
        <p align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label2" runat="server" Text="Venue Name" Width="100px"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Lab Capacity" Width="100px"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Pc Left" Width="100px"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Lab Structure" Width="100px"></asp:Label>
        </p>
        <p>&nbsp;&nbsp; &nbsp;</p>
    </asp:Panel>
    <asp:Panel ID="labControler" CssClass="str" Width="500" Visible="false" HorizontalAlign="Center" runat="server">
    </asp:Panel>
    
    <p>&nbsp;</p>
    <p align="center" style="font-size: x-large; font-weight: bolder;">
        <asp:Button ID="nextToPc" runat="server" Visible="false" Text="NEXT" OnClick="nextToPc_Click" CssClass="button1" />
        &nbsp;
    </p>
    <div id="seats">
        <asp:Panel ID="pcControlerBy4" CssClass="str" Width="1100" Visible="false" runat="server">
            <h3 align="center">
                <asp:Label ID="seatName" Visible="false" runat="server" Text="Label"></asp:Label>
            </h3>
        </asp:Panel>

        <asp:Panel ID="pcControlerBy5" CssClass="str" Visible="false" runat="server">
        </asp:Panel>


        <asp:Panel ID="pcControlerBy3" CssClass="str" Visible="false" runat="server">
        </asp:Panel>


    </div>

    <asp:Panel ID="Panel2" CssClass="str" Visible="false" runat="server">
        <p align="center">
            <asp:Label ID="labsNeed" Visible="false" runat="server" Text="You need more labs" CssClass="auto-style5" Font-Bold="True" Font-Size="Medium"></asp:Label>
        </p>
        <p align="center" style="font-size: x-large; font-weight: bolder;">
            <asp:Label ID="numStudeUpdates" runat="server" Visible="false" Text=""></asp:Label>
            <br />
            <button id="SAVE" style="border-radius:10px; height:2em; width:auto;" onclick="printo()" class="button1">Save/Print View</button>

            &nbsp;&nbsp;
        
      <asp:Button ID="saveToDB" runat="server" Text="Book Venue" OnClientClick="return confirm('Are you sure you want to save to database?');" OnClick="saveToDB_Click" CssClass="button1" />

        </p>
    </asp:Panel>
    <p align="right" style="font-size: x-large; font-weight: bolder;">
                    
 <asp:Button ID="exit" runat="server"  Text="LOGOUT" Width="66px" OnClick="exit_Click" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" PostBackUrl="~/homepage.aspx" CssClass="button1" />
            
        &nbsp;
    </p>
       <br />
    <script>

        function printo() {
            var printContents = document.getElementById("seats").innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;

            return true;
        }
    </script>

</asp:Content>


