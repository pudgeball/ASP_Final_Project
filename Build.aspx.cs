using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class Build : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int CharacterID = 0;

		NameValueCollection queryString = Request.QueryString;
		if (queryString["CharacterID"] != null)
		{
			CharacterID = Convert.ToInt32(queryString["CharacterID"]);
		}
		else
		{
			Response.Redirect("Default.aspx");
		}


		Response.Write(CharacterID);
    }
}