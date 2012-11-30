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
		public Character GetCharacter(int CharacterID)
		{
			Character requestedCharacter = new Character();

			string sql = "SELECT * FROM [Characters] WHERE [id] = " + CharacterID;
			cmd.CommandText = sql;

			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					int id = Convert.ToInt32(dr["id"]);
					string name = dr["name"].ToString();
					requestedCharacter.ID = id;
					requestedCharacter.Name = name;
				}
			}
			dr.Close();
			conn.Close();

			return requestedCharacter;
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
        public int GetVotesForCharacter(int CharacterID)
        {
            string sql = "SELECT [votes] FROM [Characters] INNER JOIN [CharacterVotes] ON [Characters].[id] = [CharacterVotes].[characterID] WHERE [CharacterVotes].[characterID] = " + CharacterID;
            cmd.CommandText = sql;

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int votes;

            if (dr.Read())
            {
                votes = Convert.ToInt32(dr["votes"]);
            }
            else
            {
                votes = -1;
            }
    
            dr.Close();
            conn.Close();

            return votes;
        }

        [WebMethod]
        public List<Character> GetCharactersOrderedByVote()
        {
            List<Character> characters = new List<Character>();

            string sql = "SELECT * FROM [Characters] INNER JOIN [CharacterVotes] ON [Characters].[id] = [CharacterVotes].[characterID] ORDER BY [votes] DESC";
            cmd.CommandText = sql;

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                characters.Add(new Character(id, name));
            }

            dr.Close();
            conn.Close();

            return characters;
        }

        [WebMethod]
        public void EnterVote(int CharacterID, int VoteValue)
        {
            string sql = "UPDATE [CharacterVotes] SET [votes] = [votes] + " + VoteValue + " WHERE [CharacterVotes].[characterID] = " + CharacterID;
            cmd.CommandText = sql;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

		[WebMethod]
		public List<Item> GetItems()
		{
			List<Item> items = new List<Item>();

			string sql = "SELECT * FROM [Items]";
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

		[WebMethod]
		public Build GetBuild(int BuildID)
		{
			Build requestedBuild = new Build();

			string sql = "SELECT * FROM [Builds] WHERE [id] = " + BuildID;
			cmd.CommandText = sql;

			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					int id = Convert.ToInt32(dr["id"]);
					string name = dr["name"].ToString();
					string username = dr["userName"].ToString();
					requestedBuild.ID = id;
					requestedBuild.BuildName = name;
					requestedBuild.UserName = username;
				}
			}
			else
			{
				dr.Close();
				conn.Close();
				requestedBuild.ID = -1;
				return requestedBuild;
			}
			dr.Close();

			conn.Close();
			requestedBuild.Character = this.GetCharacterForBuild(BuildID);

			//sql = "SELECT * FROM [Characters] INNER JOIN [BuildsCharacters] ON [Characters].[id] = [BuildsCharacters].[characterID] INNER JOIN [Builds] ON [BuildsCharacters].[buildID] = [Builds].[id] WHERE [Builds].[id] = " + BuildID;
			//cmd.CommandText = sql;

			//dr = cmd.ExecuteReader();
			//if (dr.HasRows)
			//{
			//    while (dr.Read())
			//    {
			//        int id = Convert.ToInt32(dr["id"]);
			//        string name = dr["name"].ToString();
			//        requestedBuild.Character = new Character(id, name);
			//    }
			//}
			//dr.Close();

			sql = "SELECT [Abilities].*, [BuildsAbilities].[abilityLevel] FROM [Abilities] INNER JOIN [BuildsAbilities] ON [Abilities].[name] = [BuildsAbilities].[abilityName] INNER JOIN [Builds] ON [BuildsAbilities].[buildID] = [Builds].[id] WHERE [Builds].[id] = " + BuildID + " ORDER BY [BuildsAbilities].[abilityLevel]";
			cmd.CommandText = sql;

			conn.Open();
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string name = dr["name"].ToString();
					string description = dr["description"].ToString();
					requestedBuild.Abilities.Add(new Ability(name, description));
				}
			}
			dr.Close();

			sql = "SELECT * FROM [Items] INNER JOIN [BuildsItems] ON [Items].[name] = [BuildsItems].[itemName] INNER JOIN [Builds] ON [BuildsItems].[buildID] = [Builds].[id] WHERE [Builds].[id] = " + BuildID;
			cmd.CommandText = sql;

			dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string name = dr["name"].ToString();
					double price = Convert.ToDouble(dr["price"]);
					string description = dr["description"].ToString();
					requestedBuild.Items.Add(new Item(name, price, description));
				}
			}
			dr.Close();
			conn.Close();

			return requestedBuild;
		}

        [WebMethod]
        public Build GetRandomBuild()
        {
            string sqlNumberOfBuilds = "SELECT COUNT(*) FROM [Builds]";
            cmd.CommandText = sqlNumberOfBuilds;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            int numberOfBuilds = 0;

            if (dr.Read())
            {
                numberOfBuilds = Convert.ToInt32(dr[0]);
            }

            if (numberOfBuilds <= 0)
            {
                dr.Close();
                conn.Close();

                Build failedBuild = new Build();
                failedBuild.ID = -1;
                failedBuild.BuildName = "fail";
                failedBuild.UserName = "fail";
                return failedBuild;
            }

            dr.Close();

            string sqlSelectAllBuilds = "SELECT [id] FROM [Builds]";
            cmd.CommandText = sqlSelectAllBuilds;
            dr = cmd.ExecuteReader();

            int randomRecordNumber = new Random().Next(numberOfBuilds);

            for (int i = 0; i < randomRecordNumber + 1; i++)
            {
                dr.Read();
            }

            int buildID = Convert.ToInt32(dr[0]);

            dr.Close();
            conn.Close();

            Build randomBuild = this.GetBuild(buildID);

            return randomBuild;
        }

		[WebMethod]
		public Character GetCharacterForBuild(int BuildID)
		{
			Character requestedCharacter = new Character();

			string sql = "SELECT * FROM [Characters] INNER JOIN [BuildsCharacters] ON [Characters].[id] = [BuildsCharacters].[characterID] INNER JOIN [Builds] ON [BuildsCharacters].[buildID] = [Builds].[id] WHERE [Builds].[id] = " + BuildID;
			cmd.CommandText = sql;

			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					int id = Convert.ToInt32(dr["id"]);
					string name = dr["name"].ToString();
					requestedCharacter.ID = id;
					requestedCharacter.Name = name;
				}
			}
			dr.Close();
			conn.Close();
			
			requestedCharacter.Abilities = this.GetAbilitiesForCharacter(requestedCharacter.ID);

			return requestedCharacter;
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

		[WebMethod]
		public void CreateBuild(string BuildName, string UserName, int CharacterID, List<Ability> abilities, List<Item> items)
		{
			string sql = "SELECT COUNT(*) AS Builds FROM [Builds]";
			cmd.CommandText = sql;
			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			int builds = -1;
			if (dr.HasRows)
			{
				while(dr.Read())
				{
					builds = Convert.ToInt32(dr["Builds"]);
				}
			}
			dr.Close();

			sql = "INSERT INTO [Builds] ([id], [name], [userName]) VALUES(" + builds + ", '" + BuildName + "', '" + UserName + "')";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "INSERT INTO [BuildsCharacters] ([buildID], [characterID]) VALUES(" + builds + ", " + CharacterID + ")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			for (int i = 0; i < abilities.Count; i++)
			{
				Ability ability = abilities[i];
				sql = "INSERT INTO [BuildsAbilities] ([buildID], [abilityName], [abilityLevel]) VALUES(" + builds + ", '" + ability.Name + "', " + (i+1) + ")";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
			}

			cmd.Parameters.Add("@item", System.Data.SqlDbType.VarChar);
			foreach (Item item in items)
			{
				sql = "INSERT INTO [BuildsItems] ([buildID], [itemName]) VALUES(" + builds + ", @item)";
				cmd.CommandText = sql;
				cmd.Parameters["@item"].Value = item.Name;
				cmd.ExecuteNonQuery();
			}
			conn.Close();
		}
	}
}