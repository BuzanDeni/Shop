<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="view_full_order.aspx.cs" Inherits="admin_view_full_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
      <asp:Repeater ID="r2" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray; color:white">
                    <td>id</td>
                    <td>firstname</td>
                    <td>lastname</td>
                    <td>email</td>
                    <td>address</td>
                    <td>city</td>
                    <td>state</td>
                    <td>pincode</td>
                    <td>mobile</td>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id")%></td>
                <td><%#Eval("firstname")%></td>
                <td><%#Eval("lastname")%></td>
                 <td><%#Eval("email")%></td>
               <td><%#Eval("address")%></td>
                <td><%#Eval("city")%></td>
                <td><%#Eval("state")%></td>
                <td><%#Eval("pincode")%></td>
                 <td><%#Eval("mobile")%></td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
</asp:Repeater>
    
    </br></br>
    
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table>
             <tr style="background-color:gray; color:white">
                 <td>product image</td>
                 <td>product name</td>
                 <td>product price</td>
                 <td>product qty</td>
             </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr> 
            <td><img src="../<%#Eval("product_images")%>" height="" width="100"</td>
            <td><%#Eval("product_name") %></td>
            <td><%#Eval("product_price") %></td>
            <td><%#Eval("product_qty") %></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="l1" runat="server" Text=""></asp:Label>
</asp:Content>

