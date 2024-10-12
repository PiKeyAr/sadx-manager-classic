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
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SaveProfileDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (buttonSaveProfile.Enabled)
			{
				ProfileName = textBoxProfileName.Text.Replace(".json", "");
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void textBoxProfileName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && buttonSaveProfile.Enabled)
			{
				ProfileName = textBoxProfileName.Text.Replace(".json", "");
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}