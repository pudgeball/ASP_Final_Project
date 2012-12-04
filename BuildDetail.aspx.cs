using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using localhost;
using LeagueOfLegends.Model.Utility;

public partial class BuildDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int BuildID = 0;

		NameValueCollection queryString = Request.QueryString;
		if (queryString["BuildID"] != null)
		{
			BuildID = Convert.ToInt32(queryString["BuildID"]);
			LeagueOfLegendsWebService webService = new LeagueOfLegendsWebService();
			Build characterBuild = webService.GetBuild(BuildID);

			if (characterBuild.ID == -1)
			{
				Response.Redirect("Default.aspx");
			}

			this.Page.Title = characterBuild.BuildName;

			//Create the HTML for placeBuildInfo
			//First create the div to hold the info
			HtmlGenericControl divBuildInfo = new HtmlGenericControl("div");
			divBuildInfo.ID = "BuildInfo";
			//divBuildInfo.Attributes.Add("class", "section");

			//Get the build name
			HtmlGenericControl titleBuildName = new HtmlGenericControl("h1");
			titleBuildName.InnerHtml = characterBuild.BuildName;
			divBuildInfo.Controls.Add(titleBuildName);

			//Create a div to hold the image and title info
			HtmlGenericControl divCharacter = new HtmlGenericControl("div");
			divCharacter.Attributes.Add("class", "description");

			//Then Create the image of the character
			Image characterImage = new Image();
			characterImage.ImageUrl = CharacterUtility.GetImagePath(characterBuild.Character.Name, CharacterUtility.ImageType.Square);
			characterImage.AlternateText = "Icon of " + characterBuild.Character.Name;
			characterImage.Style.Add("float", "left");
			divCharacter.Controls.Add(characterImage);
			
			//Create a div to hold the description
			HtmlGenericControl divDescription = new HtmlGenericControl("div");

			//Get the character name
			HtmlGenericControl titleCharacterName = new HtmlGenericControl("h3");
			titleCharacterName.InnerHtml = "<i>A build for " + characterBuild.Character.Name + "</i>";
			divDescription.Controls.Add(titleCharacterName);

			//Get the username
			HtmlGenericControl titleUsername = new HtmlGenericControl("h4");
			titleUsername.InnerHtml = "<i>Created by " + characterBuild.UserName + "</i>";
			divDescription.Controls.Add(titleUsername);

			//Make sure everything is added
			divCharacter.Controls.Add(divDescription);
			divBuildInfo.Controls.Add(divCharacter);

			//Create the actual placeholder
			placeBuildInfo.Controls.Add(divBuildInfo);


			//Create the placeAbilities placeholder
			//First create the div to hold the ability info
			HtmlGenericControl divAbilities = new HtmlGenericControl("div");
			divAbilities.ID = "AbilityInfo";
			divAbilities.Attributes.Add("class", "section");

			//List the section title
			HtmlGenericControl titleAbility = new HtmlGenericControl("h2");
			titleAbility.InnerText = "Ability Breakdown";
			titleAbility.Attributes.Add("class", "sectionTitle");
			divAbilities.Controls.Add(titleAbility);

			//Create the Ability Table
			Table abilitiesTable = createAbilitiesTable(characterBuild.Character.Abilities.ToList<Ability>(), characterBuild.Abilities.ToList<Ability>());
			divAbilities.Controls.Add(abilitiesTable);

			//Create the actual placeholder
			placeAbilities.Controls.Add(divAbilities);


			//Create the placeItems placeholder
			//Create the div to hold the items info
			HtmlGenericControl divItems = new HtmlGenericControl("div");
			divItems.ID = "ItemsInfo";
			divItems.Attributes.Add("class", "section");

			//List the section title
			HtmlGenericControl titleItem = new HtmlGenericControl("h2");
			titleItem.InnerHtml = "Items";
			titleItem.Attributes.Add("class", "sectionTitle");
			divItems.Controls.Add(titleItem);

			//Create the Item List
			Table itemList = createItemsTable(characterBuild.Items.ToList<Item>());
			divItems.Controls.Add(itemList);

			//Create the actual placeholder
			placeItems.Controls.Add(divItems);
		}
		else
		{
			Response.Redirect("Default.aspx");
		}
    }

	private Table createAbilitiesTable(List<Ability> abilities, List<Ability> buildAbilities)
	{
		Table abilitiesTable = new Table();

		for (int i = 0; i < 6; i++)
		{
			TableRow row = new TableRow();

			for (int j = 0; j < 19; j++)
			{
				TableCell cell = new TableCell();
				//Header Row
				if (i == 0)
				{
					//First cell has different text
					if (j == 0)
					{
						cell.Text = "Level";
						cell.CssClass = "abilityName";
					}
					else
					{
						cell.Text = j.ToString();
						cell.CssClass = "abilityLevel";
					}
				}
				//Passive Row
				else if (i == 1)
				{
					if (j == 0)
					{
						cell.Text = abilities[i - 1].Name;
						cell.CssClass = "abilityName abilityRowEven";
					}
					else if (j == 1)
					{
						cell.ColumnSpan = 18;
						cell.Text = "Passive";
						cell.CssClass = "passive";
					}
					else
					{
						continue;
					}
				}
				//Ability Rows
				else
				{
					int index = i - 1;
					if (j == 0)
					{
						cell.Text = abilities[index].Name;
						if (i % 2 == 0)
						{
							cell.CssClass = "abilityName";
						}
						else
						{
							cell.CssClass = "abilityName abilityRowEven";
						}
					}
					else
					{
						if (abilities[index].Name.Equals(buildAbilities[j - 1].Name))
						{
							cell.CssClass = "abilityLevel selected";
						}
						else
						{
							cell.CssClass = "abilityLevel";
						}
					}
				}

				row.Cells.Add(cell);
			}
			abilitiesTable.Rows.Add(row);
		}

		return abilitiesTable;
	}

	private Table createItemsTable(List<Item> items)
	{
		Table itemsTable = new Table();

		for (int i = 0; i < items.Count; i++)
		{
			TableRow row = new TableRow();
			
			TableCell imageCell = new TableCell();
			imageCell.ID = "itemImage";
			Image itemImage = new Image();
			itemImage.ImageUrl = "Images/Items/" + items[i].Name + ".png";
			imageCell.Controls.Add(itemImage);

			TableCell nameCell = new TableCell();
			nameCell.Text = items[i].Name;

			TableCell priceCell = new TableCell();
			priceCell.Text = items[i].Price.ToString();

			row.Cells.Add(imageCell);
			row.Cells.Add(nameCell);
			row.Cells.Add(priceCell);
			itemsTable.Rows.Add(row);
		}

		return itemsTable;
	}
}