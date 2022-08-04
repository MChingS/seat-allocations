<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="updateProfile.aspx.cs" Inherits="updateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
   

    <div id="first" style="height:100%; align-content:center;" >
        <div class="myleft">
            <asp:Image ID="Image1" CssClass="image" runat="server" ImageUrl="~/images/admin.png" />
            <br />
            <br />
            <table align="center" class="mytable">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=" Username :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="studUsername" runat="server" Text="current user"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=" Student No :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="studNo" runat="server" Text="current stud"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text=" Name : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="studName" runat="server" Text="current name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text=" Surname : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="studSurname" runat="server" Text="current stud"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text=" Course Code : "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="studCoursecod" runat="server" Text=" code"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label>
                    </td>
                </tr>
            </table>
                
            <asp:Button ID="exit" align="center" runat="server" OnClick="exit_Click" OnClientClick="return confirm('Are you sure you want to LOGOUT?');" Text="LOGOUT" Width="66px" />
            
        </div>
        <asp:Panel ID="lecture" Visible="" runat="server">
        <div class="myright">
            <br />
            <br />
            <br />
            <div style="width:80%;height:100%; align-content:center; align-items:center;align-self:center; float:right;margin-right:10%;background-color:rgb(128, 128, 128);">
          <asp:Label ID="Label6" runat="server" CssClass="auto-style2" Text="Select Subject  To Register"></asp:Label>
                <br />
                <br />
                  <asp:CheckBoxList ID="subjectList" style="display: table-cell;width:70%;" runat="server" DataSourceID="SqlDataSource2" DataTextField="subjCode" DataValueField="subjCode" RepeatDirection="Horizontal" RepeatColumns="5"></asp:CheckBoxList>
                <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Subject" CssClass="button1" OnClick="Button1_Click" Width="10em" />
                <br />
                <br />

                <asp:Label ID="Label4" runat="server" CssClass="auto-style2" Text="Select Subject  To Remove"></asp:Label>
                <br />
                <br />
                <asp:CheckBoxList ID="delete1" style="display: table-cell;width:70%;" runat="server" DataSourceID="SqlDataSource3" DataTextField="subjCode" DataValueField="subjCode" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT subjcode FROM tblsubj_stud WHERE studno = ?">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="studNo" Name="?" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Remove Subject" CssClass="button1" Width="10em" OnClick="Button2_Click" />
            </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT subjcode from tblsubject sb1, tblstudent s2 where sb1.coursecode = s2.coursecode and s2.studUsername = ? and subjcode NOT IN (SELECT subjcode FROM tblsubj_stud ss, tblstudent s WHERE ss.studno = s.studno and s.studno = (SELECT studno from tblstudent where studUsername = ?))
ORDER BY subjcode
">
                <SelectParameters>
                    <asp:ControlParameter ControlID="studUsername" Name="?" PropertyName="Text" />
                    <asp:ControlParameter ControlID="studUsername" Name="?" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
            
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT studNo,studPassword
FROM tblstudent 
WHERE studNo=?">
                <SelectParameters>
                    <asp:ControlParameter ControlID="studNo" Name="?" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
         
            </asp:Panel>

    </div>
    <p>

        &nbsp; .&nbsp;</p>
    <br />
    <br />
</asp:Content>

