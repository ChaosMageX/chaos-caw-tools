using System;
using System.Collections.Generic;
using System.Text;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// This class helps display successfully trapped exceptions to the user.
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        /// Displays all the data of the given exception
        /// in a message box with the default title "Error".
        /// </summary>
        /// <param name="ex">The exception to display.</param>
        public static void ShowException(Exception ex)
        {
            ShowException(ex, "", "Error");
        }

        /// <summary>
        /// Displays all the data of the given exception
        /// in a message box with the given caption title.
        /// </summary>
        /// <param name="ex">The exception to display.</param>
        /// <param name="caption">The title of the exception message box.</param>
        public static void ShowException(Exception ex, string caption)
        {
            ShowException(ex, "", caption);
        }

        /// <summary>
        /// Displays all the data of the given exception and the prefix string
        /// in a message box with the given caption title.
        /// </summary>
        /// <param name="ex">The exception to display.</param>
        /// <param name="prefix">The message to display above the exception data.</param>
        /// <param name="caption">The title of the exception message box.</param>
        public static void ShowException(Exception ex, string prefix, string caption)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(prefix);
            for (Exception exception = ex; exception != null; exception = exception.InnerException)
            {
                builder.Append("\nSource: " + exception.Source);
                builder.Append("\nAssembly: " + exception.TargetSite.DeclaringType.Assembly.FullName);
                builder.Append("\n" + exception.Message);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, false);
                builder.Append("\n" + trace);
                builder.Append("\n-----");
            }
            //CopyableMessageBox.Show(builder.ToString(), caption, CopyableMessageBoxButtons.OK,
            //    CopyableMessageBoxIcon.Error, 0);
            System.Windows.Forms.MessageBox.Show(builder.ToString(), caption, 
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error, 
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
