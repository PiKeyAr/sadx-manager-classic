using SADXModManager.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SADXModManager.Forms
{
	public partial class ModUrlDialog : Form
	{
		public List<DownloadItem> Downloads;

		public ModUrlDialog()
		{
			InitializeComponent();
			Downloads = new List<DownloadItem>();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBoxPasteUrls_TextChanged(object sender, EventArgs e)
		{
			CheckPastedUrls();
		}

		private void CheckPastedUrls()
		{
			int countUrls = 0;
			if (textBoxPasteUrls.Lines.Count() == 0)
			{
				labelParseStatus.Text = "No URLs detected.";
				buttonParse.Enabled = false;
				return;
			}
			for (int line = 0; line < textBoxPasteUrls.Lines.Length; line++)
			{
				if (!textBoxPasteUrls.Lines[line].StartsWith("http", StringComparison.OrdinalIgnoreCase) && !textBoxPasteUrls.Lines[line].StartsWith("sadxmm", StringComparison.OrdinalIgnoreCase))
				{
					labelParseStatus.Text = string.Format("Line {0} is not a valid URL.", line);
					buttonParse.Enabled = false;
					return;
				}
				if (!textBoxPasteUrls.Lines[line].StartsWith("sadxmm", StringComparison.OrdinalIgnoreCase) && !textBoxPasteUrls.Lines[line].Contains("github.com") && !textBoxPasteUrls.Lines[line].Contains("gamebanana.com"))
				{
					labelParseStatus.Text = string.Format("Line {0} is not a supported URL.", line);
					buttonParse.Enabled = false;
					return;
				}
				countUrls++;
			}
			labelParseStatus.Text = string.Format("{0} URLs detected.", countUrls);
			buttonParse.Enabled = countUrls > 0;
		}

		private void buttonParse_Click(object sender, EventArgs e)
		{
			Downloads = new List<DownloadItem>();
			foreach (string line in textBoxPasteUrls.Lines)
			{
				DownloadItem item = Utils.HandleUri(line, this);
				if (item != null)
					Downloads.Add(item);
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}