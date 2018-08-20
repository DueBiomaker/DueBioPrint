using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepetierHost.model;

namespace RepetierHost.view
{
    public partial class VisualizationControl : UserControl
    {
        public VisualizationControl()
        {
            InitializeComponent();

            labelMaxLayer.DataBindings.Add("Text", this, "MaxLayer");
            numericShowMinLayer.DataBindings.Add("Value", this, "ShowMinLayer");
            numericShowMaxLayer.DataBindings.Add("Value", this, "ShowMaxLayer");
            sliderShowFirstLayer.DataBindings.Add("value", this, "ShowMinLayer");
            sliderShowMaxLayer.DataBindings.Add("value", this, "ShowMaxLayer");
        }

        public event EventHandler MaxLayerChanged;
        public event EventHandler ShowModeChanged;
        public event EventHandler ShowMinLayerChanged;
        public event EventHandler ShowMaxLayerChanged;

        public event ContentChangedEvent contentChangedEvent = null;

        private int _maxLayer;

        public int MaxLayer
        {
            get { return _maxLayer; }
            set
            {
                if (value != _maxLayer)
                {
                    _maxLayer = value;
                    OnMaxLayerChanged(EventArgs.Empty);
                    sliderShowFirstLayer.Maximum = _maxLayer;
                    sliderShowMaxLayer.Maximum = _maxLayer;
                    numericShowMinLayer.Maximum = _maxLayer;
                    numericShowMaxLayer.Maximum = _maxLayer;
                }
            }
        }

        public int ShowMode
        {
            get { return _showMode; }
            set
            {
                if (value != _showMode)
                {
                    _showMode = value;
                    OnShowModeChanged(EventArgs.Empty);
                    if (contentChangedEvent != null)
                        contentChangedEvent();
                }
            }
        }

        private void radioShowMode_Click(object sender, EventArgs e)
        {
            ShowMode = int.Parse((string)((RadioButton)sender).Tag);
        }

        private void sliderShowFirstLayer_ValueChanged(object sender, EventArgs e)
        {
            ShowMinLayer = sliderShowFirstLayer.Value;
        }

        private void sliderShowMaxLayer_ValueChanged(object sender, EventArgs e)
        {
            ShowMaxLayer = sliderShowMaxLayer.Value;
        }

        private void numericShowMinLayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            ShowMinLayer = (int)numericShowMinLayer.Value;
        }

        private void numericShowMinLayer_ValueChanged(object sender, EventArgs e)
        {
            ShowMinLayer = (int)numericShowMinLayer.Value;
        }

        private void numericShowMaxLayer_ValueChanged(object sender, EventArgs e)
        {
            ShowMaxLayer = (int)numericShowMaxLayer.Value;
        }

        protected void OnShowModeChanged(EventArgs e)
        {
            if (ShowModeChanged != null)
            {
                ShowModeChanged(this, e);
            }
        }

        protected void OnShowMinLayerChanged(EventArgs e)
        {
            if (ShowMinLayerChanged != null)
            {
                ShowMinLayerChanged(this, e);
            }
        }

        protected void OnShowMaxLayerChanged(EventArgs e)
        {
            if (ShowMaxLayerChanged != null)
            {
                ShowMaxLayerChanged(this, e);
            }
        }

        protected void OnMaxLayerChanged(EventArgs e)
        {
            if (MaxLayerChanged != null)
            {
                MaxLayerChanged(this, e);
            }
        }

        private int _showMode = 0;
        private int _showMinLayer = 0;
        private int _showMaxLayer = 1;

        public int ShowMinLayer
        {
            get { return _showMinLayer; }
            set
            {
                if (value < 0) value = 0;
                if (value > _maxLayer) value = MaxLayer;
                if (value != _showMinLayer)
                {
                    _showMinLayer = value;
                    sliderShowFirstLayer.Value = value;
                    OnShowMinLayerChanged(EventArgs.Empty);
                    if (_showMode == 1 || _showMinLayer > _showMaxLayer)
                    {
                        _showMaxLayer = value;
                        sliderShowMaxLayer.Value = value;
                        OnShowMaxLayerChanged(EventArgs.Empty);
                    }
                    if (_showMode != 0)
                        if (contentChangedEvent != null)
                            contentChangedEvent();
                }
            }
        }

        public int ShowMaxLayer
        {
            get { return _showMaxLayer; }
            set
            {
                if (value < 0) value = 0;
                if (value > _maxLayer) value = MaxLayer;
                if (value != _showMaxLayer)
                {
                    _showMaxLayer = value;
                    sliderShowMaxLayer.Value = value;
                    OnShowMaxLayerChanged(EventArgs.Empty);
                    if (_showMode == 1 || _showMaxLayer < _showMinLayer)
                    {
                        _showMinLayer = value;
                        sliderShowFirstLayer.Value = value;
                        OnShowMinLayerChanged(EventArgs.Empty);
                    }
                    if (_showMode != 0)
                        if (contentChangedEvent != null)
                            contentChangedEvent();
                }
            }
        }

        private void translate()
        {
            tabPageVisualization.Text = Trans.T("TAB_VISUALIZATION");
            radioShowAll.Text = Trans.T("L_SHOW_COMPLETE_CODE");
            radioShowLayerRange.Text = Trans.T("L_SHOW_LAYER_RANGE");
            radioShowSingleLayer.Text = Trans.T("L_SHOW_SINGLE_LAYER");
            buttonGoFirstLayer.Text = Trans.T("L_FIRST_LAYER");
            buttonGoLastLayer.Text = Trans.T("L_LAST_LAYER");
        }
    }
}
