using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sims3.Math;

namespace ChaosTools.EffectPlayer
{
    public partial class RenderSettingsDialog : Form
    {
        public RenderSettingsDialog()
        {
            InitializeComponent();
        }

        private float mEffectStatsX;
        private float mEffectStatsY;
        private float mEffectStatsIncr;
        private float mGeneralStatsX;
        private float mGeneralStatsY;
        private Vector3 mEyePos;
        private Vector3 mUpDir;
        private Vector3 mTargetPos;

        public float EffectStatsX
        {
            get { return this.mEffectStatsX; }
        }

        public float EffectStatsY
        {
            get { return this.mEffectStatsY; }
        }

        public float EffectStatsIncr
        {
            get { return this.mEffectStatsIncr; }
        }

        public void GetEffectStatsLocation(out float effectStatsX,
            out float effectStatsY, out float effectStatsIncr)
        {
            effectStatsX = this.mEffectStatsX;
            effectStatsY = this.mEffectStatsY;
            effectStatsIncr = this.mEffectStatsIncr;
        }

        public float GeneralStatsX
        {
            get { return this.mGeneralStatsX; }
        }

        public float GeneralStatsY
        {
            get { return this.mGeneralStatsY; }
        }

        public void GetGeneralStatsLocation(out float generalStatsX,
            out float generalStatsY)
        {
            generalStatsX = this.mGeneralStatsX;
            generalStatsY = this.mGeneralStatsY;
        }

        public Vector3 CameraEyePosition
        {
            get { return this.mEyePos; }
        }

        public Vector3 CameraUpDirection
        {
            get { return this.mUpDir; }
        }

        public Vector3 CameraTargetPosition
        {
            get { return this.mTargetPos; }
        }

        public RenderSettingsDialog(float effectStatsX, float effectStatsY,
            float effectStatsIncr, float generalStatsX, float generalStatsY,
            Vector3 eyePos, Vector3 upDir, Vector3 targetPos)
            : this()
        {
            this.mEffectStatsX = effectStatsX;
            this.mEffectStatsY = effectStatsY;
            this.mEffectStatsIncr = effectStatsIncr;
            this.mGeneralStatsX = generalStatsX;
            this.mGeneralStatsY = generalStatsY;
            this.mEyePos = eyePos;
            this.mUpDir = upDir;
            this.mTargetPos = targetPos;
            this.SetTextValues();
        }

        private void GetTextValues()
        {
            float value;
            if (float.TryParse(effectStatsXtxt.Text, out value))
                this.mEffectStatsX = value;
            if (float.TryParse(effectStatsYtxt.Text, out value))
                this.mEffectStatsY = value;
            if (float.TryParse(effectStatsIncrTxt.Text, out value))
                this.mEffectStatsIncr = value;
            if (float.TryParse(generalStatsXtxt.Text, out value))
                this.mGeneralStatsX = value;
            if (float.TryParse(generalStatsYtxt.Text, out value))
                this.mGeneralStatsY = value;
            if (float.TryParse(eyePosXtxt.Text, out value))
                this.mEyePos.x = value;
            if (float.TryParse(eyePosYtxt.Text, out value))
                this.mEyePos.y = value;
            if (float.TryParse(eyePosZtxt.Text, out value))
                this.mEyePos.z = value;
            if (float.TryParse(upDirXtxt.Text, out value))
                this.mUpDir.x = value;
            if (float.TryParse(upDirYtxt.Text, out value))
                this.mUpDir.y = value;
            if (float.TryParse(upDirZtxt.Text, out value))
                this.mUpDir.z = value;
            if (float.TryParse(targetPosXtxt.Text, out value))
                this.mTargetPos.x = value;
            if (float.TryParse(targetPosYtxt.Text, out value))
                this.mTargetPos.y = value;
            if (float.TryParse(targetPosZtxt.Text, out value))
                this.mTargetPos.z = value;
        }

        private void SetTextValues()
        {
            effectStatsXtxt.Text = this.mEffectStatsX.ToString();
            effectStatsYtxt.Text = this.mEffectStatsY.ToString();
            effectStatsIncrTxt.Text = this.mEffectStatsIncr.ToString();
            generalStatsXtxt.Text = this.mGeneralStatsX.ToString();
            generalStatsYtxt.Text = this.mGeneralStatsY.ToString();
            eyePosXtxt.Text = this.mEyePos.x.ToString();
            eyePosYtxt.Text = this.mEyePos.y.ToString();
            eyePosZtxt.Text = this.mEyePos.z.ToString();
            upDirXtxt.Text = this.mUpDir.x.ToString();
            upDirYtxt.Text = this.mUpDir.y.ToString();
            upDirZtxt.Text = this.mUpDir.z.ToString();
            targetPosXtxt.Text = this.mTargetPos.x.ToString();
            targetPosYtxt.Text = this.mTargetPos.y.ToString();
            targetPosZtxt.Text = this.mTargetPos.z.ToString();
        }

        private void floatTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                float value;
                if (float.TryParse(textBox.Text, out value))
                {
                    textBox.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    textBox.ForeColor = Color.Red;
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.GetTextValues();
        }
    }
}
