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
    <asp:Label ID="lblLevelOne" runat="server" Text="Level 1: " Visible="False"></asp:Label>
&nbsp;<asp:DropDownList ID="dropLevelOne" runat="server" Visible="False">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Create Build" />
</asp:Content>

