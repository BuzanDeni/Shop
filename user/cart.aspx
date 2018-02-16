
<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="user_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
        <div>
                
              <asp:DataList ID="d1" runat="server" Height="192px" Width="527px">
               <HeaderTemplate>
               <table border="1">
       <tr style="background-color:Silver; color:white; font-weight:bold">
           <td>product image</td>
           <td>product name</td>
           <td>product description</td>
           <td>product price</td>
           <td>product qty</td>
           <td>delete</td>

       </tr>
           
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><img src="<%#Eval("product_images") %>"" height="100" width="100"/></td>
                <td><%#Eval("product_name") %></td>
                <td><%#Eval("product_descr") %></td>
                <td><%#Eval("product_price") %></td>
                <td><%#Eval("quantity") %></td>
                <td>
                    <a href="delete_cart.aspx?id=<%#Eval("id") %>">delete</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
             </table>
        </FooterTemplate>
    </asp:DataList>
            <asp:Button ID="b1" runat="server" Text="checkout" OnClick="b1_Click" Height="28px" Width="128px"/>

            <asp:Label ID="l1" runat="server"></asp:Label>
            <br/>
            <p align="center">
                <br />

</p>
        </div>
</asp:Content>

