<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="user_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <table>
        <tr>
            <td>first name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>last name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>email</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>password</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td>address</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" Height="56px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>
            <td>city</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>state</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>pincode</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>mobile number</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
        </tr>

        <tr>

            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="button_registration" />
        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>

