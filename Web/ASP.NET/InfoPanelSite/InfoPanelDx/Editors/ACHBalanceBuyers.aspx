<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACH.Master" Async="true" CodeBehind="ACHBalanceBuyers.aspx.cs" Inherits="InfoPanelDx.Editors.ACHBalanceBuyers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" Theme="Office2003Olive"
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
        <dx:GridViewDataComboBoxColumn FieldName="MemberId" Caption="Member" VisibleIndex="2">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="From" VisibleIndex="3" >
        </dx:GridViewDataTextColumn>        
        <dx:GridViewDataTextColumn FieldName="To" VisibleIndex="4" >
        </dx:GridViewDataTextColumn>        
        <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="5" >
        </dx:GridViewDataTextColumn>        
        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="6" >
        </dx:GridViewDataTextColumn>        
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>        
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>