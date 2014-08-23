using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public static class XmlLoading {

	public const string ROOTDIRECTORY = "Assets/People/";

	//TODO: Read all of the people in a folder
	public static void ReadFolderOfPeople() {

	}

	public static Person ReadPersonFromFile(string filename) {
		XmlSerializer mySerializer = new XmlSerializer(typeof(Person));
		// To read the file, create a FileStream.
		FileStream myFileStream = new FileStream(ROOTDIRECTORY + filename, FileMode.Open);
		// Call the Deserialize method and cast to the object type.
		return (Person)mySerializer.Deserialize(myFileStream);
	}
}
