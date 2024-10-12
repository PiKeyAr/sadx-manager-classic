using System.Collections.Generic;
using System.ComponentModel;

// Profiles.json in SAManager\SADX

namespace SADXModManager.DataClasses
{
	public class ProfileData
	{
		public string Name { get; set; }
		public string Filename { get; set; }
	}

	public class ProfilesJson
	{
		[DefaultValue(0)]
		public int ProfileIndex;
		public List<ProfileData> ProfilesList;

		public ProfilesJson()
		{
			ProfilesList = new List<ProfileData>();
		}
	}
}