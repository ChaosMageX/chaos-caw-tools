using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using ScriptCore;
using Sims3.SimIFace;

namespace ChaosTools.Sims3Engine
{
    /// <summary><para>
    /// This class is a re-implementation of the <see cref="T:ScriptCore.CacheManager"/> class
    /// in ScriptCore.dll, because that class is internal.
    /// </para><para>
    /// It is strongly suggested that you use the instance of this class available from
    /// <see cref="P:ChaosTools.Sims3Engine.ScriptCoreManager.CacheManager"/>,
    /// </para><para>
    /// rather than creating your own instance that resets the App Domain Data.
    /// </para></summary>
    public class CacheManager : ICacheManager
    {
        private class CacheSignature
        {
            private int mAssemblyCount;
            private ulong mAssemblySignatures;
            private ulong mSourceDataHash;
            private ulong mSourceDataSize;
            private int mSourceRecordCount;

            public override bool Equals(object o)
            {
                CacheSignature signature = o as CacheSignature;
                if (signature == null)
                {
                    return false;
                }
                return (this.mAssemblyCount == signature.mAssemblyCount) &&
                    (this.mAssemblySignatures == signature.mAssemblySignatures) &&
                    (this.mSourceDataHash == signature.mSourceDataHash) &&
                    (this.mSourceDataSize == signature.mSourceDataSize) &&
                    (this.mSourceRecordCount == signature.mSourceRecordCount);
            }

            public override int GetHashCode()
            {
                return this.mAssemblyCount +
                    this.mAssemblySignatures.GetHashCode() +
                    this.mSourceDataHash.GetHashCode() +
                    this.mSourceDataSize.GetHashCode() +
                    this.mSourceRecordCount;
            }

            public bool Init()
            {
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                this.mAssemblyCount = assemblies.Length;
                this.mAssemblySignatures = 0L;
                foreach (Assembly assembly in assemblies)
                {
                    IEnumerator hostEnumerator = assembly.Evidence.GetHostEnumerator();
                    byte[] buffer = null;
                    while (hostEnumerator.MoveNext())
                    {
                        System.Security.Policy.Hash current = hostEnumerator.Current as System.Security.Policy.Hash;
                        if (current != null)
                        {
                            buffer = current.MD5;
                            break;
                        }
                    }
                    if (buffer != null)
                    {
                        this.mAssemblySignatures += BitConverter.ToUInt64(buffer, 0) + BitConverter.ToUInt64(buffer, 8);
                    }
                }
                if (!CacheManager.CacheManager_ReadDatabaseChecksum(CacheManager.kDatabaseName, out this.mSourceDataHash, out this.mSourceDataSize, out this.mSourceRecordCount))
                {
                    return false;
                }
                return true;
            }

            public bool Read(byte[] data)
            {
                try
                {
                    using (FastStreamReader reader = new FastStreamReader(data))
                    {
                        if (reader.ReadInt32() != 1)
                        {
                            return false;
                        }
                        this.mAssemblyCount = reader.ReadInt32();
                        this.mAssemblySignatures = reader.ReadUInt64();
                        this.mSourceDataHash = reader.ReadUInt64();
                        this.mSourceDataSize = reader.ReadUInt64();
                        this.mSourceRecordCount = reader.ReadInt32();
                    }
                }
                catch (System.IO.IOException)
                {
                    return false;
                }
                return true;
            }

            public byte[] Write()
            {
                using (FastStreamWriter writer = new FastStreamWriter())
                {
                    writer.Write(1);
                    writer.Write(this.mAssemblyCount);
                    writer.Write(this.mAssemblySignatures);
                    writer.Write(this.mSourceDataHash);
                    writer.Write(this.mSourceDataSize);
                    writer.Write(this.mSourceRecordCount);
                    return writer.ToArray();
                }
            }
        }

        /// <summary>
        /// The name of the database that stores the game cache.
        /// </summary>
        public static readonly string kDatabaseName = "GameplayData";
        private bool mIsCacheVerified;
        private bool mIsCachingEnabled;

