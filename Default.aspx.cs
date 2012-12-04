using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;
using System.Web.UI.HtmlControls;
using LeagueOfLegends.Model.Utility;

public partial class _Default : System.Web.UI.Page
{
    LeagueOfLegendsWebService webService;
    public string splashUrl = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        webService = new LeagueOfLegendsWebService();

        SetRandomSplashImage();
        PopulateRandomBuildPlaceholder();
        PopulateTierPlaceholder();
    }

    private void PopulateRandomBuildPlaceholder()
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

    private void PopulateTierPlaceholder()
    {
        List<Character> characters = webService.GetCharactersOrderedByVote().ToList<Character>();
        HtmlGenericControl tierContainerContent = new HtmlGenericControl("div");
        tierContainerContent.ID = "tierContainerContent";

        for (int i = 0; i < 5; i++)
        {
            string characterName = characters[i].Name;

            tierContainerContent.InnerHtml += (i + 1) + ". <a href=ViewBuilds.aspx?ID=" + characters[i].ID + ">" + characterName + "</a><br/>";
        }

        tierPlaceholder.Controls.Add(tierContainerContent);
    }

    private void SetRandomSplashImage()
    {
        List<Character> characters = webService.GetCharacters().ToList<Character>();
        Character randomCharacter = characters[new Random().Next(characters.Count)];
        splashUrl = CharacterUtility.GetImagePath(randomCharacter.Name, CharacterUtility.ImageType.Splash);
    }
}