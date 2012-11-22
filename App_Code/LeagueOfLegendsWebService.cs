using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

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
	public ArrayList GetCharacters()
	{
		ArrayList characters = new ArrayList();

		conn.Open();
		string sql = "SELECT * FROM [Characters]";
		cmd.CommandText = sql;

		SqlDataReader dr = cmd.ExecuteReader();

		if (dr.HasRows)
		{
			while (dr.Read())
			{
				Character newChar = new Character();
				newChar.ID = Convert.ToInt32(dr["id"]);
				newChar.Name = dr["name"].ToString();
				characters.Add(newChar);
			}
		}
		dr.Close();
		conn.Close();

		return characters;
	}
}
