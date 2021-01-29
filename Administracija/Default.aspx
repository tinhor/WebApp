<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administracija._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <div class="container">
            <h2><asp:Literal runat="server" Text="<%$ Resources: masterTitle%>" /></h2>
        </div>
    </div>

    <div class="form-signin text-center">
        <h1 class="h3 mb-3 font-weight-normal"><asp:Literal runat="server" Text="<%$ Resources: loginTitle%>" /></h1>

        <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>

        <asp:TextBox type="email" ID="txtEmail" meta:resourcekey="txtEmail" CssClass="form-control" placeholder="E-pošta" runat="server" required />
        <asp:TextBox type="password" ID="txtPassword" meta:resourcekey="txtPassword" CssClass="form-control" placeholder="Lozinka" runat="server" required />
        <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="lbLanguage" AutoPostBack="True" OnSelectedIndexChanged="lbLanguage_SelectedIndexChanged">
            <asp:ListItem Text="<%$ Resources: selectLanguage %>"></asp:ListItem>
            <asp:ListItem Text="Hrvatski jezik" Value="hr"></asp:ListItem>
            <asp:ListItem Text="English" Value="en"></asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnLogin" Text="Prijava" meta:resourcekey="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-lg btn-primary btn-block mt-2" runat="server"></asp:Button>
    </div>
</asp:Content>
