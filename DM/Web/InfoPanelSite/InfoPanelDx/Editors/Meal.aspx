<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AML.master" Async="true" CodeBehind="Meal.aspx.cs" Inherits="InfoPanelDx.Editors.Meal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="Alcohol" runat="server"/>
    <asp:DropDownList ID="Alcohol" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Smoking Area" runat="server"/>
    <asp:DropDownList ID="SmokingArea" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Dress code" runat="server"/>
    <asp:DropDownList ID="DressCode" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Accessibility" runat="server"/>
    <asp:DropDownList ID="Accessibility" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Price" runat="server"/>
    <asp:DropDownList ID="Price" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Rambience" runat="server"/>
    <asp:DropDownList ID="Rambience" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Area" runat="server"/>
    <asp:DropDownList ID="Area" runat="server" ></asp:DropDownList>
    <br/>
    <asp:Label Text="Other Services" runat="server"/>
    <asp:DropDownList ID="OtherServices" runat="server" ></asp:DropDownList>
    <br/>
    <dx:ASPxButton Text="Search" OnClick="Unnamed_Click" runat="server" AutoPostBack="false"></dx:ASPxButton>
    <br/>
    <asp:Label Text="Response" runat="server"/>
    <dx:ASPxMemo ID="ResultText" Width="100%" Height="100%" runat="server"/>
</asp:Content>