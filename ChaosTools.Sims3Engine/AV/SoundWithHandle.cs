using System;
using System.Collections.Generic;
using System.Text;
using Sims3.SimIFace;

namespace ChaosTools.Sims3Engine.AV
{
    /// <summary>
    /// Groups that game sounds can belong to,
    /// which are used to control their behavior
    /// during changes in the game's speed.
    /// </summary>
    /// <remarks>
    /// Copied from <see cref="T:Sims3.Gameplay.Core.AudioGroup"/>,
    /// their descriptions are based on the code in
    /// <see cref="M:Sims3.Gameplay.Core.AudioManager.GameSpeedChangedCallback(
    /// Sims3.SimIFace.Gameflow.GameSpeed,System.Boolean)"/>,
    /// in which only GamePause and Vox are paused with game pauses,
    /// and only Vox and Sfx are pitch shifted with game speed changes.
    /// </remarks>
    public enum AudioGroup : uint
    {
        /// <summary>
        /// Ambient sounds that play in the background on continuous loops
        /// and shouldn't be affected by game speed changes.
        /// </summary>
        Ambience = 0x5174939,
        /// <summary>
        /// Sounds that should be paused with game pauses.
        /// </summary>
        GamePause = 0x280aa52f,
        /// <summary>
        /// Sounds invoked by visual effects
        /// that should have their pitch changed with game speed changes.
        /// </summary>
        Sfx = 0x17705d3e,
        /// <summary>
        /// Sounds invoked by visual effects
        /// that shouldn't be affect by game speed changes.
        /// </summary>
        SfxNoPitch = 0x57a4661e,
        /// <summary>
        /// Sim voice sounds that are paused with game pauses
        /// and pitch shifted with game speed changes.
        /// </summary>
        Vox = 0x20681cd4
    }

    /// <summary>
    /// Flags used to set a sound's properties when it is started.
    /// </summary>
    /// <remarks>
    /// Copied from <see cref="T:Sims3.SimIFace.Audio.StartFlags"/>.
    /// </remarks>
    [Flags]
    public enum SoundStartFlags : uint
    {
        /// <summary>
        /// The sound will not have any properties initially set.
        /// </summary>
        None,
        /// <summary>
        /// The sound will be set to play in a continuous loop.
        /// </summary>
        Looped,
        /// <summary>
        /// The sound will be set to be audible 
        /// at any distance from its source position.
        /// </summary>
        IgnoreMaxDistance
    }

    /// <summary>
    /// Reasons why the playback of a sound resource stopped.
    /// </summary>
    /// <remarks>
    /// Copied from <see cref="T:Sims3.SimIFace.Audio.StopReason"/>.
    /// </remarks>
    public enum SoundStopReason : uint
    {
        /// <summary>
        /// Sound playback completed
        /// </summary>
        Completed,
        /// <summary>
        /// Sound playback aborted
        /// </summary>
        Aborted,
        /// <summary>
        /// Sound playback stop requested
        /// </summary>
        Requested,
        /// <summary>
        /// Sound playback stop internally requested
        /// </summary>
        RequestedInternal,
        /// <summary>
        /// Sound playback stopped due to error
        /// </summary>
        Error,
        /// <summary>
        /// Maximum value for sound playback stop reasons
        /// </summary>
        Max
    }

