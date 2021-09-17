<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Routes.Master" Async="true" CodeBehind="RouteFuelTransactionStepScreens.aspx.cs" Inherits="InfoPanelDx.Editors.RouteFuelTransactionStepScreens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" OnRowUpdating="gv_OnRowUpdating" OnRowDeleting="gv_OnRowDeleting" Theme="Office2003Olive"
    >
    <SettingsPager PageSize="50" />
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
    <SettingsEditing Mode="Inline">
        <BatchEditSettings EditMode="Row" />
    </SettingsEditing>
    <Settings ShowGroupPanel="True" VerticalScrollBarMode="Auto"  VerticalScrollableHeight="600" />
    <SettingsSearchPanel Visible="True" />
    <Columns>
        <dx:GridViewDataTextColumn FieldName="RouteFuelTransactionStepId" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn FieldName="RoleId" Caption="Role" VisibleIndex="3">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ButtonText" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn FieldName="FuelTransactionsPatternStepScreenId" Caption="Pattern Step Screen" VisibleIndex="7">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="16">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
</asp:Content>