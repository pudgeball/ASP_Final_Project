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
        AutoPostBack="True" ViewStateMode="Enabled">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblLevelOne" runat="server" Text="Level 1: "></asp:Label>
&nbsp;<asp:DropDownList ID="dropLevelOne" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <asp:Button ID="Button2" runat="server" Text="&gt;&gt;" />
    <asp:Button ID="Button3" runat="server" Text="&lt;&lt;" />
    <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Create Build" />
</asp:Content>

