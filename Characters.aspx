<%@ Page Title="Characters" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Characters.aspx.cs" Inherits="Characters" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" rel="Stylesheet" href="CSS/characters.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
<h1>Characters</h1>

<asp:PlaceHolder ID="charactersPlaceholder" runat="server" />

    <div id="footer"></div>
</asp:Content>

