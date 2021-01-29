<%@ Page Title="New Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Project_Edit.aspx.cs" Inherits="Administracija._Project_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Uredi projekt
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                        <div class="form-group">
                            <asp:Label runat="server" for="txtProjectTitle_edit" ID="lbProjectTitle" meta:resourcekey="lbProjectTitle"></asp:Label>
                            <asp:TextBox type="text" ID="txtProjectTitle_edit"  CssClass="form-control" placeholder="npr. Pero" runat="server" required="true" />
                        </div>
                               
                    
                    <asp:Button runat="server" ID="btnEditProject" meta:resourcekey="btnEditProject" CssClass="btn btn-primary float-right" OnClick="btnEditProject_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
