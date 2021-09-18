<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ACH.Master" Async="true" CodeBehind="ACHPayments.aspx.cs" Inherits="InfoPanelDx.Editors.ACHPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" Theme="Office2003Olive"
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
        <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataComboBoxColumn FieldName="MemberSenderId" Caption="Member Sender" VisibleIndex="2">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataComboBoxColumn FieldName="MemberBeneficiaryId" Caption="Member Beneficiary" VisibleIndex="3">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataDateColumn FieldName="PaymentDate" VisibleIndex="4" >
        </dx:GridViewDataDateColumn>        
        <dx:GridViewDataTextColumn FieldName="Amount" VisibleIndex="5" >
        </dx:GridViewDataTextColumn>        
        <dx:GridViewDataComboBoxColumn FieldName="CurrencyId" Caption="Currency" VisibleIndex="6">
            <PropertiesComboBox TextField="TextCode" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>