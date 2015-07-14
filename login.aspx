<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="comp2007_lesson9_mon.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <label for ="txtUName"> UserName:</label>
        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
        <label for ="txtPass"> Password:</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <asp:Button ID="btnLog" runat="server" Text="Login" OnClick="btnLog_Click" CssClass="btn btn-primary" /> 
</asp:Content>
