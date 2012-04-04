using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;
using Sims3.SimIFace;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This class is used for loading camera tuning values
    /// from either the Sims3.Gameplay.Core.Camera XML Resource within GameplayData.package,
    /// or the CameraOverrides.xml file in the same directory as the application,
    /// and applying them to the game engine.
    /// </summary>
    public class CameraTuning
    {
        /// <summary>
        /// Default duration supplied to our lerps. Positive float. Initial GPE default: 1f.
        /// </summary>
        [Tunable, TunableComment("Default duration supplied to our lerps. Positive float. Initial GPE default: 1f.")]
        public static float kDefaultLerpDuration = 1f;

        /// <summary>
        /// Whether or not the world fly-over camera flies at a constant height?
        /// </summary>
        [Tunable]
        public static bool kFlyConstantHeight = false;

        /// <summary>
        /// The minimum zoom distance of the world fly-over camera?
        /// </summary>
        [Tunable]
        public static float kFlyMaxZoom = 192f;

        /// <summary>
        /// The maximum zoom distance of the world fly-over camera?
        /// </summary>
        [Tunable]
        public static float kFlyMinZoom = 0f;

        /// <summary>
        /// This value is added to default when shift is held down 
        /// to get the fly-over move speed when shift is held down
        /// </summary>
        [Tunable]
        public static float kFlyMoveBoostSpeed = 60f;

        /// <summary>
        /// The scrolling speed for the world fly-over camera
        /// </summary>
        [Tunable]
        public static float kFlyMoveDefaultSpeed = 30f;

        /// <summary>
        /// This value is added to default when shift is held down 
        /// to get the fly-over turn speed when shift is held down
        /// </summary>
        [Tunable]
        public static float kFlyTurnBoostSpeed = 90f;

        /// <summary>
        /// How fast the world fly-over camera turns
        /// </summary>
        [Tunable]
        public static float kFlyTurnDefaultSpeed = 45f;

        /// <summary>
        /// This value is added to default when shift is held down 
        /// to get the fly-over zoom speed when shift is held down
        /// </summary>
        [Tunable]
        public static float kFlyZoomBoostSpeed = 60f;

        /// <summary>
        /// The zoom speed for the world fly-over camera
        /// </summary>
        [Tunable]
        public static float kFlyZoomDefaultSpeed = 30f;

        /// <summary>
        /// Lot boundary tolerance to use when focusing on a lot for build/buy.
        /// </summary>
        [TunableComment("Lot boundary tolerance to use when focusing on a lot for build/buy."), Tunable]
        public static float kLotBoundaryTolerance = 5f;

        /// <summary>
        /// Whether or not the camera can switch to look at sky mode?
        /// </summary>
        [Tunable]
        public static bool kMainAllowLookAtSky = true;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainControllerMoveBoostSpeed = 5f;

        /// <summary>
        /// The scrolling speed for the controller
        /// </summary>
        [Tunable, TunableComment("The scrolling speed for the controller")]
        public static float kMainControllerMoveDefaultSpeed = 2.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainControllerPitchBoostSpeed = 10f;

        /// <summary>
        /// How fast the camera rotates up and down using controller
        /// </summary>
        [TunableComment("How fast the camera rotates up and down using controller"), Tunable]
        public static float kMainControllerPitchDefaultSpeed = 3f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainControllerYawBoostSpeed = 20f;

        /// <summary>
        /// How fast the camera rotates side to side using controller
        /// </summary>
        [Tunable, TunableComment("How fast the camera rotates side to side using controller")]
        public static float kMainControllerYawDefaultSpeed = 5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainControllerZoomInBoostSpeed = 4f;

        /// <summary>
        /// The zoom in speed for the controller
        /// </summary>
        [Tunable, TunableComment("The zoom in speed for the controller")]
        public static float kMainControllerZoomInDefaultSpeed = 1.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainControllerZoomOutBoostSpeed = 4f;

        /// <summary>
        /// The zoom out speed for the controller
        /// </summary>
        [Tunable, TunableComment("The zoom out speed for the controller")]
        public static float kMainControllerZoomOutDefaultSpeed = 1.5f;

        /// <summary>
        /// This value controls the exponential decay applied to rotation velocity after user input stops.
        /// It should be between 0 and 1.  For example a value of 0.2 means that after one second, 
        /// the speed will be at 20% of its starting value.
        /// </summary>
        [TunableComment("This value controls the exponential decay applied to rotation velocity after user input stops.  It should be between 0 and 1.  For example a value of 0.2 means that after one second, the speed will be at 20% of its starting value."), Tunable]
        public static float kMainDecayRot = 0.01f;

        /// <summary>
        /// This value controls the exponential decay applied to movement velocity after user input stops.
        /// It should be between 0 and 1.  For example a value of 0.2 means that after one second, 
        /// the speed will be at 20% of its starting value.
        /// </summary>
        [Tunable, TunableComment("This value controls the exponential decay applied to movement velocity after user input stops.  It should be between 0 and 1.  For example a value of 0.2 means that after one second, the speed will be at 20% of its starting value.")]
        public static float kMainDecayTrans = 0.02f;

        /// <summary>
        /// This value controls the exponential decay applied to zoom velocity after user input stops.
        /// It should be between 0 and 1.  For example a value of 0.2 means that after one second, 
        /// the speed will be at 20% of its starting value.
        /// </summary>
        [Tunable, TunableComment("This value controls the exponential decay applied to zoom velocity after user input stops.  It should be between 0 and 1.  For example a value of 0.2 means that after one second, the speed will be at 20% of its starting value.")]
        public static float kMainDecayZoom = 0.01f;

        /// <summary>
        /// Default pitch when entering build/buy mode.
        /// </summary>
        [Tunable, TunableComment("Default pitch when entering build/buy mode.")]
        public static float kMainDefaultBuildBuyPitchDegrees = -45f;

        /// <summary>
        /// Default zoom level when entering build/buy mode.
        /// </summary>
        [Tunable, TunableComment("Default zoom level when entering build/buy mode.")]
        public static float kMainDefaultBuildBuyZoom = 30f;

        /// <summary>
        /// Default camera field of view angle?
        /// </summary>
        [Tunable]
        public static float kMainFOVDegrees = 45f;

        /// <summary>
        /// Damping constant for the spring used to smooth out camera's vertical motion
        /// </summary>
        [Tunable, TunableComment("Damping constant for the spring used to smooth out camera's vertical motion")]
        public static float kMainHeightDampingConstant = 10f;

        /// <summary>
        /// Damping constant for the spring used to smooth out camera's vertical motion when in follow mod
        /// </summary>
        [Tunable, TunableComment("Damping constant for the spring used to smooth out camera's vertical motion when in follow mode")]
        public static float kMainHeightDampingConstantFollow = 10f;

        /// <summary>
        /// Spring constant for the spring used to smooth out camera's vertical motion
        /// </summary>
        [TunableComment("Spring constant for the spring used to smooth out camera's vertical motion"), Tunable]
        public static float kMainHeightSpringConstant = 30f;

        /// <summary>
        /// Spring constant for the spring used to smooth out camera's vertical motion when in follow mode
        /// </summary>
        [Tunable, TunableComment("Spring constant for the spring used to smooth out camera's vertical motion when in follow mode")]
        public static float kMainHeightSpringConstantFollow = 40f;

        /// <summary>
        /// Minimum velocity clamp for vertical ascent/descent (m/s).
        /// Used to limit slow vertical creep of the camera when it nears its target.
        /// </summary>
        [TunableComment("Minimum velocity clamp for vertical ascent/descent (m/s).  Used to limit slow vertical creep of the camera when it nears its target."), Tunable]
        public static float kMainHeightSpringMinClamp = 0.3f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainKeyboardMoveBoostSpeed = 10f;

        /// <summary>
        /// The scrolling speed for the keyboard
        /// </summary>
        [TunableComment("The scrolling speed for the keyboard"), Tunable]
        public static float kMainKeyboardMoveDefaultSpeed = 5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainKeyboardPitchBoostSpeed = 20f;

        /// <summary>
        /// How fast the camera rotates up and down using keyboard
        /// </summary>
        [TunableComment("How fast the camera rotates up and down using keyboard"), Tunable]
        public static float kMainKeyboardPitchDefaultSpeed = 6f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainKeyboardYawBoostSpeed = 40f;

        /// <summary>
        /// How fast the camera rotates side to side using keyboard
        /// </summary>
        [Tunable, TunableComment("How fast the camera rotates side to side using keyboard")]
        public static float kMainKeyboardYawDefaultSpeed = 10f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainKeyboardZoomInBoostSpeed = 8f;

        /// <summary>
        /// The zoom in speed for the keyboard
        /// </summary>
        [Tunable, TunableComment("The zoom in speed for the keyboard")]
        public static float kMainKeyboardZoomInDefaultSpeed = 3f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainKeyboardZoomOutBoostSpeed = 8f;

        /// <summary>
        /// The zoom out speed for the keyboard
        /// </summary>
        [TunableComment("The zoom out speed for the keyboard"), Tunable]
        public static float kMainKeyboardZoomOutDefaultSpeed = 3f;

        /// <summary>
        /// This value controls the length of the lerp from the sky target back to the ground target 
        /// when the user zooms while looking at the sky
        /// </summary>
        [Tunable, TunableComment("This value controls the length of the lerp from the sky target back to the ground target when the user zooms while looking at the sky")]
        public static float kMainLerpFromSkyDuration = 0.8f;

        /// <summary>
        /// Height reached by a long distance lerp covering minDistance.
        /// </summary>
        [Tunable, TunableComment("Height reached by a long distance lerp covering minDistance.")]
        public static float kMainLongDistanceHeightAtMinDistance = 100f;

        /// <summary>
        /// Controls the ease-in/out of the height during the period of descent.
        /// &gt; 1: ease-out (camera descends rapidly then flattens out); 
        ///    = 1: linear; 
        /// &lt; 1: ease-in (camera descends gradually, then picks up speed)
        /// </summary>
        [Tunable, TunableComment("Controls the ease-in/out of the height during the period of descent.  > 1: ease-out (camera descends rapidly then flattens out); = 1: linear; < 1: ease-in (camera descends gradually, then picks up speed)")]
        public static float kMainLongDistanceLerpEaseInExponentDown = 1f;

        /// <summary>
        /// Controls the ease-in/out of the height during the period of ascent.
        /// &gt; 1: ease-out (camera ascends rapidly then flattens out); 
        ///    = 1: linear; 
        /// &lt; 1: ease-in (camera ascends gradually, then picks up speed)
        /// </summary>
        [TunableComment("Controls the ease-in/out of the height during the period of ascent.  > 1: ease-out (camera ascends rapidly then flattens out); = 1: linear; < 1: ease-in (camera ascends gradually, then picks up speed)"), Tunable]
        public static float kMainLongDistanceLerpEaseInExponentUp = 1.5f;

        /// <summary>
        /// Meters by which the long distance lerp height increases for each meter beyond minDistance.
        /// </summary>
        [TunableComment("Meters by which the long distance lerp height increases for each meter beyond minDistance."), Tunable]
        public static float kMainLongDistanceLerpHeightIncreasePerMeter = 1f;

        /// <summary>
        /// Maximum height that can be achieved during long distance lerp.
        /// </summary>
        [TunableComment("Maximum height that can be achieved during long distance lerp."), Tunable]
        public static float kMainLongDistanceLerpMaxHeight = 300f;

        /// <summary>
        /// The minimum lerp distance needed to activate the long distance lerp.
        /// </summary>
        [Tunable, TunableComment("The minimum lerp distance needed to activate the long distance lerp.")]
        public static float kMainLongDistanceLerpMinDistance = 50f;

        /// <summary>
        /// Duration (in seconds) of a long distance lerp covering minDistance.
        /// </summary>
        [TunableComment("Duration (in seconds) of a long distance lerp covering minDistance."), Tunable]
        public static float kMainLongDistanceLerpTimeAtMinDistance = 1f;

        /// <summary>
        /// Seconds by which the long distance lerp duration increases for each meter beyond minDistance.
        /// </summary>
        [TunableComment("Seconds by which the long distance lerp duration increases for each meter beyond minDistance."), Tunable]
        public static float kMainLongDistanceLerpTimeIncreasePerMeter = 0.001f;

        /// <summary>
        /// Vertical velocity (m/s) of long distance lerp during descent.
        /// </summary>
        [TunableComment("Vertical velocity (m/s) of long distance lerp during descent."), Tunable]
        public static float kMainLongDistanceLerpVelocityDown = 100f;

        /// <summary>
        /// Vertical velocity (m/s) of long distance lerp during ascent.
        /// </summary>
        [Tunable, TunableComment("Vertical velocity (m/s) of long distance lerp during ascent.")]
        public static float kMainLongDistanceLerpVelocityUp = 200f;

        /// <summary>
        /// This defines how far down the camera can look at the minimum zoom distance
        /// </summary>
        [TunableComment("This defines how far down the camera can look at the minimum zoom distance"), Tunable]
        public static float kMainMaxAngleDown1 = -85f;


        [Tunable]
        public static float kMainMaxAngleDown2 = -85f;

        /// <summary>
        /// This defines how far down the camera can look at the maximum regular zoom distance
        /// </summary>
        [TunableComment("This defines how far down the camera can look at the maximum regular zoom distance"), Tunable]
        public static float kMainMaxAngleDown3 = -85f;

        /// <summary>
        /// This defines how far down the camera can look at the map view zoom distance
        /// </summary>
        [Tunable, TunableComment("This defines how far down the camera can look at the map view zoom distance")]
        public static float kMainMaxAngleDown4 = -85f;

        /// <summary>
        /// This defines how far up the camera can look at the minimum zoom distance
        /// </summary>
        [TunableComment("This defines how far up the camera can look at the minimum zoom distance"), Tunable]
        public static float kMainMaxAngleUp1 = 85f;


        [Tunable]
        public static float kMainMaxAngleUp2 = 55f;

        /// <summary>
        /// This defines how far up the camera can look at the maximum regular zoom distance
        /// </summary>
        [Tunable, TunableComment("This defines how far up the camera can look at the maximum regular zoom distance")]
        public static float kMainMaxAngleUp3 = 15f;

        /// <summary>
        /// This defines how far up the camera can look at the map view zoom distance
        /// </summary>
        [TunableComment("This defines how far up the camera can look at the map view zoom distance"), Tunable]
        public static float kMainMaxAngleUp4 = 10f;

        /// <summary>
        /// The tether distance for lots at the max zoom level
        /// </summary>
        [Tunable, TunableComment("The tether distance for lots at the max zoom level")]
        public static float kMainMaxTetherDistanceLot = 50f;

        /// <summary>
        /// The tether distance for sims at the max zoom level
        /// </summary>
        [TunableComment("The tether distance for sims at the max zoom level"), Tunable]
        public static float kMainMaxTetherDistanceSim = 50f;

        /// <summary>
        /// How far from the max zoom limit does the zoom speed start slowing to a stop
        /// </summary>
        [TunableComment("How far from the max zoom limit does the zoom speed start slowing to a stop"), Tunable]
        public static float kMainMaxZoomStopDistance = 150f;

        [Tunable]
        public static float kMainMinPosHeight = 0.5f;

        /// <summary>
        /// The tether distance for lots at the min zoom level
        /// </summary>
        [TunableComment("The tether distance for lots at the min zoom level"), Tunable]
        public static float kMainMinTetherDistanceLot = 5f;

        /// <summary>
        /// The tether distance for sims at the min zoom level
        /// </summary>
        [Tunable, TunableComment("The tether distance for sims at the min zoom level")]
        public static float kMainMinTetherDistanceSim = 5f;

        /// <summary>
        /// How far from the min zoom limit does the zoom speed start slowing to a stop
        /// </summary>
        [TunableComment("How far from the min zoom limit does the zoom speed start slowing to a stop"), Tunable]
        public static float kMainMinZoomStopDistance = 1.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainMouseMoveBoostSpeed = 0.05f;

        /// <summary>
        /// The scrolling speed for the mouse
        /// </summary>
        [TunableComment("The scrolling speed for the mouse"), Tunable]
        public static float kMainMouseMoveDefaultSpeed = 0.025f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainMousePitchBoostSpeed = 0.1f;

        /// <summary>
        /// How fast the camera rotates up and down using mouse
        /// </summary>
        [Tunable, TunableComment("How fast the camera rotates up and down using mouse")]
        public static float kMainMousePitchDefaultSpeed = 0.03f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainMouseYawBoostSpeed = 0.2f;

        /// <summary>
        /// How fast the camera rotates side to side using mouse
        /// </summary>
        [TunableComment("How fast the camera rotates side to side using mouse"), Tunable]
        public static float kMainMouseYawDefaultSpeed = 0.05f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainMouseZoomInBoostSpeed = 4f;

        /// <summary>
        /// The zoom in speed for the mouse
        /// </summary>
        [TunableComment("The zoom in speed for the mouse"), Tunable]
        public static float kMainMouseZoomInDefaultSpeed = 1.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainMouseZoomOutBoostSpeed = 4f;

        /// <summary>
        /// The zoom out speed for the mouse
        /// </summary>
        [TunableComment("The zoom out speed for the mouse"), Tunable]
        public static float kMainMouseZoomOutDefaultSpeed = 1.5f;

        /// <summary>
        /// This is the maximum allowable pitch (how far up the camera is looking) 
        /// before switching to look at sky mode at the minimum zoom distance
        /// </summary>
        [TunableComment("This is the maximum allowable pitch (how far up the camera is looking) before switching to look at sky mode at the minimum zoom distance"), Tunable]
        public static float kMainPitch1 = 0f;

        [Tunable]
        public static float kMainPitch2 = -10f;

        /// <summary>
        /// This is the maximum allowable pitch (how far up the camera is looking) 
        /// before switching to look at sky mode at the maximum regular zoom distance
        /// </summary>
        [Tunable, TunableComment("This is the maximum allowable pitch (how far up the camera is looking) before switching to look at sky mode at the maximum regular zoom distance")]
        public static float kMainPitch3 = -30f;

        /// <summary>
        /// This is the maximum allowable pitch (how far up the camera is looking) 
        /// before switching to look at sky mode at the map view zoom distance
        /// </summary>
        [TunableComment("This is the maximum allowable pitch (how far up the camera is looking) before switching to look at sky mode at the map view zoom distance"), Tunable]
        public static float kMainPitch4 = -50f;

        /// <summary>
        /// Controls the amount of time the camera takes to stop at the edge of the routable region
        /// </summary>
        [TunableComment("Controls the amount of time the camera takes to stop at the edge of the routable region"), Tunable]
        public static float kMainRoutableEdgeStopTime = 0.25f;

        [Tunable]
        public static float kMainTargetHeight = 1.75f;

        /// <summary><para>
        /// Ratio used for taking the weighted average between the camera target and position height, 
        /// when the position is over a lot.  If this average height is less than the terrain height
        /// </para><para>
        /// underneath the camera position, the position and target are shifted up by the difference.
        /// Must be between 0 and 1.  If 0, this is the old behavior
        /// </para><para>
        /// where the target's height is unaffected by the terrain under the position.  
        /// If 1, the target's height can never be less than the terrain height under
        /// </para><para>
        /// the position.
        /// </para></summary>
        [Tunable, TunableComment("Ratio used for taking the weighted average between the camera target and position height, when the position is over a lot.  If this average height is less than the terrain height\r\nunderneath the camera position, the position and target are shifted up by the difference.  Must be between 0 and 1.  If 0, this is the old behavior\r\nwhere the target's height is unaffected by the terrain under the position.  If 1, the target's height can never be less than the terrain height under\r\nthe position.")]
        public static float kMainTargetToPositionHeightRatioLot = 1f;

        /// <summary><para>
        /// Ratio used for taking the weighted average between the camera target and position height, 
        /// when the position is over world terrain.  If this average height is less than the terrain height
        /// </para><para>
        /// underneath the camera position, the position and target are shifted up by the difference.  
        /// Must be between 0 and 1.  If 0, this is the old behavior
        /// </para><para>
        /// where the target's height is unaffected by the terrain under the position.  
        /// If 1, the target's height can never be less than the terrain height under
        /// </para><para>
        /// the position.
        /// </para></summary>
        [TunableComment("Ratio used for taking the weighted average between the camera target and position height, when the position is over world terrain.  If this average height is less than the terrain height\r\nunderneath the camera position, the position and target are shifted up by the difference.  Must be between 0 and 1.  If 0, this is the old behavior\r\nwhere the target's height is unaffected by the terrain under the position.  If 1, the target's height can never be less than the terrain height under\r\nthe position."), Tunable]
        public static float kMainTargetToPositionHeightRatioTerrain = 0.6f;

        /// <summary>
        /// How far from the tether distance does the camera start slowing down (when tethered to lot)
        /// </summary>
        [TunableComment("How far from the tether distance does the camera start slowing down (when tethered to lot)"), Tunable]
        public static float kMainTetherSlowDownDistanceLot = 2f;

        /// <summary>
        /// How far from the tether distance does the camera start slowing down (when tethered to sim)
        /// </summary>
        [TunableComment("How far from the tether distance does the camera start slowing down (when tethered to sim)"), Tunable]
        public static float kMainTetherSlowDownDistanceSim = 2f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainUIMoveBoostSpeed = 5f;

        /// <summary>
        /// The scrolling speed for the UI
        /// </summary>
        [TunableComment("The scrolling speed for the UI"), Tunable]
        public static float kMainUIMoveDefaultSpeed = 2.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainUIPitchBoostSpeed = 10f;

        /// <summary>
        /// How fast the camera rotates up and down using UI
        /// </summary>
        [Tunable, TunableComment("How fast the camera rotates up and down using UI")]
        public static float kMainUIPitchDefaultSpeed = 3f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [Tunable, TunableComment("This value is added to default when shift is held down to get the speed when shift is held down")]
        public static float kMainUIYawBoostSpeed = 20f;

        /// <summary>
        /// How fast the camera rotates side to side using UI
        /// </summary>
        [Tunable, TunableComment("How fast the camera rotates side to side using UI")]
        public static float kMainUIYawDefaultSpeed = 5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainUIZoomInBoostSpeed = 4f;

        /// <summary>
        /// The zoom in speed for the UI
        /// </summary>
        [TunableComment("The zoom in speed for the UI"), Tunable]
        public static float kMainUIZoomInDefaultSpeed = 1.5f;

        /// <summary>
        /// This value is added to default when shift is held down to get the speed when shift is held down
        /// </summary>
        [TunableComment("This value is added to default when shift is held down to get the speed when shift is held down"), Tunable]
        public static float kMainUIZoomOutBoostSpeed = 4f;

        /// <summary>
        /// The zoom out speed for the UI
        /// </summary>
        [Tunable, TunableComment("The zoom out speed for the UI")]
        public static float kMainUIZoomOutDefaultSpeed = 1.5f;

        /// <summary>
        /// The movement velocity is multiplied by this amount when at the farthest zoom level
        /// </summary>
        [Tunable, TunableComment("The movement velocity is multiplied by this amount when at the farthest zoom level")]
        public static float kMainVelTransScale = 50f;

        /// <summary>
        /// The zoom velocity is multiplied by this amount when at the farthest zoom level
        /// </summary>
        [TunableComment("The zoom velocity is multiplied by this amount when at the farthest zoom level"), Tunable]
        public static float kMainVelZoomScale = 100f;

        /// <summary>
        /// SunsetValley: This defines the minimum zoom distance
        /// </summary>
        [Tunable, TunableComment("SunsetValley: This defines the minimum zoom distance")]
        public static float kMainZoom1 = 2.5f;

        /// <summary>
        /// China: This defines the minimum zoom distance
        /// </summary>
        [TunableComment("China: This defines the minimum zoom distance"), Tunable]
        public static float kMainZoom1China = 2.5f;

        /// <summary>
        /// Egypt: This defines the minimum zoom distance
        /// </summary>
        [TunableComment("Egypt: This defines the minimum zoom distance"), Tunable]
        public static float kMainZoom1Egypt = 2.5f;

        /// <summary>
        /// France: This defines the minimum zoom distance
        /// </summary>
        [Tunable, TunableComment("France: This defines the minimum zoom distance")]
        public static float kMainZoom1France = 2.5f;

        [Tunable]
        public static float kMainZoom2 = 7f;

        [Tunable]
        public static float kMainZoom2China = 7f;

        [Tunable]
        public static float kMainZoom2Egypt = 7f;

        [Tunable]
        public static float kMainZoom2France = 7f;

        /// <summary>
        /// This defines be the maximum zoom distance before going to map view
        /// </summary>
        [Tunable, TunableComment("This defines be the maximum zoom distance before going to map view")]
        public static float kMainZoom3 = 30f;

        /// <summary>
        /// China: This defines be the maximum zoom distance before going to map view
        /// </summary>
        [Tunable, TunableComment("China: This defines be the maximum zoom distance before going to map view")]
        public static float kMainZoom3China = 30f;

        /// <summary>
        /// Egypt: This defines be the maximum zoom distance before going to map view
        /// </summary>
        [TunableComment("Egypt: This defines be the maximum zoom distance before going to map view"), Tunable]
        public static float kMainZoom3Egypt = 30f;

        /// <summary>
        /// France: This defines be the maximum zoom distance before going to map view
        /// </summary>
        [TunableComment("France: This defines be the maximum zoom distance before going to map view"), Tunable]
        public static float kMainZoom3France = 30f;

        /// <summary>
        /// This defines be the map view zoom distance
        /// </summary>
        [TunableComment("This defines be the map view zoom distance"), Tunable]
        public static float kMainZoom4 = 350f;

        /// <summary>
        /// China: This defines be the map view zoom distance
        /// </summary>
        [TunableComment("China: This defines be the map view zoom distance"), Tunable]
        public static float kMainZoom4China = 350f;

        /// <summary>
        /// Egypt: This defines be the map view zoom distance
        /// </summary>
        [Tunable, TunableComment("Egypt: This defines be the map view zoom distance")]
        public static float kMainZoom4Egypt = 350f;

        /// <summary>
        /// France: This defines be the map view zoom distance
        /// </summary>
        [TunableComment("France: This defines be the map view zoom distance"), Tunable]
        public static float kMainZoom4France = 350f;

        /// <summary>
        /// Loads the camera tuning values
        /// from either the Sims3.Gameplay.Core.Camera XML Resource within GameplayData.package,
        /// or the CameraOverrides.xml file in the same directory as the application.
        /// </summary>
        public static void InitializeTuningData()
        {
            XmlDocument doc = new XmlDocument();
            ResourceKey key = ResourceKey.CreateXMLKey("Sims3.Gameplay.Core.Camera", 0);
            string xmlText = Sims3.CSHost.ResourceMgr.LoadXMLStr(new Sims3.CSHost.ResourceKey(key.TypeId, key.GroupId, key.InstanceId));
            if (!string.IsNullOrEmpty(xmlText))
            {
                doc.LoadXml(xmlText);
                if (doc != null)
                {
                    InitializeTuningData(doc);
                }
                string xmlFile = string.Concat(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), 
                    Path.DirectorySeparatorChar, "CameraOverrides.xml");
                if (File.Exists(xmlFile))
                {
                    doc.Load(xmlFile);
                    if (doc != null)
                    {
                        InitializeTuningData(doc);
                    }
                }
            }
        }

        private static void InitializeTuningData(XmlDocument doc)
        {
            Type type = typeof(CameraTuning);
            XmlNodeList elementsByTagName = doc.GetElementsByTagName("Current_Tuning");
            if (elementsByTagName.Count != 0)
            {
                foreach (XmlNode node in elementsByTagName[0].ChildNodes)
                {
                    if (node is XmlElement)
                    {
                        XmlElement element = node as XmlElement;
                        try
                        {
                            FieldInfo field = type.GetField(element.Name);
                            if (field != null)
                            {
                                string attribute = element.GetAttribute("value");
                                Type fieldType = field.FieldType;
                                object value = null;
                                if (fieldType == typeof(float))
                                {
                                    value = Convert.ToSingle(attribute);
                                }
                                else if (fieldType == typeof(int))
                                {
                                    value = Convert.ToInt32(attribute);
                                }
                                else if (fieldType == typeof(uint))
                                {
                                    value = Convert.ToUInt32(attribute);
                                }
                                else if (fieldType == typeof(long))
                                {
                                    value = Convert.ToInt64(attribute);
                                }
                                else if (fieldType == typeof(ulong))
                                {
                                    value = Convert.ToUInt64(attribute);
                                }
                                else if (fieldType == typeof(string))
                                {
                                    value = attribute;
                                }
                                else if (fieldType == typeof(bool))
                                {
                                    value = (bool)Convert.ToBoolean(attribute);
                                }
                                type.GetField(element.Name).SetValue(null, value);
                            }
                            continue;
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private const float Deg2Rad = 0.01745329f;

        /// <summary>
        /// Applies the current camera tuning values 
        /// to the game engine's scene manager's cameras.
        /// </summary>
        /// <param name="type">Camera Controller Type</param>
        /// <param name="worldName">World Type</param>
        public static void Load(Sims3.CSHost.Camera.CameraControllerType type, WorldName worldName)
        {
            switch (type)
            {
                case Sims3.CSHost.Camera.CameraControllerType.WorldEdit:
                    bool kFlyConstantHeight = CameraTuning.kFlyConstantHeight;
                    float[] vars = new float[]
                    { 
                        kFlyMoveDefaultSpeed, 
                        kFlyMoveBoostSpeed, 
                        kFlyZoomDefaultSpeed, 
                        kFlyZoomBoostSpeed, 
                        kFlyTurnDefaultSpeed * Deg2Rad, 
                        kFlyTurnBoostSpeed * Deg2Rad, 
                        kFlyMinZoom, 
                        kFlyMaxZoom 
                    };
                    Sims3.CSHost.Camera.LoadTuning((uint)type, vars, kFlyConstantHeight);
                    break;
                case Sims3.CSHost.Camera.CameraControllerType.InGame:
                    LoadInGame(worldName);
                    break;
            }
        }

        private static void LoadInGame(WorldName worldName)
        {
            float[] vars = new float[0x5f];
            bool kFlyConstantHeight = kMainAllowLookAtSky;
            vars[0x00] = kMainKeyboardMoveDefaultSpeed;
            vars[0x01] = kMainKeyboardMoveBoostSpeed;
            vars[0x02] = kMainMouseMoveDefaultSpeed;
            vars[0x03] = kMainMouseMoveBoostSpeed;
            vars[0x04] = kMainControllerMoveDefaultSpeed;
            vars[0x05] = kMainControllerMoveBoostSpeed;
            vars[0x06] = kMainUIMoveDefaultSpeed;
            vars[0x07] = kMainUIMoveBoostSpeed;
            vars[0x08] = kMainKeyboardZoomInDefaultSpeed;
            vars[0x09] = kMainKeyboardZoomInBoostSpeed;
            vars[0x0a] = kMainMouseZoomInDefaultSpeed;
            vars[0x0b] = kMainMouseZoomInBoostSpeed;
            vars[0x0c] = kMainControllerZoomInDefaultSpeed;
            vars[0x0d] = kMainControllerZoomInBoostSpeed;
            vars[0x0e] = kMainUIZoomInDefaultSpeed;
            vars[0x0f] = kMainUIZoomInBoostSpeed;
            vars[0x10] = kMainKeyboardZoomOutDefaultSpeed;
            vars[0x11] = kMainKeyboardZoomOutBoostSpeed;
            vars[0x12] = kMainMouseZoomOutDefaultSpeed;
            vars[0x13] = kMainMouseZoomOutBoostSpeed;
            vars[0x14] = kMainControllerZoomOutDefaultSpeed;
            vars[0x15] = kMainControllerZoomOutBoostSpeed;
            vars[0x16] = kMainUIZoomOutDefaultSpeed;
            vars[0x17] = kMainUIZoomOutBoostSpeed;
            vars[0x18] = (float)(kMainKeyboardPitchDefaultSpeed * Deg2Rad);
            vars[0x19] = (float)(kMainKeyboardPitchBoostSpeed * Deg2Rad);
            vars[0x1a] = (float)(kMainMousePitchDefaultSpeed * Deg2Rad);
            vars[0x1b] = (float)(kMainMousePitchBoostSpeed * Deg2Rad);
            vars[0x1c] = (float)(kMainControllerPitchDefaultSpeed * Deg2Rad);
            vars[0x1d] = (float)(kMainControllerPitchBoostSpeed * Deg2Rad);
            vars[0x1e] = (float)(kMainUIPitchDefaultSpeed * Deg2Rad);
            vars[0x1f] = (float)(kMainUIPitchBoostSpeed * Deg2Rad);
            vars[0x20] = (float)(kMainKeyboardYawDefaultSpeed * Deg2Rad);
            vars[0x21] = (float)(kMainKeyboardYawBoostSpeed * Deg2Rad);
            vars[0x22] = (float)(kMainMouseYawDefaultSpeed * Deg2Rad);
            vars[0x23] = (float)(kMainMouseYawBoostSpeed * Deg2Rad);
            vars[0x24] = (float)(kMainControllerYawDefaultSpeed * Deg2Rad);
            vars[0x25] = (float)(kMainControllerYawBoostSpeed * Deg2Rad);
            vars[0x26] = (float)(kMainUIYawDefaultSpeed * Deg2Rad);
            vars[0x27] = (float)(kMainUIYawBoostSpeed * Deg2Rad);
            vars[0x28] = kMainDecayTrans;
            vars[0x29] = kMainDecayRot;
            vars[0x2a] = kMainDecayZoom;
            vars[0x2b] = kMainVelTransScale;
            vars[0x2c] = kMainVelZoomScale;
            vars[0x2d] = kMainTargetHeight;
            vars[0x2e] = kMainMinPosHeight;
            vars[0x2f] = kMainLerpFromSkyDuration;
            vars[0x30] = kMainFOVDegrees;
            if (worldName > WorldName.RiverView)
            {
                if (worldName == WorldName.Egypt)
                {
                    vars[0x31] = kMainZoom1Egypt;
                    vars[0x32] = kMainZoom2Egypt;
                    vars[0x33] = kMainZoom3Egypt;
                    vars[0x34] = kMainZoom4Egypt;
                }
                else if (worldName == WorldName.China)
                {
                    vars[0x31] = kMainZoom1China;
                    vars[0x32] = kMainZoom2China;
                    vars[0x33] = kMainZoom3China;
                    vars[0x34] = kMainZoom4China;
                }
                else if (worldName == WorldName.France)
                {
                    vars[0x31] = kMainZoom1France;
                    vars[0x32] = kMainZoom2France;
                    vars[0x33] = kMainZoom3France;
                    vars[0x34] = kMainZoom4France;
                }
                else
                {
                    vars[0x31] = kMainZoom1;
                    vars[0x32] = kMainZoom2;
                    vars[0x33] = kMainZoom3;
                    vars[0x34] = kMainZoom4;
                }
            }
            else
            {
                vars[0x31] = kMainZoom1;
                vars[0x32] = kMainZoom2;
                vars[0x33] = kMainZoom3;
                vars[0x34] = kMainZoom4;
            }
            vars[0x35] = kMainPitch1;
            vars[0x36] = kMainPitch2;
            vars[0x37] = kMainPitch3;
            vars[0x38] = kMainPitch4;
            vars[0x39] = kMainMaxAngleUp1;
            vars[0x3a] = kMainMaxAngleUp2;
            vars[0x3b] = kMainMaxAngleUp3;
            vars[0x3c] = kMainMaxAngleUp4;
            vars[0x3d] = kMainMaxAngleDown1;
            vars[0x3e] = kMainMaxAngleDown2;
            vars[0x3f] = kMainMaxAngleDown3;
            vars[0x40] = kMainMaxAngleDown4;
            vars[0x41] = kMainMinTetherDistanceSim;
            vars[0x42] = kMainMaxTetherDistanceSim;
            vars[0x43] = kMainMinTetherDistanceLot;
            vars[0x44] = kMainMaxTetherDistanceLot;
            vars[0x45] = kMainTetherSlowDownDistanceSim;
            vars[0x46] = kMainTetherSlowDownDistanceLot;
            vars[0x47] = kMainHeightSpringConstant;
            vars[0x48] = kMainHeightDampingConstant;
            vars[0x49] = kMainHeightSpringConstantFollow;
            vars[0x4a] = kMainHeightDampingConstantFollow;
            vars[0x4b] = kMainMinZoomStopDistance;
            vars[0x4c] = kMainMaxZoomStopDistance;
            vars[0x4d] = kMainRoutableEdgeStopTime;
            vars[0x4e] = kMainLongDistanceLerpMinDistance;
            vars[0x4f] = kMainLongDistanceLerpTimeAtMinDistance;
            vars[0x50] = kMainLongDistanceLerpTimeIncreasePerMeter;
            vars[0x51] = kMainLongDistanceHeightAtMinDistance;
            vars[0x52] = kMainLongDistanceLerpHeightIncreasePerMeter;
            vars[0x53] = kMainLongDistanceLerpMaxHeight;
            vars[0x54] = kMainLongDistanceLerpVelocityUp;
            vars[0x55] = kMainLongDistanceLerpVelocityDown;
            vars[0x56] = kMainLongDistanceLerpEaseInExponentUp;
            vars[0x57] = kMainLongDistanceLerpEaseInExponentDown;
            vars[0x58] = kMainTargetToPositionHeightRatioTerrain;
            vars[0x59] = kMainTargetToPositionHeightRatioLot;
            vars[0x5a] = kMainHeightSpringMinClamp;
            vars[0x5b] = kMainDefaultBuildBuyZoom;
            vars[0x5c] = kMainDefaultBuildBuyPitchDegrees;
            vars[0x5d] = kDefaultLerpDuration;
            vars[0x5e] = kLotBoundaryTolerance;
            Sims3.CSHost.Camera.LoadTuning((uint)Sims3.CSHost.Camera.CameraControllerType.InGame, vars, kFlyConstantHeight);
        }
    }
}
