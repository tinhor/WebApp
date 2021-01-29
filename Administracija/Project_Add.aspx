<%@ Page Title="New Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Project_Add.aspx.cs" Inherits="Administracija._Project_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Dodaj Projekt
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                        <div class="form-group">
                            <asp:Label runat="server" for="txtProjectTitle" ID="lbProjectTitle" meta:resourcekey="lbProjectTitle"></asp:Label>
                            <asp:TextBox type="text" ID="txtProjectTitle"  CssClass="form-control" placeholder="npr. Pero" runat="server" required="true" />
                        </div>
                    
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="listProjectClient" ID="lbProjectClient" meta:resourcekey="lbProjectClient"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="listProjectClient"></asp:DropDownList>
                        </div>                      
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="listProjectTeamLeader" ID="lbProjectTeamLeader" meta:resourcekey="lbProjectTeamLeader"></asp:Label>
                             <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="listProjectTeamLeader"></asp:DropDownList>
                    </div>
                     </div>               
                    
                    <asp:Button runat="server" ID="btnNewProject" meta:resourcekey="btnNewProject" CssClass="btn btn-primary float-right" OnClick="btnNewProject_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
