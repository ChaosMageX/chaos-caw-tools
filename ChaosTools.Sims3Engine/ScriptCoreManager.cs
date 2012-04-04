using System;
using System.Collections.Generic;
using System.Text;
using ScriptCore;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This class manages all classes in ScriptCore.dll that need to be initialized
    /// into the AppDomain data so that classes in SimIFace.dll can use them.
    /// </summary>
    /// <remarks>
    /// Please try to use the instances of ScriptCore classes created by this class,
    /// or retrieve them from the AppDomain Data, rather than creating your own instances.
    /// </remarks>
    public static class ScriptCoreManager
    {
        // Missing AppDomain Data:
        // AppDomain.CurrentDomain.GetData("ConsoleHost") as Sims3.SimIFace.IConsoleHost;
        // AppDomain.CurrentDomain.GetData("RoutingMgr") as Sims3.SimIFace.IRoutingMgr;

        private static bool sInitialized = false;

        /// <summary>
        /// Initializes all ScriptCore classes that data to the App Domain
        /// and initialize any other static members in Sims3.SimIFace classes.
        /// </summary>
        public static void Initialize()
        {
            if (!sInitialized)
            {
                if (gAnimation == null) gAnimation = new Animation();
                if (gAudio == null) gAudio = new Audio();
                if (gAutomationUtils == null) gAutomationUtils = new AutomationUtils();
                if (gCacheManager == null) gCacheManager = new CacheManager();
                if (gCameraController == null) gCameraController = new CameraController();
                if (gCASUtils == null) gCASUtils = new CASUtils();
                if (gCommandSystem == null) gCommandSystem = new CommandSystem();
                if (gCTProductModularObject == null) gCTProductModularObject = new CTProductModularObject();
                if (gDataFactory == null) gDataFactory = new DataFactory();
                if (gDebugDraw == null) gDebugDraw = new DebugDraw();
                if (gDeviceConfig == null) gDeviceConfig = new DeviceConfig();
                if (gDownloadContent == null) gDownloadContent = new DownloadContent();
                if (gEAText == null) gEAText = new EAText();
                if (gEATrace == null) gEATrace = new EATrace();
                if (gEventQueueInitializer == null) gEventQueueInitializer = new EventQueueInitializer();
                if (gGameUtils == null) gGameUtils = new GameUtils();
                if (gLoadSaveManager == null) gLoadSaveManager = new LoadSaveManager();
                if (gLocalizedStringService == null) gLocalizedStringService = new LocalizedStringService();
                if (gLookAtMgr == null) gLookAtMgr = new LookAtMgr();
                if (gNameGuidMapService == null) gNameGuidMapService = new NameGuidMapService();
                if (gObjects == null) gObjects = new Objects();
                if (gOnlineFeatures == null) gOnlineFeatures = new OnlineFeatures();
                //if (gProfilerUtils == null) gProfilerUtils = new ProfilerUtils();
                if (gQueries == null) gQueries = new Queries();
                if (gRandom == null) gRandom = new ScriptCore.Random();
                if (gReflection == null) gReflection = new ScriptCore.Reflection();
                if (gRouteManager == null) gRouteManager = new RouteManager();
                if (gSACS == null) gSACS = new SACS();
                if (gSimulator == null) gSimulator = new Simulator();
                if (gSlots == null) gSlots = new Slots();
                if (gSocialFeatures == null) gSocialFeatures = new SocialFeatures();
                if (gStopWatch == null) gStopWatch = new StopWatch();
                if (gStreamHost == null) gStreamHost = new StreamHost();
                if (gSwarm == null) gSwarm = new Swarm();
                if (gThumbnailManager == null) gThumbnailManager = new ThumbnailManager();
                if (gUIManager == null) gUIManager = new UIManager();
                if (gUserToolUtils == null) gUserToolUtils = new UserToolUtils();
                if (gVideoRecorder == null) gVideoRecorder = new VideoRecorder();
                if (gWorld == null) gWorld = new World();
                // Will this still be reached if any of the constructors throw an Exception? Hopefully not
                sInitialized = true;
            }
        }

        private static Animation gAnimation = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Animation") as Sims3.SimIFace.IAnimation;
        /// </summary>
        public static Animation Animation
        {
            get { Initialize(); return gAnimation; }
        }

        private static Audio gAudio = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Audio") as Sims3.SimIFace.IAudio;
        /// </summary>
        public static Audio Audio
        {
            get { Initialize(); return gAudio; }
        }

        private static AutomationUtils gAutomationUtils = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("AutomationUtils") as Sims3.SimIFace.IAutomationUtils;
        /// </summary>
        public static AutomationUtils AutomationUtils
        {
            get { Initialize(); return gAutomationUtils; }
        }

        private static CacheManager gCacheManager = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("CacheManager") as Sims3.SimIFace.ICacheManager;
        /// </summary>
        public static CacheManager CacheManager
        {
            get { Initialize(); return gCacheManager; }
        }/**/

        private static CameraController gCameraController = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("CameraController") as Sims3.SimIFace.ICameraController;
        /// </summary>
        public static CameraController CameraController
        {
            get { Initialize(); return gCameraController; }
        }

        private static CASUtils gCASUtils = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("CASUtils") as Sims3.SimIFace.CAS.ICASUtils;
        /// </summary>
        public static CASUtils CASUtils
        {
            get { Initialize(); return gCASUtils; }
        }

        private static CommandSystem gCommandSystem = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("CommandSystem") as Sims3.SimIFace.ICommandSystem;
        /// </summary>
        public static CommandSystem CommandSystem
        {
            get { Initialize(); return gCommandSystem; }
        }

        private static CTProductModularObject gCTProductModularObject = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("CTProductModularObject") as Sims3.SimIFace.BuildBuy.IModularObject;
        /// </summary>
        public static CTProductModularObject CTProductModularObject
        {
            get { Initialize(); return gCTProductModularObject; }
        }

        private static DataFactory gDataFactory = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("DataFactory") as Sims3.SimIFace.IDataFactory;
        /// </summary>
        public static DataFactory DataFactory
        {
            get { Initialize(); return gDataFactory; }
        }

        private static DebugDraw gDebugDraw = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("DebugDraw") as Sims3.SimIFace.IDebugDraw;
        /// </summary>
        public static DebugDraw DebugDraw
        {
            get { Initialize(); return gDebugDraw; }
        }

        private static DeviceConfig gDeviceConfig = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("DeviceConfig") as Sims3.SimIFace.IDeviceConfig;
        /// </summary>
        public static DeviceConfig DeviceConfig
        {
            get { Initialize(); return gDeviceConfig; }
        }

        private static DownloadContent gDownloadContent = null;

        /// <summary><para>
        /// AppDomain.CurrentDomain.GetData("DownloadContent") as Sims3.SimIFace.CustomContent.IContentManager;
        /// </para><para>
        /// AppDomain.CurrentDomain.GetData("DownloadContent") as Sims3.SimIFace.CustomContent.IDownloadContent;
        /// </para><para>
        /// AppDomain.CurrentDomain.GetData("DownloadContent") as Sims3.SimIFace.CustomContent.IExportBin;
        /// </para></summary>
        public static DownloadContent DownloadContent
        {
            get { Initialize(); return gDownloadContent; }
        }

        private static EAText gEAText = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("EAText") as Sims3.SimIFace.IEAText;
        /// </summary>
        public static EAText EAText
        {
            get { Initialize(); return gEAText; }
        }

        private static EATrace gEATrace = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("EATrace") as Sims3.SimIFace.ITrace;
        /// </summary>
        public static EATrace EATrace
        {
            get { Initialize(); return gEATrace; }
        }

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("EventQueueCtor") as System.Reflection.ConstructorInfo;
        /// </summary>
        private static EventQueueInitializer gEventQueueInitializer = null;

        private static GameUtils gGameUtils = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("GameUtils") as Sims3.SimIFace.IGameUtils;
        /// </summary>
        public static GameUtils GameUtils
        {
            get { Initialize(); return gGameUtils; }
        }

        private static LoadSaveManager gLoadSaveManager = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("LoadSaveManager") as Sims3.SimIFace.ILoadSaveManager;
        /// </summary>
        public static LoadSaveManager LoadSaveManager
        {
            get { Initialize(); return gLoadSaveManager; }
        }

        private static LocalizedStringService gLocalizedStringService = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("LocalizedStringService") as Sims3.SimIFace.IStringTable;
        /// </summary>
        public static LocalizedStringService LocalizedStringService
        {
            get { Initialize(); return gLocalizedStringService; }
        }

        private static LookAtMgr gLookAtMgr = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("LookAtMgr") as Sims3.SimIFace.ILookAt;
        /// </summary>
        public static LookAtMgr LookAtMgr
        {
            get { Initialize(); return gLookAtMgr; }
        }

        private static NameGuidMapService gNameGuidMapService = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("NameGuidMapService") as Sims3.SimIFace.INameGuidMap;
        /// </summary>
        public static NameGuidMapService NameGuidMapService
        {
            get { Initialize(); return gNameGuidMapService; }
        }

        private static Objects gObjects = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Objects") as Sims3.SimIFace.IObjects;
        /// </summary>
        public static Objects Objects
        {
            get { Initialize(); return gObjects; }
        }

        private static OnlineFeatures gOnlineFeatures = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("OnlineFeatures") as Sims3.SimIFace.IOnlineFeatures;
        /// </summary>
        public static OnlineFeatures OnlineFeatures
        {
            get { Initialize(); return gOnlineFeatures; }
        }

        /*private static ProfilerUtils gProfilerUtils = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("ProfilerUtils") as Sims3.SimIFace.IProfiler;
        /// </summary>
        public static ProfilerUtils ProfilerUtils
        {
            get { Initialize(); return gProfilerUtils; }
        }/**/

        private static Queries gQueries = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Queries") as Sims3.SimIFace.IQueries;
        /// </summary>
        public static Queries Queries
        {
            get { Initialize(); return gQueries; }
        }

        private static ScriptCore.Random gRandom = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("RandomGen") as Sims3.SimIFace.IRandom;
        /// </summary>
        public static ScriptCore.Random Random
        {
            get { Initialize(); return gRandom; }
        }

        private static ScriptCore.Reflection gReflection = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Reflection") as Sims3.SimIFace.IReflection;
        /// </summary>
        public static ScriptCore.Reflection Reflection
        {
            get { Initialize(); return gReflection; }
        }

        /// <summary><para>
        /// AppDomain.CurrentDomain.GetData("RouteCtor") as System.Reflection.ConstructorInfo;
        /// </para><para>
        /// AppDomain.CurrentDomain.GetData("RouteSlotCtor") as System.Reflection.ConstructorInfo;
        /// </para></summary>
        private static RouteManager gRouteManager = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("RouteManager") as Sims3.SimIFace.IRouteManager;
        /// </summary>
        public static RouteManager RouteManager
        {
            get { Initialize(); return gRouteManager; }
        }

        private static SACS gSACS = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("SacsProxy") as Sims3.SimIFace.ISacsProxy;
        /// </summary>
        public static SACS SACS
        {
            get { Initialize(); return gSACS; }
        }

        private static Simulator gSimulator = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Simulator") as Sims3.SimIFace.ISimulator;
        /// </summary>
        public static Simulator Simulator
        {
            get { Initialize(); return gSimulator; }
        }

        private static Slots gSlots = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("Slots") as Sims3.SimIFace.ISlots;
        /// </summary>
        public static Slots Slots
        {
            get { Initialize(); return gSlots; }
        }

        private static SocialFeatures gSocialFeatures = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("SocialFeatures") as Sims3.SimIFace.ISocialFeatures;
        /// </summary>
        public static SocialFeatures SocialFeatures
        {
            get { Initialize(); return gSocialFeatures; }
        }

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("StopWatchCtor") as System.Reflection.ConstructorInfo;
        /// </summary>
        private static StopWatch gStopWatch = null;

        /// <summary><para>
        /// Sims3.SimIFace.FastStreamWriter.sFastBaseStreamWriterCreator;
        /// </para><para>
        /// Sims3.SimIFace.FastStreamReader.sFastBaseStreamReaderCreator;
        /// </para></summary>
        private static StreamHost gStreamHost = null;

        /// <summary><para>
        /// AppDomain.CurrentDomain.GetData("VisualEffectCtor") as System.Reflection.ConstructorInfo;
        /// </para><para>
        /// AppDomain.CurrentDomain.GetData("Swarm") as ScriptCore.Swarm;
        /// </para></summary>
        private static Swarm gSwarm = null;

        private static ThumbnailManager gThumbnailManager = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("ThumbnailManager") as Sims3.SimIFace.IThumbnailManager;
        /// </summary>
        public static ThumbnailManager ThumbnailManager
        {
            get { Initialize(); return gThumbnailManager; }
        }

        private static UIManager gUIManager = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("UIManager") as Sims3.SimIFace.IUIManager;
        /// </summary>
        public static UIManager UIManager
        {
            get { Initialize(); return gUIManager; }
        }

        private static UserToolUtils gUserToolUtils = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("UserToolUtils") as Sims3.SimIFace.IUserToolUtils;
        /// </summary>
        public static UserToolUtils UserToolUtils
        {
            get { Initialize(); return gUserToolUtils; }
        }

        private static VideoRecorder gVideoRecorder = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("VideoRecorder") as Sims3.SimIFace.VideoRecording.IVideoRecorder;
        /// </summary>
        public static VideoRecorder VideoRecorder
        {
            get { Initialize(); return gVideoRecorder; }
        }

        private static World gWorld = null;

        /// <summary>
        /// AppDomain.CurrentDomain.GetData("World") as Sims3.SimIFace.IWorld;
        /// </summary>
        public static World World
        {
            get { Initialize(); return gWorld; }
        }
    }
}
