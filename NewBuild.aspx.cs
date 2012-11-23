using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using LeagueOfLegends;

public partial class NewBuild : System.Web.UI.Page
{
	localhost.LeagueOfLegendsWebService webService;

    protected void Page_Load(object sender, EventArgs e)
    {
		webService = new localhost.LeagueOfLegendsWebService();

        dropCharacter.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);
		if (!Page.IsPostBack)
		{
			dropCharacter.DataSource = webService.GetCharacters();
			dropCharacter.DataTextField = "Name";
			dropCharacter.DataValueField = "ID";
			dropCharacter.DataBind();

			int id = Convert.ToInt32(dropCharacter.Items[dropCharacter.SelectedIndex].Value);
			dropLevelOne.DataSource = webService.GetAbilities(id);
			dropLevelOne.DataTextField = "Name";
			dropLevelOne.DataValueField = "Name";
			dropLevelOne.DataBind();
		}
    }

    void characterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
		DropDownList listBox = (DropDownList)sender;
		localhost.LeagueOfLegendsWebService leagueService = new localhost.LeagueOfLegendsWebService();
		int id = Convert.ToInt32(listBox.Items[listBox.SelectedIndex].Value);
		dropLevelOne.DataSource = leagueService.GetAbilities(id);
		dropLevelOne.DataTextField = "Name";
		dropLevelOne.DataValueField = "Name";
		dropLevelOne.DataBind();
    }
}