using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Item
	{
		public Item()
		{

		}

		public Item(string name, double price, string description)
		{
			Name = name;
			Price = price;
			Description = description;
		}

		public override string ToString()
		{
			return String.Format("{0} - {1} - {2}", Name, Price, Description);
		}

		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
	}
}