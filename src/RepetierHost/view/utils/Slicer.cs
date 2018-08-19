using BioMaker.model;
using BioMaker.model.geom;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BioMaker.view.utils
{
    public class Slicer : IDisposable
    {
        public enum SlicerID { Slic3r, Slic3rExternal };

        private SlicerID _ActiveSlicer = SlicerID.Slic3r;
        private bool _hasSlic3r = false;
        private bool _hasSlic3rExternal = false;
        public static RHBoundingBox lastBox = new RHBoundingBox();

        public Slicer()
        {
            Main.slicer = this;
            ActiveSlicer = Main.printerModel.ActiveSlicer; // (Slicer.SlicerID)(int)Main.main.repetierKey.GetValue("ActiveSlicer", (int)ActiveSlicer);
            Main.printerModel.PropertyChanged += printerPropertyChanged;

            Update();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (postproc != null)
                    postproc.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool hasSlic3r
        {
            get
            {
                return _hasSlic3r;
            }
        }

        public bool hasSlic3rExternal
        {
            get
            {
                return _hasSlic3rExternal;
            }
        }

        public string wrapQuotes(string text)
        {
            if (text.StartsWith("\"") && text.EndsWith("\"")) return text;
            return "\"" + text.Replace("\"", "\\\"") + "\"";
        }

        public delegate void LoadGCode(String myString);

        private string postprocessFile = null;
        private Process postproc = null;

        public void Postprocess(string file)
        {
            string dir = Main.globalSettings.Workdir;
            if (Main.conn.runFilterEverySlice == false || postproc != null || dir.Length == 0)
            {
                SlicingInfo.f.Invoke(SlicingInfo.f.StopInfo);
                LoadGCode lg = Main.main.LoadGCode;
                Main.main.Invoke(lg, file);
                if (SlicingInfo.f.checkStartBoxAfterSlicing.Checked && Main.conn.connector.IsConnected())
                    Main.main.Invoke(Main.main.StartJob);
                return; // Nothing to do
            }
            SlicingInfo.f.Invoke(SlicingInfo.f.PostprocInfo);
            // Copy file to work dir
            postprocessFile = file;
            string tmpfile = dir + Path.DirectorySeparatorChar + "filter.gcode";
            File.Copy(file, tmpfile, true);
            // run filter
            string full = Main.conn.filterCommand;
            int p = full.IndexOf(' ');
            if (p < 0) return;
            string cmd = full.Substring(0, p);
            string args = full.Substring(p + 1);
            args = args.Replace("#in", wrapQuotes(tmpfile));
            args = args.Replace("#out", wrapQuotes(file));
            Main.conn.log(cmd + " " + args, false, 3);
            postproc = new Process();
            postproc.EnableRaisingEvents = true;
            postproc.Exited += new EventHandler(PostprocessExited);
            postproc.StartInfo.FileName = Main.IsMono ? cmd : wrapQuotes(cmd);
            postproc.StartInfo.Arguments = args;
            postproc.StartInfo.UseShellExecute = false;
            postproc.StartInfo.RedirectStandardOutput = true;
            postproc.OutputDataReceived += new DataReceivedEventHandler(OutputDataHandler);
            postproc.StartInfo.RedirectStandardError = true;
            postproc.ErrorDataReceived += new DataReceivedEventHandler(OutputDataHandler);
            try
            {
                postproc.Start();
            }
            catch (Exception e)
            {
                postproc = null;
                SlicingInfo.f.Invoke(SlicingInfo.f.StopInfo);
                MessageBox.Show("Error starting postprocessor:" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Start the asynchronous read of the standard output stream.
            postproc.BeginOutputReadLine();
            postproc.BeginErrorReadLine();
        }

        private void PostprocessExited(object sender, System.EventArgs e)
        {
            postproc.Close();
            postproc = null;
            SlicingInfo.f.Invoke(SlicingInfo.f.StopInfo);
            LoadGCode lg = Main.main.LoadGCode;
            Main.main.Invoke(lg, postprocessFile);
            if (SlicingInfo.f.checkStartBoxAfterSlicing.Checked && Main.conn.connector.IsConnected())
                Main.main.Invoke(Main.main.StartJob);
        }

        private static void OutputDataHandler(object sendingProcess,
             DataReceivedEventArgs outLine)
        {
            // Collect the net view command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Main.conn.log("<Postprocess> " + outLine.Data, false, 4);
            }
        }

        private void printerPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            if (evt.PropertyName == "ActiveSlicer")
            {
                ActiveSlicer = Main.printerModel.ActiveSlicer;
            }
        }

        public SlicerID ActiveSlicer
        {
            get { return _ActiveSlicer; }
            set
            {
                if (value != _ActiveSlicer)
                {
                    _ActiveSlicer = value;
                    Main.printerModel.ActiveSlicer = _ActiveSlicer;
                    //Main.main.repetierKey.SetValue("ActiveSlicer", (int)_ActiveSlicer);
                }
                Main.main.slic3rToolStripMenuItem.Checked = _ActiveSlicer == SlicerID.Slic3r;
                Main.main.externalSlic3rToolStripMenuItem.Checked = _ActiveSlicer == SlicerID.Slic3rExternal;
                //Main.main.stlComposer1.buttonSlice.Text = Trans.T1("L_SLICE_WITH", SlicerName);
                if (Main.main.slicerPanel != null)
                    Main.main.slicerPanel.UpdateSelection();
            }
        }

        public void Update()
        {
            string basedir = (string)Main.main.repetierKey.GetValue("installPath", "");
            _hasSlic3r = Main.slic3r.findSlic3rExecutable() != null;
            /*if(basedir.Length>0) {
                string exname = "slic3r.exe";
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                    exname = "bin" + Path.DirectorySeparatorChar + "slic3r";
                if(Main.IsMac)
                    exname = "MacOS"+Path.DirectorySeparatorChar+"slic3r";
                _hasSlic3r = File.Exists(basedir+Path.DirectorySeparatorChar+"Slic3r"+Path.DirectorySeparatorChar+exname);
            }
            _hasSlic3rExternal = File.Exists(BasicConfiguration.basicConf.ExternalSlic3rIniFile) &&
                (_hasSlic3r || File.Exists(BasicConfiguration.basicConf.ExternalSlic3rPath));
            */
            Main.main.slic3rToolStripMenuItem.Enabled = _hasSlic3r;
            Main.main.externalSlic3rToolStripMenuItem.Enabled = _hasSlic3rExternal;
            Main.main.externalSlic3rConfigurationToolStripMenuItem.Enabled = _hasSlic3r || File.Exists(BasicConfiguration.basicConf.ExternalSlic3rPath);
            // Check if active slicer is possible
            if (ActiveSlicer == SlicerID.Slic3r && !_hasSlic3r && _hasSlic3rExternal)
                ActiveSlicer = SlicerID.Slic3rExternal;
            else if (_hasSlic3r)
                ActiveSlicer = SlicerID.Slic3r;
            else if (ActiveSlicer == SlicerID.Slic3rExternal && !_hasSlic3rExternal)
                ActiveSlicer = SlicerID.Slic3r;
            else ActiveSlicer = _ActiveSlicer;
        }

        /// <summary>
        /// Convert STL in GCode and load into editor
        /// </summary>
        /// <param name="file"></param>
        public void RunSlice(string file)
        {
            switch (_ActiveSlicer)
            {
                case SlicerID.Slic3r:
                    Main.slic3r.RunSliceNew(file, Main.printerSettings.PrintAreaWidth / 2, Main.printerSettings.PrintAreaDepth / 2);
                    break;
            }
        }

        public string SlicerName
        {
            get
            {
                switch (_ActiveSlicer)
                {
                    case SlicerID.Slic3r:
                        return "Slic3r";

                    case SlicerID.Slic3rExternal:
                        return "external Slic3r";
                }
                return "Unknown";
            }
        }
    }
}