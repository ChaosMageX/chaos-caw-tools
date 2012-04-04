using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.AudioPlayer
{
    public class TagValue<T>
    {
        public string Tag;
        public T Value;
        public TagValue(string tag, T value)
        {
            Tag = tag; Value = value;
        }
        public override string ToString()
        {
            return Tag;
        }
    }
}
