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
			try
			{
				characterID = Convert.ToInt32(characterData["ID"]);
				LeagueOfLegendsWebService webservice = new LeagueOfLegendsWebService();

				Character selectedCharacter = webservice.GetCharacter(characterID);

				List<Character> characters = webservice.GetCharacters().ToList<Character>();
				if (characterID > characters.Count())
				{
					Response.Redirect("Characters.aspx");
				}
				if (characterID < 0)
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
				if (builds.Count() < 1)
				{
					HtmlGenericControl noBuildsContainer = new HtmlGenericControl("div");
					noBuildsContainer.InnerText = "There are currently no builds for this champion";
					HyperLink characterLink = new HyperLink();
					HtmlGenericControl noBuildsRedirectContainer = new HtmlGenericControl("div");

					characterLink.NavigateUrl = "Characters.aspx";
					characterLink.Text = "Back to Characters page";
					noBuildsRedirectContainer.Controls.Add(characterLink);
					buildsPlaceholder.Controls.Add(noBuildsContainer);
					buildsPlaceholder.Controls.Add(noBuildsRedirectContainer);

					noBuildsRedirectContainer.ID = "redirectContainer";
					noBuildsContainer.ID = "noBuildsContainer";
				}
				else
				{
					for (int i = 0; i < builds.Count(); i++)
					{
						HtmlGenericControl buildContainer = new HtmlGenericControl("div");
						HtmlGenericControl buildNameContainer = new HtmlGenericControl("div");
						HtmlGenericControl buildUserNameContainer = new HtmlGenericControl("div");
						

						HyperLink buildClick2 = new HyperLink();
						buildClick2.NavigateUrl = "BuildDetail.aspx?BuildID=" + builds[i].ID;
						buildContainer.ID = "buildContainer";
						buildNameContainer.ID = "buildNameContainer";
						buildUserNameContainer.ID = "buildUserNameContainer";

						buildNameContainer.InnerText = builds[i].BuildName;
						buildUserNameContainer.InnerText = builds[i].UserName;
							
						buildContainer.Controls.Add(buildNameContainer);
						buildContainer.Controls.Add(buildUserNameContainer);
						buildClick2.Controls.Add(buildContainer);
						buildsPlaceholder.Controls.Add(buildClick2);



					}
				}
			}
			catch (Exception ex)
			{
				Response.Redirect("Characters.aspx");
			}
		

		}
		else
		{
			Response.Redirect("Characters.aspx");
		}
    }
}
