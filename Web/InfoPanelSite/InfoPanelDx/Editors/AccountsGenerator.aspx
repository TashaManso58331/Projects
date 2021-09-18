<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AmsSettingMaster.Master" Async="true" CodeBehind="AccountsGenerator.aspx.cs" Inherits="InfoPanelDx.Editors.AccountsGenerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" Theme="Office2003Olive"
    OnCellEditorInitialize="gv_CellEditorInitialize"
     OnCustomButtonCallback="grid_CustomButtonCallback" 
    >
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
    <SettingsPager PageSize="50" />
    <SettingsEditing Mode="Inline">
        <BatchEditSettings EditMode="Row" />
    </SettingsEditing>
    <Settings ShowGroupPanel="True" VerticalScrollBarMode="Auto"  VerticalScrollableHeight="600" />
    <SettingsSearchPanel Visible="True" />
    <Columns>        
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
        <dx:GridViewCommandColumn VisibleIndex="6">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="Generate">
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>        
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>