<%@ Page Title="Edit client" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Client_Edit.aspx.cs" Inherits="Administracija._Client_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Uredi klijenta
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" for="txtTitle_edit" ID="lbFirstName" meta:resourcekey="lbTitle"></asp:Label>
                            <asp:TextBox type="text" ID="txtTitle_edit"  CssClass="form-control" placeholder="npr. Pero" Text="" runat="server" required EnableViewState="False" />
                        </div>                                                                     

                    <asp:Button runat="server" ID="btnUpdateClient" meta:resourcekey="btnUpdateClient" CssClass="btn btn-primary float-right" OnClick="btnUpdateClient_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
