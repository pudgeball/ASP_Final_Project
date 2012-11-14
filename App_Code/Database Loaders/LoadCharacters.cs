using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LoadCharacters
/// </summary>
public class LoadCharacters
{
    public static void LoadCharactersIntoDatabase(string path, HttpResponse response)
    {
        XDocument charactersXML = XDocument.Load(path + "\\XML Files\\Characters.xml");
        IEnumerable<Character> characters =
            from character in charactersXML.Descendants("character")
            select new Character(character);

		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr_LeagueOfLegends"].ConnectionString);
		conn.Open();
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = conn;

        foreach (Character character in characters)
        {
			string sql = "INSERT INTO [Characters] ([id], [name]) VALUES(";
			sql += "'" + character.getID().ToString() + "',";
			sql += "'" + character.getName() + "'";
			sql += ")";
			cmd.CommandText = sql;
			bool worked = Convert.ToBoolean(cmd.ExecuteNonQuery());
			if (!worked)
				response.Write(character.ToString() + "   -   Not written <br/>");
        }

		conn.Close();
    }
}