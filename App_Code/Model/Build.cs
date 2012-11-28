using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Build
	{
		public int ID { get; set; }
		public string BuildName { get; set; }
		public string UserName { get; set; }
		public Character Character { get; set; }
		public List<Item> Items { get; set; }
		public List<Ability> Abilities { get; set; }

		public Build()
		{
			Items = new List<Item>();
			Abilities = new List<Ability>();
		}
	}
}