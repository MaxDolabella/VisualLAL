using System.Windows.Forms;

namespace Maxsys.VisualLAL.CustomCode.Utils
{
    /// <summary>
    /// Provide methods that helps to show a message box
    /// </summary>
    public class MessageBoxUtils
    {
        /// <summary>
        /// Display a warning message box
        /// </summary>
        /// <param name="text">Text of the message box</param>
        /// <param name="mboxTitle">Title of the message box</param>
        public static void ShowWarning(string text, string mboxTitle)
        {
            MessageBox.Show(text, mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Display an error message box
        /// </summary>
        /// <param name="text">Text of the message box</param>
        /// <param name="mboxTitle">Title of the message box</param>
        public static void ShowError(string text, string mboxTitle)
        {
            MessageBox.Show(text, mboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
