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
		public List<Character> GetCharacters()
		{
			List<Character> characters = new List<Character>();

			string sql = "SELECT * FROM [Characters]";
			cmd.CommandText = sql;

			conn.Open();
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
		public List<Ability> GetAbilitiesForCharacter(int CharacterID)
		{
			List<Ability> abilities = new List<Ability>();

			string sql = "SELECT [Abilities].* FROM [Abilities] INNER JOIN [CharactersAbilities] ON [Abilities].[name] = [CharactersAbilities].[abilityName] WHERE [CharactersAbilities].[characterID] = " + CharacterID;
			cmd.CommandText = sql;

			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string name = dr["name"].ToString();
					string description = dr["description"].ToString();
					abilities.Add(new Ability(name, description));
				}
			}
			dr.Close();
			conn.Close();

			return abilities;
		}

		[WebMethod]
		public List<Item> GetItemsForBuild(int BuildID)
		{
			List<Item> items = new List<Item>();

			string sql = "SELECT [Items].* FROM [Items] INNER JOIN [BuildsItems] ON [Items].name = [BuildsItems].itemName WHERE [BuildsItems].buildID = " + BuildID;
			cmd.CommandText = sql;

			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string name = dr["name"].ToString();
					double price = Convert.ToDouble(dr["price"]);
					string description = dr["description"].ToString();
					items.Add(new Item(name, price, description));
				}
			}
			dr.Close();
			conn.Close();

			return items;
		}
	}
}