        /// <summary>
        /// Creates a new CacheManager instance and adds it to the App Domain data
        /// so that <see cref="T:Sims3.SimIFace.CacheManager"/> can use it.
        /// </summary>
        public CacheManager()
        {
            AppDomain.CurrentDomain.SetData("CacheManager", this);
        }

        [DllImport("Sims3Common")]
        private static extern void CacheManager_ClearCache();
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("Sims3Common")]
        private static extern bool CacheManager_IsCachingAllowed([MarshalAs(UnmanagedType.LPWStr)] string databaseName);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("Sims3Common")]
        private static extern bool CacheManager_ReadCachedData([MarshalAs(UnmanagedType.LPWStr)] string tagStr, [MarshalAs(UnmanagedType.SafeArray)] out byte[] data);
        [DllImport("Sims3Common")]
        private static extern uint CacheManager_ReadCachedDataAsStream([MarshalAs(UnmanagedType.LPWStr)] string tagStr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("Sims3Common")]
        internal static extern bool CacheManager_ReadDatabaseChecksum([MarshalAs(UnmanagedType.LPWStr)] string databaseName, out ulong checksum, out ulong dataSize, out int recordCount);
        [DllImport("Sims3Common")]
        private static extern void CacheManager_WriteCachedData([MarshalAs(UnmanagedType.LPWStr)] string tagStr, [MarshalAs(UnmanagedType.SafeArray)] byte[] data, uint length);
        [DllImport("Sims3Common")]
        private static extern void CacheManager_WriteCachedDataFromStream([MarshalAs(UnmanagedType.LPWStr)] string tagStr, uint streamHandle);
        
        private static object Deserialize(FastStreamReader streamReader)
        {
            using (PersistReader reader = new PersistReader())
            {
                bool enableTypeRemapping = Persist.EnableTypeRemapping;
                Persist.EnableTypeRemapping = false;
                bool requireAllPersistable = Persist.RequireAllPersistable;
                Persist.RequireAllPersistable = true;
                try
                {
                    reader.Load(streamReader, null);
                }
                finally
                {
                    Persist.EnableTypeRemapping = enableTypeRemapping;
                    Persist.RequireAllPersistable = requireAllPersistable;
                }
                return ((reader.Count > 0) ? reader[0] : null);
            }
        }

        /// <summary>
        /// Deserializes persisted script data, such as the data from a saved game file, 
        /// back into an instance of a Persistable class.
        /// </summary>
        /// <param name="data">The persisted script data</param>
        /// <returns>An instance of a Persistable class.</returns>
        public object Deserialize(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            using (FastStreamReader reader = new FastStreamReader(data))
            {
                return Deserialize(reader);
            }
        }

        /// <summary>
        /// Loads data that is stored in the game cache with the given tag.
        /// </summary>
        /// <param name="tag">A unique string that identifies the cached data to be loaded.</param>
        /// <returns>The raw data that was stored in the game cache.</returns>
        public byte[] LoadRawTuningData(string tag)
        {
            byte[] buffer;
            if (!this.mIsCacheVerified)
            {
                this.VerifyCache();
            }
            if (!this.mIsCachingEnabled)
            {
                return null;
            }
            if (!CacheManager_ReadCachedData(tag, out buffer))
            {
                return null;
            }
            return buffer;
        }

        /// <summary>
        /// Loads data that was written to the game cache with the given tag,
        /// and deserializes it back into an object instance.
        /// </summary>
        /// <param name="tag">A unique string that identifies the cached data to be loaded.</param>
        /// <returns>The deserialized object instance that was stored in the game cache.</returns>
        public object LoadTuningData(string tag)
        {
            if (!this.mIsCacheVerified)
            {
                this.VerifyCache();
            }
            if (!this.mIsCachingEnabled)
            {
                return null;
            }
            uint handle = CacheManager_ReadCachedDataAsStream(tag);
            if (handle == 0)
            {
                return null;
            }
            using (FastStreamReader reader = new FastStreamReader(handle))
            {
                return Deserialize(reader);
            }
        }

        /// <summary>
        /// Saves the given data to the game cache with the given tag.
        /// </summary>
        /// <param name="tag">A unique string that identifies 
        /// the data in the game cache.</param>
        /// <param name="data">The data to be written to the game cache.</param>
        public void SaveRawTuningData(string tag, byte[] data)
        {
            if (!this.mIsCacheVerified)
            {
                this.VerifyCache();
            }
            if (this.mIsCachingEnabled)
            {
                CacheManager_WriteCachedData(tag, data, (uint)data.Length);
            }
        }

        /// <summary>
        /// Serializes the given object instance using the given persist group
        /// and then saves it to the game cache with the given tag.
        /// </summary>
        /// <param name="tag">A unique string that identifies 
        /// the serialized object in the game cache.</param>
        /// <param name="baseObject">The object instance to be serialized and written to the game cache.</param>
        /// <param name="basePersistGroup">The persist group used to serialize the object instance.</param>
        public void SaveTuningData(string tag, object baseObject, object basePersistGroup)
        {
            if (!this.mIsCacheVerified)
            {
                this.VerifyCache();
            }
            if (this.mIsCachingEnabled)
            {
                using (FastStreamWriter writer = new FastStreamWriter())
                {
                    new ScriptCore.StopWatch(Sims3.SimIFace.StopWatch.TickStyles.Milliseconds).Start();
                    //Sims3.SimIFace.StopWatch.Create(Sims3.SimIFace.StopWatch.TickStyles.Milliseconds).Start();
                    Serialize(baseObject, basePersistGroup, writer);
                    CacheManager_WriteCachedDataFromStream(tag, writer.Handle);
                }
            }
        }

        /// <summary>
        /// Serializes an instance of a Persistable class into persisted script data,
        /// such as the data from a saved game file.
        /// </summary>
        /// <param name="baseObject">The Persistable class instance to serialize.</param>
        /// <param name="basePersistGroup">The persist group used to serialize the Persistable class instance.</param>
        /// <returns>The persisted script data of the given Persistable instance.</returns>
        public byte[] Serialize(object baseObject, object basePersistGroup)
        {
            using (FastStreamWriter writer = new FastStreamWriter())
            {
                Serialize(baseObject, basePersistGroup, writer);
                return writer.ToArray();
            }
        }

        private static void Serialize(object baseObject, object basePersistGroup, FastStreamWriter binWriter)
        {
            PersistWriter writer = new PersistWriter();
            bool enableTypeRemapping = Persist.EnableTypeRemapping;
            Persist.EnableTypeRemapping = false;
            bool requireAllPersistable = Persist.RequireAllPersistable;
            Persist.RequireAllPersistable = true;
            try
            {
                writer.AddGroup(basePersistGroup);
                writer.Begin();
                writer.AddObject(baseObject);
                writer.End(binWriter);
            }
            finally
            {
                Persist.EnableTypeRemapping = enableTypeRemapping;
                Persist.RequireAllPersistable = requireAllPersistable;
            }
        }

        private void VerifyCache()
        {
            this.mIsCacheVerified = true;
            this.mIsCachingEnabled = false;
            CacheSignature signature = new CacheSignature();
            if (signature.Init())
            {
                byte[] buffer;
                if (CacheManager_IsCachingAllowed(kDatabaseName) && 
                    CacheManager_ReadCachedData("CacheSignature", out buffer))
                {
                    CacheSignature signature2 = new CacheSignature();
                    if (signature2.Read(buffer) && signature2.Equals(signature))
                    {
                        this.mIsCachingEnabled = true;
                    }
                }
                if (!this.mIsCachingEnabled)
                {
                    CacheManager_ClearCache();
                    byte[] data = signature.Write();
                    CacheManager_WriteCachedData("CacheSignature", data, (uint)data.Length);
                }
            }
        }

        /// <summary>
        /// Whether or not data can be loaded from and saved to the game cache.
        /// </summary>
        public bool IsCachingEnabled
        {
            get
            {
                if (!this.mIsCacheVerified)
                {
                    this.VerifyCache();
                }
                return this.mIsCachingEnabled;
            }
        }
    }
}
