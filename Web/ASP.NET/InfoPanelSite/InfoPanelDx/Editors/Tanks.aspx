<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Member.master" Async="true" CodeBehind="Tanks.aspx.cs" Inherits="InfoPanelDx.Editors.Tanks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" OnRowUpdating="gv_OnRowUpdating" OnRowDeleting="gv_OnRowDeleting" Theme="Office2003Olive">
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
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataComboBoxColumn FieldName="TruckId" Caption="Vehicle" VisibleIndex="1">
            <PropertiesComboBox TextField="RegistrationNumber" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataTextColumn FieldName="Volume" VisibleIndex="2">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="TankSide" Caption="Tank Side" VisibleIndex="3">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataTextColumn FieldName="Id" Visible="False">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
</asp:Content>