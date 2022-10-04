using Analogy.LogViewer.WordsSearch.Managers;
using System;
using System.Windows.Forms;

namespace Analogy.LogViewer.WordsSearch
{
    public partial class WordsSearchSettings : UserControl
    {
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;

        public WordsSearchSettings()
        {
            InitializeComponent();
        }

        private void WordsSearchSettings_Load(object sender, EventArgs e)
        {
            nudLength.Value = Settings.Length;
            txtFilesLocation.Text = Settings.FilesLocation;
            RefreshList();
        }

        private void RefreshList()
        {
            lstCharPositions.Items.Clear();
            lstCharPositions.Items.AddRange(Settings.CharsPositions.ToArray());
        }

        private void nudLength_ValueChanged(object sender, EventArgs e)
        {
            Settings.Length = decimal.ToInt32(nudLength.Value);
            nudPosition.Maximum = nudLength.Value - 1;
        }

        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            if (lstCharPositions.SelectedItem is CharPosition p)
            {
                Settings.RemovePosition(p);
                RefreshList();
            }

        }

        private void btnAddOrReplace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbChr.Text))
            {
                CharPosition p = new CharPosition(txtbChr.Text[0], decimal.ToInt32(nudPosition.Value));
                Settings.AddOrReplacePosition(p);
                RefreshList();
            }
        }

        private void btnFolderSelection_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = UserSettingsManager.UserSettings.FilesLocation;
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog(this))
            {
                UserSettingsManager.UserSettings.FilesLocation = folderBrowserDialog1.SelectedPath;
                txtFilesLocation.Text = UserSettingsManager.UserSettings.FilesLocation;
                UserSettingsManager.UserSettings.Save();
            }
        }
    }
}
