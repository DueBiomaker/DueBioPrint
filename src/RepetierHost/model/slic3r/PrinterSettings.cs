using RepetierHost.extensions;
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

            builder.AppendFormat("{0} = {1}\n", "bed_shape", BedShape.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "before_layer_gcode", BeforeLayerGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "end_gcode", EndGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extruder_offset", string.Join(", ", ExtrudersSettings.Select(es => es.ExtruderOffset.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "gcode_flavor", GcodeFlavor.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "layer_gcode", LayerGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "nozzle_diameter", string.Join(", ", ExtrudersSettings.Select(es => es.NozzleDiameter.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "octoprint_apikey", OctoprintApikey.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "octoprint_host", OctoprintHost.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "pressure_advance", PressureAdvance.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "retract_before_travel", string.Join(", ", ExtrudersSettings.Select(es => es.RetractBeforeTravel.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_layer_change", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLayerChange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_length", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLength.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_length_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLengthToolchange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_lift", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLift.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_restart_extra", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtra.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_restart_extra_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtraToolchange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_speed", string.Join(", ", ExtrudersSettings.Select(es => es.RetractSpeed.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "start_gcode", StartGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "toolchange_gcode", ToolchangeGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_firmware_retraction", UseFirmwareRetraction.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_relative_e_distances", UseRelativeEDistances.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_volumetric_e", UseVolumetricE.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "vibration_limit", VibrationLimit.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "wipe", string.Join(", ", ExtrudersSettings.Select(es => es.Wipe.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "z_offset", ZOffset.ToSlic3rSettings());

            return builder.ToString();
        }

    }
}
