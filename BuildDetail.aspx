<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuildDetail.aspx.cs" Inherits="BuildDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="Stylesheet" href="CSS/BuildDetail.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
<asp:PlaceHolder ID="placeBuildInfo" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="placeAbilities" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="placeItems" runat="server"></asp:PlaceHolder>
</asp:Content>

