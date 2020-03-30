<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSingleMenu.Master" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="ApiSep.Ui.Grid.Grid" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles/grid.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="grid_wrapper">
        <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="10" PagerStyle-PageButtonCount="5"
            OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCreated="RadGrid1_ItemCreated" OnItemDataBound="RadGrid1_ItemDataBound"
            OnUpdateCommand="RadGrid1_UpdateCommand" OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
            AllowPaging="True" AllowSorting="true" ShowGroupPanel="true" RenderMode="Auto">
            <GroupingSettings ShowUnGroupButton="true" />
            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
            <MasterTableView AutoGenerateColumns="False"
                AllowFilteringByColumn="true" TableLayout="Fixed"
                DataKeyNames="ID" CommandItemDisplay="Top"
                InsertItemPageIndexAction="ShowItemOnFirstPage">
                <CommandItemSettings ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="true" />
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" HeaderText="Id" SortExpression="Id"
                        UniqueName="Id">
                        <HeaderStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="Username" HeaderText="Username" SortExpression="Username"
                        UniqueName="Username">
                        <HeaderStyle Width="150px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname"
                                               UniqueName="Firstname">
                        <HeaderStyle Width="150px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridNumericColumn DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname"
                                               UniqueName="Firstname">
                        <HeaderStyle Width="150px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridDateTimeColumn DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth"
                        UniqueName="DateOfBirth" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated"
                                                UniqueName="DateCreated" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridEditCommandColumn UniqueName="EditColumn" HeaderText="Edit Command Column">
                        <HeaderStyle Width="70px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="Delete Command Column">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings AllowColumnsReorder="true" AllowColumnHide="true" AllowDragToGroup="true">
                <Selecting AllowRowSelect="true" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
    <telerik:RadCodeBlock runat="server">
        <script type="text/javascript">
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("Button") >= 0) {
                    args.set_enableAjax(false);
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>


