<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Administracija._Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        <%= Resources.Table.Table_Title_Workers %>
                        <a href="Worker_Add.aspx" class="btn btn-sm btn-secondary float-right m-0 waves-effect waves-light text-white"><%= Resources.Button.BtnAdd %></a>
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="table-responsive table-striped">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><%= Resources.Table.Table_FirstName %></th>
                                    <th><%= Resources.Table.Table_LastName %></th>
                                    <th><%= Resources.Table.Table_Position %></th>
                                    <th><%= Resources.Table.Table_Email %></th>
                                    <th><%= Resources.Table.Table_Date %></th>
                                    <th class="text-right"><%= Resources.Table.Table_Action %></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                  <% foreach (var user in workerList) { %>
                                 <tr>
                                    <td><%= user.First_name %></td>
                                    <td><%= user.Last_name %></td>
                                    <td><%= Administracija.Models.UserRoles.State[user.UserLevel] %></td>
                                    <td><%= user.Email_address %></td>
                                    <td><%= user.EmploymentDate %></td>
                                    <td class="td-actions text-right">
                                        <a href="Worker_Edit.aspx?id=<%= user.IDWorker %>" type="button" class="btn btn-sm btn-primary">
                                            <%= Resources.Button.BtnEdit %>
                                        </a>
                                        <a href="Worker_Delete.aspx?id=<%= user.IDWorker %>" type="button" class="btn btn-sm btn-danger">
                                           <%= Resources.Button.BtnDelete %>
                                        </a>
                                    </td>
                                </tr>

                                  <% } %>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
