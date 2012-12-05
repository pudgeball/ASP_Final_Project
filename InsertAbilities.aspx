<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertAbilities.aspx.cs" Inherits="InsertAbilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Passive"></asp:Label>
    <asp:TextBox ID="txtPassive" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Ability 1"></asp:Label>
    <asp:TextBox ID="txtAbility1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Ability 2"></asp:Label>
    <asp:TextBox ID="txtAbility2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Ability 3"></asp:Label>
    <asp:TextBox ID="txtAbility3" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Ability 4"></asp:Label>
    <asp:TextBox ID="txtAbility4" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="cmdInsert" runat="server" onclick="cmdInsert_Click" 
        Text="Insert" />
</asp:Content>

