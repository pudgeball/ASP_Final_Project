using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Ability
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public Ability()
		{

		}

		public Ability(string name, string desc)
		{
			Name = name;
			Description = desc;
		}
	}
}