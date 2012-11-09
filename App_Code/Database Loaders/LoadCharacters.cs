using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for LoadCharacters
/// </summary>
public class LoadCharacters
{
    public static void LoadCharactersIntoDatabase(string path, HttpResponse response)
    {
        XDocument charactersXML = XDocument.Load(path + "\\Characters.xml");
        IEnumerable<Character> characters =
            from character in charactersXML.Descendants("character")
            select new Character(character);

        foreach (Character character in characters)
        {
            response.Write(character.ToString());
        }
    }
}