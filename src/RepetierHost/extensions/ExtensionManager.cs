namespace RepetierHost.extensions
{
    public static class ExtensionManager
    {
        public static string ToSlic3rSettings(this bool value)
        {
            return value ? "1" : "0";
        }

        public static string ToSlic3rSettings(this string value)
        {
            return value;
        }
    }
}