using System;
using System.IO;
using System.Windows.Forms;
using Sims3.CSHost;

namespace ChaosTools.Sims3Engine
{
    /// <summary><para>
    /// The absolute bare minimum class needed to load the game engine
    /// and execute code that depends on the game engine.
    /// </para><para>
    /// This class is meant mainly for command line applications.
    /// It is strongly suggested that you use <see cref="T:ChaosTools.Sims3Engine.RenderPanelEx"/>
    /// and <see cref="T:ChaosTools.Sims3Engine.RenderForm"/> for GUI applications.
    /// </para></summary>
    public abstract class BasicEngine
    {
        private string mOverrideUserDataPath;

        /// <summary>
        /// The user data path given to the game engine initialization function
        /// </summary>
        protected string OverrideUserDataPath
        {
            get { return this.mOverrideUserDataPath; }
        }

        /// <summary>
        /// This is where user code dependent on the game engine is executed.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>Zero if execution was successful, 
        /// or failure codes normally returned 
        /// by application's main entry point.</returns>
        protected virtual int Execute(string[] args)
        {
            return 0;
        }

        /// <summary>
        /// This is the main function that loads the game engine, 
        /// executes the user code that depends on it,
        /// and then shuts down the game engine.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>Zero if execution was successful, 
        /// or failure codes normally returned 
        /// by application's main entry point.</returns>
        public int Run(string[] args)
        {
            int returnCode = 1;
            this.mOverrideUserDataPath = null;
            string installedGameUserDataDir = App.GetInstalledGameUserDataDir();
            SharedInitialization.AddGimexSupport();
            Panel panel1 = new Panel();
            if (!string.IsNullOrEmpty(installedGameUserDataDir))
            {
                string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                this.mOverrideUserDataPath = Path.Combine(folderPath, installedGameUserDataDir);
            }
            if (!App.InitApp("", "", panel1.Width, panel1.Height, IntPtr.Zero, 0, panel1.Handle, true, null, this.mOverrideUserDataPath))
            {
                throw new Exception("Failed to initialize game engine");
            }
            App.StartProcessMessages();

            returnCode = this.Execute(args);

            App.Shutdown();

            return returnCode;
        }
    }
}
