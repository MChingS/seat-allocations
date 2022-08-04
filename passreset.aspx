<%@ Page Title="" Language="C#" MasterPageFile="~/theGreat.master" AutoEventWireup="true" CodeFile="passreset.aspx.cs" Inherits="passreset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            height: 66px;
        }
        .auto-style3 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">

    <asp:Panel ID="Panel1" runat="server">
       <table runat="server" align="center" style="background-color: #808080">
         
        <tr>
            <td colspan="2" align="center" style="height: 17px">
                <asp:Label ID="Label1" runat="server" align="center" Text="Password Reset" style="font-weight: 700; color: #000000; font-size: xx-large; text-align: center"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
       
       
            
        <tr>
            <td class="text-right">
                <asp:Label ID="Label10" runat="server" style="color: #000000; font-size: medium; font-weight: bold;" Text="Username (Email)"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="username" runat="server" style="border-radius:5px;" Height="35px" Width="396px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="username" ErrorMessage="invalid email" style="font-weight: 700; color: #FF0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label26" runat="server" style="color: #000000; font-size: medium; font-weight: bold;" Text="New Password"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="newPass" runat="server" style="border-radius:5px;" Height="35px" Width="396px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="newPass" ErrorMessage="password is required" style="font-weight: 700; color: #FF0000"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>
       
           <tr>
               <td class="auto-style2">
                   <asp:Label ID="Label25" runat="server" style="color: #000000; font-size: medium; font-weight: bold;" Text="Cornfirm Password"></asp:Label>
               </td>
               <td class="auto-style2">
                   <asp:TextBox ID="cornPass" runat="server" Height="35px" style="border-radius:5px;" TextMode="Password" Width="396px"></asp:TextBox>
                   <strong>
                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="cornPass" ControlToValidate="newPass" CssClass="auto-style1" ErrorMessage="password must match"></asp:CompareValidator>
                   </strong>
                   <br />
                   <br />
               </td>
           </tr>
       
        <tr>
            <td colspan="2" style="height: 45px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="warning" Style="color: red;" runat="server" Visible="false" Text="Invalid Username Or Password" Font-Size="Medium"></asp:Label>
                      <br />  
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <strong>
                <asp:Button ID="Button2" runat="server" align="center" CssClass="auto-style3" Height="30px" OnClick="Button2_Click" style="border-radius:5px" Text="Reset" Width="180px" />
                </strong>
                   
                 <br />
                 </td>
        </tr>
       
        <tr>
            <td>
                &nbsp;</td>
            <td>
                                   
               </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
    </table>
  <br />
        </asp:Panel>
</asp:Content>

