using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ChaosTools.Sims3Engine;
using Sims3.CSHost;

namespace ChaosTools.EffectPlayer
{
    public partial class EffectForm : RenderForm
    {
        private ScriptCore.UIManager mUIManager = null;
        private ScriptCore.LocalizedStringService mLocalizer = null;

        public EffectForm()
        {
            InitializeComponent();
            this.RenderingPanel = this.renderPanelEx1;
#if !DEBUG
            this.openPackageToolStripMenuItem.Enabled = false;
#endif
        }

        private void OnEffectFinished(object sender, EventArgs e)
        {
            Sims3.SimIFace.VisualEffect.EffectFinishedEventArgs args 
                = e as Sims3.SimIFace.VisualEffect.EffectFinishedEventArgs;
            if (this.mVisualEffect != null && args != null && args.ObjectId == this.mVisualEffect.ObjectId)
            {
                this.DestroyEffect();
            }
        }

        private const char kNumberSeparator = ';';
        private static Sims3.Math.Matrix44 sDrawTransform = Sims3.Math.Matrix44.gIdentity;
        private const uint kGreenColor = 0xff00ff00;
        private const uint kYellowColor = 0xffffff00;
        private const uint kRedColor = 0xffff0000;

        private uint mDrawColor = kYellowColor;
        private bool mDebugCircleVisible = true;
        private bool mGeneralStatsVisible = false;
        private bool mEffectsStatsVisible = false;
        private bool mGameSpeedVisible = false;

        private Sims3.Math.Vector3 mCameraEye = new Sims3.Math.Vector3(2.5f, 2.5f, 2.5f);
        private Sims3.Math.Vector3 mCameraUp = new Sims3.Math.Vector3(0f, 1f, 0f);
        private Sims3.Math.Vector3 mCameraTarget = new Sims3.Math.Vector3(0f, 0f, 0f);

        private float mEffectStatsX = 2f;
        private float mEffectStatsY = 2f;
        private float mEffectStatsIncr = 12f;
        private float mGeneralStatsX = 2f;
        private float mGeneralStatsY = 2f;

        protected override bool InitExtra()
        {
            this.mUIManager = ScriptCoreManager.UIManager;
            this.mLocalizer = ScriptCoreManager.LocalizedStringService;
            ScriptCore.VisualEffect.OnEffectFinishedEventHandler += new EventHandler(OnEffectFinished);
            this.Scene.MainCamera.LookAt(ref this.mCameraEye, ref this.mCameraUp, ref this.mCameraTarget);
            return true;
        }

        protected override void DrawExtra(EngineTime engineTime)
        {
            if (this.mDebugCircleVisible)
                GraphicsUtil.DrawCircle(ref sDrawTransform, 1f, this.mDrawColor, false);
            if (this.mEffectsStatsVisible)
                EffectsManager.DrawStats(this.mEffectStatsX, this.mEffectStatsY, this.mEffectStatsIncr);
            if (this.mGeneralStatsVisible)
                StatsManager.DrawStats(this.mGeneralStatsX, this.mGeneralStatsY);
            if (this.mGameSpeedVisible)
            {
                float textY = this.renderPanelEx1.Height - 14f;
                App.DrawText(string.Concat("Game Speed: ",
                    this.PauseGameTime ? "Paused" : this.GameTimeMultiplier.ToString()),
                    2f, textY);
            }
        }

        public override void ShutdownExtra(bool immediately)
        {
            this.DestroyEffect();
        }

        private string mEffectName = "zzz";
        private ScriptCore.VisualEffect mVisualEffect;
        private Sims3.SimIFace.VisualEffect.TransitionType mEffectTransition 
            = Sims3.SimIFace.VisualEffect.TransitionType.SoftTransition;

        private void CreateEffect()
        {
            this.mEffectName = this.effectNameTxt.Text;
            if (this.mVisualEffect == null && !string.IsNullOrEmpty(this.mEffectName))
            {
                this.mVisualEffect = new ScriptCore.VisualEffect(this.mEffectName);
                if (this.mVisualEffect.ObjectId == Sims3.SimIFace.ObjectGuid.InvalidObjectGuid)
                {
                    //this.mVisualEffect.Dispose();
                    this.mVisualEffect = null;
                    this.mDrawColor = kRedColor;
                }
                else
                {
                    this.Scene.AddObject(this.mVisualEffect.ObjectId.Value);
                    this.mVisualEffect.Start(this.mEffectTransition, true);
                    this.mDrawColor = kGreenColor;
                    this.startEffectBtn.Enabled = false;
                    this.stopEffectBtn.Enabled = true;
                }
            }
        }

