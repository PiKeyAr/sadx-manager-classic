using SADXModManager.DataClasses;
using System;
using System.IO;
using System.Windows.Forms;

namespace SADXModManager.Forms
{
	public partial class SaveProfileDialog : Form
	{
		public string ProfileName;

		public SaveProfileDialog()
		{
			InitializeComponent();
			textBoxProfileName.Select();
		}

		private void textBoxProfileName_TextChanged(object sender, EventArgs e)
		{
			buttonSaveProfile.Enabled = (!string.IsNullOrEmpty(textBoxProfileName.Text) && textBoxProfileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) == -1);
		}

		private void buttonSaveProfile_Click(object sender, EventArgs e)
		{
			ProfileName = textBoxProfileName.Text.Replace(".json", "");
			Save();
		}

		private void SaveProfileDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && buttonSaveProfile.Enabled)
			{
				ProfileName = textBoxProfileName.Text.Replace(".json", "");
				Save();
			}
		}

		private void textBoxProfileName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && buttonSaveProfile.Enabled)
			{
				ProfileName = textBoxProfileName.Text.Replace(".json", "");
				Save();
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void Save()
		{
			// Check if the specified name already exists
			bool exists = false;
			foreach (ProfileData data in Variables.profilesJson.ProfilesList)
				if (data.Name == ProfileName)
					exists = true;
			// Show a dialog if it exists
			if (exists)
			{
				DialogResult result = MessageBox.Show(this, string.Format("Profile with the name '{0}' already exists. Would you like to overwrite it?", ProfileName), "SADX Mod Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Yes:
						DialogResult = DialogResult.OK;
						Close();
						return;
					case DialogResult.No:
						DialogResult = DialogResult.Cancel;
						Close();
						return;
					case DialogResult.Cancel:
						return;
				}
			}
			else
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}