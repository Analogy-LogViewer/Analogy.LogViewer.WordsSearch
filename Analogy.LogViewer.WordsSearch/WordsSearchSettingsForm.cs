using Analogy.LogViewer.WordsSearch.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.WordsSearch
{
    public partial class WordsSearchSettingsForm : Form
    {
        public WordsSearchSettingsForm()
        {
            InitializeComponent();
        }

        private void WordsSearchSettingsForm_Load(object sender, EventArgs e)
        {
            WordsSearchSettings uc = new WordsSearchSettings();
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void WordsSearchSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettingsManager.UserSettings.Save();
        }
    }
}