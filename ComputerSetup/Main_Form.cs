using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Standard;

namespace ComputerSetup
{
    public partial class Main_Form : Form
    {
        string PUBLIC_DESKTOP = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        string CURR_DIR = Directory.GetCurrentDirectory();
        string CURR_DIR_ROOT = Path.GetPathRoot(Directory.GetCurrentDirectory());
        string LINK_PATH = "\\Links";
        string APP_PATH = "\\Apps";
        string FILES_PATH = "\\Files";
        string BASIC_FILENAME = "basic_setup.txt";
        string POST_FILENAME = "post_setup.txt";
        about_form about;

        private void Output_Line(string output)
        {
            string time = System.DateTime.Now.TimeOfDay.Hours.ToString("00") + ":";
            time = time + System.DateTime.Now.TimeOfDay.Minutes.ToString("00") + ":";
            time = time + System.DateTime.Now.TimeOfDay.Seconds.ToString("00");
            output = "(" + time + ") " + output + "\n\n";
            Output_box.Text = Output_box.Text.Insert(0, output);
        }

        private void Add_Status(string status)
        {
            string[] lines = Output_box.Lines;
            lines[0] = lines[0] + "  -  " + status;
            Output_box.Lines = lines;
        }

        // This function updates the status.
        // Useful for download indicator
        private void Update_Status(string status)
        {
            string[] lines = Output_box.Lines;
            if (lines[0].Contains("  -  "))
            {
                int dash = lines[0].IndexOf("  -  ");
                string temp = lines[0].Substring(0, dash);
                lines[0] = temp + "  -  " + status;
                Output_box.Lines = lines;
            }
            else
                Add_Status(status);            
        }

        private void Add_Cmd_Ouput(string cmd_ouput, string cmd)
        {
            string divider = "****************************************************************************************************************";
            string[] lines = Output_box.Lines;
            cmd_ouput = divider + Environment.NewLine + "> " + cmd + Environment.NewLine + cmd_ouput + divider;
            Output_box.Text = Output_box.Text.Insert(lines[0].Length + 1, cmd_ouput);
        }

        private void Pop_Links()
        {
            try
            {
                string[] files = Directory.GetFiles(CURR_DIR + LINK_PATH, "*.*");

                foreach (string file in files)
                    Link_Box.Items.Add(file, true);
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                Output_Line("Links Directory Not Found!");
            }

            Link_Box_MouseLeave(null, null);
        }

        private void Pop_Apps()
        {
            try
            {
                string[] files = Directory.GetFiles(CURR_DIR + APP_PATH, "*.exe");
                foreach (string file in files)
                    App_Box.Items.Add(file, true);

                files = Directory.GetFiles(CURR_DIR + APP_PATH, "*.msi");
                foreach (string file in files)
                    App_Box.Items.Add(file, true);
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                Output_Line("Applications Directory Not Found!");
            }
            App_Box_MouseLeave(null, null);
        }

        string [] Parse_Command(string command)
        {
            string[] output = command.Split(';');
            return output;
        }

        private void Pop_Basic()
        {
            string line;
            
            if (!File.Exists(Path.Combine(CURR_DIR, BASIC_FILENAME)))
            {
                Output_Line(BASIC_FILENAME + " Not Found!");
                Basic_Box_MouseLeave(null, null);
                return;
            }

            try
            {
                StreamReader file = new StreamReader(Path.Combine(CURR_DIR, BASIC_FILENAME));

                while ((line = file.ReadLine()) != null)
                    if (line.Substring(0, 1) != "#")
                        Basic_Box.Items.Add(line, true);
                    
                file.Close();
            }
            catch
            {
                Output_Line("Error reading " + BASIC_FILENAME + ". Make Sure No Empty Lines.");
            }
            Basic_Box_MouseLeave(null, null);
        }

