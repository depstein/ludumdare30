using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Scripts {
	public static class XmlLoading {

		public const string ROOTDIRECTORY = "Assets/People/";

		//TODO: Read all of the people in a folder
		public static List<Person> ReadFolderOfPeople() {
			FileInfo[] fileList = new DirectoryInfo(ROOTDIRECTORY).GetFiles("*.xml", SearchOption.AllDirectories);
			List<Person> people = new List<Person>();
			foreach(var file in fileList) {
				people.Add(ReadPersonFromFile(file));
			}
			return people;
		}

		public static Person ReadPersonFromFile(FileInfo file) {
			XmlSerializer mySerializer = new XmlSerializer(typeof(Person));
			// To read the file, create a FileStream.
			FileStream myFileStream = file.Open(FileMode.Open);
			// Call the Deserialize method and cast to the object type.
			return (Person)mySerializer.Deserialize(myFileStream);
		}
	}
}