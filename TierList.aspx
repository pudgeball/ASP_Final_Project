<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TierList.aspx.cs" Inherits="TierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        ol
        {
            list-style-type: none;
            padding: 0px;
            margin: 0 auto;
            width: 600px;
        }
        
        #pageContent_listItem
        {
            background-color: #0A0A0A;
            margin-bottom: 10px;
            height: 52px;
            border: 1px solid black;
            clear: both;
        }
        
        #pageContent_listItem img
        {
            height: 50px;
            float:left;
        }
        
        #pageContent_rankContainer
        {
            padding-top: 3px;
            width: 100px;
            text-align: center;
            font-size: 38px;
            font-weight: bold;
            float: left;
            color: #EACE41;
        }
        
        #pageContent_masterContainer
        {
            float: left;
            width: 448px;
            height: 52px;
            background-color: #2A2A2A;
        }
        
        #pageContent_characterNameContainer
        {
            color: #EACE41;
            font-size: 20px;
            font-weight: bold;
            padding: 0px;
            width: 175px;
            float: left;
            padding-top: 15px;
            text-align: center;
            width: 150px;
        }
        
        #pageContent_upvote
        {
            display: inline-block;
            margin-top: 10px;
            background-color: #1A1A1A;
            border: 1px solid black;
            box-shadow: 1px 1px 3px black;
            float: left;
        }
        
        #pageContent_upvote img
        {
            height: 30px;
        }
        
        #pageContent_upvote:hover
        {
            border: 1px solid white;
            box-shadow: 1px 1px 3px white;
        }
        
        #pageContent_downvote
        {
            margin-left: 20px;
            margin-top: 10px;
            display: inline-block;
            background-color: #1A1A1A;
            border: 1px solid black;
            box-shadow: 1px 1px 3px black;
            float: left;
        }
        
        #pageContent_downvote img
        {
            height: 30px;
        }
        
        #pageContent_downvote:hover
        {
            border: 1px solid white;
            box-shadow: 1px 1px 3px white;
        }
        
        #pageContent_voteNumber
        {
            margin-top: 15px;
            width: 189px;
            text-align: center;
            float: left;
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

