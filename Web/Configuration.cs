using MudBlazor;
using MudBlazor.Utilities;

namespace Web
{
    public static class Configuration
    {
        public const string HttpClientName = "dmo";

        public static string BackendUrl = "http://localhost:5107";

        public static MudTheme Theme = new()
        {
            Typography = new Typography
            {
                Default = new Default
                {
                    FontFamily = new[] { "Raleway", "sans-serif" }
                }
            },
            PaletteLight = new PaletteLight
            {
                //Primary = new MudColor("#1EFA2D"),
                Primary = new MudColor("#3A8AC5"),
                PrimaryContrastText = new MudColor("#000000"),
                Secondary = Colors.LightBlue.Darken3,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#3A8AC5"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.White,
                DrawerBackground = new MudColor("#3A8AC5")
            },
            PaletteDark = new PaletteDark
            {
                Primary = new MudColor("#3A8AC5"),
                Secondary = Colors.LightBlue.Darken3,
                AppbarBackground = Colors.LightBlue.Accent3,
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000"),
                DrawerBackground = new MudColor("#3A8AC5")
            }
        };
    }
}
