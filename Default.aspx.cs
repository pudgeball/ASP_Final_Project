using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    LeagueOfLegendsWebService webService;

    protected void Page_Load(object sender, EventArgs e)
    {
        webService = new LeagueOfLegendsWebService();

        populateRandomBuildPlaceholder();
        populateTierPlaceholder();
    }

    private void populateRandomBuildPlaceholder()
    {
        Build randomBuild = webService.GetRandomBuild();
        string characterName = randomBuild.Character.Name;
        string buildName = randomBuild.BuildName;
        string userName = randomBuild.UserName;

        HyperLink linkToBuild = new HyperLink();
        linkToBuild.ID = "linkToBuild";
        linkToBuild.NavigateUrl = "BuildDetail.aspx?BuildID=" + randomBuild.ID.ToString();

        HtmlGenericControl randomBuildControl = new HtmlGenericControl("div");
        randomBuildControl.InnerHtml += "<b>" + buildName + "</b>";
        randomBuildControl.InnerHtml += "<br/>A guide for the Champion " + characterName;
        randomBuildControl.InnerHtml += "<br/>By: " + userName;

        linkToBuild.Controls.Add(randomBuildControl);

        randomBuildPlaceholder.Controls.Add(linkToBuild);
    }

    private void populateTierPlaceholder()
    {
        List<Character> characters = webService.GetCharactersOrderedByVote().ToList<Character>();
        HtmlGenericControl tierContainerContent = new HtmlGenericControl("div");
        tierContainerContent.ID = "tierContainerContent";

        for (int i = 0; i < 2; i++)
        {
            string characterName = characters[i].Name;

            tierContainerContent.InnerHtml += (i + 1) + ". <a href=ViewBuilds?ID=" + i + ">" + characterName + "</a><br/>";
        }

        tierPlaceholder.Controls.Add(tierContainerContent);
    }
}