using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using localhost;
using System.Collections.Specialized;
using LeagueOfLegends.Model.Utility;

public partial class TierList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LeagueOfLegendsWebService webService = new LeagueOfLegendsWebService();
        
        NameValueCollection qs = Request.QueryString;
        string qsCharacterID = qs.Get("characterID");
        string qsVoteType = qs.Get("voteType");
        int characterCount = webService.GetCharacters().Count();

        //for (int i = 0; i < characterCount; i++)
        //{
        //    Response.Write(webService.GetCharacters()[i].Name + ": " + Session["vote" + i] + "<br/>");
        //}

        try
        {
            if (qsCharacterID != null && qsVoteType != null && Convert.ToInt32(qsCharacterID) < characterCount)
            {
                if (Session["vote" + qsCharacterID] == null)
                {
                    switch (qsVoteType)
                    {
                        case "upvote":
                            webService.EnterVote(Convert.ToInt32(qsCharacterID), 1);
                            break;
                        case "downvote":
                            webService.EnterVote(Convert.ToInt32(qsCharacterID), -1);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    string previousVote = Session["vote" + qsCharacterID].ToString();

                    switch (qsVoteType)
                    {
                        case "upvote":
                            if (!previousVote.Equals(qsVoteType))
                            {
                                webService.EnterVote(Convert.ToInt32(qsCharacterID), 2);
                            }
                            break;
                        case "downvote":
                            if (!previousVote.Equals(qsVoteType))
                            {
                                webService.EnterVote(Convert.ToInt32(qsCharacterID), -2);
                            }
                            break;
                        default:
                            break;
                    }
                }

                Session["vote" + qsCharacterID] = qsVoteType;
                Response.Redirect("TierList.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("TierList.aspx");
        }

        List<Character> characters = webService.GetCharactersOrderedByVote().ToList<Character>();
        
        // This ordered list will hold the tier list. It will be placed into the placeholder at the end.
        HtmlGenericControl orderedList = new HtmlGenericControl("ol");
        orderedList.ID = "orderedListControl";

        for (int i = 0; i < characters.Count; i++)
        {
            string characterName = characters[i].Name;
            int characterID = characters[i].ID;
            string votes = webService.GetVotesForCharacter(characterID).ToString();

            Image characterImage = new Image();
            characterImage.ImageUrl = CharacterUtility.GetImagePath(characterName, CharacterUtility.ImageType.Square);
            //characterImage.ImageUrl = "Images/" + characterName.ToLower() + ".png";
            
            Image plusImage = new Image();
            plusImage.ImageUrl = "Images/plus.png";

            Image minusImage = new Image();
            minusImage.ImageUrl = "Images/minus.png";

            HtmlGenericControl listItem = new HtmlGenericControl("li");
            HtmlGenericControl rankContainer = new HtmlGenericControl("div");
            HtmlGenericControl masterContainer = new HtmlGenericControl("div");
            HtmlGenericControl voteControlAndVoteNumberContainer = new HtmlGenericControl("div");
            HtmlGenericControl characterNameContainer = new HtmlGenericControl("div");
            HtmlGenericControl voteControl = new HtmlGenericControl("div");
            HtmlGenericControl voteNumber = new HtmlGenericControl("div");
            HyperLink upvote = new HyperLink();
            HyperLink downvote = new HyperLink();

            // Assign neccessary Controls an ID so they may be styled through css
            listItem.ID = "listItem";
            rankContainer.ID = "rankContainer";
            masterContainer.ID = "masterContainer";
            voteControlAndVoteNumberContainer.ID = "voteControlAndVoteNumberContainer";
            characterNameContainer.ID = "characterNameContainer";
            voteControl.ID = "voteControl";
            voteNumber.ID = "voteNumber";
            upvote.ID = "upvote";
            downvote.ID = "downvote";

            HighlightSelectedVoteButton(upvote, downvote, characterID);

            // Populate up/downvote Controls
            upvote.NavigateUrl = "TierList.aspx?characterID=" + characterID + "&voteType=upvote";
            upvote.Controls.Add(plusImage);
            downvote.NavigateUrl = "TierList.aspx?characterID=" + characterID + "&voteType=downvote";
            downvote.Controls.Add(minusImage);

            // Populate the voteNumber control with the vote number
            voteNumber.InnerText = votes + " points";

            // Populate the rankContainer with the rank number
            rankContainer.InnerText = (i + 1).ToString();

            // Populate the characterNameContainer with name
            characterNameContainer.InnerText = characterName;

            // Add HyperLink controls into voteControl
            voteControl.Controls.Add(upvote);
            voteControl.Controls.Add(downvote);

            // Add controls, in order, into voteControlAndVoteNumberContainer
            voteControlAndVoteNumberContainer.Controls.Add(voteControl);
            voteControlAndVoteNumberContainer.Controls.Add(voteNumber);

            // Add controls, in order, into masterContainer
            masterContainer.Controls.Add(characterNameContainer);
            masterContainer.Controls.Add(voteControlAndVoteNumberContainer);

            // Add controls, in order, into listItem
            listItem.Controls.Add(rankContainer);
            listItem.Controls.Add(characterImage);
            listItem.Controls.Add(masterContainer);

            // Add the listItem into the orderedList
            orderedList.Controls.Add(listItem);
        }

        tierListPlaceholder.Controls.Add(orderedList);
    }

    private void HighlightSelectedVoteButton(HyperLink upvote, HyperLink downvote, int characterID)
    {
        if (Session["vote" + characterID] != null)
        {
            if (Session["vote" + characterID].Equals("upvote"))
            {
                upvote.CssClass = "selected";
            }
            else if (Session["vote" + characterID].Equals("downvote"))
            {
                downvote.CssClass = "selected";
            }
        }
    }

}