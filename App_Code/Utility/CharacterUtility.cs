using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Model.Utility
{
	public static class CharacterUtility
	{
		public enum ImageType
		{
			Portrait,
			Splash,
			Square
		}

		public static string GetImagePath(string CharacterName, ImageType Type)
		{
			return GetImagePath(CharacterName, Type, 0);
		}

		public static string GetImagePath(string CharacterName, ImageType Type, int Skin)
		{
			string path = "Images/";
			if (Type == ImageType.Portrait || Type == ImageType.Splash)
			{
				path += Type + "/" + CharacterName + "_";
				if (Type == ImageType.Splash)
				{
					path += Type + "_";
				}

				path += Skin + ".jpg";
			}
			else if (Type == ImageType.Square)
			{
				path += Type + "/" + CharacterName + "_" + Type + "_" + "0.png";
			}

			return path;
		}
	}
}