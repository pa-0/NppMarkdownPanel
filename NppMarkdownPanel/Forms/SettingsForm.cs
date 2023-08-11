﻿using NppMarkdownPanel.Entities;
using System;
using System.Windows.Forms;

namespace NppMarkdownPanel.Forms
{
    public partial class SettingsForm : Form
    {
        public int ZoomLevel { get; set; }
        public string CssFileName { get; set; }
        public string CssDarkModeFileName { get; set; }
        public string HtmlFileName { get; set; }
        public bool ShowToolbar { get; set; }
        public string MkdnExtensions { get; set; }
        public string HtmlExtensions { get; set; }
        public bool AutoShowPanel { get; set; }
        public bool ShowStatusbar { get; set; }
        public bool SuppressScriptErrors { get; set; }

        public SettingsForm(Settings settings)
        {
            ZoomLevel = settings.ZoomLevel;
            CssFileName = settings.CssFileName;
            CssDarkModeFileName = settings.CssDarkModeFileName;
            HtmlFileName = settings.HtmlFileName;
            ShowToolbar = settings.ShowToolbar;
            MkdnExtensions = settings.MkdnExtensions;
            HtmlExtensions = settings.HtmlExtensions;
            AutoShowPanel = settings.AutoShowPanel;
            ShowStatusbar = settings.ShowStatusbar;
            SuppressScriptErrors = settings.SuppressScriptErrors;

            InitializeComponent();

            trackBar1.Value = ZoomLevel;
            lblZoomValue.Text = $"{ZoomLevel}%";
            tbCssFile.Text = CssFileName;
            tbDarkmodeCssFile.Text = CssDarkModeFileName;
            tbHtmlFile.Text = HtmlFileName;
            cbShowToolbar.Checked = ShowToolbar;
            tbMkdnExts.Text = MkdnExtensions;
            tbHtmlExts.Text = HtmlExtensions;
            cbAutoShowPanel.Checked = AutoShowPanel;
            cbShowStatusbar.Checked = ShowStatusbar;
            cbSuppressScriptErrors.Checked = SuppressScriptErrors;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            ZoomLevel = trackBar1.Value;
            lblZoomValue.Text = $"{ZoomLevel}%";
        }

        private void tbCssFile_TextChanged(object sender, EventArgs e)
        {
            CssFileName = tbCssFile.Text;
        }
        private void tbDarkmodeCssFile_TextChanged(object sender, EventArgs e)
        {
            CssDarkModeFileName = tbDarkmodeCssFile.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbHtmlFile.Text) && String.IsNullOrEmpty(sblInvalidHtmlPath.Text))
            {
                bool validHtmlPath = Utils.ValidateFileSelection(tbHtmlFile.Text, out string validPath, out string error, "HTML Output");
                if (!validHtmlPath)
                    sblInvalidHtmlPath.Text = error;
                else
                    tbHtmlFile.Text = validPath;
            }

            if (String.IsNullOrEmpty(sblInvalidHtmlPath.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelEsc_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnChooseCss_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "css files (*.css)|*.css|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((sender as Button).Name == "btnChooseCss")
                    {
                        CssFileName = openFileDialog.FileName;
                        tbCssFile.Text = CssFileName;
                    }
                    else if ((sender as Button).Name == "btnChooseDarkmodeCss")
                    {
                        CssDarkModeFileName = openFileDialog.FileName;
                        tbDarkmodeCssFile.Text = CssDarkModeFileName;
                    }

                }
            }
        }

        private void btnDefaultCss_Click(object sender, EventArgs e)
        {
            tbCssFile.Text = "style.css";
        }
        private void btnDefaultDarkmodeCss_Click(object sender, EventArgs e)
        {
            tbDarkmodeCssFile.Text = "style-dark.css";
        }

        #region Output HTML File
        private void tbHtmlFile_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbHtmlFile.Text))
            {
                bool valid = Utils.ValidateFileSelection(tbHtmlFile.Text, out string validPath, out string error, "HTML Output");
                if (valid)
                {
                    HtmlFileName = validPath;
                    if (!String.IsNullOrEmpty(sblInvalidHtmlPath.Text))
                        sblInvalidHtmlPath.Text = String.Empty;
                }
                else
                {
                    sblInvalidHtmlPath.Text = error;
                }
            }
            else
            {
                HtmlFileName = String.Empty;
                if (!String.IsNullOrEmpty(sblInvalidHtmlPath.Text))
                    sblInvalidHtmlPath.Text = String.Empty;
            }
        }

        private void tbHtmlFile_Leave(object sender, EventArgs e)
        {
            tbHtmlFile.Text = HtmlFileName;
        }

        private void btnChooseHtml_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "html files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    HtmlFileName = saveFileDialog.FileName;
                    tbHtmlFile.Text = HtmlFileName;
                }
            }
        }

        private void btnResetHtml_Click(object sender, EventArgs e)
        {
            tbHtmlFile.Text = "";
        }
        #endregion

        #region Show Toolbar
        private void cbShowToolbar_Changed(object sender, EventArgs e)
        {
            ShowToolbar = cbShowToolbar.Checked;
        }

        #endregion

        private void tbMkdnExts_TextChanged(object sender, EventArgs e)
        {
            MkdnExtensions = tbMkdnExts.Text;
        }
        private void btnDefaultMkdnExts_Click(object sender, EventArgs e)
        {
            tbMkdnExts.Text = Settings.DEFAULT_SUPPORTED_MKDN_EXT;
        }

        private void tbHtmlExts_TextChanged(object sender, EventArgs e)
        {
            HtmlExtensions = tbHtmlExts.Text;
        }
        private void btnDefaultHtmlExts_Click(object sender, EventArgs e)
        {
            tbHtmlExts.Text = Settings.DEFAULT_SUPPORTED_HTML_EXT;
        }

        private void cbAutoShowPanel_CheckedChanged(object sender, EventArgs e)
        {
            AutoShowPanel = cbAutoShowPanel.Checked;
        }

        private void cbShowStatusbar_CheckedChanged(object sender, EventArgs e)
        {
            ShowStatusbar = cbShowStatusbar.Checked;
        }

        private void cbSuppressScriptErrors_CheckedChanged(object sender, EventArgs e)
        {
            SuppressScriptErrors = cbSuppressScriptErrors.Checked;
        }
    }
}
