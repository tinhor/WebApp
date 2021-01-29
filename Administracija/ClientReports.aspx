<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Administracija.Master" AutoEventWireup="true" CodeBehind="ClientReports.aspx.cs" Inherits="Administracija._ClientReports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <!-- NASLOV -->
                <div class="card-header">
                         <div class="input-group input-group-sm">
                                        <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack ="false" CssClass="w-100 form-control" data-live-search="true"></asp:DropDownList>
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
                                                <th>Projekt</th>
                                                <th>Datum</th>
                                                <th>Ukupno vrijeme</th>
                                            </tr>
                                        </thead>
                                <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                        <td><asp:Literal ID="txtProject" runat="server" Text='<%# Eval("Title") %>' /></td>
                                        <td><asp:Literal ID="txtDate" runat="server" Text='<%# ((DateTime)Eval("Date")).ToString("dd/MM/yyyy") %>' /></td>
                                        <td class="text-primary"><asp:Literal ID="txtWorktime" runat="server" Text='<%# Eval("Fulltime") %>' /></td>
                                       
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <% if (rpTableClients.Items.Count == 0) { %>
                                    <tr><td class="text-center" colspan="3">Nema podataka</td></tr>
                                    <% } %>

                                </tbody>
                                     <tfoot>
                                    <tr>
                                        <th>Ukupno</th>
                                        <th></th>
                                        <th class=""><asp:Literal ID="txtSum" runat="server" Text='<%# Administracija.Models.ClientReports.Sum %>'></asp:Literal></th>
                                    </tr>
                                </tfoot>
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
