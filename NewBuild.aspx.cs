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

			AddTableToPage(true);
			bindListBoxs();

			Session["allItems"] = allItems;
			Session["buildItems"] = buildItems;
			Session["abilties"] = abilties;
		}

		dropCharacter.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);
		
    }

    void characterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
		DropDownList listBox = (DropDownList)sender;

		int id = Convert.ToInt32(listBox.Items[listBox.SelectedIndex].Value);
		abilties = webService.GetAbilitiesForCharacter(id).ToList<localhost.Ability>();
		Session["CharacterID"] = id;

		AddTableToPage(true);
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

		cmdAdd.Enabled = false;

		AddTableToPage(false);
		bindListBoxs();
	}

	protected void cmdRemove_Click(object sender, EventArgs e)
	{
		allItems = (List<localhost.Item>)Session["allItems"];
		buildItems = (List<localhost.Item>)Session["buildItems"];

		allItems.Add(buildItems[listBuildItems.SelectedIndex]);
		buildItems.Remove(buildItems[listBuildItems.SelectedIndex]);

		cmdRemove.Enabled = false;

		AddTableToPage(false);
		bindListBoxs();
	}

	protected void cmdCreate_Click(object sender, EventArgs e)
	{
		Table abilityTable = (Table)Session["abilityTable"];
		List<string> selectedAbilities = new List<string>();

		for (int i = 2; i < abilityTable.Rows.Count; i++)
		{
			for (int j = 1; j < abilityTable.Rows[i].Cells.Count; j++)
			{
				if (abilityTable.Rows[i].Cells[j].Controls.Count > 0)
				{
					RadioButton radioButton = (RadioButton)abilityTable.Rows[i].Cells[j].Controls[0];
					if (radioButton.Checked == true)
					{
						Response.Write("zomg");
						selectedAbilities.Add(radioButton.ToolTip);
					}
				}
			}
		}

		foreach (string s in selectedAbilities)
		{
			Response.Write(s + "<br/>");
		}
		AddTableToPage(false);
	}

	private Table CreateAbilityTable()
	{
		Table abilityTable = new Table();
		abilityTable.BorderWidth = 1;
		int id = Convert.ToInt32(Session["CharacterID"]);
		Response.Write("Current ID " + id);
		abilties = webService.GetAbilitiesForCharacter(id).ToList<localhost.Ability>();
		
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
							cell.Text = abilties[i - 1].Name;
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
							radioButton.ToolTip = abilties[i - 1].Name;
							radioButton.AutoPostBack = true;
							radioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
							cell.Controls.Add(radioButton);
						}
						else
						{

							cell.Text = abilties[i - 1].Name;
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

	void radioButton_CheckedChanged(object sender, EventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		Response.Write(radioButton.GroupName + " - " + radioButton.ToolTip);
		AddTableToPage(false);
	}

	private void AddTableToPage(bool NewCharacter)
	{
		Table abilityTable;

		if (NewCharacter)
		{
			abilityTable = CreateAbilityTable();
			
			Session["abilityTable"] = abilityTable;
		}
		else
		{
			abilityTable = (Table)Session["abilityTable"];
		}

		placeholderAbilityTable.Controls.Add(abilityTable);
	}

	protected void listAllItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		AddTableToPage(false);
		cmdAdd.Enabled = true;
	}
	protected void listBuildItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		AddTableToPage(false);
		cmdRemove.Enabled = true;
	}
}