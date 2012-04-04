using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// The interface for <see cref="T:System.Windows.Forms.Form"/> derived
    /// classes that can be used as a "splash" screen
    /// that displays messages to the user while the main form is initializing.
    /// </summary>
    public interface ISplashForm : IDisposable
    {
        /// <summary>
        /// Display the splash to the user.
        /// </summary>
        void Show();
        /// <summary>
        /// Cause the splash to redraw the invalidated regions within its client area.
        /// </summary>
        void Update();
        /// <summary>
        /// Close the splash.
        /// </summary>
        void Close();

        /// <summary>
        /// The message that is displayed to the user on the splash.
        /// </summary>
        string Message { get; set; }
    }
}
