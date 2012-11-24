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
	List<localhost.Item> buildItems;
	List<localhost.Item> allItems;
	List<localhost.Ability> abilties;
	List<RadioButtonList> radioButtonList;

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			allItems = webService.GetItems().ToList<localhost.Item>();
			buildItems = new List<localhost.Item>();

			dropCharacter.DataSource = webService.GetCharacters();
			dropCharacter.DataTextField = "Name";
			dropCharacter.DataValueField = "ID";
			dropCharacter.DataBind();

			Session["CharacterID"] = Convert.ToInt32(dropCharacter.Items[dropCharacter.SelectedIndex].Value);
			Session["allItems"] = allItems;
			Session["buildItems"] = buildItems;

			UpdateUI();
		}
		dropCharacter.SelectedIndexChanged += new EventHandler(characterSelect_SelectedIndexChanged);
    }

    void characterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
		DropDownList listBox = (DropDownList)sender;

		int id = Convert.ToInt32(listBox.Items[listBox.SelectedIndex].Value);
		
		Session["CharacterID"] = id;

		UpdateUI();
    }

	private void createRadioListArray()
	{
		radioButtonList = new List<RadioButtonList>();
		radioButtonList.Add(radioListLevel1);
		radioButtonList.Add(radioListLevel2);
		radioButtonList.Add(radioListLevel3);
		radioButtonList.Add(radioListLevel4);
		radioButtonList.Add(radioListLevel5);
		radioButtonList.Add(radioListLevel6);
		radioButtonList.Add(radioListLevel7);
		radioButtonList.Add(radioListLevel8);
		radioButtonList.Add(radioListLevel9);
		radioButtonList.Add(radioListLevel10);
		radioButtonList.Add(radioListLevel11);
		radioButtonList.Add(radioListLevel12);
		radioButtonList.Add(radioListLevel13);
		radioButtonList.Add(radioListLevel14);
		radioButtonList.Add(radioListLevel15);
		radioButtonList.Add(radioListLevel16);
		radioButtonList.Add(radioListLevel17);
		radioButtonList.Add(radioListLevel18);
	}

	private void UpdateUI()
	{
		int id = Convert.ToInt32(Session["CharacterID"]);
		abilties = webService.GetAbilitiesForCharacter(id).ToList<localhost.Ability>();

		lblAbility1.Text = abilties[0].Name.ToString();
		lblAbility2.Text = abilties[1].Name.ToString();
		lblAbility3.Text = abilties[2].Name.ToString();
		lblAbility4.Text = abilties[3].Name.ToString();
		lblAbility5.Text = abilties[4].Name.ToString();

		//Remove the Passive Skill
		abilties.Remove(abilties[0]);
		createRadioListArray();

		foreach (RadioButtonList buttonList in radioButtonList)
		{
			buttonList.Items.Clear();
			buttonList.DataSource = abilties;
			buttonList.DataTextField = "Name";
			buttonList.DataTextFormatString = "&nbsp";
			buttonList.DataValueField = "Name";
			buttonList.DataBind();
		}

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

		UpdateUI();
	}

	protected void cmdRemove_Click(object sender, EventArgs e)
	{
		allItems = (List<localhost.Item>)Session["allItems"];
		buildItems = (List<localhost.Item>)Session["buildItems"];

		allItems.Add(buildItems[listBuildItems.SelectedIndex]);
		buildItems.Remove(buildItems[listBuildItems.SelectedIndex]);

		cmdRemove.Enabled = false;

		UpdateUI();
	}

	protected void cmdCreate_Click(object sender, EventArgs e)
	{
		if (ValidateBuild())
		{
			int id = Convert.ToInt32(dropCharacter.Items[dropCharacter.SelectedIndex].Value);
			buildItems = (List<localhost.Item>)Session["buildItems"];

			List<localhost.Ability> buildAbilities = new List<localhost.Ability>();
			createRadioListArray();
			foreach (RadioButtonList list in radioButtonList)
			{
				localhost.Ability ability = new localhost.Ability();
				ability.Name = list.SelectedItem.Value;
				buildAbilities.Add(ability);
			}

			webService = new localhost.LeagueOfLegendsWebService();
			webService.CreateBuild(txtBuildName.Text, txtUsername.Text, id, buildAbilities.ToArray(), buildItems.ToArray());
		}
	}

	protected void listAllItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		cmdAdd.Enabled = true;
	}
	protected void listBuildItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		cmdRemove.Enabled = true;
	}

	private bool ValidateBuild()
	{
		if (txtBuildName.Text.Length == 0)
		{
			lblError.Text = "Build Name Required";
			return false;
		}
		else if (txtUsername.Text.Length == 0)
		{
			lblError.Text = " Username Required";
			return false;
		}
		else if (radioListLevel1.SelectedItem == null)
		{
			lblError.Text = "Level 1 Ability Required";
			return false;
		}
		else if (radioListLevel2.SelectedItem == null)
		{
			lblError.Text = "Level 2 Ability Required";
			return false;
		}
		else if (radioListLevel3.SelectedItem == null)
		{
			lblError.Text = "Level 3 Ability Required";
			return false;
		}
		else if (radioListLevel4.SelectedItem == null)
		{
			lblError.Text = "Level 4 Ability Required";
			return false;
		}
		else if (radioListLevel5.SelectedItem == null)
		{
			lblError.Text = "Level 5 Ability Required";
			return false;
		}
		else if (radioListLevel6.SelectedItem == null)
		{
			lblError.Text = "Level 6 Ability Required";
			return false;
		}
		else if (radioListLevel7.SelectedItem == null)
		{
			lblError.Text = "Level 7 Ability Required";
			return false;
		}
		else if (radioListLevel8.SelectedItem == null)
		{
			lblError.Text = "Level 8 Ability Required";
			return false;
		}
		else if (radioListLevel9.SelectedItem == null)
		{
			lblError.Text = "Level 9 Ability Required";
			return false;
		}
		else if (radioListLevel10.SelectedItem == null)
		{
			lblError.Text = "Level 10 Ability Required";
			return false;
		}
		else if (radioListLevel11.SelectedItem == null)
		{
			lblError.Text = "Level 11 Ability Required";
			return false;
		}
		else if (radioListLevel12.SelectedItem == null)
		{
			lblError.Text = "Level 12 Ability Required";
			return false;
		}
		else if (radioListLevel13.SelectedItem == null)
		{
			lblError.Text = "Level 13 Ability Required";
			return false;
		}
		else if (radioListLevel14.SelectedItem == null)
		{
			lblError.Text = "Level 14 Ability Required";
			return false;
		}
		else if (radioListLevel15.SelectedItem == null)
		{
			lblError.Text = "Level 15 Ability Required";
			return false;
		}
		else if (radioListLevel16.SelectedItem == null)
		{
			lblError.Text = "Level 16 Ability Required";
			return false;
		}
		else if (radioListLevel17.SelectedItem == null)
		{
			lblError.Text = "Level 17 Ability Required";
			return false;
		}
		else if (radioListLevel18.SelectedItem == null)
		{
			lblError.Text = "Level 18 Ability Required";
			return false;
		}


		return true;

	}

	private void output()
	{
		Response.Write(radioListLevel1.SelectedItem.Value);
		Response.Write(radioListLevel2.SelectedItem.Value);
		Response.Write(radioListLevel3.SelectedItem.Value);
		Response.Write(radioListLevel4.SelectedItem.Value);
		Response.Write(radioListLevel5.SelectedItem.Value);
		Response.Write(radioListLevel6.SelectedItem.Value);
		Response.Write(radioListLevel7.SelectedItem.Value);
		Response.Write(radioListLevel8.SelectedItem.Value);
		Response.Write(radioListLevel9.SelectedItem.Value);
		Response.Write(radioListLevel10.SelectedItem.Value);
		Response.Write(radioListLevel11.SelectedItem.Value);
		Response.Write(radioListLevel12.SelectedItem.Value);
		Response.Write(radioListLevel13.SelectedItem.Value);
		Response.Write(radioListLevel14.SelectedItem.Value);
		Response.Write(radioListLevel15.SelectedItem.Value);
		Response.Write(radioListLevel16.SelectedItem.Value);
		Response.Write(radioListLevel17.SelectedItem.Value);
		Response.Write(radioListLevel18.SelectedItem.Value);
	}
}