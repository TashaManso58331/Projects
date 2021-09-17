<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" Async="true" CodeBehind="Instructions.aspx.cs" Inherits="InfoPanelDx.Editors.Instructions" ValidateRequest="false"%>

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
        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2" Width="120">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Text" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataComboBoxColumn FieldName="TextType" Caption="Text Type" VisibleIndex="4" Width="60">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="CultureInfo" Caption="Language" VisibleIndex="5" Width="60">
            <PropertiesComboBox TextField="Name" ValueField="Name">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn> 
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
</asp:Content>