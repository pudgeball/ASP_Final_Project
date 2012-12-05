<%@ Page Title="Tier List" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TierList.aspx.cs" Inherits="TierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="Stylesheet" href="CSS/TierList.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <h1>Tier List</h1>
    <div id="tierList">
        <asp:PlaceHolder ID="tierListPlaceholder" runat="server" />
    </div>
</asp:Content>

