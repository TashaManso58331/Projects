<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ContractMaster.Master" Async="true" CodeBehind="Contracts.aspx.cs" Inherits="InfoPanelDx.Editors.Contracts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" OnRowUpdating="gv_OnRowUpdating" OnRowDeleting="gv_OnRowDeleting" Theme="Office2003Olive"
    OnCellEditorInitialize="gv_CellEditorInitialize"
    >
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
    <SettingsPager PageSize="50" />
    <SettingsEditing Mode="Inline">
        <BatchEditSettings EditMode="Row" />
    </SettingsEditing>
    <Settings ShowGroupPanel="True" VerticalScrollBarMode="Auto"  VerticalScrollableHeight="600" />
    <SettingsSearchPanel Visible="True" />
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Number" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="RegistrationDate" VisibleIndex="3">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataDateColumn FieldName="ExpiryDate" VisibleIndex="4">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataComboBoxColumn FieldName="MemberId" Caption="Member" VisibleIndex="3">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn FieldName="ContractorId" Caption="Member" VisibleIndex="4">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>        
        <dx:GridViewDataComboBoxColumn FieldName="AmsShemaId" Caption="Accounts generation rule" VisibleIndex="5">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>        
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>        
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>