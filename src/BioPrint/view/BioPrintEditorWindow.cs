using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BioPrint.view
{
    public partial class BioPrintEditorWindow : Form
    {
        public BioPrintEditorWindow(BioPrintEditor editor)
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
