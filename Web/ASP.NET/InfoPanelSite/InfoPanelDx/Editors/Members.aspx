<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Member.master" Async="true" CodeBehind="Members.aspx.cs" Inherits="InfoPanelDx.Editors.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
    Width="100%" KeyFieldName="Id" OnRowInserting="gv_OnRowInserting" OnRowUpdating="gv_OnRowUpdating" OnRowDeleting="gv_OnRowDeleting" Theme="Office2003Olive">
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
        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataComboBoxColumn FieldName="MemberTypeId" Caption="Member Type" VisibleIndex="3">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>         

        <dx:GridViewDataComboBoxColumn FieldName="CountryId" Caption="Country" VisibleIndex="4">
            <PropertiesComboBox TextField="Name" ValueField="Id">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="Zip" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="City" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="State" VisibleIndex="7">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Street" VisibleIndex="8">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Building" VisibleIndex="9">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Extension" VisibleIndex="10">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="FormattedAddress" VisibleIndex="10">
        </dx:GridViewDataTextColumn>


        <dx:GridViewDataTextColumn FieldName="RegistrationNumber" VisibleIndex="11">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="TaxNumber" VisibleIndex="12">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="VATNumber" VisibleIndex="14">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="BIC" Caption="BIC/SWIFT" VisibleIndex="14">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="BankName" VisibleIndex="15">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="BankAccount" Caption="BankAccount (IBAN)" VisibleIndex="16">
        </dx:GridViewDataTextColumn>  

        <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="17">
        </dx:GridViewDataTextColumn>  

        <dx:GridViewDataTextColumn FieldName="MerchantId" VisibleIndex="18">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="MerchantMCC" VisibleIndex="19">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="BankCity" VisibleIndex="20">
        </dx:GridViewDataTextColumn>  
        <dx:GridViewDataTextColumn FieldName="BankOwner" VisibleIndex="21">
        </dx:GridViewDataTextColumn>  

        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
        </dx:GridViewDataTextColumn>        
    </Columns>
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
</dx:ASPxGridView>
</asp:Content>