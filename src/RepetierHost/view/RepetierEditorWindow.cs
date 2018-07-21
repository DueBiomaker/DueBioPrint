using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RepetierHost.view
{
    public partial class RepetierEditorWindow : Form
    {
        public RepetierEditorWindow(RepetierEditor editor)
        {
            InitializeComponent();
            pnlContent.Controls.Add(editor);
        }

        private void RepetierEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            pnlContent.Controls.Clear();
        }
    }
}
