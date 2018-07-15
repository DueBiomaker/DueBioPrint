using RepetierHost.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class FilamentSettings
    {
        // Filament
        public string FilamentColour { get; set; }
        public string FilamentDiameter { get; set; }
        public string ExtrusionMultiplier { get; set; }
        public string FirstLayerTemperature { get; set; }
        public string Temperature { get; set; }
        public string FirstLayerBedTemperature { get; set; }
        public string BedTemperature { get; set; }

        // Cooling
        public string FanAlwaysOn { get; set; }
        public string Cooling { get; set; }
        public string MaxFanSpeed { get; set; }
        public string MinFanSpeed { get; set; }
        public string BridgeFanSpeed { get; set; }
        public string DisableFanFirstLayers { get; set; }
        public string FanBelowLayerTime { get; set; }
        public string SlowdownBelowLayerTime { get; set; }
        public string MinPrintSpeed { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}\n", "bed_temperature", BedTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bridge_fan_speed", BridgeFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "cooling", Cooling.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "disable_fan_first_layers", DisableFanFirstLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extrusion_multiplier", ExtrusionMultiplier.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fan_always_on", FanAlwaysOn.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fan_below_layer_time", FanBelowLayerTime.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "filament_colour", FilamentColour.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "filament_diameter", FilamentDiameter.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_bed_temperature", FirstLayerBedTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_temperature", FirstLayerTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "max_fan_speed", MaxFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "min_fan_speed", MinFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "min_print_speed", MinPrintSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "slowdown_below_layer_time", SlowdownBelowLayerTime.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "temperature", Temperature.ToSlic3rSettings());

            return builder.ToString();
        }
    }
}
