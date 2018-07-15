using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class PrinterSettings
    {
        // General
        public string BedShape { get; set; }
        public string ZOffset { get; set; }
        public string OctoprintHost { get; set; }
        public string OctoprintApikey { get; set; }
        public string GcodeFlavor { get; set; }
        public bool UseRelativeEDistances { get; set; }
        public bool UseFirmwareRetraction { get; set; }
        public bool UseVolumetricE { get; set; }
        public string PressureAdvance { get; set; }
        public string VibrationLimit { get; set; }

        // Custom G-code
        public string StartGcode { get; set; }
        public string EndGcode { get; set; }
        public string BeforeLayerGcode { get; set; }
        public string LayerGcode { get; set; }
        public string ToolchangeGcode { get; set; }

        // Extruder
        public List<PrinterExtruderSettings> ExtrudersSettings { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}", "bed_shape", BedShape);
            builder.AppendFormat("{0} = {1}", "before_layer_gcode", BeforeLayerGcode);
            builder.AppendFormat("{0} = {1}", "end_gcode", EndGcode);
            builder.AppendFormat("{0} = {1}", "extruder_offset", string.Join(", ", ExtrudersSettings.Select(es => es.ExtruderOffset)));
            builder.AppendFormat("{0} = {1}", "gcode_flavor", GcodeFlavor);
            builder.AppendFormat("{0} = {1}", "layer_gcode", LayerGcode);
            builder.AppendFormat("{0} = {1}", "nozzle_diameter", string.Join(", ", ExtrudersSettings.Select(es => es.NozzleDiameter)));
            builder.AppendFormat("{0} = {1}", "octoprint_apikey", OctoprintApikey);
            builder.AppendFormat("{0} = {1}", "octoprint_host", OctoprintHost);
            builder.AppendFormat("{0} = {1}", "pressure_advance", PressureAdvance);
            builder.AppendFormat("{0} = {1}", "retract_before_travel", string.Join(", ", ExtrudersSettings.Select(es => es.RetractBeforeTravel)));
            builder.AppendFormat("{0} = {1}", "retract_layer_change", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLayerChange)));
            builder.AppendFormat("{0} = {1}", "retract_length", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLength)));
            builder.AppendFormat("{0} = {1}", "retract_length_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLengthToolchange)));
            builder.AppendFormat("{0} = {1}", "retract_lift", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLift)));
            builder.AppendFormat("{0} = {1}", "retract_restart_extra", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtra)));
            builder.AppendFormat("{0} = {1}", "retract_restart_extra_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtraToolchange)));
            builder.AppendFormat("{0} = {1}", "retract_speed", string.Join(", ", ExtrudersSettings.Select(es => es.RetractSpeed)));
            builder.AppendFormat("{0} = {1}", "start_gcode", StartGcode);
            builder.AppendFormat("{0} = {1}", "toolchange_gcode", ToolchangeGcode);
            builder.AppendFormat("{0} = {1}", "use_firmware_retraction", UseFirmwareRetraction);
            builder.AppendFormat("{0} = {1}", "use_relative_e_distances", UseRelativeEDistances);
            builder.AppendFormat("{0} = {1}", "use_volumetric_e", UseVolumetricE);
            builder.AppendFormat("{0} = {1}", "vibration_limit", VibrationLimit);
            builder.AppendFormat("{0} = {1}", "wipe", string.Join(", ", ExtrudersSettings.Select(es => es.Wipe)));
            builder.AppendFormat("{0} = {1}", "z_offset", ZOffset);

            return builder.ToString();
        }

    }
}
