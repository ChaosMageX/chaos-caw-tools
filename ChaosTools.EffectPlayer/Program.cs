﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChaosTools.EffectPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
#if DEBUG
            return ChaosTools.Sims3Engine.RenderForm.MainLoop(args, new EffectForm(), null);
#else
            return ChaosTools.Sims3Engine.RenderForm.MainLoopSafe(args, new EffectForm(), null);
#endif
        }
    }
}
