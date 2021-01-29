<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="Administracija._Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        <%= Resources.Table.Table_Title_Projects %>
                        <a href="Project_Add.aspx" class="btn btn-sm btn-secondary float-right m-0 waves-effect waves-light text-white"><%= Resources.Button.BtnAdd %></a>
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="table-responsive table-striped">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><%= Resources.Table.Table_Title %></th>
                                    <th><%= Resources.Table.Table_Client %></th>
                                    <th><%= Resources.Table.Table_TeamLeader %></th>
                                    <th class="text-right"><%= Resources.Table.Table_Action %></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                  <% 
                                      if (ProjectList.Count > 0)
                                      {
                                          foreach (var project in ProjectList)
                                          {

                                 %>
                                 <tr>
                                    <td><%= project.Title %></td>
                                     <td><%= project.Client.ToString() %></td>
                                     <td><%= project.TeamLeader.ToString() %></td>
                                    <td class="td-actions text-right">
                                        <a href="Project_Users.aspx?id=<%= project.IDProject %>" type="button" class="btn btn-sm btn-secondary">
                                              <%= Resources.Button.BtnShow %>
                                        </a>
                                        <a href="Project_Edit.aspx?id=<%= project.IDProject %>" type="button" class="btn btn-sm btn-primary">
                                              <%= Resources.Button.BtnEdit %>
                                        </a>
                                        <a href="Project_Delete.aspx?id=<%= project.IDProject %>" type="button" class="btn btn-sm btn-danger">
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