        private void Pop_Post()
        {
            string line;

            if (!File.Exists(Path.Combine(CURR_DIR, POST_FILENAME)))
            {
                Output_Line(POST_FILENAME + " Not Found!");
                Post_Box_MouseLeave(null, null);
                return;
            }

            try
            {
                StreamReader file = new StreamReader(Path.Combine(CURR_DIR, POST_FILENAME));

                while ((line = file.ReadLine()) != null)
                    if (line.Substring(0, 1) != "#")
                        Post_Box.Items.Add(line, true);

                file.Close();
            }
            catch
            {
                Output_Line("Error reading " + POST_FILENAME);
            }
            Post_Box_MouseLeave(null, null);
        }

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            // Reset All boxes back to default values
            Basic_Box.Items.Clear();
            App_Box.Items.Clear();
            Link_Box.Items.Clear();
            Post_Box.Items.Clear();

            Check_File_System();
            about = new about_form();
            Output_box.Clear();
            desktop_path_box.Text = PUBLIC_DESKTOP;
            Working_Dir.Text = CURR_DIR;
            Pop_Basic();
            Pop_Links();
            Pop_Apps();
            Pop_Post();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string Parse_External_Path(string input)
        {
            string part_path;

            if (input.Contains("&WORKDRIVE&"))
            {
                part_path = input.Substring((input.LastIndexOf('&') + 1), (input.Length - (input.LastIndexOf('&') + 1)));

                if (!part_path.StartsWith("\\"))
                    part_path = "\\" + part_path;

                return(CURR_DIR_ROOT.TrimEnd('\\') + part_path);
            }

            else if (input.Contains("&WORKPATH&"))
            {
                part_path = input.Substring((input.LastIndexOf('&') + 1), (input.Length - (input.LastIndexOf('&') + 1)));

                if (!part_path.StartsWith("\\"))
                    part_path = "\\" + part_path;

                return (CURR_DIR.TrimEnd('\\') + part_path);
            }

            else
                return input;
        }

        private bool Run_Encoded_Command(string input)
        {
            string[] command;
            command = Parse_Command(input);
            if (command[0] == "CMD")
                return Run_Cmd(command[1]);
            else if (command[0] == "RUN")
                return Run_App(CURR_DIR + command[1]);
            else if (command[0] == "XRUN")
                return Run_App(Parse_External_Path(command[1]));
            else if (command[0] == "REG")
                return Reg_Import(CURR_DIR + command[1]);
            else if (command[0] == "COPY")
                return File_Copy(CURR_DIR + command[1], command[2]);
            else if (command[0] == "XCOPY")
                return File_Copy(Parse_External_Path(command[1]), command[2]);
            else if (command[0] == "RM")
                return File_Delete(command[1]);
            else if (command[0] == "XRM")
                return File_Delete(Parse_External_Path(command[1]));
            else if (command[0] == "WGET")
            {
                bool result = Download_File(command[1], Parse_External_Path(command[2]));
                return Check_Downloaded_File(Parse_External_Path(command[2])) && result;
            }
            else
                return false;
        }

        private void Disable_Buttons()
        {
            Basic_Go.Enabled = false;
            App_Go.Enabled = false;
            Link_Go.Enabled = false;
            Post_Go.Enabled = false;
            Refresh_Button.Enabled = false;
            change_dir_button.Enabled = false;
            Clear_Output_Button.Enabled = false;
            Working_Dir.Enabled = false;
        }

        private void Enable_Buttons()
        {
            Refresh_Button.Enabled = true;
            change_dir_button.Enabled = true;
            Clear_Output_Button.Enabled = true;
            Working_Dir.Enabled = true;
            Refresh_Button_Click(null, null);
        }

        private void Basic_Go_Click(object sender, EventArgs e)
        {
            Disable_Buttons();

            foreach (object item_checked in Basic_Box.CheckedItems)
                if (!Run_Encoded_Command(item_checked.ToString()))
                    Output_Line(item_checked.ToString() + " - FAILED!");

            Enable_Buttons();
        }

        private void Link_Go_Click(object sender, EventArgs e)
        {
            Disable_Buttons();
                      
            foreach (object item_checked in Link_Box.CheckedItems)
                File_Copy(item_checked.ToString(), PUBLIC_DESKTOP);

            Enable_Buttons();
        }

