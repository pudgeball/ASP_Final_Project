using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Ability
	{
		private string _name;
		private string _description;

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

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public Ability()
		{

		}

		public Ability(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}