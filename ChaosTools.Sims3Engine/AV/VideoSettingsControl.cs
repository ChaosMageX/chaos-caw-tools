using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sims3.SimIFace.VideoRecording;

namespace ChaosTools.Sims3Engine.AV
{
    /// <summary>
    /// This is a control for defining video recording settings.
    /// </summary>
    public partial class VideoSettingsControl : UserControl
    {
        // Video
        //private static readonly ulong kVideoSettingsTitle = 0x70b8e5da5fb68dac;

        // Video Sound Capture
        private static readonly ulong kVideoSoundCapture = 0x120ae17d4395e920;
        // Disabled
        //private static readonly ulong kAudioDisabledText = 0x7c41fa67b346d45f;
        // Do not capture sound with video
        //private static readonly ulong kAudioDisabledTooltip = 0x2f8be803c9356e37;
        // Enabled
        //private static readonly ulong kAudioEnabledText = 0x80f9b347008be9f2;
        // Capture sound with video
        //private static readonly ulong kAudioEnabledTooltip = 0x25bd2494a38bc8d4;

        // Maximum Video Recording Time
        private static readonly ulong kRecordingTimeText = 0xa020c5256b5c06f0;
        // Increase or decrease the maximum video recording time. 
        // The system will stop after capturing that amount of video.
        //private static readonly ulong kRecordingTimeTooltip = 0x549bc7d72ed3b3db;
        // Enter maximum time to allow for video recording here. 
        // The system will stop after capturing this amount of video.
        //private static readonly ulong kMaxRecordingTimeTooltip = 0x95753dd6c26407d3;
        // Seconds
        private static readonly ulong kRecordingTimeUnitText = 0xe9fa5e5bbf00a4d6;
        // min = 0, max = 9999, delta = 1, period = 50

        // Hide User Interface During Video Capture
        private static readonly ulong kHideUITitleText = 0x5110aaa9918de045;
        // Show
        //private static readonly ulong kShowUIText = 0x9546e13ad22746cc;
        //private static readonly ulong kShowUITooltip = 0x74114cb976e16c12;
        // Hide
        //private static readonly ulong kHideUIText = 0xbcb6b93a577cf337;
        //private static readonly ulong kHideUITooltip = 0x4f213ce7caecef99;

        // Restore Defaults
        //private static readonly ulong kRestoreDefaultsText = 0xd81060658460e199;
        //private static readonly ulong kRestoreDefaultsTooltip = 0x1d34463acaf72002;

        // Video Capture Size
        private static readonly ulong kFrameSizeText = 0x86ce3d255d346318;

        // Set the frame size for video captures. 
        // Note that larger frame sizes require more storage.
        //private static readonly ulong kFrameSizeTooltip = 0x3396b108165f76a7;

        private static readonly ulong[] kFrameSizeKeys = new ulong[]
        {
            0xf9f954f33139be1c, // Small
            0x67597e6f0b8d779a, // Medium
            0x953c52ff015105f4  // Large
        };

        private RadioButton[] mFrameSizeRads;

        // Video Capture Quality
        private static readonly ulong kQualityText = 0xda535600399460ce;

        // Set the quality level for video captures. 
        // Note that higher quality levels require more storage space.
        //private static readonly ulong kQualityTooltip = 0x5f82392cc03bde9f;

        private static readonly ulong[] kQualityKeys = new ulong[]
        {
            0xb378f73f87af28aa, // Ui/Caption/Options:Low_Female
            0x2e2ae37c4bc730c9, // Ui/Caption/Options:Medium_Female
            0x0292b5e47d31b4a6, // Ui/Caption/Options:High_Female
            0xbc59d25956367484, // Ui/Caption/Options:Uncompressed_Female
        };

        private RadioButton[] mQualityRads;

        /// <summary>
        /// Localizes the labels of the controls
        /// using the game engine's localization service.
        /// </summary>
        public void Localize()
        {
            ScriptCore.LocalizedStringService gStringTable 
                = ScriptCoreManager.LocalizedStringService;
            if (gStringTable != null)
            {
                string local = gStringTable.GetLocalizedString(kVideoSoundCapture);
                if (!string.IsNullOrEmpty(local))
                    soundCaptureCHK.Text = local;
                local = gStringTable.GetLocalizedString(kHideUITitleText);
                if (!string.IsNullOrEmpty(local))
                    hideUiCHK.Text = local;
                local = gStringTable.GetLocalizedString(kRecordingTimeText);
                if (!string.IsNullOrEmpty(local))
                    maxRecordTimeGRP.Text = local;
                local = gStringTable.GetLocalizedString(kRecordingTimeUnitText);
                if (!string.IsNullOrEmpty(local))
                    secondsLBL.Text = local;
                local = gStringTable.GetLocalizedString(kFrameSizeText);
                if (!string.IsNullOrEmpty(local))
                    frameSizeGRP.Text = local;
                for (int i = 0; i < 3; i++)
                {
                    local = gStringTable.GetLocalizedString(kFrameSizeKeys[i]);
                    if (!string.IsNullOrEmpty(local))
                        this.mFrameSizeRads[i].Text = local;
                }
                local = gStringTable.GetLocalizedString(kQualityText);
                if (!string.IsNullOrEmpty(local))
                    qualityGRP.Text = local;
                for (int j = 0; j < 4; j++)
                {
                    local = gStringTable.GetLocalizedString(kQualityKeys[j]);
                    if (!string.IsNullOrEmpty(local))
                        this.mQualityRads[j].Text = local;
                }
            }
        }

