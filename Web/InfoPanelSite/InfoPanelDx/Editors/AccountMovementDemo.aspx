<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AmsSettingMaster.Master" Async="true" CodeBehind="AccountMovementDemo.aspx.cs" Inherits="InfoPanelDx.Editors.AccountMovementDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" AlignItemCaptionsInAllGroups="True" Height="120px" Width="100%">
            <Items>
                <dx:LayoutItem Caption="Movement Type">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cbMovementType" runat="server" DataSourceID="SqlDataSource1" TextField="Name" ValueField="Id" Theme="Office2003Olive" SelectedIndex="0">
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DM_UATConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [MovementTypes]"></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Ams Schema">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cbAmsSchema" runat="server" DataSourceID="SqlDataSource2" TextField="Name" ValueField="Id" Width="100%" Theme="Office2003Olive" SelectedIndex="0">
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DM_UATConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [AmsShemas]"></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Members">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxGridView ID="gvMembers" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" KeyFieldName="Id" Width="100%" Theme="Office2003Olive">
                                <SettingsSearchPanel Visible="True" />
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" Visible="False" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TaxRegistrationNumber" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="BankAccount" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DM_UATConnectionString %>" SelectCommand="SELECT [Id], [Name], [Country], [TaxRegistrationNumber], [Address], [BankAccount] FROM [Members]"></asp:SqlDataSource>                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Parameters">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxMemo ID="memoParameters" runat="server" Font-Size="Large" Width="100%" Theme="Office2003Olive" Height="100px">
                            </dx:ASPxMemo>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" HorizontalAlign="Center">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton runat="server" ID="ASPxFormLayout1_E3" Text="Press to start valuation" OnClick="RunClick" Theme="Office2003Olive"/>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:ASPxFormLayout>
</asp:Content>