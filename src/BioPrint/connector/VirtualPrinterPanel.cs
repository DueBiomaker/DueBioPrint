using BioPrint.model;
using System;
using System.Windows.Forms;

namespace BioPrint.connector
{
    public partial class VirtualPrinterPanel : UserControl
    {
        private VirtualPrinterConnector con = null;

        public VirtualPrinterPanel()
        {
            InitializeComponent();
            Main.main.languageChanged += Translate;
            Translate();
        }

        public void Connect(VirtualPrinterConnector con)
        {
            this.con = con;
            bindingConnection.DataSource = con;
            bindingConnection_CurrentItemChanged(null, null);
        }

        public void Translate()
        {
            labelBaudRate.Text = Trans.T("L_BAUD_RATE");
        }

        private bool updating = false;

        private void bindingConnection_CurrentItemChanged(object sender, EventArgs e)
        {
            updating = true;
            comboBaud.Text = con.BaudRate;
            updating = false;
        }

        private void comboBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating || con == null) return;
            con.BaudRate = comboBaud.Text;
        }
    }
}