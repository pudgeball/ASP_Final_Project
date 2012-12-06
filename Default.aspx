<%@ Page Title="League of Legends" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #content
        {
            background-image:url(<%=splashUrl%>);
            background-size: 900px;
	        background-repeat: no-repeat;
	        padding-bottom: 5px;
        }
    </style>

    <link type="text/css" rel="Stylesheet" href="CSS/Default.css" />    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <div id="transparentBoxContainer">
        <div id="transparentBox">
            <h1>Welcome</h1>

			<p>
				Welcome to the League of Legends Nexus! Want advice on how to play your favourite champion? Check out the <a                          href="#">Champion Builds</a> page to browse a selection of guides made by our own community. Think you can give better                advice? Write your own build guide with our <a href="#">build creator!</a> And don't forget to visit the always-                      changing <a href="#">Tier List</a> page, where you can see what the community has to say about the League. Don't like                 where your favourite (or least favourite) champions rank on the list? Cast your vote!
			</p>

            <div id="randomBuildContainer">
                <h2>Random Build</h2>
                <asp:PlaceHolder ID="randomBuildPlaceholder" runat="server" />
            </div>

            <div id="tierContainer">
                <h2>Top Tier Champions</h2>
                <asp:PlaceHolder ID="tierPlaceholder" runat="server" />
            </div>

            <div class="clear"></div>
        </div>
        <div id="grad"></div>
    </div>
</asp:Content>

