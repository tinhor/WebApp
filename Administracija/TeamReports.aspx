<%@ Page Title="Team" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="TeamReports.aspx.cs" Inherits="Administracija._TeamReports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                         <div class="input-group input-group-sm">
                                        <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack ="false" CssClass="w-100 form-control" data-live-search="true"></asp:DropDownList>
                                    </div>   
                                    <div class="input-group input-group-sm mt-2">
                                        <asp:Textbox ID="txtClientDatesStart" type="date" CssClass="form-control" runat="server" placeholder="Odaberite početni datum" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:Textbox ID="txtClientDatesEnd" type="date" CssClass="form-control" runat="server" placeholder="Odaberite krajnji datum" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                    </div>    
                                            <div class="input-group-prepend mt-2">
                                                <asp:LinkButton ID="btnClientReport" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnClientReport_Click">Pregled</asp:LinkButton>
                                                <button id="printCSV" class="btn btn-sm btn-warning ml-2">CSV Export</button>
                                            </div>
                        

                </div>
                <!-- // -->

                <div class="card-body mt-2">
                    <div class="table-responsive table-striped">
                          <table id="clientTable" class="table table-bordered">
                              <asp:Repeater ID="rpTableClients" runat="server">
                                    <HeaderTemplate>
                                        <thead>
                                            <tr>
                                                <th>Osoba</th>
                                                <th>Datum</th>
                                                <th>Radni sati</th>
                                                <th>Prekovremni sati</th>
                                            </tr>
                                        </thead>
                                <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                        <td><asp:Literal ID="txtProject" runat="server" Text='<%# Eval("FullName") %>' /></td>
                                        <td><asp:Literal ID="txtDate" runat="server" Text='<%# ((DateTime)Eval("Date")).ToString("dd/MM/yyyy") %>' /></td>
                                        <td class="text-primary"><asp:Literal ID="txtWorktime" runat="server" Text='<%# Eval("Worktime") %>' /></td>
                                        <td class="text-primary"><asp:Literal ID="txtOvertime" runat="server" Text='<%# Eval("Overtime") %>' /></td>
                                       
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <% if (rpTableClients.Items.Count == 0) { %>
                                    <tr><td class="text-center" colspan="5">Nema podataka</td></tr>
                                    <% } %>

                                </tbody>
                            </table>
                            </FooterTemplate>
                           </asp:Repeater>
                         </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        let options = {
            "separator": ",",
            "newline": "\n",
            "quoteFields": true,
            "excludeColumns": "",
            "excludeRows": "",
            "trimContent": true,
            "filename": "ClientReport.csv"
        }

        $(document).on("click", "#printCSV", function () {
            $('#clientTable').table2csv('download', options);
        });

</script>
</asp:Content>
