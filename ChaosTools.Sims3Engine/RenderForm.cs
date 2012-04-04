using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Sims3.CSHost;
using Sims3.Math;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// A form specially designed for utilizing all the capabilities of
    /// The Sims 3 Game Engine provided with the Create A World Tool.
    /// </summary>
    public class RenderForm : Form
    {
        #region Fields and Constructors
        private RenderPanelEx mRenderingPanel;
        private SceneManager mScene;
        private Sims3.CSHost.Renderer.TextRenderer mTextRenderer;
        private bool mGraphicsInitialized = false;

        /// <summary>
        /// Initializes a new RenderForm with Double Buffering,
        /// and ensures that the ScriptCoreManager is initialized.
        /// </summary>
        public RenderForm()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /// <summary><para>
        /// The Rendering Panel where 2D UI and 3D graphics
        /// created by the Game Engine will appear.
        /// </para><para>
        /// This must be set to a non-null value in the derived class
        /// constructor before the Init() function is called
        /// in order to utilize Game Engine graphics.
        /// </para></summary>
        protected RenderPanelEx RenderingPanel
        {
            get { return this.mRenderingPanel; }
            set
            {
                if (!this.mGraphicsInitialized)
                {
                    this.mRenderingPanel = value;
                }
            }
        }

        /// <summary>
        /// The Scene Manager used to control the contents
        /// of the 3D graphics created by the game engine,
        /// including cameras, objects, etc.
        /// </summary>
        protected SceneManager Scene
        {
            get { return this.mScene; }
        }

        /// <summary>
        /// A provided Text Renderer for drawing text in the
        /// Rendering Panel's scene relative to given 3D points
        /// </summary>
        protected Sims3.CSHost.Renderer.TextRenderer TextRenderer
        {
            get { return this.mTextRenderer; }
        }
        #endregion

        #region Timing
        // Doubles used just in case the game is left running a REALLY long time.
        private Sims3.StopWatch mStopWatch = new Sims3.StopWatch();
        private float mAppInitTime;
        private float mSceneInitTime;
        private float mTimeAtLastFrame;
        private double mTotalRealTime = 0.0;
        private double mTotalGameTime = 0.0;

        /// <summary>
        /// The total time in seconds it took the App.InitApp function to execute.
        /// Basically the time it took to load all packaged resources.
        /// </summary>
        public float AppInitTime
        {
            get { return this.mAppInitTime; }
        }

        /// <summary>
        /// The total time in seconds it took for Scene Manager 
        /// and other critical components dependent on the game engine to load.
        /// </summary>
        public float SceneInitTime
        {
            get { return this.mSceneInitTime; }
        }

        /// <summary>
        /// This class stores game engine clock values 
        /// that are passed to the Updating and Drawing functions.
        /// </summary>
        public struct EngineTime
        {
            /// <summary>
            /// The elapsed real time in seconds since the last update/draw frame
            /// </summary>
            public float DeltaRealTime;
            /// <summary>
            /// The elapsed game time in seconds since the last update/draw frame
            /// </summary>
            public float DeltaGameTime;
            /// <summary>
            /// The total real time in seconds since the render form was initialized
            /// </summary>
            public double TotalRealTime;
            /// <summary>
            /// The total game time in seconds since the render form was initialized
            /// </summary>
            public double TotalGameTime;

            /// <summary>
            /// Initializes a new instance of the EngineTime structure
            /// with the given time values.
            /// </summary>
            /// <param name="deltaRealTime">Elapsed real time in seconds since previous frame.</param>
            /// <param name="deltaGameTime">Elapsed game time in seconds since previous frame.</param>
            /// <param name="totalRealTime">Total real time in seconds since initialization.</param>
            /// <param name="totalGameTime">Total game time in seconds since initialization.</param>
            public EngineTime(float deltaRealTime, float deltaGameTime,
                double totalRealTime, double totalGameTime)
            {
                this.DeltaRealTime = deltaRealTime;
                this.DeltaGameTime = deltaGameTime;
                this.TotalRealTime = totalRealTime;
                this.TotalGameTime = totalGameTime;
            }
        }
        #endregion

        #region Initialization
        private void InitMainCamera()
        {
            System.Drawing.Size clientSize = this.mRenderingPanel.ClientSize;
            this.mScene.MainCamera.AspectRatio = (float)clientSize.Width / (float)clientSize.Height;
            this.mScene.MainCamera.FOV = 70f;
            this.mScene.MainCamera.NearClip = 0.1f;
            this.mScene.MainCamera.FarClip = 5500f;
            this.mScene.MainCamera.ControlStyle = Camera.CameraControllerType.InGame;
            this.mScene.MainCamera.UpdateMatrices();
        }

        private void InitializeScene()
        {
            //this.UpdateToggleMenus();
            //this.UpdateMenus();
            //this.ClearUndoStack();
            CameraTuning.Load(this.mScene.MainCamera.ControlStyle, Sims3.SimIFace.WorldName.UserCreated);
            this.InitMainCamera();
            this.mRenderingPanel.Invalidate();
        }

        /// <summary>
        /// Scene Initialization.
        /// The Game Engine, Rendering Panel, Scene Manager, Text Renderer,
        /// and other game engine dependent components
        /// are initialized here.
        /// </summary>
        /// <param name="splash">A splash form for displaying initialization messages.</param>
        /// <returns>True if all components were successfully initialized,
        /// False otherwise</returns>
        public bool Init(ISplashForm splash)
        {
            if (this.mRenderingPanel == null)
            {
				this.mRenderingPanel = new RenderPanelEx();
                //return false;
            }
            if (splash != null) 
                splash.Message = "Initializing Game Engine...";
            string overrideUserDataPath = null;
            string installedGameUserDataDir = App.GetInstalledGameUserDataDir();
            SharedInitialization.AddGimexSupport();
            if (!string.IsNullOrEmpty(installedGameUserDataDir))
            {
                string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                overrideUserDataPath = Path.Combine(folderPath, installedGameUserDataDir);
            }
            this.mStopWatch.Start();
            float startTime = this.mStopWatch.GetElapsedMilliSecs() / 1000f;
            if (!App.InitApp("", "", this.mRenderingPanel.Width, this.mRenderingPanel.Height, IntPtr.Zero, 0, this.mRenderingPanel.Handle, true, null, overrideUserDataPath))
            //if (!App.InitApp("", "", this.mRenderPanel.Width, this.mRenderPanel.Height, IntPtr.Zero, 0, this.mRenderPanel.Handle, true, null, App.StartupServices.ServicesFull, null, overrideUserDataPath, true))
            {
                //throw new Exception("Failed to initialise CSHost");
                return false;
            }
            float endTime = this.mStopWatch.GetElapsedMilliSecs() / 1000f;
            this.mAppInitTime = endTime - startTime;

            App.StartProcessMessages();
            this.mRenderingPanel.AttachToNativeCanvas();
            this.mRenderingPanel.Resize += new EventHandler(RenderPanel_Resize);
            GameObjectFactory.Init();
            SharedInitialization.RegisterResourceFactories();

            if (splash != null)
                splash.Message = "Initializing Scene...";
            this.mScene = new SceneManager();
            if (!this.mScene.Init())
            {
                return false;
            }
            CameraTuning.InitializeTuningData();
            this.InitializeScene();
            ScriptCoreManager.Initialize();

            if (splash != null)
                splash.Message = "Reticulating Splines...";
            startTime = this.mStopWatch.GetElapsedMilliSecs() / 1000f;
            this.mSceneInitTime = startTime - endTime;
            this.mStopWatch.Stop();
            this.mStopWatch.Reset();
            this.mStopWatch.Start();
            this.mTimeAtLastFrame = 0f;

            this.mTextRenderer = new Sims3.CSHost.Renderer.TextRenderer();

            this.mGraphicsInitialized = true;

            return this.InitExtra();
        }

        /// <summary>
        /// Place to put code that is executed after Game Engine, Scene Manager,
        /// and other provided components are initialized 
        /// and before the main execution loop begins.
        /// </summary>
        /// <returns>True to begin the main execution loop or
        /// False to immediately shutdown the application.</returns>
        protected virtual bool InitExtra()
        {
            return true;
        }

        /// <summary>
        /// This function is called after initialization and 
        /// before the main execution loop begins.
        /// This function processes any command line arguments
        /// and determines whether or not the form should be shown 
        /// and start its main execution loop.
        /// </summary>
        /// <param name="args">The command line arguments given to the program when it started.</param>
        /// <param name="keepRunning">Always passed true by the program.</param>
        /// <returns>True if the form is shown and starts its main execution loop, false otherwise.</returns>
        public virtual bool ProcessCommandLineArgs(string[] args, bool keepRunning)
        {
            return keepRunning;
        }
        #endregion

        #region Drawing And Updating
        /// <summary>
        /// This boolean determines whether or not the main execution loop
        /// should continue running or shutdown.
        /// </summary>
        public bool IsRunning = false;

        // Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event, and
        /// <summary>
        /// Sets <see cref="F:ChaosTools.Sims3Engine.RenderForm.IsRunning"/>
        /// to False to shutdown the execution loop.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //base.OnClosing(e);
            e.Cancel = true;
            this.IsRunning = false;
        }

        /// <summary>
        /// If inactive, sleep for 10 milliseconds
        /// </summary>
        public void ThrottleIfInactive()
        {
            if (Form.ActiveForm == null)
            {
                System.Threading.Thread.Sleep(10);
            }
        }

        private bool mPauseGameTime = false;
        private float mGameTimeMultiplier = 1f;

        /// <summary>
        /// Whether or not the elapsed game time is paused.
        /// </summary>
        public bool PauseGameTime
        {
            get { return this.mPauseGameTime; }
            set { this.mPauseGameTime = value; }
        }

        /// <summary>
        /// The multiplier for the game time increment,
        /// which is always positive.
        /// </summary>
        public float GameTimeMultiplier
        {
            get { return this.mGameTimeMultiplier; }
            set { if (value != 0) this.mGameTimeMultiplier = Math.Abs(value); }
        }
        
        private void RenderPanel_Resize(object sender, EventArgs e)
        {
            System.Drawing.Size clientSize = this.mRenderingPanel.ClientSize;
            this.mScene.MainCamera.AspectRatio = (float)clientSize.Width / (float)clientSize.Height;
            this.mScene.MainCamera.UpdateMatrices();
        }

        /// <summary>
        /// Scene Drawing and Updating.
        /// </summary>
        public void UpdateAndDraw()
        {
            this.ThrottleIfInactive();
            App.BeginProfiling();
            try
            {
                float elapsedSecs = this.mStopWatch.GetElapsedMilliSecs() / 1000f;
                float deltaRealTime = elapsedSecs - this.mTimeAtLastFrame;
                float deltaGameTime = 0f;
                if (!this.mPauseGameTime)
                {
                    deltaGameTime = deltaRealTime * this.mGameTimeMultiplier;
                }
                this.mTotalRealTime += deltaRealTime;
                this.mTotalGameTime += deltaGameTime;
                EngineTime engineTime = new EngineTime(deltaRealTime, deltaGameTime,
                    this.mTotalRealTime, this.mTotalGameTime);
                this.mTimeAtLastFrame = elapsedSecs;

                App.PauseGameClock(this.mPauseGameTime);
                App.SetGameTimeScale(this.mGameTimeMultiplier);
                App.Update(deltaRealTime, deltaGameTime);
                Sims3.CSHost.Animation.Manager.UpdateRenderer(deltaGameTime);
                this.UpdateExtra(engineTime);
                if (GfxDevice.BeginScene())
                {
                    this.mScene.BeginFrame();
                    this.mScene.DrawScene();
                    this.DrawExtra(engineTime);
                    GfxDevice.RectInt viewport = GfxDevice.GetViewport();
                    App.RenderUI(viewport.left, viewport.top, viewport.right, viewport.bottom);
                    GfxDevice.EndScene();
                }
                GfxDevice.Present();
            }
            finally
            {
                App.EndProfiling();
            }
        }

        /// <summary>
        /// Place to put code that is executed before drawing is performed 
        /// in the current game time frame.
        /// </summary>
        /// <param name="engineTime">The time values for the current updating frame.</param>
        protected virtual void UpdateExtra(EngineTime engineTime)
        {
        }

        /// <summary>
        /// Place to put code that is executed between 
        /// GfxDevice.BeginScene() and GfxDevice.EndScene(),
        /// after the Scene Manager is rendered and before the UI is rendered.
        /// </summary>
        /// <param name="engineTime">The time values for the current drawing frame.</param>
        protected virtual void DrawExtra(EngineTime engineTime)
        {
        }
        #endregion

        #region Shutdown
        /// <summary>
        /// Place to put code that is performed before the
        /// Scene Manager, Text Renderer, and Game Engine are shut down.
        /// </summary>
        /// <param name="immediately">True if shutdown should be performed immediately,
        /// due to initialization failure or critical error. False if the user
        /// should prompted to shutdown safely.</param>
        public virtual void ShutdownExtra(bool immediately)
        {
        }

        /// <summary>
        /// Scene Shutdown.
        /// The Game Engine, Rendering Panel, Scene Manager, Text Renderer,
        /// and other game engine dependent components
        /// are shutdown here.
        /// </summary>
        /// <param name="immediately">True if shutdown should be performed immediately,
        /// due to initialization failure or critical error. False if the user
        /// should prompted to shutdown safely.</param>
        public void Shutdown(bool immediately)
        {
            this.ShutdownExtra(immediately);
            this.mStopWatch.Stop();
            if (this.mScene != null)
            {
                this.mScene.Shutdown();
                this.mScene.Dispose();
                this.mScene = null;
            }
            if (this.mTextRenderer != null)
            {
                this.mTextRenderer.Dispose();
                this.mTextRenderer = null;
            }
            App.PreShutdown();
            GameObjectFactory.Shutdown();
            App.Shutdown();
        }
        #endregion

        #region Application Entry
        [System.Runtime.InteropServices.DllImport("Sims3Common.dll")]
        private static extern void SetDefaultAppDomain(AppDomain defaultDomain);

        /// <summary><para>
        /// This function initializes the give RenderForm instance,
        /// runs its main execution loop, and properly shuts it down.
        /// </para><para>
        /// It also properly disposes the Render Form and Splash Form when finished.
        /// </para></summary>
        /// <param name="args">The command line arguments from the application's main entry point.</param>
        /// <param name="mainForm">The main form of the application.</param>
        /// <param name="splash">The splash form displayed while the main form is initializing.</param>
        /// <returns>1 if a problem was encountered, 0 otherwise.</returns>
        public static int MainLoop(string[] args, RenderForm mainForm, ISplashForm splash)
        {
            if (mainForm == null)
                return 1;
            SetDefaultAppDomain(AppDomain.CurrentDomain);
            if (splash != null)
            {
                splash.Show();
                splash.Update();
            }
            using (mainForm)
            {
                if (!mainForm.Init(splash))
                {
                    if (splash != null)
                    {
                        splash.Close();
                        splash.Dispose();
                    }
                    mainForm.Shutdown(true);
                    return 1;
                }
                mainForm.IsRunning = true;
                bool keepRunning = true;
                keepRunning = mainForm.ProcessCommandLineArgs(args, keepRunning);
                mainForm.IsRunning = keepRunning;
                if (mainForm.IsRunning)
                {
                    if (splash != null)
                    {
                        splash.Close();
                        splash.Dispose();
                    }
                    mainForm.Show();
                }
                while (mainForm.IsRunning)
                {
                    Application.DoEvents();
                    mainForm.UpdateAndDraw();
                }
                mainForm.Shutdown(false);
            }
            return 0;
        }

        /// <summary><para>
        /// This function initializes the give RenderForm instance,
        /// runs its main execution loop, and properly shuts it down.
        /// </para><para>
        /// It traps and displays any errors that occur.
        /// </para><para>
        /// It also properly disposes the Render Form and Splash Form when finished.
        /// </para></summary>
        /// <param name="args">The command line arguments from the application's main entry point.</param>
        /// <param name="mainForm">The main form of the application.</param>
        /// <param name="splash">The splash form displayed while the main form is initializing.</param>
        /// <returns>1 if a problem was encountered, 0 otherwise.</returns>
        public static int MainLoopSafe(string[] args, RenderForm mainForm, ISplashForm splash)
        {
            if (mainForm == null)
                return 1;
            SetDefaultAppDomain(AppDomain.CurrentDomain);
            if (splash != null)
            {
                splash.Show();
                splash.Update();
            }
            using (mainForm)
            {
                try
                {
                    if (!mainForm.Init(splash))
                    {
                        if (splash != null)
                        {
                            splash.Close();
                            splash.Dispose();
                        }
                        mainForm.Shutdown(true);
                        return 1;
                    }
                    mainForm.IsRunning = true;
                    bool keepRunning = true;
                    keepRunning = mainForm.ProcessCommandLineArgs(args, keepRunning);
                    mainForm.IsRunning = keepRunning;
                    if (mainForm.IsRunning)
                    {
                        if (splash != null)
                        {
                            splash.Close();
                            splash.Dispose();
                        }
                        mainForm.Show();
                    }
                    while (mainForm.IsRunning)
                    {
                        Application.DoEvents();
                        mainForm.UpdateAndDraw();
                    }
                }
                catch (Exception ex1)
                {
                    try
                    {
                        // Display Crashed + Exception
                        ExceptionHelper.ShowException(ex1, "Application Crashed");
                        mainForm.Shutdown(true);
                    }
                    catch (Exception ex2)
                    {
                        // Display Shutdown Failed + Exception
                        ExceptionHelper.ShowException(ex2, "Application Shutdown Failed");
                    }
                    return 1;
                }
                try
                {
                    mainForm.Shutdown(false);
                }
                catch (Exception ex3)
                {
                    // Display Shutdown Failed + Exception
                    ExceptionHelper.ShowException(ex3, "Application Shutdown Failed");
                    return 1;
                }
            }
            return 0;
        }
        #endregion
    }
}
