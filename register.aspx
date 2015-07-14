<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="comp2007_lesson9_mon.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Register
    </h1>
    <div>
        <asp:Label id="lblStatus" runat="server"></asp:Label>

        <label for ="txtUName"> UserName:</label>
        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
        <label for ="txtPass"> Password:</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <label for ="txtPConfirm"> Confirm Password:</label>
        <asp:TextBox ID="txtPConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator runat="server" ControlToValidate="txtPass" ControlToCompare="txtPConfirm" Operator="Equal" ErrorMessage="Must match" CssClass="label-danger"></asp:CompareValidator>
        <asp:Button ID="btnReg" runat="server" Text="Register" OnClick="CreateUser_Click" /> 
    </div>
</asp:Content>
