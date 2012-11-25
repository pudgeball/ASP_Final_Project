<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TierList.aspx.cs" Inherits="TierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        ol
        {
            list-style-type: none;
            padding: 0px;
            margin: 0 auto;
            width: 500px;
        }
        
        #pageContent_listItem
        {
            background-color: #0A0A0A;
            margin-bottom: 10px;
            height: 120px;
            border: 1px solid black;
        }
        
        #pageContent_voteControl
        {
            vertical-align: top;
            /*background-color: Red;*/
            display: inline-block;
            height: 120px;
            width: 210px;
        }
        
        #pageContent_voteControl a
        {
            text-decoration: none;
            font-size: 24pt;
        }
        
        #pageContent_upvote
        {
            margin-top: 35px;
            margin-left: 50px;
            width: 50px;
            height: 50px;
            display: inline-block;
            text-align: center;
            background-color: #2A2A2A;
            border: 1px solid black;
            box-shadow: 1px 1px 3px black;
        }
        
        #pageContent_upvote:hover
        {
            border: 1px solid white;
            box-shadow: 1px 1px 3px white;
        }
        
        #pageContent_downvote
        {
            margin-left: 50px;
            width: 50px;
            height: 50px;
            display: inline-block;
            text-align: center;
            background-color: #2A2A2A;
            border: 1px solid black;
            box-shadow: 1px 1px 3px black;
        }
        
        #pageContent_downvote:hover
        {
            border: 1px solid white;
            box-shadow: 1px 1px 3px white;
        }
        
        #pageContent_voteNumber
        {
            margin-top: 50px;
            margin-left: 50px;
            vertical-align: top;
            display: inline-block;
            height: 120px;
        }
        
        .selected
        {
            background-color: #EACE41 !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <h1>Tier List</h1>
    <div id="tierList">
        <asp:PlaceHolder ID="tierListPlaceholder" runat="server" />
    </div>
</asp:Content>

