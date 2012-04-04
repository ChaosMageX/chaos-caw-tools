using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChaosTools.AudioPlayer
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
            //Application.Run(new AudioForm());
            return ChaosTools.Sims3Engine.RenderForm.MainLoop(args, new AudioForm(), null);
        }
    }
}
