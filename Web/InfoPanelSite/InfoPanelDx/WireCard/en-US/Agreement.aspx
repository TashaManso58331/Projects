<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agreement.aspx.cs" Inherits="InfoPanelDx.WireCard.en_US.Agreement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
            <Items>
                <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="True">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxLabel ID="ASPxFormLayout1_E1" runat="server" Font-Size="XX-Large" Text="Diesel.Market">
                            </dx:ASPxLabel>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutGroup Caption="" ColSpan="1">
                    <GroupBoxStyle Border-BorderStyle="None">
                    </GroupBoxStyle>
                    <Items>
                        <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="ASPxFormLayout1_E4" runat="server" CheckState="Unchecked" Font-Size="Medium" OnCheckedChanged="ASPxFormLayout1_E4_CheckedChanged" Text="Ich akzeptiere die Nutzungsbedingungen">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="False" Visible="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="ASPxFormLayout1_E5" runat="server" Enabled="True" Font-Size="Large" Height="35px" Text="Weiter" Width="92px">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="1">
                        </dx:EmptyLayoutItem>
                        <dx:LayoutGroup Caption="" ColCount="2" ColSpan="1" ColumnCount="2">
                            <GroupBoxStyle Border-BorderStyle="None">
                            </GroupBoxStyle>
                            <Items>
                                <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxHyperLink ID="ASPxFormLayout1_E7" runat="server" Font-Size="Medium" Text="AGB" NavigateUrl="~/WireCard/en-US/Pages/AGB.aspx">
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxHyperLink ID="ASPxFormLayout1_E8" runat="server" Font-Size="Medium" Text="Datenschutz" NavigateUrl="~/WireCard/en-US/Pages/Datenschutz.aspx">
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxHyperLink ID="ASPxFormLayout1_E6" runat="server" Font-Size="Medium" Text="Widerrufserklärung" NavigateUrl="~/WireCard/en-US/Pages/Widerrufserklarung.aspx">
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ColSpan="1" HorizontalAlign="Center" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxHyperLink ID="ASPxFormLayout1_E9" runat="server" Font-Size="Medium" Text="Impressum" NavigateUrl="~/WireCard/en-US/Pages/Impressum.aspx">
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </form>
</body>
</html>
