using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for Character
/// </summary>
public class Character
{
    private int id;
    private string name;

	public Character()
	{

	}

    public Character(XContainer character)
    {
        this.id = Convert.ToInt32(GetElementValue(character, "id"));
        this.name = GetElementValue(character, "name");
    }

    private static string GetElementValue(XContainer element, string name)
    {
        if ((element == null) || (element.Element(name) == null))
            return String.Empty;
        return element.Element(name).Value;
    }

    public override string ToString()
    {
        return String.Format("{0} - {1}", this.id, this.name);
    }
}