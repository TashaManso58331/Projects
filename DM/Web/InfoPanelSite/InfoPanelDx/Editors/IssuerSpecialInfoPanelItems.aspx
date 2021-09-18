<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Price.master" Async="true" CodeBehind="IssuerSpecialInfoPanelItems.aspx.cs" Inherits="InfoPanelDx.Editors.IssuerSpecialInfoPanelItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" OnRowUpdating="gv_OnRowUpdating" OnRowDeleting="gv_OnRowDeleting" Theme="Office2003Olive"
    OnCellEditorInitialize="gv_CellEditorInitialize"
    >
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
    <%-- <SettingsPager PageSize="50" /> --%>
    <SettingsPager PageSize="50" />

    <SettingsEditing Mode="Inline">
        <BatchEditSettings EditMode="Row" />
    </SettingsEditing>
    <Settings ShowGroupPanel="True" VerticalScrollBarMode="Auto"  VerticalScrollableHeight="600" />
    <SettingsSearchPanel Visible="True" />
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataComboBoxColumn FieldName="GasStationId" Caption="Station" VisibleIndex="3">
            <PropertiesComboBox TextField="PublicId" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn FieldName="MemberId" Caption="Issuer" VisibleIndex="4">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn FieldName="FuelId" Caption="Fuel" VisibleIndex="5">
            <PropertiesComboBox TextField="Remarka" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn FieldName="CurrencyId" Caption="Currency" VisibleIndex="6">
            <PropertiesComboBox TextField="TextCode" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="7">
            <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="N2">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
         <dx:GridViewDataComboBoxColumn FieldName="BuyerId" Caption="Buyer" VisibleIndex="8">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="ValidFrom" VisibleIndex="8">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ValidTo" VisibleIndex="9">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="IsLatestPrice" VisibleIndex="10">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="PublishDateTime" ReadOnly="True" VisibleIndex="2">
            <PropertiesDateEdit DisplayFormatString="" EditFormat="DateTime">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>