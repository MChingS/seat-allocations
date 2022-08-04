                                    <%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="labtec.aspx.cs" Inherits="labtec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    labTec
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            float: right;
            background-color: rgb(214, 207, 207);
            border-radius: 5px 5px 5px 5px;
            width: 20%;
            height: 289px;
        }
        .auto-style3 {
            float: left;
            background-color: rgb(214, 207, 207);
            border-radius: 5px 5px 5px 5px;
            width: 80%;
            height: 158px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <h2 align="center">Lab Configurations</h2>

    <div id="det" class="auto-style2">
         
        <asp:Image ID="Image1" CssClass="image" runat="server" ImageUrl="~/images/admin.png" />
        <br />
        <br />
         <table align="center" class="mytable">
             <tr>
        <td><asp:Label ID="Label1" runat="server" Text=" Username :"></asp:Label></td>
         <td><asp:Label ID="studUsername" runat="server" Text="current user"></asp:Label></td>
        </tr>
           <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="User Id :"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="userid" runat="server" Text="Label"></asp:Label>
                 </td>
             </tr>
        <tr>
        <td> <asp:Label ID="Label11" runat="server" Text=" Logged at : "></asp:Label></td>
        <td>  <asp:Label ID="timeLoged" runat="server" Text=" time"></asp:Label></td>
            </tr>
             
            </table>
  
    </div>
    <div id="details" class="auto-style3">
    <table id="lab" align="center">
        <tr>
            <td class="auto-style1">
               Choose Lab Name
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="labList" runat="server" AutoPostBack="true" Height="17px" Width="100px" OnSelectedIndexChanged="labList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Choose type of configuration
            </td>
            <td>
                <asp:DropDownList ID="configList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="configList_SelectedIndexChanged" Height="17px" Width="100px">
                    <asp:ListItem>Lab Status</asp:ListItem>
                    <asp:ListItem>Pc's Status</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="config" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Height="17px" Width="100px" AutoPostBack="True">
                    <asp:ListItem Value="0">unavailable</asp:ListItem>
                    <asp:ListItem Value="1">available</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="pcDet" runat="server" Visible="False" Text="Select Pc To Update"></asp:Label>

            </td>
            <td>

        <asp:DropDownList ID="pcListFromDB" align="center" Visible="false" runat="server" Height="18px" Width="100px">
        </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="update" runat="server" Text="UPDATE" OnClick="update_Click" />

            </td>
        </tr>
    </table>
   </div>
             <asp:SqlDataSource ID="updateSource" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" UpdateCommand="UPDATE tblPC
SET pcStatus = 0
WHERE pcName = ?">
                 <UpdateParameters>
                     <asp:SessionParameter Name="pcName" SessionField="pcName" />
                 </UpdateParameters>
             </asp:SqlDataSource>
    <p align="center">
        <asp:Label ID="labName" runat="server" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
    </p>
    <div style="width:500px;">
    <p>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="checkSource" DataTextField="pcName" DataValueField="pcName" Visible="false" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
        <asp:SqlDataSource ID="checkSource" runat="server" ConnectionString="<%$ ConnectionStrings:mchingis %>" ProviderName="<%$ ConnectionStrings:mchingis.ProviderName %>" SelectCommand="SELECT pcName,pcStatus
FROM tblPc
WHERE pcStatus &lt;&gt; ?
AND venCode = ?">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList3" Name="pcStatus" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="labList" Name="venCode" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p></div>
    <p align="right">
        <asp:Button ID="Button2" runat="server" Text="LOGOUT" OnClick="Button2_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p><br />
    </asp:Content>