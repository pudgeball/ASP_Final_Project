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
            height: 120px;
            border: 1px solid black;
            clear: both;
        }
        
        #pageContent_rankContainer
        {
            margin-top: 30px;
            width: 100px;
            text-align: center;
            font-size: 48px;
            font-weight: bold;
            float: left;
            color: #EACE41;
        }
        
        #pageContent_masterContainer
        {
            float: left;
            width: 378px;
            height: 120px;
            background-color: #2A2A2A;
        }
        
        #pageContent_voteControlAndVoteNumberContainer
        {
            margin-top: 17px;
        }
        
        #pageContent_characterNameContainer
        {
            background-color: #3A3A3A;
            color: #EACE41;
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            padding: 5px 0px;
            border-bottom: 1px solid black;
        }
        
        #pageContent_voteControl
        {
            float: left;
        }
        
        #pageContent_voteControl a
        {
            text-decoration: none;
            font-size: 24pt;
        }
        
        #pageContent_upvote
        {
            margin-left: 50px;
            display: inline-block;
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
            display: inline-block;
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
            margin-top: 15px;
            margin-left: 50px;
            float: left;
        }
        
        #pageContent_listItem img
        {
            float:left;
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

