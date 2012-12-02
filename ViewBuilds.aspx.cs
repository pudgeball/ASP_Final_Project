using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using localhost;
using LeagueOfLegends.Model.Utility;

public partial class ViewBuilds : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
		int characterID = 0;
		NameValueCollection characterData = Request.QueryString;



		if (characterData["ID"] != null)
		{
			characterID = Convert.ToInt32(characterData["ID"]);
			LeagueOfLegendsWebService webservice = new LeagueOfLegendsWebService();

			Character selectedCharacter = webservice.GetCharacter(characterID);

			List<Character> characters = webservice.GetCharacters().ToList<Character>();
			if(characterID > characters.Count())
			{
				Response.Redirect("Characters.aspx");
			}
			if(characterID < 0)
			{
				Response.Redirect("Characters.aspx");
			}


			string characterName = selectedCharacter.Name;
			int skinCount = selectedCharacter.SkinCount;
			

			//Create HTMLGenericControl and add Character name to it
			HtmlGenericControl title = new HtmlGenericControl("h1");
			title.InnerText = characterName;
			buildsPlaceholder.Controls.Add(title);

			//Add random portrait art
			Random rand = new Random();
			Image characterPortrait = new Image();
			characterPortrait.ImageUrl = CharacterUtility.GetImagePath(characterName, CharacterUtility.ImageType.Portrait, rand.Next(skinCount));
			HtmlGenericControl portraitImage = new HtmlGenericControl("div");
			portraitImage.Controls.Add(characterPortrait);
			portraitImage.ID = "portraitContainer";
			buildsPlaceholder.Controls.Add(portraitImage);

			List<Build> builds = webservice.GetBuildsForCharacter(characterID).ToList<Build>();
			for (int i = 0; i < builds.Count(); i++)
			{
				HtmlGenericControl buildContainer = new HtmlGenericControl("div");
				HtmlGenericControl buildNameContainer = new HtmlGenericControl("div");
				HtmlGenericControl buildUserNameContainer = new HtmlGenericControl("div");

				buildContainer.ID = "buildContainer";
				buildNameContainer.ID = "buildNameContainer";
				buildUserNameContainer.ID = "buildUserNameContainer";

				HyperLink buildNameLink = new HyperLink();
				HyperLink buildUserNameLink = new HyperLink();
				buildNameLink.NavigateUrl = "BuildDetail.aspx?BuildID=" + builds[i].ID;
				buildUserNameLink.NavigateUrl = "BuildDetail.aspx?BuildID=" + builds[i].ID;
				
				buildNameLink.Text = builds[i].BuildName;
				buildUserNameLink.Text = "By " + builds[i].UserName;
				
				buildNameContainer.Controls.Add(buildNameLink);
				buildUserNameContainer.Controls.Add(buildUserNameLink);

				buildContainer.Controls.Add(buildNameContainer);
				buildContainer.Controls.Add(buildUserNameContainer);

				buildsPlaceholder.Controls.Add(buildContainer);

			}

		}
		else
		{
			Response.Redirect("Characters.aspx");
		}
    }
}
