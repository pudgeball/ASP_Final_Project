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
		private List<Ability> _abilities;
		private int _skinCount;

		public enum ImageType
		{
			Portrait,
			Splash,
			Square
		}

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

		public int SkinCount
		{
			get
			{
				return _skinCount;
			}
			set
			{
				_skinCount = value;
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

		public string GetImagePath(ImageType type)
		{
			return GetImagePath(type, 0);
		}

		public string GetImagePath(ImageType type, int Skin)
		{
			string path = "Images/";
			string typeString = type.ToString();
			if (type == ImageType.Portrait || type == ImageType.Splash)
			{
				path += type + "/" + this.Name + "_";
				if (type == ImageType.Splash)
				{
					path += type + "_";
				}
				if (Skin > _skinCount)
				{
					path += _skinCount + ".jpg";
				}
				else
				{
					path += Skin + ".jpg";
				}
			}
			else if (type == ImageType.Square)
			{
				path += type + "/" + this.Name + "_" + type + "_" + "0.png";
			}

			return path;
		}
	}
}