<%@ Page Title="Edit Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Worker_Edit.aspx.cs" Inherits="Administracija._Worker_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Uredi djelatnika
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtFirstName_edit" ID="lbFirstName" meta:resourcekey="lbFirstName"></asp:Label>
                            <asp:TextBox type="text" ID="txtFirstName_edit"  CssClass="form-control" placeholder="npr. Pero" Text="" runat="server" required EnableViewState="False" />
                        </div>                      
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtLastName_edit" ID="lbLastName" meta:resourcekey="lbLastName"></asp:Label>
                            <asp:TextBox type="text" ID="txtLastName_edit" CssClass="form-control" placeholder="npr. Peric" Text="" runat="server" required />
                        </div>
                    </div>
                     <div class="form-group">
                            <asp:Label runat="server" for="txtEmail_edit" ID="lbEmail" meta:resourcekey="lbEmail"></asp:Label>
                            <asp:TextBox type="email" ID="txtEmail_edit" CssClass="form-control" placeholder="npr. p.peric@domena.hr" runat="server" required />
                     </div>                                                  
                    <div class="form-group">
                        <asp:Label runat="server" for="listWorkLevel_edit" ID="lbWorkerLevel" meta:resourcekey="lbWorkerLevel"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="listWorkLevel_edit"></asp:DropDownList>
                    </div>
                    <asp:Button runat="server" ID="btnUpdateWorker" meta:resourcekey="btnUpdateWorker" CssClass="btn btn-primary float-right" OnClick="btnUpdateWorker_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
