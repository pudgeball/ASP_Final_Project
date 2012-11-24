﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using localhost;

public partial class TierList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LeagueOfLegendsWebService webService = new LeagueOfLegendsWebService();
        List<Character> characters = webService.GetCharacters().ToList<Character>();
        
        for (int i = 0; i < characters.Count; i++)
        {
            string characterName = characters[i].Name.ToLower();
            string characterID = characters[i].ID.ToString();
            int tierPosition;
            //get tierPosition ... webService.GetTierPosition(characterID);

            HtmlGenericControl listItem = new HtmlGenericControl("li");
            Image image = new Image();
            image.ImageUrl = "Images/" + characterName + ".png";


            //string imagePath = "<img src=\"Images/" + characterName + ".png\"></img>";

            tierListPlaceholder.Controls.Add(image);
        }

    }
}