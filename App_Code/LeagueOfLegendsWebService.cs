using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml.Serialization;

using LeagueOfLegends.Model;

namespace LeagueOfLegends
{
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

	public class LeagueOfLegendsWebService : System.Web.Services.WebService
	{
		string connStr;
		SqlConnection conn;
		SqlCommand cmd;

		public LeagueOfLegendsWebService()
		{
			connStr = ConfigurationManager.ConnectionStrings["connStr_LeagueOfLegends"].ConnectionString;
			conn = new SqlConnection(connStr);
			cmd = new SqlCommand();
			cmd.Connection = conn;
		}

		[WebMethod]
		[XmlInclude(typeof(Character))]
		public List<Character> GetCharacters()
		{
			List<Character> characters = new List<Character>();

			conn.Open();
			string sql = "SELECT * FROM [Characters]";
			cmd.CommandText = sql;

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					int id = Convert.ToInt32(dr["id"]);
					string name = dr["name"].ToString();
					characters.Add(new Character(id, name));
				}
			}
			dr.Close();
			conn.Close();

			return characters;
		}

		[WebMethod]
		public List<Ability> GetAbilities(int ID)
		{
			List<Ability> abilities = new List<Ability>();
			string sql = "SELECT [Abilities].[name], [Abilities].[description] FROM [Abilities] INNER JOIN [CharactersAbilities] ON [Abilities].[name] = [CharactersAbilities].[abilityName] INNER JOIN [Characters] ON [CharactersAbilities].[characterId] = [Characters].[id] WHERE [Characters].[id] = " + ID;

			conn.Open();
			cmd.CommandText = sql;

			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string Name = dr["name"].ToString();
					string Description = dr["description"].ToString();
					abilities.Add(new Ability(Name, Description));
				}
			}
			return abilities;
		}
	}
}