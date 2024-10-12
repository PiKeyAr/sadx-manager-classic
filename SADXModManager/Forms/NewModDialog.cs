using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniFile;

namespace SADXModManager.Forms
{
	public partial class NewModDialog : Form
	{
		public string ModAuthor;

		public NewModDialog()
		{
			InitializeComponent();
			textBoxModAuthor.Text = ModAuthor;
			textBoxModID.Text = GenerateModID();
		}

		public NewModDialog(string author)
		{
			InitializeComponent();
			ModAuthor = textBoxModAuthor.Text = author;
			textBoxModID.Text = GenerateModID();
		}

		static string GenerateModID()
		{
			return "sadx." + ((uint)DateTime.Now.GetHashCode()).ToString();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// Save mod author in Manager settings
			if (isStringNotEmpty(textBoxModAuthor.Text))
			{
				ModAuthor = textBoxModAuthor.Text;
			}

			string moddir = Path.Combine(Path.Combine(Environment.CurrentDirectory, "mods"), ValidateFilename(textBoxModName.Text));

			if (textBoxModName.Text.Length <= 0)
			{
				MessageBox.Show("You can't have a mod without a name.", "Invalid mod name", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				if (Directory.Exists(moddir))
				{
					MessageBox.Show("A mod with that folder name already exists."
					                + "\nPlease choose a different name or rename the existing one.", "Mod folder already exists",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}

				Directory.CreateDirectory(moddir);

				if (checkBoxRedirectMainSave.Checked || checkBoxRedirectChaoSave.Checked)
				{
					Directory.CreateDirectory(Path.Combine(moddir, "SAVEDATA"));
				}

				if (comboBoxModCategory.Text == "Music")
				{
					Directory.CreateDirectory(@Path.Combine(moddir, "system/SoundData/bgm/wma"));
				}

				if (comboBoxModCategory.Text == "Sound")
				{
					Directory.CreateDirectory(@Path.Combine(moddir, "system/SoundData/SE"));
				}

				if (comboBoxModCategory.Text == "Textures")
				{
					Directory.CreateDirectory(Path.Combine(moddir, "textures"));
				}

				if (isStringNotEmpty(textBoxIncludeFolders.Text))
				{
					try
					{
						foreach (string incdir in textBoxIncludeFolders.Text.Split(','))
						{
							Directory.CreateDirectory(Path.Combine(moddir, incdir));
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Error creating mod include folders: " + ex.Message.ToString(), "SADX Mod Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				if (comboBoxModCategory.SelectedIndex < 0)
				{
					comboBoxModCategory.Text = "";
				}

				// GameBanana ID workaround
				long? gbId = Convert.ToInt64(numericUpDownGameBananaID.Value);
				if (gbId == 0)
					gbId = null;

				// Assign variables to null if the string are empty so they won't show up at all in mod.ini.
				SADXModInfo newMod = new SADXModInfo
				{
					// Properties
					Name = textBoxModName.Text,
					Author = isStringNotEmpty(textBoxModAuthor.Text) ? textBoxModAuthor.Text : null,
					Version = isStringNotEmpty(textBoxModVersion.Text) ? textBoxModVersion.Text : null,
					Category = isStringNotEmpty(comboBoxModCategory.Text) ? comboBoxModCategory.Text : null,
					ModID = isStringNotEmpty(textBoxModID.Text) ? textBoxModID.Text : null,
					DLLFile = isStringNotEmpty(textBoxModDll.Text) ? textBoxModDll.Text : null,
					Description = textBoxModDescription.Text.Length > 0 ? textBoxModDescription.Text : null,
					// Updates: GitHub
					GitHubRepo = (radioButtonModUpdatesGitHub.Checked && isStringNotEmpty(textBoxGitHubRepo.Text)) ? textBoxGitHubRepo.Text : null,
					GitHubAsset = (radioButtonModUpdatesGitHub.Checked && isStringNotEmpty(textBoxGitHubAttachment.Text)) ? textBoxGitHubAttachment.Text : null,
					// Updates: Self-Hosted
					UpdateUrl = (radioButtonModUpdatesSelf.Checked && isStringNotEmpty(textBoxSelfHostUrl.Text)) ? textBoxSelfHostUrl.Text : null,
					ChangelogUrl = (radioButtonModUpdatesSelf.Checked && isStringNotEmpty(textBoxSelfHostChangelogUrl.Text)) ? textBoxSelfHostChangelogUrl.Text : null,
					// Updates: GameBanana
					GameBananaItemId = radioButtonModUpdatesGameBanana.Checked ? gbId : null,
					GameBananaItemType = (radioButtonModUpdatesGameBanana.Checked && isStringNotEmpty(comboBoxGameBananaType.Text)) ? comboBoxGameBananaType.Text : null,
					// Advanced
					IncludeDirs = isStringNotEmpty(textBoxIncludeFolders.Text) ? textBoxIncludeFolders.Text.Split(',').ToList() : null,
					IncludeDirCount = isStringNotEmpty(textBoxIncludeFolders.Text) ? textBoxIncludeFolders.Text.Split(',').Length.ToString() : null,
					AuthorURL = isStringNotEmpty(textBoxHomepageUrl.Text) ? textBoxHomepageUrl.Text : null,
					SourceCode = isStringNotEmpty(textBoxSourceUrl.Text) ? textBoxSourceUrl.Text : null,
					EXEFile = isStringNotEmpty(textBoxModExeFile.Text) ? textBoxModExeFile.Text : null,
					RedirectMainSave = checkBoxRedirectMainSave.Checked,
					RedirectChaoSave = checkBoxRedirectChaoSave.Checked,
					// TODO: Dependencies
				};

				IniSerializer.Serialize(newMod, Path.Combine(moddir, "mod.ini"));

				if (checkBoxOpenModFolder.Checked)
				{
					System.Diagnostics.Process.Start(moddir);
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception error)
			{
				MessageBox.Show(this, error.Message, "Mod Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		static string ValidateFilename(string filename)
		{
			string result = filename;

			foreach (char c in Path.GetInvalidFileNameChars())
				result = result.Replace(c, '_');

			return result;
		}

		static bool isStringNotEmpty(string txt)
		{
			return !string.IsNullOrEmpty(txt) && txt.Length > 0;
		}

		static string RemoveSpecialCharacters(string str)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '-')
				{
					sb.Append(c);
				}
			}
			return sb.ToString().ToLowerInvariant();
		}

		private void buttonGenerateModId_Click(object sender, EventArgs e)
		{
			textBoxModID.Clear();
			string name = isStringNotEmpty(textBoxModName.Text) ? textBoxModName.Text : null;
			string author = isStringNotEmpty(textBoxModAuthor.Text) ? textBoxModAuthor.Text : null;

			if (name != null && author != null)
			{
				string idName = RemoveSpecialCharacters(name);
				string idAuthor = RemoveSpecialCharacters(author);
				textBoxModID.Text = String.Format("sadx.{0}.{1}", idAuthor, idName);
			}
			else
				textBoxModID.Text = GenerateModID();
		}
	}
}