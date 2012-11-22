using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ability
/// </summary>
public class Ability
{
	public string Name { get; set; }
	public string Description { get; set; }

	public Ability(string name, string desc)
	{
		Name = name;
		Description = desc;
	}
}