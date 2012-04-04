using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This class is used for loading and managing the game fonts
    /// contained in the Resources folder in the same directory as the application.
    /// </summary>
    public sealed class FontManager
    {
        /// <summary>
        /// Enumeration of all the fonts used in The Sims 3 Create A World Tool
        /// </summary>
        public enum Fonts
        {
            /// <summary>
            /// HelveticaRounded LT Std Bd; The font used for most languages
            /// </summary>
            HelveticaRoundedBold,
            /// <summary>
            /// AR Heiti Medium B5; The font used for Taiwanese
            /// </summary>
            TChinese,
            /// <summary>
            /// AR YuanGB Bold; The font used for Chinese
            /// </summary>
            SChinese,
            /// <summary>
            /// The font used for Korean
            /// </summary>
            Korean,
            /// <summary>
            /// PSK SarabunL; The font used for Thai
            /// </summary>
            Thai,
            /// <summary>
            /// DFGothicP-W5; The font used for Japanese
            /// </summary>
            Japanese,
            /// <summary>
            /// Trebuchet EA; The font used for Russian, Polish, and other Slavic languages
            /// </summary>
            Trebuchet
        }

        private class Nested
        {
            public static readonly FontManager mInstance = new FontManager();

            static Nested()
            {
                mInstance.Init();
            }
        }

        private const string kLogCategory = "FontManager";
        private static bool mbInited;
        private Fonts mDefaultFontType;
        private Dictionary<Fonts, string> mFontDictionary;
        private PrivateFontCollection mFonts = new PrivateFontCollection();

        private FontManager()
        {
        }

        private void AddAllCustomFonts()
        {
            string uiCultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            List<string> fontFiles = new List<string>();
            if (uiCultureName.Contains("zh"))
            {
                if (uiCultureName.Contains("tw"))
                {
                    this.mDefaultFontType = Fonts.TChinese;
                }
                else
                {
                    this.mDefaultFontType = Fonts.SChinese;
                }
            }
            else if (uiCultureName.Contains("ja"))
            {
                this.mDefaultFontType = Fonts.Japanese;
            }
            else if (uiCultureName.Contains("ko"))
            {
                this.mDefaultFontType = Fonts.Korean;
            }
            else if (uiCultureName.Contains("th"))
            {
                this.mDefaultFontType = Fonts.Thai;
            }
            else if (uiCultureName.Contains("ru") || uiCultureName.Contains("pl") ||
                     uiCultureName.Contains("el") || uiCultureName.Contains("cs") ||
                     uiCultureName.Contains("hu"))
            {
                this.mDefaultFontType = Fonts.Trebuchet;
            }
            else
            {
                this.mDefaultFontType = Fonts.HelveticaRoundedBold;
            }
            fontFiles.Add(@"Resources\HelveticaRoundedLTStd-Bd.ttf");
            fontFiles.Add(@"Resources\bhei01m.ttf");
            fontFiles.Add(@"Resources\ggtr00b.TTF");
            fontFiles.Add(@"Resources\PSK SarabunSim3.ttf");
            fontFiles.Add(@"Resources\DF-KaKouGothic-W5.ttc");
            fontFiles.Add(@"Resources\TrebuchetEAbold.ttf");
            try
            {
                if (fontFiles.Count > 0)
                {
                    foreach (string fontFile in fontFiles)
                    {
                        FileInfo fontFileInfo = new FileInfo(Path.Combine(Application.StartupPath, fontFile));
                        if (fontFileInfo.Exists)
                        {
                            this.mFonts.AddFontFile(fontFileInfo.FullName);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Sims3.Log.gError(kLogCategory, exception.Message);
            }
        }

        private void AddCustomFonts()
        {
            string uiCultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            List<string> fontFiles = new List<string>();
            if (uiCultureName.Contains("zh"))
            {
                if (uiCultureName.Contains("tw"))
                {
                    fontFiles.Add(@"Resources\bhei01m.ttf");
                    this.mDefaultFontType = Fonts.TChinese;
                }
                else
                {
                    fontFiles.Add(@"Resources\ggtr00b.TTF");
                    this.mDefaultFontType = Fonts.SChinese;
                }
            }
            else if (uiCultureName.Contains("ja"))
            {
                fontFiles.Add(@"Resources\DF-KaKouGothic-W5.ttc");
                this.mDefaultFontType = Fonts.Japanese;
            }
            else if (uiCultureName.Contains("ko"))
            {
                this.mDefaultFontType = Fonts.Korean;
            }
            else if (uiCultureName.Contains("th"))
            {
                fontFiles.Add(@"Resources\PSK SarabunSim3.ttf");
                this.mDefaultFontType = Fonts.Thai;
            }
            else if (uiCultureName.Contains("ru") || uiCultureName.Contains("pl") || 
                     uiCultureName.Contains("el") || uiCultureName.Contains("cs") || 
                     uiCultureName.Contains("hu"))
            {
                fontFiles.Add(@"Resources\TrebuchetEAbold.ttf");
                this.mDefaultFontType = Fonts.Trebuchet;
            }
            else
            {
                fontFiles.Add(@"Resources\HelveticaRoundedLTStd-Bd.ttf");
                this.mDefaultFontType = Fonts.HelveticaRoundedBold;
            }
            try
            {
                if (fontFiles.Count > 0)
                {
                    foreach (string fontFile in fontFiles)
                    {
                        FileInfo fontFileInfo = new FileInfo(Path.Combine(Application.StartupPath, fontFile));
                        if (fontFileInfo.Exists)
                        {
                            this.mFonts.AddFontFile(fontFileInfo.FullName);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Sims3.Log.gError(kLogCategory, exception.Message);
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Drawing.FontFamily"/>
        /// for the given game font, which can be used to create a new
        /// <see cref="T:System.Drawing.Font"/> instance.
        /// </summary>
        /// <param name="font">The game font family to get.</param>
        /// <returns>The font family of the given game font.</returns>
        public FontFamily GetFont(Fonts font)
        {
            string str;
            if (this.FontDictionary.TryGetValue(font, out str))
            {
                FontFamily[] families = this.mFonts.Families;
                if (families.Length > 0)
                {
                    System.Globalization.CultureInfo currentUICulture =
                            System.Threading.Thread.CurrentThread.CurrentUICulture;
                    if (currentUICulture.Name.Contains("ja") || currentUICulture.Name.Contains("zh") ||
                        currentUICulture.Name.Contains("ko") || currentUICulture.Name.Contains("th"))
                    {
                        return families[0];
                    }
                }
                FontFamily family;
                for (int i = 0; i < families.Length; i++)
                {
                    family = families[i];
                    if (family.Name == str)
                    {
                        return family;
                    }
                }
            }
            return FontFamily.GenericSansSerif;
        }

        /// <summary>
        /// Loads all the game fonts from the Resources folder
        /// and sets the default game font for the current UI culture.
        /// </summary>
        public void Init()
        {
            if (!mbInited)
            {
                mbInited = true;
                //this.AddCustomFonts();
                this.AddAllCustomFonts();
            }
        }

        /// <summary>
        /// Sets the font of the control and all of the controls it contains
        /// to the default game font for the current UI culture, 
        /// while preserving their font sizes and styles.
        /// </summary>
        /// <param name="control">The control that will have its font changed.</param>
        public void SetAmbientFont(Control control)
        {
            SetAmbientFont(control, this.mDefaultFontType);
        }

        /// <summary>
        /// Sets the font of the control and all of the controls it contains
        /// to the given game font, while preserving their font sizes and styles.
        /// </summary>
        /// <param name="control">The control that will have its font changed.</param>
        /// <param name="fontType">The game font that the given control will use.</param>
        public void SetAmbientFont(Control control, Fonts fontType)
        {
            if (control != null)
            {
                float fontSize = control.Font.SizeInPoints;
                FontStyle fontStyle = control.Font.Style;
                if (this.mDefaultFontType == Fonts.Trebuchet)
                {
                    fontStyle = FontStyle.Bold;
                }
                Font controlFont = new Font(this.GetFont(fontType), fontSize, fontStyle);
                control.Font = controlFont;
                foreach (Control child in control.Controls)
                {
                    this.SetAmbientFont(child, fontType);
                }
            }
        }

        private Dictionary<Fonts, string> FontDictionary
        {
            get
            {
                if (this.mFontDictionary == null)
                {
                    this.mFontDictionary = new Dictionary<Fonts, string>();
                    this.mFontDictionary.Add(Fonts.HelveticaRoundedBold, "HelveticaRounded LT Std Bd");
                    this.mFontDictionary.Add(Fonts.TChinese, "AR Heiti Medium B5");
                    this.mFontDictionary.Add(Fonts.SChinese, "AR YuanGB Bold");
                    this.mFontDictionary.Add(Fonts.Thai, "PSK SarabunL");
                    this.mFontDictionary.Add(Fonts.Japanese, "DFGothicP-W5");
                    this.mFontDictionary.Add(Fonts.Trebuchet, "Trebuchet EA");
                }
                return this.mFontDictionary;
            }
        }

        /// <summary>
        /// Returns an initialized font manager instance.
        /// </summary>
        public static FontManager Instance
        {
            get
            {
                return Nested.mInstance;
            }
        }
    }
}
