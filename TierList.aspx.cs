using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeagueOfLegends.Model;

public partial class TierList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        localhost.LeagueOfLegendsWebService webService = new localhost.LeagueOfLegendsWebService();
        List<localhost.Character> characters = webService.GetCharacters().ToList<localhost.Character>();
        
        for (int i = 0; i < characters.Count; i++)
        {
            string characterName = characters[i].Name.ToLower();
            string characterID = characters[i].ID.ToString();
            int tierPosition;
            //get tierPosition ... webService.GetTierPosition(characterID);

            string imagePath = "<img src=\"Images/" + characterName + ".png\"></img>";
        }

    }
}