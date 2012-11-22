using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewBuild : System.Web.UI.Page
{
	private List<Ability> abilities = new List<Ability>();

    protected void Page_Load(object sender, EventArgs e)
    {
        characterSelect.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);

		if (Page.IsPostBack)
		{
			lblLevelOne.Visible = true;
			dropLevelOne.Visible = true;
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
		string sql = "SELECT Abilities.name, Abilities.description FROM [Abilities] INNER JOIN [CharactersAbilities] ON Abilities.name = CharactersAbilities.abilityName INNER JOIN [Characters] ON CharactersAbilities.characterId = Characters.id WHERE (Characters.id = " + listBox.Items[listBox.SelectedIndex].Value + ")";
		cmd.CommandText = sql;
		SqlDataReader dr = cmd.ExecuteReader();

		Response.Write(sql);
		if (dr.HasRows)
		{
			while (dr.Read())
			{
				string Name = dr["name"].ToString();
				string Description = dr["description"].ToString();
				abilities.Add(new Ability(Name, Description));
			}
		}
		else
		{
			Response.Write("No Rows");
		}
		dr.Close();
		conn.Close();

		Response.Write(abilities.Count);

		dropLevelOne.DataSource = abilities;
		dropLevelOne.DataTextField = "Name";
		dropLevelOne.DataValueField = "Name";
		dropLevelOne.DataBind();
    }
}