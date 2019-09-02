using System.Windows.Media;
using static System.Console;


namespace InstalledFontListSample
{
    using System.Windows.Markup;

    class Program
    {
        static void Main(string[] args)
        {
            DisplayInstalledFontSampleWPF();
        }

        /// <summary>
        /// Displays installed font list in the console window.
        /// </summary>
        static void DisplayInstalledFontSampleWPF()
        {
            XmlLanguage en_us = XmlLanguage.GetLanguage("en-us");
            XmlLanguage localLang = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.Name);

            foreach (FontFamily fontFamily in System.Windows.Media.Fonts.SystemFontFamilies)
            {
                fontFamily.FamilyNames.TryGetValue(localLang, out var localFamilyName);
                WriteLine($"{fontFamily.FamilyNames[en_us]} {localFamilyName ?? ""}");

                FamilyTypefaceCollection typefaces = fontFamily.FamilyTypefaces;
                foreach (var face in typefaces)
                {
                    WriteLine($"\t{face.AdjustedFaceNames[en_us]}");

                    //日本語のFaceNameを含むフォントはおそらくない？ので以下はいらないだろう
                    //if (face.AdjustedFaceNames.TryGetValue(localLang, out var localFaceName))
                    //{
                    //    WriteLine($"\t\"{face.AdjustedFaceNames[en_us]}\" \"{localFaceName}\"");
                    //    continue;
                    //}
                    //WriteLine($"\t{face.AdjustedFaceNames[en_us]}");
                }
            }
        }
    }
}
