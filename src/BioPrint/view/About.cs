/*
   Copyright 2011 repetier repetierdev@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using BioPrint.model;
using BioPrint.view.utils;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BioPrint.view
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            RegMemory.RestoreWindowPos("aboutWindow", this);
            textLicence.SelectionLength = 0;
            textLicence.SelectionStart = 0;
            translate();
            Main.main.languageChanged += translate;
        }

        private void translate()
        {
            buttonOK.Text = Trans.T("B_OK");
            Text = Trans.T("W_ABOUT_REPETIER_HOST");
            labelLicenceAndLibraries.Text = Trans.T("L_LICENCE_AND_LIBRARIES");
            labelRepetierInfo.Text = Trans.T("L_REPETIER_INFO");
            textLicence.Text = Trans.T("L_LICENCE_TEXT");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main.main.openLink("https://loja.duelaser.com/");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegMemory.StoreWindowPos("aboutWindow", this, false, false);
        }
    }
}