<%@ Page Title="Delete client" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Project_Users_Delete.aspx.cs" Inherits="Administracija._Project_Users_Delete" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
           <div class="jumbotron">
                <h1>Micanje korisnika sa projekta: <asp:Literal ID="removeUser" runat="server" /></h1>
                <p class="lead">Ovu radnju nećete moći izmjeniti!</p>

                <asp:Button ID="btnDeleteUser"  CssClass="btn btn-sm btn-danger" runat="server" Text="Želim maknuti programera s projekta»" OnClick="btnRemoveUserFromProject_Click" />                
                <a href="Projects.aspx" class="btn btn-sm btn-primary text-white" role="button">Odustajem</a>
            </div>
        </div>
    </div>
</asp:Content>
