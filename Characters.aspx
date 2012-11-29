<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Characters.aspx.cs" Inherits="Characters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    #pageContent_characterContainer
    {
        padding:20px;
        width: 120px;
        text-align:center;
        float:left;
    }
    #footer
    {
        clear:both;
    }
    #characters
    {
        width:auto;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
<div id="characters">
<asp:PlaceHolder ID="charactersPlaceholder" runat="server" />
    </div>
    <div id="footer"></div>
</asp:Content>

