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
		NameValueCollection characterData = Request.QueryString;

		if (characterData["ID"] != null)
		{
			int characterID = Convert.ToInt32(characterData["ID"]);
			LeagueOfLegendsWebService webservice = new LeagueOfLegendsWebService();
			Character selectedCharacter = webservice.GetCharacter(characterID);

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

			
		}
		else
		{
			Response.Redirect("Characters.aspx");
		}
    }
}
