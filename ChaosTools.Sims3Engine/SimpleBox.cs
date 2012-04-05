using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This simple class is used to box a value of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of value to contain.</typeparam>
    public sealed class SimpleBox<T> : IEquatable<SimpleBox<T>> 
        where T : struct
    {
        /// <summary>
        /// This box's value.
        /// </summary>
        public T Value;
        /// <summary>
        /// Initializes a new box with the default value of
        /// <typeparamref name="T"/>.
        /// </summary>
        public SimpleBox() { Value = default(T); }
        /// <summary>
        /// Initializes a new box with the given value.
        /// </summary>
        /// <param name="value">The value to box.</param>
        public SimpleBox(T value) { Value = value; }
        /// <summary>
        /// Returns the hash code of the container's value.
        /// </summary>
        /// <returns>The hash code of the container's value.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        /// <summary>
        /// Returns True if the object is an instance of <typeparamref name="T"/>
        /// that equals the container's value, or if the oject is another 
        /// SimpleBox&lt;<typeparamref name="T"/>&gt;
        /// that contains a value equal to this container's value.
        /// </summary>
        /// <param name="obj">The object to test for equality with.</param>
        /// <returns>True if the object equals this container's value
        /// or the container itself, False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is T)
                return Value.Equals(obj);
            if (obj is SimpleBox<T>)
                return (obj as SimpleBox<T>).Value.Equals(Value);
            return false;
        }
        /// <summary>
        /// Tests the equality of this box with another box,
        /// and returns True if the values they contain are equal.
        /// </summary>
        /// <param name="other">The box to test for equality with.</param>
        /// <returns>True if the other box's value
        /// equals this box's value.</returns>
        public bool Equals(SimpleBox<T> other)
        {
            return Value.Equals(other.Value);
        }
        /// <summary>
        /// Returns the value contained in a specific box value.
        /// </summary>
        /// <param name="value">A box value.</param>
        /// <returns>The value contained in the 
        /// <paramref name="value"/> parameter.</returns>
        public static explicit operator T(SimpleBox<T> value)
        {
            return value.Value;
        }
        /// <summary>
        /// Creates a new box containing a specific value.
        /// </summary>
        /// <param name="value">A value type.</param>
        /// <returns>A new box containing the value
        /// of the <paramref name="value"/> parameter.</returns>
        public static implicit operator SimpleBox<T>(T value)
        {
            return new SimpleBox<T>(value);
        }
        /// <summary>
        /// Returns the string version of the container's value,
        /// <c>Value.ToString()</c>.
        /// </summary>
        /// <returns>The string version of the container's value.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