        private Settings mRecordingSettings;

        /// <summary>
        /// The video recording settings defined
        /// by the current control.
        /// </summary>
        public Settings RecordingSettings
        {
            get { return this.mRecordingSettings; }
            set { this.mRecordingSettings = value; this.SetRecordingSettings(value); }
        }

        /// <summary>
        /// Creates a new VideoSettingsControl instance
        /// with the default video recording settings.
        /// </summary>
        public VideoSettingsControl()
        {
            InitializeComponent();
            this.mFrameSizeRads = new RadioButton[]
            {
                this.frameSizeSmallRad, this.frameSizeMediumRad, this.frameSizeLargeRad
            };
            this.mQualityRads = new RadioButton[]
            {
                this.qualityLowRad, this.qualityMediumRad, this.qualityHighRad, this.qualityMaxRad
            };
            this.mRecordingSettings = new Settings();
            this.mRecordingSettings.AudioEnabled = false;
            this.mRecordingSettings.ContainerFormat = ContainerFormat.Avi;
            this.mRecordingSettings.Content = Content.All;
            this.mRecordingSettings.FrameSize = FrameSize.Medium;
            this.mRecordingSettings.Quality = Quality.Medium;
            this.mRecordingSettings.RecordToDatabase = false;
            this.mRecordingSettings.TimeLimitSeconds = 1;
            this.mRecordingSettings.VirtualTimingEnabled
                = this.mRecordingSettings.Quality == Quality.Max;
        }

        /// <summary>
        /// Creates a new VideoSettingsControl instance
        /// with the specified video recording settings.
        /// </summary>
        /// <param name="settings">The video recording settings
        /// used to initialize the control.</param>
        public VideoSettingsControl(Settings settings)
            : this()
        {
            this.mRecordingSettings = settings;
            this.SetRecordingSettings(settings);
        }

        private void SetRecordingSettings(Settings settings)
        {
            soundCaptureCHK.Checked = settings.AudioEnabled;
            hideUiCHK.Checked = (settings.Content == Content.MainSceneOnly);
            maxRecordTimeNUM.Value = Sims3.SimIFace.MathUtils.Clamp(settings.TimeLimitSeconds, 0, 9999);
            switch (settings.ContainerFormat)
            {
                case ContainerFormat.Avi:
                    formatAVIrad.Checked = true;
                    break;
                case ContainerFormat.Flv:
                    formatFLVrad.Checked = true;
                    break;
            }
            switch (settings.FrameSize)
            {
                case FrameSize.Small:
                    frameSizeSmallRad.Checked = true;
                    break;
                case FrameSize.Medium:
                    frameSizeMediumRad.Checked = true;
                    break;
                case FrameSize.Large:
                    frameSizeLargeRad.Checked = true;
                    break;
            }
            switch (settings.Quality)
            {
                case Quality.Low:
                    qualityLowRad.Checked = true;
                    break;
                case Quality.Medium:
                    qualityMediumRad.Checked = true;
                    break;
                case Quality.High:
                    qualityHighRad.Checked = true;
                    break;
                case Quality.Max:
                    qualityMaxRad.Checked = true;
                    break;
            }
            this.mRecordingSettings.RecordToDatabase = false;
            this.mRecordingSettings.VirtualTimingEnabled = (settings.Quality == Quality.Max);
        }

        private void format_CheckedChanged(object sender, EventArgs e)
        {
            if (formatAVIrad.Checked)
                this.mRecordingSettings.ContainerFormat = ContainerFormat.Avi;
            if (formatFLVrad.Checked)
                this.mRecordingSettings.ContainerFormat = ContainerFormat.Flv;
        }

        private void quality_CheckedChanged(object sender, EventArgs e)
        {
            if (qualityLowRad.Checked)
                this.mRecordingSettings.Quality = Quality.Low;
            if (qualityMediumRad.Checked)
                this.mRecordingSettings.Quality = Quality.Medium;
            if (qualityHighRad.Checked)
                this.mRecordingSettings.Quality = Quality.High;
            if (qualityMaxRad.Checked)
                this.mRecordingSettings.Quality = Quality.Max;
        }

        private void frameSize_CheckedChanged(object sender, EventArgs e)
        {
            if (frameSizeSmallRad.Checked)
                this.mRecordingSettings.FrameSize = FrameSize.Small;
            if (frameSizeMediumRad.Checked)
                this.mRecordingSettings.FrameSize = FrameSize.Medium;
            if (frameSizeLargeRad.Checked)
                this.mRecordingSettings.FrameSize = FrameSize.Large;
        }

        private void hideUi_CheckedChanged(object sender, EventArgs e)
        {
            if (hideUiCHK.Checked)
                this.mRecordingSettings.Content = Content.MainSceneOnly;
            else
                this.mRecordingSettings.Content = Content.All;
        }

        private void soundCapture_CheckedChanged(object sender, EventArgs e)
        {
            this.mRecordingSettings.AudioEnabled = soundCaptureCHK.Checked;
        }

        private void maxRecordTime_ValueChanged(object sender, EventArgs e)
        {
            this.mRecordingSettings.TimeLimitSeconds = (int)maxRecordTimeNUM.Value;
        }
    }
}
