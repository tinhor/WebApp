<%@ Page Title="New Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Client_Add.aspx.cs" Inherits="Administracija._Client_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Dodaj klijenta
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" for="txtTitle" ID="lbFirstName" meta:resourcekey="lbTitle"></asp:Label>
                            <asp:TextBox type="text" ID="txtTitle"  CssClass="form-control" placeholder="npr. Marko d.o.o." runat="server" required="true" />
                        </div>                              
                    
                    <asp:Button runat="server" ID="btnNewClient" meta:resourcekey="btnNewClient" CssClass="btn btn-primary float-right" OnClick="btnNewClient_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