        private void Link_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Link_Box.CheckedIndices.Count < 1)
                Link_Go.Enabled = false;
            else
                Link_Go.Enabled = true;
        }

        private void App_Box_MouseLeave(object sender, EventArgs e)
        {
            if (App_Box.CheckedIndices.Count < 1)
                App_Go.Enabled = false;
            else
                App_Go.Enabled = true;
        }

        private void Basic_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Basic_Box.CheckedIndices.Count < 1)
                Basic_Go.Enabled = false;
            else
                Basic_Go.Enabled = true;
        }

        private void App_Go_Click(object sender, EventArgs e)
        {
            Disable_Buttons();
                                   
            foreach (object item_checked in App_Box.CheckedItems)
                Run_App(item_checked.ToString());

            Enable_Buttons();
        }

        private bool Reg_Import(string reg_file)
        {
            if (File.Exists(reg_file))
            {
                Output_Line("Adding: " + reg_file + " to registry");
                if (Path.GetExtension(reg_file) != ".reg")
                {
                    Add_Status("Incorrect File Type!");
                    return false;
                }
                Process reg_process = Process.Start("regedit.exe", "/S " + reg_file);
                reg_process.WaitForExit();
                Add_Status("Done.");
                return true;
            }
            else
            {
                Output_Line("File " + reg_file + " Not Found!");
                return false;
            }
        }

        private bool File_Copy(string source, string dest_dir)
        {
            Output_Line("Copying: " + Path.GetFileName(source) + " -> " + dest_dir);
            if (File.Exists(source))
            {
                try
                {
                    File.Copy(source, Path.Combine(dest_dir, Path.GetFileName(source)));
                    if (File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
                    {
                        Add_Status("Done.");
                        return true;
                    }
                    else
                    {
                        Add_Status("Unable to copy!");
                        return false;
                    }
                        
                }
                catch
                {
                    Add_Status("Unable to copy!");
                    return false;
                }
                
            }
            else
            {
                Add_Status("File Not Found!");
                return false;
            }
        }

        private bool File_Delete(string path)
        {
            Output_Line("Deleting: " + path);
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    if (!File.Exists(path))
                    {
                        Add_Status("Done.");
                        return true;
                    }
                    else
                    {
                        Add_Status("Unable to Delete!");
                        return false;
                    }
                }
                catch
                {
                    Add_Status("Unable to Delete!");
                    return false;
                }
            }
            else
            {
                Add_Status("File Not Found!");
                return false;
            }
        }

        private bool Run_Cmd(string cmd)
        {
            Output_Line("Executing: " + cmd);
            if (cmd != "")
            {
                Process proc = new Process();
                ProcessStartInfo start_info = new ProcessStartInfo();

                start_info.UseShellExecute = false;
                start_info.FileName = "cmd.exe";
                start_info.RedirectStandardOutput = true;
                start_info.CreateNoWindow = false;
                start_info.Arguments = "/C " + cmd;
                proc.StartInfo = start_info;
                proc.Start();
                Add_Cmd_Ouput(proc.StandardOutput.ReadToEnd(), cmd);
                proc.WaitForExit();
                return true;
            }
            else
            {
                Add_Status("Empy Command!");
                return false;
            }
        }

        private bool Run_App(string exe)
        {
            Output_Line("Running: " + Path.GetFileName(exe));
            if (File.Exists(exe))
            {
                try
                {
                    this.WindowState = FormWindowState.Minimized;
                    Process proc = new Process();
                    proc = Process.Start(exe);
                    proc.WaitForExit();
                    this.WindowState = FormWindowState.Normal;
                    Add_Status("Done.");
                    return true;
                }

                catch
                {
                    Add_Status("Unable to run!");
                    return false;
                }
            }
            else
            {
                Add_Status("File Not Found!");
                return false;
            }
        }

        private bool downloadComplete = false;

        private bool Download_File(string source, string dest_file)
        {
            Output_Line("Downloading: " + source + " -> " + dest_file);
            Output_Line("Download Status: ");

            if (!check_download_path(source))
            {
                Add_Status("Link Does Not Exist!");
                return false;
            }
            
            WebClient web_client = new WebClient();
            web_client.DownloadProgressChanged += web_client_DownloadProgressChanged;
            web_client.DownloadFileCompleted += web_client_DownloadFileCompleted;

            try
            {
                web_client.DownloadFileAsync(new System.Uri(source), dest_file);
                
                while (!downloadComplete)
                {
                    Application.DoEvents();
                }

                downloadComplete = false;
            }
            catch
            {
                Add_Status("Unable to Download!");

                return false;
            }
            return true;
        }

        private bool check_download_path(string source)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(new System.Uri(source));
            request.Method = "HEAD";
            bool result = false;
            
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                result = false;
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                    result = true;
                }
            }
            return result;
        }

        private void web_client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                Add_Status("Done");
                downloadComplete = true;
            });            
        }

        private void web_client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Update_Status(e.ProgressPercentage.ToString() + "%");
        }

        private bool Check_Downloaded_File(string dest_file)
        {
            if (File.Exists(dest_file))
            {
                Add_Status("File Verified.");
                return true;
            }
            else
            {
                Add_Status("Download Failed!");
                return false;
            }
        }

        private void Post_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Post_Box.CheckedIndices.Count < 1)
                Post_Go.Enabled = false;
            else
                Post_Go.Enabled = true;
        }

        private void Post_Go_Click(object sender, EventArgs e)
        {
            Disable_Buttons();

            foreach (object item_checked in Post_Box.CheckedItems)
                if (!Run_Encoded_Command(item_checked.ToString()))
                    Output_Line(item_checked.ToString() + " - FAILED!");

            Enable_Buttons();
        }

        private void change_dir_button_Click(object sender, EventArgs e)
        {
            string new_path;
            if (Standard.Procedures.path_box(out new_path, "Select New Working Directory"))
            {
                CURR_DIR = new_path;
                CURR_DIR_ROOT = Path.GetPathRoot(CURR_DIR);
                Main_Form_Load(null, null);
            }
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            // Reset All boxes back to default values
            Basic_Box.Items.Clear();
            App_Box.Items.Clear();
            Link_Box.Items.Clear();
            Post_Box.Items.Clear();

            Check_File_System();
            about = new about_form();
            desktop_path_box.Text = PUBLIC_DESKTOP;
            Working_Dir.Text = CURR_DIR;
            Pop_Basic();
            Pop_Links();
            Pop_Apps();
            Pop_Post();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
            about.Activate();
        }

        private void Check_File_System()
        {
            if (!Directory.Exists(CURR_DIR + APP_PATH))
            {
                if (Standard.Procedures.question_box_yes_no("Apps Directory Missing. Shall I Make One?", "Missing Directory"))
                {
                    try
                    {
                        Directory.CreateDirectory(CURR_DIR + APP_PATH);
                    }
                    catch
                    {
                        Standard.Procedures.error_box("Unable to create Apps directory!");
                    }
                }
            }

            if (!Directory.Exists(CURR_DIR + LINK_PATH))
            {
                if (Standard.Procedures.question_box_yes_no("Links Directory Missing. Shall I Make One?", "Missing Directory"))
                {
                    try
                    {
                        Directory.CreateDirectory(CURR_DIR + LINK_PATH);
                    }
                    catch
                    {
                        Standard.Procedures.error_box("Unable to create Links directory!");
                    }
                }
            }

            if (!Directory.Exists(CURR_DIR + FILES_PATH))
            {
                if (Standard.Procedures.question_box_yes_no("Files Directory Missing. Shall I Make One?", "Missing Directory"))
                {
                    try
                    {
                        Directory.CreateDirectory(CURR_DIR + FILES_PATH);
                    }
                    catch
                    {
                        Standard.Procedures.error_box("Unable to create Files directory!");
                    }
                }
            }

            if (!File.Exists(Path.Combine(CURR_DIR, BASIC_FILENAME)))
            {
                if (Standard.Procedures.question_box_yes_no("basic_setup.txt is missing. Shall I Make One?", "Missing File"))
                {
                    try
                    {
                        File.WriteAllLines(Path.Combine(CURR_DIR, BASIC_FILENAME), Setup_Text());
                    }
                    catch
                    {
                        Standard.Procedures.error_box("Unable to create basic_setup.txt!");
                    }
                }
            }

            if (!File.Exists(Path.Combine(CURR_DIR, POST_FILENAME)))
            {
                if (Standard.Procedures.question_box_yes_no("post_setup.txt is missing. Shall I Make One?", "Missing file"))
                {
                    try
                    {
                        File.WriteAllLines(Path.Combine(CURR_DIR, POST_FILENAME), Setup_Text());
                    }
                    catch
                    {
                        Standard.Procedures.error_box("Unable to create post_setup.txt!");
                    }
                }
            }
        }

        private string [] Setup_Text()
        {
            string[] text = new string[31];
            text[0] = "# This is a ComputerSetup basic or post setup text file";
            text[1] = "# Do not use empy lines in this file. Use '#' for comments or blank lines.";
            text[2] = "# The valid commands are:";
            text[3] = "#";
            text[4] = "# CMD - Run a command through Windows command shell";
            text[5] = "# Usage: CMD;'System Command'        Example: CMD;ipconfig";
            text[6] = "#";
            text[7] = "# COPY - Copy a file with the working directory as a base.";
            text[8] = "# Usage: COPY;'Source File';'Destination Directory'        Example: COPY;\\Files\\text.txt;C:\\Windows";
            text[9] = "#";
            text[10] = "# WGET - Download a file from a web location";
            text[11] = "# Usage: WGET;http://address:port/filepath;'Local Destination File        Example WGET;http//192.168.1.101/test.txt;C:\\Windows\\test.txt";
            text[12] = "#";
            text[13] = "# RUN - Run an application with the working directory as a base";
            text[14] = "# Usage: RUN;'Program'        Example: RUN;\\Files\\putty.exe";
            text[15] = "#";
            text[16] = "# RM - Delete a file with the working directory as a base.";
            text[17] = "# Usage: RM;'file path and name'        Example: RM;\\Files\\putty.exe";
            text[18] = "#";
            text[19] = "# XRUN, XCOPY, and XRM - Same as RUN, COPY, and RM but using external file paths";
            text[20] = "# Example: XRUN;C:\\Windows\\regedit.exe    Example: XCOPY;E:\\hosts;C:\\Windows\\System32\\drivers\\etc    Example: RM;C:\\Windows\\putty.exe";
            text[21] = "#";
            text[22] = "# In XRUN, XCOPY, XRM, and WGET, You can use &WORKDRIVE& as a pointer to the root drive of the working directory.";
            text[23] = "# Example: XRUN;&WORKDRIVE&\\Files\\setup.exe       If the root working directory drive is E: the path above is E:\\Files\\setup.exe";
            text[24] = "# You can also use &WORKPATH& as a pointer to the current working directory";
            text[25] = "#";
            text[26] = "# REG - Add a registry file to the local registry using the working directory as a base";
            text[27] = "# Usage: REG;'Registry file'        Example: REG;\\Files\\ODBC.reg";
            text[28] = "#";
            text[29] = "# For more information visit the wiki page at: https://github.com/jhale85446/ComputerSetup/wiki";
            text[30] = "#";
            return text;
        }

        private void Clear_Output_Button_Click(object sender, EventArgs e)
        {
            Output_box.ResetText();
        }

        private void Basic_Edit_Button_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(CURR_DIR, BASIC_FILENAME);

            if (File.Exists(path))
            {
                try
                {
                    Run_App(path);
                }
                catch
                {
                    Standard.Procedures.error_box("Unable to edit Basic Setup!");
                }
            }
        }

        private void Post_Edit_Button_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(CURR_DIR, POST_FILENAME);

            if (File.Exists(path))
            {
                try
                {
                    Run_App(path);
                }
                catch
                {
                    Standard.Procedures.error_box("Unable to edit Post Setup!");
                }
            }
        }
    }
}