    /// <summary>
    /// This class is basically just the <see cref="T:Sims3.SimIFace.Sound"/> class
    /// with the native sound handle exposed to the user for equality testing.
    /// </summary>
    /// <remarks><para>
    /// This class is necessary because of how it delays its finalization in the GC.
    /// Working with the sound handle directly causes the App.Update function
    /// to throw AccessViolation and EngineExecution exceptions.
    /// </para><para>
    /// It is most likely because the <see cref="T:Sims3.SimIFace.Sound.SoundFinished"/>
    /// delegate is marshalled as a COM Interface, so its memory is shared between
    /// the managed environment and the unmanaged game engine,
    /// and if the delegate is garbage collected before the sound stops,
    /// then when it does stop game engine will try to call a reference 
    /// to null or invalid data on the next App.Update, and an exception will be thrown.
    /// </para></remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class SoundWithHandle : Sound, IEquatable<SoundWithHandle>
    {
        /// <summary>
        /// Creates a new sound without a name.
        /// </summary>
        protected SoundWithHandle() : base() { }
        /// <summary>
        /// Creates a new sound with the given name, 
        /// which will be FNV-64 hashed into instance ID 
        /// of the AUDT resource that will be played by the game engine.
        /// </summary>
        /// <param name="name">The unique name 
        /// of the sound resource to be played.</param>
        public SoundWithHandle(string name) : base(name) { }

        #region Properties
        /// <summary>
        /// The current sound's native handle created and used by 
        /// the functions of <see cref="T:Sims3.SimIFace.Audio"/>.
        /// </summary>
        public uint Handle { get { return this.mHandle; } }
        /// <summary>
        /// Whether or not the current sound is set to continuously loop.
        /// </summary>
        public bool Looping { get { return this.mbLooping; } }
        /// <summary>
        /// The flags the current sound was started with.
        /// </summary>
        public SoundStartFlags StartFlags { get { return (SoundStartFlags)this.mStartFlags; } }
        /// <summary>
        /// Returns true if the current sound has already been disposed by either
        /// <see cref="M:Sims3.SimIFace.Sound.Dispose"/> or its destructor.
        /// </summary>
        public bool HasBeenDisposed { get { return this.mDisposed; } }
        /// <summary>
        /// Gets the value of a specific sound property that was set earlier 
        /// for the current sound using the function 
        /// <see cref="M:Sims3.SimIFace.Sound.SetProperty(System.UInt32,System.Float)"/>.
        /// </summary>
        /// <param name="prop">The identifier of the sound property.</param>
        /// <param name="value">The current value of the specified sound property, 
        /// which is set to <c>0</c> if the property wasn't set earlier.</param>
        /// <returns>true if the specific sound property was set earlier
        /// and its value is successfully retrieved; false otherwise</returns>
        public bool GetProperty(uint prop, out float value)
        {
            if (base.mProperties == null)
            {
                value = 0f;
                return false;
            }
            return this.mProperties.TryGetValue(prop, out value);
        }
        #endregion
        /// <summary>
        /// Starts the current sound with the specified start flags.
        /// </summary>
        /// <param name="startFlags">Specific flags used to start the sound.</param>
        /// <returns>true if the sound was successfully started; 
        /// false otherwise</returns>
        public bool Start(SoundStartFlags startFlags)
        {
            return this.Start((uint)startFlags);
        }
        /// <summary>
        /// Starts the current sound with the specified start flags
        /// and sets the callback that is called when the current sound stops.
        /// </summary>
        /// <param name="startFlags">Specific flags used to start the sound.</param>
        /// <param name="finishedCallback">The delegate that will be called
        /// when the current sound stops playing.</param>
        /// <returns>true if the sound was successfully started; 
        /// false otherwise</returns>
        /// <remarks>
        /// The <see cref="T:Sims3.SimIFace.Sound.SoundFinished"/> instance 
        /// given to this function will be kept in the scope of this class 
        /// and prevented from being garbaged collect until it has been called
        /// by the unmanaged game engine, in order to prevent an access violation.
        /// </remarks>
        public bool Start(SoundStartFlags startFlags, SoundFinished finishedCallback)
        {
            return this.Start((uint)startFlags, finishedCallback);
        }

        /*/// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/>
        /// is equal to the current sound.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/>
        /// to compare with the current sound.</param>
        /// <returns>true if the specified <see cref="T:System.Object"/>
        /// is equal to the current sound; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SoundWithHandle)
                return this.Equals(obj as SoundWithHandle);
            else
                return base.Equals(obj);
        }/**/
        /// <summary>
        /// Tests whether or not this sound's name and native handle
        /// are equal to those of the given sound.
        /// </summary>
        /// <param name="other">The sound to test for equality with.</param>
        /// <returns>True if the sound names and native handles are equal,
        /// False if they are not.</returns>
        public bool Equals(SoundWithHandle other)
        {
            return this.mHandle == other.mHandle &&
                this.mName == other.mName;
        }
        /*/// <summary>
        /// Returns the combined hash codes of 
        /// the native pointer and the name of
        /// the current sound.
        /// </summary>
        /// <returns>A hash code for the current sound.</returns>
        /// <remarks>The hash code combining algorithm was copied from
        /// <see cref="M:System.Tuple.CombineHashCodes(System.Int32,System.Int32)"/>
        /// in the .NET 4.0 Framework.
        /// </remarks>
        public override int GetHashCode()
        {
            int handleHash = this.mHandle.GetHashCode();
            return ((handleHash << 5) + handleHash) ^ this.mName.GetHashCode();
            //return (*((int*)this.mHandle) << 5 + *((int*)this.mHandle)) ^ this.mName.GetHashCode();
        }/**/
        /// <summary>
        /// Returns the name of the sound followed by 
        /// its native handle as a hex string.
        /// </summary>
        /// <returns>A string of the sound's name and handle.</returns>
        public override string ToString()
        {
            return string.Format("{0} (0x{1:X8})", this.mName, this.mHandle);
        }
    }
}
