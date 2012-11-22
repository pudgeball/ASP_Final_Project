using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Character
	{
		private int _id;
		private string _name;

		public int ID
		{
			get
			{
				return _id;
			}

			set
			{
				_id = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public Character()
		{

		}

		public Character(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString()
		{
			return String.Format("{0} - {1}", ID, Name);
		}
	}
}