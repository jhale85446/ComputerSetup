using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Standard
{
    /// <summary>
    /// Common applicaiton procedures simplified.
    /// </summary>
    class Procedures
    {
        /// <summary>
        /// Displays an Error box with the provided message.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        internal static void Error_Box(string message)
        {
            String caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;
            MessageBoxDefaultButton dflt = MessageBoxDefaultButton.Button1;

            MessageBox.Show(message, caption, buttons, icon, dflt);
        }

        /// <summary>
        /// Displays a Message box with the provided message and caption.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the message box</param>
        internal static void Msg_Box(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBoxDefaultButton dflt = MessageBoxDefaultButton.Button1;

            MessageBox.Show(message, caption, buttons, icon, dflt);
        }

        /// <summary>
        /// Displays a Question box with yes and no buttons. Returns true for yes and false for no.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the Question box</param>
        /// <returns>yes = true, no = false</returns>
        internal static bool Question_Box_Yes_No(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton deftbtn = MessageBoxDefaultButton.Button1;

            var result = MessageBox.Show(message, caption, buttons, icon, deftbtn);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Displays a Question box with ok and cancel buttons. Returns true for ok and false for cancel.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the Question box</param>
        /// <returns>ok = true, cancel = false</returns>
        internal static bool Question_Box_Ok_Cancel(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton deftbtn = MessageBoxDefaultButton.Button1;

            var result = MessageBox.Show(message, caption, buttons, icon, deftbtn);

            if (result == DialogResult.OK)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Displays a Question box with retry and cancel buttons. Returns true for retry and false for cancel.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the Question box</param>
        /// <returns>retry = true, cancel = false</returns>
        internal static bool Question_Box_Retry_Cancel(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton deftbtn = MessageBoxDefaultButton.Button1;

            var result = MessageBox.Show(message, caption, buttons, icon, deftbtn);

            if (result == DialogResult.Retry)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Displays a Question box with abort, retry and ignore buttons. Returns 0 for abort, 1 for retry, and 2 for ignore.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the Question box</param>
        /// <returns>Abort = 0, Retry = 1, Ignore = 2</returns>
        internal static int Question_Box_Abort_Retry_Ignore(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.AbortRetryIgnore;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton deftbtn = MessageBoxDefaultButton.Button1;

            var result = MessageBox.Show(message, caption, buttons, icon, deftbtn);

            if (result == DialogResult.Abort)
                return 0;
            else if (result == DialogResult.Retry)
                return 1;
            else
                return 2; ;
        }

        /// <summary>
        /// Displays a Question box with yes, no, and cancel buttons. Returns 0 for no, 1 for yes, and 2 for cancel.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="caption">Caption for the Question box</param>
        /// <returns>Abort = 0, Retry = 1, Ignore = 2</returns>
        internal static int Question_Box_Yes_No_Cancel(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton deftbtn = MessageBoxDefaultButton.Button1;

            var result = MessageBox.Show(message, caption, buttons, icon, deftbtn);

            if (result == DialogResult.No)
                return 0;
            else if (result == DialogResult.Yes)
                return 1;
            else
                return 2; ;
        }

        /// <summary>
        /// Displays a path selection box.  Returns true when a path is selected that exists.
        /// </summary>
        /// <param name="path">Out string for the path selected.</param>
        /// <param name="message">Message to be displayed on the path selection box.</param>
        /// <returns>True if selected path exists. False if cancel is clicked or path does not exist.</returns>
        internal static bool Path_Box(out string path, string message)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = message;

            if ((folder.ShowDialog() == DialogResult.OK) & (Directory.Exists(folder.SelectedPath)))
            {
                path = folder.SelectedPath;
                return true;
            }

            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Displays an open file box. Returns true if path exists.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <returns>True if the file exists. False if not or cancel.</returns>
        internal static bool Open_File_Box(out string path, string message)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.CheckFileExists = true;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = open_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Displays an open file box. Returns true if path exists.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <param name="filter">File type filter to be used.</param>
        /// <returns>True if the file exists. False if not or cancel.</returns>
        internal static bool Open_File_Box(out string path, string message, string filter)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.Filter = filter;
            open_file_dialog.CheckFileExists = true;
            
            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = open_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Displays an open file box. Returns true if path exists.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <param name="filter">File type filter to be used.</param>
        /// <param name="form">Form for the box to be assocated with.</param>
        /// <returns>True if the file exists. False if not or cancel.</returns>
        internal static bool Open_File_Box(out string path, string message, string filter, IWin32Window form)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.Filter = filter;
            open_file_dialog.CheckFileExists = true;

            if (open_file_dialog.ShowDialog(form) == DialogResult.OK)
            {
                path = open_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Displays a file selection box set to recieve multiple files.  Returns ture when the files are selected.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <returns>True if the files exists. False if not or cancel.</returns>
        internal static bool Open_Files_Box(out string[] path, string message)
        {
            string[] empty = new string[1] { "" };
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.CheckFileExists = true;
            open_file_dialog.Multiselect = true;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = open_file_dialog.FileNames;
                return true;
            }
            else
            {
                path = empty;
                return false;
            }
        }

        /// <summary>
        /// Displays a file selection box set to recieve multiple files.  Returns ture when the files are selected.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <param name="filter">File type filter to be used.</param>
        /// <returns>True if the files exists. False if not or cancel.</returns>
        internal static bool Open_Files_Box(out string[] path, string message, string filter)
        {
            string[] empty = new string[1] { "" };
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.Filter = filter;
            open_file_dialog.CheckFileExists = true;
            open_file_dialog.Multiselect = true;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = open_file_dialog.FileNames;
                return true;
            }
            else
            {
                path = empty;
                return false;
            }
        }

        /// <summary>
        /// Displays a file selection box set to recieve multiple files.  Returns ture when the files are selected.
        /// </summary>
        /// <param name="path">Out string for the full path with filename.</param>
        /// <param name="message">Message to be displayed in on the box.</param>
        /// <param name="filter">File type filter to be used.</param>
        /// <param name="form">Form to assocate this box with.</param>
        /// <returns>True if the files exists. False if not or cancel.</returns>
        internal static bool Open_Files_Box(out string[] path, string message, string filter, IWin32Window form)
        {
            string[] empty = new string[1] { "" };
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = message;
            open_file_dialog.Filter = filter;
            open_file_dialog.CheckFileExists = true;
            open_file_dialog.Multiselect = true;

            if (open_file_dialog.ShowDialog(form) == DialogResult.OK)
            {
                path = open_file_dialog.FileNames;
                return true;
            }
            else
            {
                path = empty;
                return false;
            }
        }

        /// <summary>
        /// Shows a Save File box.  Returns true if a file is entered.
        /// </summary>
        /// <param name="path">Out string of the path selected.</param>
        /// <param name="message">Message to be displayed.</param>
        /// <returns>True if file selected, false if not.</returns>
        internal static bool Save_File_Box(out string path, string message)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Title = message;

            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = save_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Shows a Save File box.  Returns true if a file is entered.
        /// </summary>
        /// <param name="path">Out string of the path selected.</param>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="filter">File type filter.</param>
        /// <returns>True if file selected, false if not.</returns>
        internal static bool Save_File_Box(out string path, string message, string filter)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Title = message;
            save_file_dialog.Filter = filter;

            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                path = save_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Shows a Save File box.  Returns true if a file is entered.
        /// </summary>
        /// <param name="path">Out string of the path selected.</param>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="filter">File type filter.</param>
        /// <param name="form">Form to assocate the box with.</param>
        /// <returns>True if file selected, false if not.</returns>
        internal static bool Save_File_Box(out string path, string message, string filter, IWin32Window form)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Title = message;
            save_file_dialog.Filter = filter;

            if (save_file_dialog.ShowDialog(form) == DialogResult.OK)
            {
                path = save_file_dialog.FileName;
                return true;
            }
            else
            {
                path = "";
                return false;
            }
        }

        /// <summary>
        /// Builds a File Box filter. Example: Standard.Procedures.filter_builder(new string[] { "Text files", "All files" }, new string[] { "*.txt", "*.*" });
        /// </summary>
        /// <param name="filetypes">Array of file types.</param>
        /// <param name="extensions">Array of file extensions</param>
        /// <returns>Filter for use in File Open/Save boxes.</returns>
        internal static string Filter_Builder(string[] filetypes, string[] extensions)
        {
            if (filetypes.GetLength(0) != extensions.GetLength(0))
                throw new ArgumentNullException("Argument miss match.");           

            StringBuilder output = new StringBuilder();
            int count = filetypes.GetLength(0);

            for (int x = 0; x < count; x++)
            {
                output.Append(filetypes[x] + "(" + extensions[x] + ")|" + extensions[x]);
                if (x != (count - 1))
                    output.Append("|");
            }

            return output.ToString();
        }
    }
}
