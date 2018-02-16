<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="user_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <table>
        <tr>
            <td>Enter EmailID

            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            </td>

        </tr>


          <tr>
            <td>Enter Password

            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>

            </td>

        </tr>

        <tr>
          <td colspan="2" align="center">
              <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Buton_Login" />

          </td>
        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>

