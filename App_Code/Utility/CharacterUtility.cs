using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model.Utility
{
	public class CharacterUtility
	{
		public enum ImageType
		{
			Portrait,
			Splash,
			Square
		}

		public string GetImagePath(Character character, ImageType type)
		{
			return GetImagePath(character, type, 0);
		}

		public string GetImagePath(Character character, ImageType type, int Skin)
		{
			string path = "Images/";
			string typeString = type.ToString();
			if (type == ImageType.Portrait || type == ImageType.Splash)
			{
				path += type + "/" + character.Name + "_";
				if (type == ImageType.Splash)
				{
					path += type + "_";
				}
				if (Skin > character.SkinCount)
				{
					path += character.SkinCount + ".jpg";
				}
				else
				{
					path += Skin + ".jpg";
				}
			}
			else if (type == ImageType.Square)
			{
				path += type + "/" + character.Name + "_" + type + "_" + "0.png";
			}

			return path;
		}
	}
}