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

            builder.AppendFormat("{0} = {1}", "bed_temperature", BedTemperature);
            builder.AppendFormat("{0} = {1}", "bridge_fan_speed", BridgeFanSpeed);
            builder.AppendFormat("{0} = {1}", "cooling", Cooling);
            builder.AppendFormat("{0} = {1}", "disable_fan_first_layers", DisableFanFirstLayers);
            builder.AppendFormat("{0} = {1}", "extrusion_multiplier", ExtrusionMultiplier);
            builder.AppendFormat("{0} = {1}", "fan_always_on", FanAlwaysOn);
            builder.AppendFormat("{0} = {1}", "fan_below_layer_time", FanBelowLayerTime);
            builder.AppendFormat("{0} = {1}", "filament_colour", FilamentColour);
            builder.AppendFormat("{0} = {1}", "filament_diameter", FilamentDiameter);
            builder.AppendFormat("{0} = {1}", "first_layer_bed_temperature", FirstLayerBedTemperature);
            builder.AppendFormat("{0} = {1}", "first_layer_temperature", FirstLayerTemperature);
            builder.AppendFormat("{0} = {1}", "max_fan_speed", MaxFanSpeed);
            builder.AppendFormat("{0} = {1}", "min_fan_speed", MinFanSpeed);
            builder.AppendFormat("{0} = {1}", "min_print_speed", MinPrintSpeed);
            builder.AppendFormat("{0} = {1}", "slowdown_below_layer_time", SlowdownBelowLayerTime);
            builder.AppendFormat("{0} = {1}", "temperature", Temperature);

            return builder.ToString();
        }
    }
}