        private void DestroyEffect()
        {
            if (this.mVisualEffect != null)
            {
                this.mVisualEffect.Dispose();
                this.mVisualEffect = null;
                this.mDrawColor = kYellowColor;
                this.startEffectBtn.Enabled = true;
                this.stopEffectBtn.Enabled = false;
            }
        }

        #region File Menu Handlers
        private const string sPackageFilter = "Sims 3 Package (*.package)|*.package";

        private uint mCurrentPackage = 0;
        //private ulong mScenePackage = 0;
        private IntPtr[] mLoadedResources = null;
        //private ContentManagerHelper.ModifyResult mInstallResult;

        private void ForceLoadResources()
        {
            if (this.mCurrentPackage != 0)
            {
                ResourceKey[] resources = ResourceMgr.GetKeyList(this.mCurrentPackage, 0, 0);
                int i, length = resources.Length;
                this.mLoadedResources = new IntPtr[length];
                for (i = 0; i < length; i++)
                {
                    this.mLoadedResources[i] = ResourceMgr.LoadResource(resources[i]);
                }
            }
        }

        private void openPackage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = sPackageFilter;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fullPath = Path.GetFullPath(dialog.FileName);
                    string name = Path.GetFileNameWithoutExtension(fullPath);
                    this.mCurrentPackage = ResourceMgr.OpenPackage(fullPath, name, FileAccess.Read);
                    //this.mScenePackage = this.Scene.AddPackageToScene(fullPath);
                    //Various attempts to get the Game Engine to actually load the opened resources
                    //this.ForceLoadResources();
                    //SharedInitialization.RegisterResourceFactories();
                }
            }
            if (this.mCurrentPackage != 0)
            {
                this.openPackageToolStripMenuItem.Enabled = false;
                this.closePackageToolStripMenuItem.Enabled = true;
            }
        }

        private void closePackage_Click(object sender, EventArgs e)
        {
            if (this.mCurrentPackage != 0)
            {
                this.DestroyEffect();
                if (ResourceMgr.ClosePackage(this.mCurrentPackage))
                {
                    this.mCurrentPackage = 0;
                    //this.mScenePackage = 0;
                    this.mLoadedResources = null;
                    this.openPackageToolStripMenuItem.Enabled = true;
                    this.closePackageToolStripMenuItem.Enabled = false;
                }
            }
        }
        #endregion

        #region Debug Menu Handlers
        private void showLoadedSWBs_Click(object sender, EventArgs e)
        {
            ResourceKey[] swbs = ResourceMgr.GetKeyList(0, 0xea5118b0, 0);
            StringBuilder builder = new StringBuilder();
            int i, length = swbs.Length;
            ContentType source;
            for (i = 0; i < length; i++)
            {
                source = ContentManager.GetContentSource(swbs[i]);
                builder.AppendLine(string.Concat(swbs[i].ToString(), " | ", source.ToString()));
                builder.AppendLine(string.Concat("DB: ", ResourceMgr.GetDBLocationForKey(swbs[i])));
                //This just returns a hex string of the resource's instance ID
                //builder.AppendLine(string.Concat("File: ", ResourceMgr.GetFilenameForKey(swbs[i])));
                builder.AppendLine();
            }
            MessageBox.Show(builder.ToString(), "Loaded SWBs");
        }

        private void showLoadedS3SAs_Click(object sender, EventArgs e)
        {
            ResourceKey[] s3sas = ResourceMgr.GetKeyList(0, 0x73faa07, 0);
            StringBuilder builder = new StringBuilder();
            int i, length = s3sas.Length;
            ContentType source;
            for (i = 0; i < length; i++)
            {
                source = ContentManager.GetContentSource(s3sas[i]);
                builder.AppendLine(string.Concat(s3sas[i].ToString()," | ",source.ToString()));
                builder.AppendLine(string.Concat("DB: ", ResourceMgr.GetDBLocationForKey(s3sas[i])));
                //This just returns a hex string of the resource's instance ID
                //builder.AppendLine(string.Concat("File: ", ResourceMgr.GetFilenameForKey(s3sas[i])));
                builder.AppendLine();
            }
            MessageBox.Show(builder.ToString(), "Loaded S3SAs");
        }

        private void showAppData_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Concat("ForwardExecutable: ", App.GetForwardExecutable()));
            builder.AppendLine(string.Concat("InstalledGameDir: ", App.GetInstalledGameDir()));
            builder.AppendLine(string.Concat("InstalledGameUserDataDir: ", App.GetInstalledGameUserDataDir()));
            builder.AppendLine(string.Concat("VertexShaderSupport: ", App.GetVertexShaderSupport().ToString()));
            builder.AppendLine(string.Concat("WorldBuilderCompatibilityVersion: ", App.GetWorldBuilderCompatibilityVersion().ToString()));
            builder.AppendLine(string.Concat("AssetsBuiltPath: ", App.AssetsBuiltPath));
            builder.AppendLine(string.Concat("AssetsJazzSourcePath: ", App.AssetsJazzSourcePath));
            builder.AppendLine(string.Concat("AssetsLocalWorkPath: ", App.AssetsLocalWorkPath));
            builder.AppendLine(string.Concat("AssetsSourcePath: ", App.AssetsSourcePath));
            builder.AppendLine(string.Concat("AssetsWorldFilesPath: ", App.AssetsWorldFilesPath));
            builder.AppendLine(string.Concat("BaseGameAssetsPath: ", App.BaseGameAssetsPath));
            builder.AppendLine(string.Concat("BaseGameExePathName: ", App.BaseGameExePathName));
            builder.AppendLine(string.Concat("BuildConfig: ", App.BuildConfig));
            builder.AppendLine(string.Concat("BuildHostName: ", App.BuildHostName));
            builder.AppendLine(string.Concat("BuildTimeStamp: ", App.BuildTimeStamp));
            builder.AppendLine(string.Concat("BuildUser: ", App.BuildUser));
            builder.AppendLine(string.Concat("BuildVersion: ", App.BuildVersion));
            builder.AppendLine(string.Concat("ExePath: ", App.ExePath));
            builder.AppendLine(string.Concat("GameplayScriptsPath: ", App.GameplayScriptsPath));
            builder.AppendLine(string.Concat("GameWasInstalled: ", App.GameWasInstalled.ToString()));
            builder.AppendLine(string.Concat("HighestGameExePathName: ", App.HighestGameExePathName));
            builder.AppendLine(string.Concat("LogPath: ", App.LogPath));
            builder.AppendLine(string.Concat("OverlayDirectoryPath: ", App.OverlayDirectoryPath));
            builder.AppendLine(string.Concat("StoreJazzPackagePath: ", App.StoreJazzPackagePath));
            builder.AppendLine(string.Concat("StoreScriptsPackagePath: ", App.StoreScriptsPackagePath));
            MessageBox.Show(builder.ToString(), "App Data");
        }

        private void showLoadTimes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("App Init: {0} seconds\nScene Init: {1} seconds",
                this.AppInitTime, this.SceneInitTime), "Load Times");
        }

        private void getEffectName_Click(object sender, EventArgs e)
        {
            this.effectNameTxt.Text = this.mEffectName;
        }

        private const string sTextFileFilter = "Text File (*.txt)|*.txt";

        private void printEffectNames_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Print Effect Names to Text File";
                dialog.Filter = sTextFileFilter;
                dialog.AddExtension = true;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        System.Collections.ArrayList effectNames = EffectComponent.GetEffectNameList();
                        int i, length = effectNames.Count;
                        writer.WriteLine(length);
                        for (i = 0; i < length; i++)
                        {
                            writer.WriteLine(effectNames[i]);
                        }
                    }
                }
            }
        }

        private void printInstalledPackages_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Print Installed Packages to Text File";
                dialog.Filter = sTextFileFilter;
                dialog.AddExtension = true;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        InstalledPackageData[] installed = ContentManager.GetInstalledPackages();
                        int i, ilength = installed.Length;
                        for (i = 0; i < ilength; i++)
                        {
                            writer.WriteLine(string.Concat(installed[i].PackageId.ToString(), " : ",
                                ContentManager.GetPackageName(installed[i].PackageId)));
                        }
                    }
                }
            }
        }

        private void printLoadingTexts_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Print Localized Game Loading Messages to Text File";
                dialog.Filter = sTextFileFilter;
                dialog.AddExtension = true;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.LoadLoadingTexts();
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        string[] texts;
                        foreach (KeyValuePair<Sims3.SimIFace.ProductVersion, string[]> loadingText in this.mLoadingTexts)
                        {
                            writer.WriteLine(string.Concat(loadingText.Key.ToString(), ":"));
                            texts = loadingText.Value;
                            for (int i = 0; i < texts.Length; i++)
                            {
                                writer.WriteLine(texts[i]);
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
        }

        private void printGameTips_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Print Localized Game Tip Messages to Text File";
                dialog.Filter = sTextFileFilter;
                dialog.AddExtension = true;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.LoadGameTips();
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        string[] tips;
                        foreach (KeyValuePair<Sims3.SimIFace.ProductVersion, string[]> gameTip in this.mGameTips)
                        {
                            writer.WriteLine(string.Concat(gameTip.Key.ToString(), ":"));
                            tips = gameTip.Value;
                            for (int i = 0; i < tips.Length; i++)
                            {
                                writer.WriteLine(tips[i]);
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
        }

        // TODO: App.DumpMemorySummary function is possibly evil.
        // It never creates the given file and it might be causing App.Update to be corrupted
        private void dumpMemorySummary_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = sTextFileFilter;
                dialog.AddExtension = true;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fullPath = Path.GetFullPath(dialog.FileName);
                    App.DumpMemorySummary(fullPath);
                    App.Flush();
                }
            }/**/
            /*using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);
                    App.DumpMemorySummary(fullPath);
                    App.Flush();
                }
            }/**/
        }

        private void unhash32_Click(object sender, EventArgs e)
        {
            uint hash;
            if (uint.TryParse(this.effectNameTxt.Text,
                System.Globalization.NumberStyles.HexNumber,
                System.Globalization.CultureInfo.CurrentCulture, out hash))
            {
                string result = HashUtils.Unhash(hash);
                MessageBox.Show(result == null ? "" : result, "Unhash 32 Result");
            }
        }

        private void unhash64_Click(object sender, EventArgs e)
        {
            ulong hash;
            if (ulong.TryParse(this.effectNameTxt.Text,
                System.Globalization.NumberStyles.HexNumber,
                System.Globalization.CultureInfo.CurrentCulture, out hash))
            {
                string result = HashUtils.Unhash(hash);
                MessageBox.Show(result == null ? "" : result, "Unhash 64 Result");
            }
        }
        #endregion

        #region Rendering Menu Handlers
        private void showEffectStats_Click(object sender, EventArgs e)
        {
            this.mEffectsStatsVisible = !this.mEffectsStatsVisible;
            this.showEffectStatsToolStripMenuItem.Text
                = this.mEffectsStatsVisible ? "Hide Effect Stats" : "Show Effect Stats";
        }

        private void showGeneralStats_Click(object sender, EventArgs e)
        {
            this.mGeneralStatsVisible = !this.mGeneralStatsVisible;
            this.showGeneralStatsToolStripMenuItem.Text
                = this.mGeneralStatsVisible ? "Hide General Stats" : "Show General Stats";
        }

        private void showCircle_Click(object sender, EventArgs e)
        {
            this.mDebugCircleVisible = !this.mDebugCircleVisible;
            this.showCircleToolStripMenuItem.Text
                = this.mDebugCircleVisible ? "Hide Circle" : "Show Circle";
        }

        private void showGameSpeed_Click(object sender, EventArgs e)
        {
            this.mGameSpeedVisible = !this.mGameSpeedVisible;
            this.showGameSpeedToolStripMenuItem.Text
                = this.mGameSpeedVisible ? "Hide Game Speed" : "Show Game Speed";
        }

        private void invalidateRenderPanel_Click(object sender, EventArgs e)
        {
            this.renderPanelEx1.Invalidate();
        }

        private void showRenderSettings_Click(object sender, EventArgs e)
        {
            using (RenderSettingsDialog dialog = new RenderSettingsDialog(
                this.mEffectStatsX, this.mEffectStatsY, this.mEffectStatsIncr,
                this.mGeneralStatsX, this.mGeneralStatsY,
                this.mCameraEye, this.mCameraUp, this.mCameraTarget))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    dialog.GetEffectStatsLocation(out this.mEffectStatsX,
                        out this.mEffectStatsY, out this.mEffectStatsIncr);
                    dialog.GetGeneralStatsLocation(out this.mGeneralStatsX,
                        out this.mGeneralStatsY);
                    this.mCameraEye = dialog.CameraEyePosition;
                    this.mCameraUp = dialog.CameraUpDirection;
                    this.mCameraTarget = dialog.CameraTargetPosition;
                    this.Scene.MainCamera.LookAt(ref this.mCameraEye, ref this.mCameraUp, ref this.mCameraTarget);
                }
            }
        }
        #endregion

        #region Miscellaneous
        private const ulong sTreeOfProsperitySWB = 0xC377DD74D9F63C3B;

        private ResourceData[] FindTreeOfProsperity()
        {
            InstalledPackageData[] installed = ContentManager.GetInstalledPackages();
            ResourceKey[] resources;
            List<ResourceData> found = new List<ResourceData>();
            int i, r, rlength, ilength = installed.Length;
            for (i = 0; i < ilength; i++)
            {
                resources = ContentManager.GetSourceKeyList(installed[i].PackageId);
                rlength = resources.Length;
                for (r = 0; r < rlength; r++)
                {
                    if (resources[r].mInstance == sTreeOfProsperitySWB)
                    {
                        found.Add(new ResourceData(installed[i].PackageId, resources[r]));
                    }
                }
            }
            return found.ToArray();
        }

        private void TestUI()
        {
            Sims3.SimIFace.ResourceKey key = Sims3.SimIFace.ResourceKey.CreateUILayoutKey("SimpleMessageDialogPretty", 0);
            //Sims3.CSHost.ResourceKey[] keys = Sims3.CSHost.ResourceMgr.GetKeyList(0, key.TypeId, 0);
            uint mainWindow = this.mUIManager.GetMainWindow();
            uint layout = this.mUIManager.LoadLayoutAndAddToWindow(key, mainWindow);
            uint dialog = this.mUIManager.GetWindowByExportID(layout, 2);
            // Set Visible
            this.SetFlagProperty(dialog, 0xeec1b000, 1, true);
        }

        private bool GetFlagProperty(uint handle, uint flagsetPropID, uint flagMask)
        {
            return ((this.mUIManager.GetUInt32Property(handle, flagsetPropID) & flagMask) != 0);
        }

        private void SetFlagProperty(uint handle, uint flagsetPropID, uint flagMask, bool value)
        {
            uint flag = this.mUIManager.GetUInt32Property(handle, flagsetPropID);
            uint result = value ? (flag | flagMask) : (flag & ~flagMask);
            this.mUIManager.SetUInt32Property(handle, flagsetPropID, result);
        }
        #endregion

        #region Localization
        private const uint kXmlTID = 0x0333406c;

        private string Localize(string key)
        {
            if (this.mLocalizer == null)
                return key;
            else
            {
                string result = this.mLocalizer.GetLocalizedString(key);
                if (string.IsNullOrEmpty(result))
                    return key;
                return result;
            }
        }

        private string[] LoadLoadingTexts(XmlDocument doc)
        {
            if (doc != null)
            {
                List<string> results = new List<string>();
                string nameKey;
                //string countAttr;
                foreach (XmlElement loadingText in doc.GetElementsByTagName("LoadingText"))
                {
                    //countAttr = loadingText.Attributes.GetNamedItem("count").Value;
                    foreach (XmlElement text in loadingText.GetElementsByTagName("Text"))
                    {
                        nameKey = text.Attributes.GetNamedItem("localizedName").Value;
                        results.Add(Localize(nameKey));
                    }
                }
                return results.ToArray();
            }
            return null;
        }

        private Dictionary<Sims3.SimIFace.ProductVersion, string[]> mLoadingTexts;

        private void LoadLoadingTexts()
        {
            if (this.mLoadingTexts == null)
            {
                Sims3.SimIFace.ProductVersion[] products
                    = Enum.GetValues(typeof(Sims3.SimIFace.ProductVersion))
                    as Sims3.SimIFace.ProductVersion[];
                XmlDocument doc;
                string xmlName, xmlText;
                string[] loadingTexts;
                if (products != null)
                {
                    this.mLoadingTexts = new Dictionary<Sims3.SimIFace.ProductVersion, string[]>(products.Length);
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i] == Sims3.SimIFace.ProductVersion.BaseGame)
                            xmlName = "LoadingText";
                        else
                            xmlName = string.Concat("LoadingText", products[i].ToString());
                        xmlText = ResourceMgr.LoadXMLStr(new ResourceKey(kXmlTID, 0,
                            Sims3.SimIFace.ResourceUtils.HashString64(xmlName)));
                        if (!string.IsNullOrEmpty(xmlText))
                        {
                            doc = new XmlDocument();
                            doc.LoadXml(xmlText);
                            loadingTexts = LoadLoadingTexts(doc);
                            if (loadingTexts != null && loadingTexts.Length > 0)
                            {
                                this.mLoadingTexts.Add(products[i], loadingTexts);
                            }
                        }
                    }
                }
            }
        }

        private string[] LoadGameTips(XmlDocument doc)
        {
            if (doc != null)
            {
                List<string> results = new List<string>();
                string nameKey;
                //string countAttr;
                foreach (XmlElement gameTips in doc.GetElementsByTagName("GameTips"))
                {
                    //countAttr = loadingText.Attributes.GetNamedItem("count").Value;
                    foreach (XmlElement tip in gameTips.GetElementsByTagName("Tip"))
                    {
                        nameKey = tip.Attributes.GetNamedItem("localizedName").Value;
                        results.Add(Localize(nameKey));
                    }
                }
                return results.ToArray();
            }
            return null;
        }

        private Dictionary<Sims3.SimIFace.ProductVersion, string[]> mGameTips;

        private void LoadGameTips()
        {
            if (this.mGameTips == null)
            {
                Sims3.SimIFace.ProductVersion[] products
                    = Enum.GetValues(typeof(Sims3.SimIFace.ProductVersion))
                    as Sims3.SimIFace.ProductVersion[];
                XmlDocument doc;
                string xmlName, xmlText;
                string[] gameTips;
                if (products != null)
                {
                    this.mGameTips = new Dictionary<Sims3.SimIFace.ProductVersion, string[]>(products.Length + 3);
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i] == Sims3.SimIFace.ProductVersion.BaseGame)
                            xmlName = "GameTips";
                        else
                            xmlName = string.Concat("GameTips", products[i].ToString());
                        xmlText = ResourceMgr.LoadXMLStr(new ResourceKey(kXmlTID, 0,
                            Sims3.SimIFace.ResourceUtils.HashString64(xmlName)));
                        if (!string.IsNullOrEmpty(xmlText))
                        {
                            doc = new XmlDocument();
                            doc.LoadXml(xmlText);
                            gameTips = LoadGameTips(doc);
                            if (gameTips != null && gameTips.Length > 0)
                            {
                                this.mGameTips.Add(products[i], gameTips);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Control Handlers
        private void startEffect_Click(object sender, EventArgs e)
        {
            this.CreateEffect();
        }

        private void stopEffect_Click(object sender, EventArgs e)
        {
            if (this.mVisualEffect != null)
            {
                this.mVisualEffect.Stop(this.mEffectTransition);
            }
            this.DestroyEffect();
        }

        private void effectName_TextChanged(object sender, EventArgs e)
        {
            if (this.mDrawColor == kRedColor)
                this.mDrawColor = kYellowColor;
        }

        private void pause_Click(object sender, EventArgs e)
        {
            this.PauseGameTime = true;
            this.pauseBtn.Enabled = false;
            this.playBtn.Enabled = true;
        }

        private void play_Click(object sender, EventArgs e)
        {
            float speed;
            if (float.TryParse(this.speedMultiplierTxt.Text, out speed))
            {
                this.GameTimeMultiplier = speed;
            }
            this.PauseGameTime = false;
            this.pauseBtn.Enabled = true;
            this.playBtn.Enabled = false;
        }

        private void speedMultiplier_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (!float.TryParse(this.speedMultiplierTxt.Text, out value))
            {
                this.speedMultiplierTxt.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (value == 0)
                    this.speedMultiplierTxt.ForeColor = System.Drawing.Color.Red;
                else
                    this.speedMultiplierTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void setLifeScale_Click(object sender, EventArgs e)
        {
            if (this.mVisualEffect != null)
            {
                float lifeScale;
                if (float.TryParse(this.lifeScaleTXT.Text, out lifeScale))
                {
                    this.mVisualEffect.SetEffectLifeScale(lifeScale);
                }
            }
        }

        private void effectTransRAD_CheckedChanged(object sender, EventArgs e)
        {
            if (this.effectTransSoftRAD.Checked)
                this.mEffectTransition = Sims3.SimIFace.VisualEffect.TransitionType.SoftTransition;
            if (this.effectTransHardRAD.Checked)
                this.mEffectTransition = Sims3.SimIFace.VisualEffect.TransitionType.HardTransition;
        }
        #endregion
    }
}
