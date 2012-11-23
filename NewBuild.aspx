<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewBuild.aspx.cs" Inherits="NewBuild" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Build Name: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Character: "></asp:Label>
&nbsp;<asp:DropDownList ID="dropCharacter" runat="server" 
        AutoPostBack="True">
    </asp:DropDownList>
    <br />
&nbsp;<br />
    <asp:PlaceHolder ID="placeholderAbilityTable" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <br />
    <asp:ListBox ID="listAllItems" runat="server" AutoPostBack="True" 
        onselectedindexchanged="listAllItems_SelectedIndexChanged"></asp:ListBox>
    <asp:Button ID="cmdAdd" runat="server" Text="&gt;&gt;" onclick="cmdAdd_Click" 
        Enabled="False" />
    <asp:Button ID="cmdRemove" runat="server" Text="&lt;&lt;" 
        onclick="cmdRemove_Click" Enabled="False" />
    <asp:ListBox ID="listBuildItems" runat="server" AutoPostBack="True" 
        onselectedindexchanged="listBuildItems_SelectedIndexChanged"></asp:ListBox>
    <br />
    <br />
    <br />
    <asp:Button ID="cmdCreate" runat="server" Text="Create Build" 
        onclick="cmdCreate_Click" />
</asp:Content>

