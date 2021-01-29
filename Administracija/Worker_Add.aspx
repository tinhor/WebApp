<%@ Page Title="New Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Worker_Add.aspx.cs" Inherits="Administracija._Worker_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Dodaj djelatnika
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtFirstName" ID="lbFirstName" meta:resourcekey="lbFirstName"></asp:Label>
                            <asp:TextBox type="text" ID="txtFirstName"  CssClass="form-control" placeholder="npr. Pero" runat="server" required="true" />
                        </div>                      
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtLastName" ID="lbLastName" meta:resourcekey="lbLastName"></asp:Label>
                            <asp:TextBox type="text" ID="txtLastName" CssClass="form-control" placeholder="npr. Peric" runat="server" required="true" />
                        </div>
                    </div>
                     <div class="form-row">
                     <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtEmail" ID="lbEmail" meta:resourcekey="lbEmail"></asp:Label>
                            <asp:TextBox type="email" ID="txtEmail" CssClass="form-control" placeholder="npr. p.peric@domena.hr" runat="server" required="true" />
                     </div>                        
                      <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtDate" ID="lbDate" meta:resourcekey="lbDate"></asp:Label>
                            <asp:TextBox type="date" ID="txtDate" CssClass="form-control" runat="server" required="true" />
                     </div>                     
                     </div>    
                       <div class="form-group">
                            <asp:Label runat="server" for="dllTeams" ID="lbTeams" meta:resourcekey="lbTeams"></asp:Label>
                              <asp:DropDownList ID="dllTeams" runat="server" AutoPostBack ="false" CssClass="form-control w-100"></asp:DropDownList>
                     </div>

                    <div class="form-row">
                    <div class="form-group col-md-6">
                            <asp:Label runat="server" for="txtPassword" ID="lbPassword" meta:resourcekey="lbPassword"></asp:Label>
                            <asp:TextBox type="password" ID="txtPassword" meta:resourcekey="txtPassword"  CssClass="form-control" placeholder="******" runat="server" required="true" />
                     </div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" for="listWorkLevel" ID="lbWorkerLevel" meta:resourcekey="lbWorkerLevel"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="listWorkLevel"></asp:DropDownList>
                    </div>
                    </div>
                    <asp:Button runat="server" ID="btnNewWorker" meta:resourcekey="btnNewWorker" CssClass="btn btn-primary float-right" OnClick="btnNewWorker_Click" />
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
