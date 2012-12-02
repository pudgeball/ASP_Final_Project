<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            #content
            {
                background-image:url(<%=splashUrl%>);
                background-size: 900px;
				background-repeat: no-repeat;
            }
        
        	#transparentBoxContainer
			{
				padding-top: 160px;
				padding-bottom: 20px;
				position: relative;
				width: 900px;
			}

			#transparentBox
			{
				margin: 0px 20px 20px 20px;
				padding: 10px 30px 30px 30px;
				background-color: rgba(0, 0, 0, 0.7);
			}
			
			#randomBuildContainer
			{
			    text-align: center;
			    width: 375px;
			    float: left;
			}
			
			#pageContent_linkToBuild
			{
			    text-decoration: none;
			    margin: 0 auto;
			    padding: 10px 0px;
			    width: 300px;
			    display: block;
			    background-color: rgb(54, 23, 94);
			    border-radius: 10px 10px;
			    border-bottom: 3px solid rgb(123, 82, 171);
			}
			
			#pageContent_linkToBuild:hover
			{
			    color: inherit;
			    background-color: rgb(123, 82, 171);
			}
			
			#tierContainer
			{
			    text-align: center;
			    width: 375px;
			    float: left;   
			}
			
			#pageContent_tierContainerContent
			{
			    margin: 0 auto;
			    width: 300px;
			}
			
			#grad
			{
			    position: absolute;
			    bottom: 0;
			    left: 0;
			    right: 0;
			    height: 100px;
			    background-image: -webkit-linear-gradient(top, rgba(0, 0, 0, 0) 0%, rgba(20, 19, 18, 1) 100%, #24221F 100%);
			}
    </style>
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

