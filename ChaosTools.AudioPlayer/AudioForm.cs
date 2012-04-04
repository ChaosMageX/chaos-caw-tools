using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sims3.SimIFace;

namespace ChaosTools.AudioPlayer
{
    public partial class AudioForm : ChaosTools.Sims3Engine.RenderForm
    {
        public enum SoundProperty : uint
        {
            AddGroups = 0xf58ca0be,
            Age = 0x489c3762,
            Aggregate = 0x5a32a0ce,
            AtmosphericCurve = 0xbdc98ce5,
            AtmosphericHiPassCurve = 0x8adce22f,
            AttenuatedGain = 0x6325c989,
            Attenuation = 0x1e4db1eb,
            AttenuationCurve = 0x6e3d22e0,
            Codec = 0xba03d0cd,
            DacOutputSampleRate = 0x6a371e0,
            DefaultToMaster = 0x6b16ae3d,
            Delay = 0x15525baa,
            DistanceCurve = 0xEC361CD1,
            DopplerCurve = 0x9bfc37ac,
            Duration = 0xb1f42539,
            EffectiveGain = 0xc2d1f579,
            EmitterType = 0x6610c2bd,
            FadeIn = 0x98ac8996,
            FadeOut = 0xe8ab99b9,
            Feedback = 0xfc047eec,
            Gain = 0x25df0108,
            Groups = 0x7cb81a35,
            HardStop = 0x222b8006,
            HighPass = 0xa26a765f,
            IgnorePauseGain = 0xd1daef42,
            Is3d = 0x12d2a4d4,
            IsLooped = 0x6dd08218,
            IsVirtual = 0xba134192,
            LoopPlaylist = 0x3c10c7b9,
            LowPass = 0x647a7836,
            MaxDistance = 0x3593710,
            MaxGainChange = 0xc742ceb8,
            MinDistance = 0xf616b72,
            MinPerformanceLevel = 0xb2550953,
            MuteAll = 0x899eb157,
            NoteDuration = 0xcd928a9,
            NoteNumber = 0x66ef9aba,
            NoteVelocity = 0xe4dd1818,
            OutsideCurve = 0xD9B1D9DF,
            Pan = 0x4a77693a,
            PanDistance = 0x6eb7a717,
            PanLFE = 0xB73EE5C5,
            PanSize = 0xce78d695,
            PanTwist = 0xa4d2160b,
            Parent = 0x5f6317d5,
            Pause = 0xb85523e5,
            PerformanceLevel = 0x6df5822d,
            PickupIndex = 0xed1f36d5,
            Pitch = 0x71bc3009,
            PitchShiftModifier = 0x779a5ff4,
            Polyphony = 0xbaf7f4f9,
            PolyphonyMode = 0x7f28acc,
            PondEnabledCurve = 0x0774F9BC,
            PositionX = 0x50c5d67,
            PositionY = 0x50c5d66,
            PositionZ = 0x50c5d65,
            PreFade = 0x6257eb2a,
            PrimitiveHashes = 0xe39eb081,
            Primitives = 0x3da0a727,
            Priority = 0x393f7f7d,
            Probability = 0x8fc9308e,
            RandomPitch = 0x56e7c242,
            RemoveGroups = 0x14043549,
            RingModFreq = 0x703d682b,
            Rolloff = 0x2406a047,
            SampleLength = 0xd24d4aff,
            SamplePosition = 0x893f8476,
            Samples = 0x701ed91e,
            SeekTime = 0x14f9bdf6,
            Send = 0x2fe09c83,
            Skip = 0x310330cc,
            StartDelay = 0x29e8b9f8,
            StreamBufferReadSize = 0xb03a6504,
            StreamBufferSize = 0x3c2b4ea4,
            SurroundOn = 0xfe3c587c,
            Symbols = 0x4b2a3424,
            TimeInvariantPitch = 0x82beafe0,
            TimeOfDayCurve = 0x8AC7E06E,
            VoiceTemplate = 0x544E850B,
            WaterEnabledCurve = 0xCE0EB28E,
            WetLevel = 0x49eb68db,
            WetLevelCurve = 0x173c2710
        }

