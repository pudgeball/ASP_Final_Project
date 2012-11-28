<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuildDetail.aspx.cs" Inherits="BuildDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
       #pageContent_AbilityInfo
       {
           clear: both;
       }
       
       .description
       {
           padding: 10px;
           width: inherit;
           background-color: #2A2A2A;
           overflow: hidden;
           
       }
       
       .selected 
       {
           background-color: Lime;
       }
       
       .passive 
       {
           background-color: #0A0A0A;
           text-align: center;
       }
       
       .section
       {
           background-color: #2A2A2A;
       }
       
       .sectionTitle
       {
           background-color: #3A3A3A;
           padding: 5px 10px;
           margin: 0;
       }
       
       .abilityName
       {
           width: 220px;
           border-spacing: 0;
           padding-left: 10px;
       }
       
       .abilityLevel
       {
           width: 35px;
           border-spacing: 0;
           padding: 0;
           text-align: center;
       }
       
       .abilityRowEven
       {
           background-color: #2A2A2A;
       }
       
       Table 
       {
           width: 100%;
       }
       
       tr
       {
           background-color: #0A0A0A;
       }
       
       h3, h4 
       {
           text-align: center;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
<asp:PlaceHolder ID="placeBuildInfo" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="placeAbilities" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="placeItems" runat="server"></asp:PlaceHolder>
</asp:Content>

