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
	private int index;

    protected void Page_Load(object sender, EventArgs e)
    {
		localhost.LeagueOfLegendsWebService leagueService = new localhost.LeagueOfLegendsWebService();
		List<localhost.Character> characters = leagueService.GetCharacters().ToList<localhost.Character>();

        dropCharacter.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);

		if (Page.IsPostBack)
		{
			lblLevelOne.Visible = true;
			dropLevelOne.Visible = true;
		}
		else
		{
			dropCharacter.DataSource = characters;
			dropCharacter.DataTextField = "Name";
			dropCharacter.DataValueField = "ID";
			dropCharacter.DataBind();
		}
    }

    void characterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
		DropDownList listBox = (DropDownList)sender;
		string connStr = ConfigurationManager.ConnectionStrings["connStr_LeagueOfLegends"].ConnectionString;
		SqlConnection conn = new SqlConnection(connStr);
		conn.Open();
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = conn;
		string sql = "SELECT [Abilities].[name], [Abilities].[description] FROM [Abilities] INNER JOIN [CharactersAbilities] ON [Abilities].[name] = [CharactersAbilities].[abilityName] INNER JOIN [Characters] ON [CharactersAbilities].[characterId] = [Characters].[id] WHERE [Characters].[id] = " + listBox.Items[listBox.SelectedIndex].Value;
		cmd.CommandText = sql;
		SqlDataReader dr = cmd.ExecuteReader();

		Response.Write(sql);
		if (dr.HasRows)
		{
			while (dr.Read())
			{
				string Name = dr["name"].ToString();
				string Description = dr["description"].ToString();
				//abilities.Add(new Ability(Name, Description));
			}
		}
		else
		{
			Response.Write("No Rows");
		}
		dr.Close();
		conn.Close();

		//Response.Write(abilities.Count);
		localhost.LeagueOfLegendsWebService leagueService = new localhost.LeagueOfLegendsWebService();
		int id = Convert.ToInt32(listBox.Items[listBox.SelectedIndex].Value);
		dropLevelOne.DataSource = leagueService.GetAbilities(id);
		dropLevelOne.DataTextField = "Name";
		dropLevelOne.DataValueField = "Name";
		dropLevelOne.DataBind();
    }
}