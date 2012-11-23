using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using LeagueOfLegends;

public partial class NewBuild : System.Web.UI.Page
{
	localhost.LeagueOfLegendsWebService webService = new localhost.LeagueOfLegendsWebService();
	List<localhost.Item> buildItems = new List<localhost.Item>();
	List<localhost.Item> allItems = new List<localhost.Item>();
	List<localhost.Ability> abilties = new List<localhost.Ability>();
	List<Label> abiltyLabels = new List<Label>();

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			allItems = webService.GetItems().ToList<localhost.Item>();

			dropCharacter.DataSource = webService.GetCharacters();
			dropCharacter.DataTextField = "Name";
			dropCharacter.DataValueField = "ID";
			dropCharacter.DataBind();

			int id = Convert.ToInt32(dropCharacter.Items[dropCharacter.SelectedIndex].Value);

			abilties = webService.GetAbilitiesForCharacter(id).ToList<localhost.Ability>();

			for (int i = 0; i < 5; i++)
			{
				Label label = new Label();
				label.Text = abilties[i].Name;
				abiltyLabels.Add(label);
			}

			bindListBoxs();

			Session["allItems"] = allItems;
			Session["buildItems"] = buildItems;
			Session["abilties"] = abilties;
			Session["abilityLabels"] = abiltyLabels;
		}

		placeholderAbilityTable.Controls.Add(CreateTables());
		dropCharacter.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);
    }

    void characterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
		DropDownList listBox = (DropDownList)sender;

		abiltyLabels = (List<Label>)Session["abilityLabels"];

		int id = Convert.ToInt32(listBox.Items[listBox.SelectedIndex].Value);
		abilties = webService.GetAbilitiesForCharacter(id).ToList<localhost.Ability>();

		for (int i = 0; i < abiltyLabels.Count; i++)
		{
			abiltyLabels[i].Text = abilties[i].Name;
		}

		Session["abilityLabels"] = abiltyLabels;
    }

	private void bindListBoxs()
	{
		listAllItems.DataSource = allItems;
		listAllItems.DataTextField = "Name";
		listAllItems.DataBind();

		listBuildItems.DataSource = buildItems;
		listBuildItems.DataTextField = "Name";
		listBuildItems.DataBind();
	}

	protected void cmdAdd_Click(object sender, EventArgs e)	
	{
		allItems = (List<localhost.Item>)Session["allItems"];
		buildItems = (List<localhost.Item>)Session["buildItems"];

		buildItems.Add(allItems[listAllItems.SelectedIndex]);
		allItems.Remove(allItems[listAllItems.SelectedIndex]);

		if (allItems.Count == 0)
		{
			cmdAdd.Enabled = false;
		}

		bindListBoxs();
	}

	protected void cmdRemove_Click(object sender, EventArgs e)
	{
		allItems = (List<localhost.Item>)Session["allItems"];
		buildItems = (List<localhost.Item>)Session["buildItems"];

		allItems.Add(buildItems[listBuildItems.SelectedIndex]);
		buildItems.Remove(buildItems[listBuildItems.SelectedIndex]);

		if (buildItems.Count == 0)
		{
			cmdRemove.Enabled = false;
		}

		bindListBoxs();
	}

	protected void cmdCreate_Click(object sender, EventArgs e)
	{
	}

	private Table CreateTables()
	{
		Table abilityTable = new Table();
		abilityTable.BorderWidth = 1;
		abiltyLabels = (List<Label>)Session["abilityLabels"];

		for (int i = 0; i < 6; i++)
		{
			TableRow row = new TableRow();
			for (int j = 0; j < 19; j++)
			{
				if (i == 0)
				{
					TableHeaderCell cell = new TableHeaderCell();
					cell.BorderWidth = 1;
					cell.Text = (j > 0) ? j.ToString() : "Level";
					row.Cells.Add(cell);
				}
				else
				{
					TableCell cell = new TableCell();
					cell.BorderWidth = 1;
					if (i == 1)
					{
						if (j == 0)
						{
							cell.Controls.Add(abiltyLabels[i - 1]);
						}
						else if (j == 1)
						{
							cell.ColumnSpan = 18;
							cell.Text = "Passive";
						}
						else
						{
							cell = null;
						}
					}
					else
					{
						if (j > 0)
						{
							RadioButton radioButton = new RadioButton();
							radioButton.GroupName = "Level" + j.ToString();

							cell.Controls.Add(radioButton);
						}
						else
						{
							
							cell.Controls.Add(abiltyLabels[i-1]);
						}
					}

					if (cell != null)
					{
						row.Cells.Add(cell);
					}
				}
			}
			abilityTable.Rows.Add(row);
		}

		return abilityTable;
	}
	protected void listAllItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		cmdAdd.Enabled = true;
	}
	protected void listBuildItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		cmdRemove.Enabled = true;
	}
}