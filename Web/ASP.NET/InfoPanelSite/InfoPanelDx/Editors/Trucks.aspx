<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Member.master" Async="true" CodeBehind="Trucks.aspx.cs" Inherits="InfoPanelDx.Editors.Trucks" %>

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
        <dx:GridViewDataTextColumn FieldName="RegistrationNumber" VisibleIndex="2">
        </dx:GridViewDataTextColumn>      
        <dx:GridViewDataTextColumn FieldName="Model" VisibleIndex="3">
        </dx:GridViewDataTextColumn>    
        <dx:GridViewDataTextColumn FieldName="K" Caption="Consumption" VisibleIndex="4">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataTextColumn FieldName="Vcritical" VisibleIndex="7">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataTextColumn FieldName="Vmax" VisibleIndex="6">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataTextColumn FieldName="Vstart" VisibleIndex="5">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="MemberId" Caption="Member" VisibleIndex="8">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="FuelTypeId" Caption="Fuel" VisibleIndex="9">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="InjectorId" Caption="Injector" VisibleIndex="10">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="DispencerVehicleType" Caption="Dispencer Vehicle" VisibleIndex="11">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="PortalDispencersType" Caption="Portal Dispencers" VisibleIndex="12">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="VehicleClass" Caption="Vehicle Class" VisibleIndex="12">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataTextColumn FieldName="Id" Visible="False">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
</asp:Content>