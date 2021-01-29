<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Administracija._Clients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        <%= Resources.Table.Table_Title_Clients %>
                        <a href="Client_Add.aspx" class="btn btn-sm btn-secondary float-right m-0 waves-effect waves-light text-white"><%= Resources.Button.BtnAdd %></a>
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="table-responsive table-striped">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><%= Resources.Table.Table_FirstName %></th>
                                    <th class="text-right"><%= Resources.Table.Table_Action %></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                  <% 
                                      if (ClientList.Count > 0)
                                      {
                                          foreach (var user in ClientList)
                                          {

                                 %>
                                 <tr>
                                    <td><%= user.Title %></td>
                                    <td class="td-actions text-right">
                                        <a href="Client_Edit.aspx?id=<%= user.IDClient %>" type="button" class="btn btn-sm btn-primary">
                                              <%= Resources.Button.BtnEdit %>
                                        </a>
                                        <a href="Client_Delete.aspx?id=<%= user.IDClient %>" type="button" class="btn btn-sm btn-danger">
                                               <%= Resources.Button.BtnDelete %>
                                        </a>
                                    </td>
                                </tr>

                                  <% } } else{ %>
                                          
                                <tr><td class="text-center" colspan="6"><%= Resources.ApiResponse.noData %></td></tr>
                                
                                <%  }  %>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
