<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Scent.CO.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href ="css/signup.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Sign In form code goes here -->
    <center>
        <div class="login-container">
            <center><h1>Sign In</h1>
                <asp:Label ID="Label1" runat="server" Text="Welcome Back!" CssClass="info"></asp:Label><br />
                <asp:TextBox ID="username" runat="server" placeholder="Username" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="password" runat="server" placeholder="Password" TextMode="Password" CssClass="signin"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass="btnlogin" OnClick="Button1_Click" /><br />
                <asp:Button ID="Button2" runat="server" Text="Not Member? Sign Up!" CssClass="createacc" OnClick="Button2_Click" />
            </center>
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