        public enum StopReason : uint
        {
            Completed,
            Aborted,
            Requested,
            RequestedInternal,
            Error
        }

        private class SoundPropNameComparer : IComparer<SoundProperty>
        {
            public int Compare(SoundProperty x, SoundProperty y)
            {
                return x.ToString().CompareTo(y.ToString());
            }
        }

        // This class is necessary.
        // Working with the handle directly causes the App.Update function
        // to throw Access Violation and Engine Execution exceptions.
        // It might have something to do with how the sound completion
        // callback is shared between managed and unmanaged memory.
        private class SoundWithHandle : Sound
        {
            public SoundWithHandle(string name) : base(name) { }
            public uint Handle { get { return base.mHandle; } }
        }

        private SoundWithHandle mCurrentSound = null;

        public AudioForm()
        {
            InitializeComponent();
            SoundProperty[] properties = Enum.GetValues(typeof(SoundProperty)) as SoundProperty[];
            Array.Sort<SoundProperty>(properties, new SoundPropNameComparer());
            if (properties != null)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    this.soundPropCMB.Items.Add(properties[i]);
                }
            }
            this.soundPropCMB.SelectedItem = SoundProperty.Gain;
        }

        protected override bool InitExtra()
        {
            MusicData.Intialize();
            return true;
        }

        private void StartSound()
        {
            if (this.mCurrentSound == null)
            {
                this.mCurrentSound = new SoundWithHandle(this.soundNameTXT.Text);
                if (!this.mCurrentSound.Start(new Sound.SoundFinished(this.OnSoundFinished)))
                {
                    this.mCurrentSound.Dispose();
                    this.mCurrentSound = null;
                }
                else
                {
                    this.startSoundBTN.Enabled = false;
                    this.stopSoundBTN.Enabled = true;
                }
            }
        }

        private void StopSound(uint soundHandle)
        {
            if (this.mCurrentSound != null && this.mCurrentSound.IsPlaying() && 
                this.mCurrentSound.Handle == soundHandle)
            {
                this.mCurrentSound.Stop();
                this.mCurrentSound.Dispose();
                this.mCurrentSound = null;

                this.startSoundBTN.Enabled = true;
                this.stopSoundBTN.Enabled = false;
            }
        }

        private void OnSoundFinished(uint soundHandle, ulong objectId, uint stopReason)
        {
            MessageBox.Show(((StopReason)stopReason).ToString(), "Sound Stopped");
            // There could be another sound playing at this point,
            // so "double-dipping" needs to be prevented.
            this.StopSound(soundHandle);
        }

        public override void ShutdownExtra(bool immediately)
        {
            if (this.mCurrentSound != null)
                this.StopSound(this.mCurrentSound.Handle);
        }

        private void startSound_Click(object sender, EventArgs e)
        {
            this.StartSound();
        }

        private void stopSound_Click(object sender, EventArgs e)
        {
            if (this.mCurrentSound != null)
                this.StopSound(this.mCurrentSound.Handle);
        }

        private void soundPropValue_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(this.soundPropValueTXT.Text, out value))
            {
                this.soundPropValueTXT.ForeColor = SystemColors.ControlText;
            }
            else
            {
                this.soundPropValueTXT.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void setSoundProp_Click(object sender, EventArgs e)
        {
            if (this.mCurrentSound != null)
            {
                uint property = (uint)this.soundPropCMB.SelectedItem;
                float value;
                if (float.TryParse(this.soundPropValueTXT.Text, out value))
                {
                    this.mCurrentSound.SetProperty(property, value);
                }
            }
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

        private void selectSong_Click(object sender, EventArgs e)
        {
            using (MusicSelectionDialog dialog = new MusicSelectionDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (dialog.SelectedSong != null)
                    {
                        this.soundNameTXT.Text = dialog.SelectedSong.mSongKey;
                        if (this.mCurrentSound != null)
                            this.StopSound(this.mCurrentSound.Handle);
                        this.StartSound();
                    }
                }
            }
        }
    }
}
