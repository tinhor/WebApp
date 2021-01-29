<%@ Page Title="New Worker" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="Project_Users.aspx.cs" Inherits="Administracija._Project_Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
             <asp:Label runat="server" ID="lblSystemMessage"></asp:Label>
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                    <h4 class="card-title">
                        Osobe na projekt
                    </h4>
                </div>
                <!-- // -->

                <div class="card-body mt-2">
<div class="input-group input-group-sm">
  <asp:DropDownList runat="server" CssClass="form-control mb-2" ID="workerList"></asp:DropDownList>
  <div class="input-group-prepend">
      <asp:Button runat="server" ID="btnAddUserToProject" meta:resourcekey="btnNewProject" CssClass="btn btn-primary float-right" OnClick="btnAddUserToProject_Click" />
  </div>
</div>                </div>

                         <div class="card-body mt-2">
                    <div class="table-responsive table-striped">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><%= Resources.Table.Table_FirstName %></th>
                                    <th><%= Resources.Table.Table_LastName %></th>
                                    <th class="text-right"><%= Resources.Table.Table_Action %></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                  <% 
                                      if (ProjectUsers.Count > 0)
                                      {
                                          foreach (var user in ProjectUsers)
                                          {

                                 %>
                                 <tr>
                                    <td><%= user.First_name %></td>
                                     <td><%= user.Last_name %></td>
                                    <td class="td-actions text-right">
                                        <a href="Project_Users_Delete.aspx?id=<%= user.IDWorker %>" type="button" class="btn btn-sm btn-danger">
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
