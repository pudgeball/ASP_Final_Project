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
    private int _id;
    private string _name;

	public Character()
	{

	}

    public override string ToString()
    {
        return String.Format("{0} - {1}", ID, Name);
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
}