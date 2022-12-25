<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Scent.CO.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href ="css/addr.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="address-box">
        <center><h1 id="title" runat="server">Add New Address</h1>
            <asp:TextBox ID="name" runat="server" placeholder="Recipient's Name" CssClass="newaddr"></asp:TextBox><br />
            <asp:TextBox ID="phone" runat="server" placeholder="Phone Number" CssClass="newaddr"></asp:TextBox><br />
            <asp:TextBox ID="state" runat="server" placeholder="State" CssClass="newaddr"></asp:TextBox><br />
            <asp:TextBox ID="postcode" runat="server" placeholder="Postcode" CssClass="newaddr"></asp:TextBox><br />
            <asp:TextBox ID="city" runat="server" placeholder="City" CssClass="newaddr"></asp:TextBox><br />
            <asp:TextBox ID="unit" runat="server" placeholder="Address Details" TextMode="MultiLine" CssClass="newaddr"></asp:TextBox><br />
            <asp:Button ID="AddressButton" runat="server" Text="Add and Choose" CssClass="btn-add" OnClick="AddressButton_Click"/><br />
        </center>
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
