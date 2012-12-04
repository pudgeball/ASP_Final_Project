using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model
{
	public class Build
	{
		private int _id;
		private string _buildName;
		private string _userName;
		private Character _character;
		private List<Item> _items;
		private List<Ability> _abilities;

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

		public string BuildName
		{
			get
			{
				return _buildName;
			}
			set
			{
				_buildName = value;
			}
		}

		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}

		public Character Character
		{
			get
			{
				return _character;
			}

			set
			{
				_character = value;
			}
		}
		public List<Item> Items
		{
			get
			{
				return _items;
			}

			set
			{
				_items = value;
			}
		}
		public List<Ability> Abilities
		{
			get
			{
				return _abilities;
			}

			set
			{
				_abilities = value;
			}
		}

		public Build()
		{
			Items = new List<Item>();
			Abilities = new List<Ability>();
		}
	}
}