using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class InsertAbilities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void cmdInsert_Click(object sender, EventArgs e)
	{
		string connStr = ConfigurationManager.ConnectionStrings["connStr_LeagueOfLegends"].ConnectionString;

		SqlConnection conn = new SqlConnection(connStr);
		conn.Open();
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = conn;

		string sql = "INSERT INTO Abilities([name]) VALUES(@abilityName)";
		cmd.CommandText = sql;
		cmd.Parameters.Add("@abilityName", System.Data.SqlDbType.VarChar);

		cmd.Parameters["@abilityName"].Value = txtPassive.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility1.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility2.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility3.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility4.Text;
		cmd.ExecuteNonQuery();


		sql = "INSERT INTO CharactersAbilities ([characterID], [abilityName]) VALUES(@characterID, @abilityName)";
		cmd.CommandText = sql;
		cmd.Parameters.Add("@characterID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(txtID.Text);
		

		cmd.Parameters["@abilityName"].Value = txtPassive.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility1.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility2.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility3.Text;
		cmd.ExecuteNonQuery();

		cmd.Parameters["@abilityName"].Value = txtAbility4.Text;
		cmd.ExecuteNonQuery();

		conn.Close();

		txtID.Text = "";
		txtPassive.Text = "";
		txtAbility1.Text = "";
		txtAbility2.Text = "";
		txtAbility3.Text = "";
		txtAbility4.Text = "";
	}
}