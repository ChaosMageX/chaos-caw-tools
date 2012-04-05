using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This simple class is used to contain a value of the specified type,
    /// along with a seperate tag string that is given instead of
    /// <c>value.ToString()</c>.
    /// </summary>
    /// <typeparam name="T">The type of value to contain.</typeparam>
    public class TagValue<T>
    {
        /// <summary>
        /// This container's tag.
        /// </summary>
        public string Tag;
        /// <summary>
        /// This container's value.
        /// </summary>
        public T Value;
        /// <summary>
        /// Initializes a new instance containing the given value
        /// and a tag equal to the string version of the given value.
        /// </summary>
        /// <param name="value">The value to contain and tag.</param>
        public TagValue(T value)
        {
            Value = value; Tag = value.ToString();
        }
        /// <summary>
        /// Initializes a new instance with the given tag
        /// and containing the given value.
        /// </summary>
        /// <param name="tag">The container's tag.</param>
        /// <param name="value">The value to contain and tag.</param>
        public TagValue(T value, string tag)
        {
            Value = value; Tag = tag;
        }
        /// <summary>
        /// Returns the container's tag.
        /// </summary>
        /// <returns>The container's tag.</returns>
        public override string ToString()
        {
            return Tag;
        }
    }
}
