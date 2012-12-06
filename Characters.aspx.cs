using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using localhost;
using LeagueOfLegends.Model.Utility;

public partial class Characters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		LeagueOfLegendsWebService webservice = new LeagueOfLegendsWebService();

		HtmlGenericControl characterTextContainer = new HtmlGenericControl("p");
		characterTextContainer.InnerText = "Click a portrait below to view builds for that character";
		charactersPlaceholder.Controls.Add(characterTextContainer);

		List<Character> characters = webservice.GetCharacters().ToList<Character>();
		for (int i = 0; i < characters.Count(); i++)
		{
			HtmlGenericControl imageContainer = new HtmlGenericControl("div");
			HtmlGenericControl nameContainer = new HtmlGenericControl("div");
			HtmlGenericControl characterContainer = new HtmlGenericControl("div");
			
			

			imageContainer.ID = "imageContainer";
			nameContainer.ID = "nameContainer";
			characterContainer.ID = "characterContainer";
			string name = characters[i].Name;
			string link = "ViewBuilds.aspx?ID=" + characters[i].ID;

			Image charImage = new Image();
            charImage.ImageUrl = CharacterUtility.GetImagePath(name, CharacterUtility.ImageType.Square);
			HyperLink imageLink = new HyperLink();
			imageLink.NavigateUrl = link;
			

			HyperLink nameLink = new HyperLink();
			nameLink.Text = name;
			imageLink.Controls.Add(charImage);
			nameLink.NavigateUrl = link;

			imageContainer.Controls.Add(imageLink);
			nameContainer.Controls.Add(nameLink);
			characterContainer.Controls.Add(imageContainer);
			characterContainer.Controls.Add(nameContainer);
			
			charactersPlaceholder.Controls.Add(characterContainer);

		}
    }
}