﻿using System;
using System.Collections.Generic;
using System.Text;

namespace System.Sims3Engine
{
    public class FNVHasher
    {
        private const int kLCAlphabetsLength = 256;
        private static readonly byte[] kLCAlphabets = new byte[]
        { 
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 
            0x40, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f, 
            0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f, 
            0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 
            0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 
            0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 
            0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 
            0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xd7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xdf, 
            0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 
            0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff
        };
        // 0x00 - 0x40, 0x5b - 0xbf, 0xdf, 0xe0 - 0xff

        private const int kLCAllLength = 199;
        private static readonly byte[] kLCAll = new byte[]
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 
            0x40, 0xdf,                                                       0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f, 
            0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f, 
            0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 
            0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 
            0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 
            0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 
            0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff
        };

        private const int kLCPrintableLength = 69;
        private static readonly byte[] kLCPrintable = new byte[]
        {
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 
            0x40,                                                             0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e
        };

        public static uint HashString24(string str)
        {
            uint num = HashString32(str);
            return ((num >> 0x18) ^ (num & 0xffffff));
        }

        public static uint HashString32(string str)
        {
            uint num = 0x811c9dc5;
            foreach (char ch in str)
            {
                num = (num * 0x01000193) ^ kLCAlphabets[ch];
            }
            return num;
        }

        private const byte kNotFoundChar = 0x50; // P = 0x50

        public class UnHasher32
        {
            private readonly uint mTargetHash;
            private readonly int mMaxLength;
            private byte[] mMatch;

            private readonly ulong mMaxIterations;
            private ulong mIterations = 0;
            private bool mFinished = false;
            private string mResult = null;

            public ulong MaxIterations
            {
                get { return this.mMaxIterations; }
            }

            public ulong Iterations
            {
                get { return this.mIterations; }
            }

            public string Result
            {
                get { return this.mResult; }
            }

            public UnHasher32(uint hash, int maxChars = 10)
            {
                this.mTargetHash = hash;
                this.mMaxLength = maxChars;
                this.mMatch = new byte[maxChars];
                this.mMaxIterations = 1;
                for (int i = 0; i < maxChars; i++)
                {
                    this.mMatch[i] = kNotFoundChar;
                    this.mMaxIterations *= kLCPrintableLength;
                }
            }

            public string Run()
            {
                if (this.mFinished)
                    return this.mResult;
                this.mFinished = Match(0x811c9dc5, 0);
                if (!this.mFinished)
                {
                    this.mFinished = true;
                    return null;
                }
                this.mResult = "";
                for (int i = 0; i < this.mMaxLength; i++)
                {
                    if (this.mMatch[i] == kNotFoundChar)
                        break;
                    this.mResult += (char)this.mMatch[i];
                }
                return this.mResult;
            }

            private unsafe bool Match(uint current, int offset)
            {
                if (offset == mMaxLength)
                    return false;
                fixed (byte* chars = kLCPrintable)
                {
                    uint result, product = current * 0x01000193;
                    for (int i = 0; i < kLCPrintableLength; i++)
                    {
                        result = product ^ chars[i];
                        if (result == this.mTargetHash)
                        {
                            this.mMatch[offset] = chars[i];
                            return true;
                        }
                        this.mIterations++;
                        if (Match(result, offset + 1))
                        {
                            this.mMatch[offset] = chars[i];
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public string UnHashString32(uint hash, int maxChars = 10)
        {
            UnHasher32 unhasher = new UnHasher32(hash, maxChars);
            return unhasher.Run();
        }

        public static ulong HashString64(string str)
        {
            ulong num = 0xcbf29ce484222325L;
            foreach (char ch in str)
            {
                num = (num * ((ulong)0x100000001b3L)) ^ kLCAlphabets[ch];
            }
            return num;
        }

        public static uint XorFoldHashString32(string str)
        {
            uint num = HashString32(str);
            return ((num >> 0x18) ^ (num & 0xffffff));
        }
    }
}
