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
using System.Diagnostics;

namespace ComputerSetup
{
    public partial class Main_Form : Form
    {
        string PUBLIC_DESKTOP = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        //string CURR_DIR = Directory.GetCurrentDirectory();
        string CURR_DIR = "E:\\OSSI_Setup";
        string LINK_PATH = "\\Links";
        string APP_PATH = "\\Applications";
        string BASIC_FILENAME = "basic_setup.txt";
        string POST_FILENAME = "post_setup.txt";

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
            //Output_box.Text = Output_box.Text + "  -  " + status;
        }

        private void Add_Cmd_Ouput(string cmd_ouput, string cmd)
        {
            string divider = "****************************************************************************************************************";
            string[] lines = Output_box.Lines;
            cmd_ouput = divider + Environment.NewLine + "> " + cmd + Environment.NewLine + cmd_ouput + divider;
            Output_box.Text = Output_box.Text.Insert(lines[0].Length + 1, cmd_ouput);
        }

        private void Error_Box(string message)
        {
            String caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;
            MessageBoxDefaultButton dflt = MessageBoxDefaultButton.Button1;

            MessageBox.Show(message, caption, buttons, icon, dflt);
        } // Shows an Error box

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
                Output_Line("Directory Not Found!");
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
                Error_Box("Directory Not Found!");
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
                Output_Line("Error reading " + BASIC_FILENAME);
            }
            Basic_Box_MouseLeave(null, null);
        }

        private void Pop_Post()
        {
            string line;

            if (!File.Exists(Path.Combine(CURR_DIR, POST_FILENAME)))
            {
                Output_Line(POST_FILENAME + " Not Found!");
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
            textBox1.Text = PUBLIC_DESKTOP;
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

        private bool Run_Encoded_Command(string input)
        {
            string[] command;
            command = Parse_Command(input);
            if (command[0] == "CMD")
                return Run_Cmd(command[1]);
            else if (command[0] == "RUN")
                return Run_App(CURR_DIR + command[1]);
            else if (command[0] == "XRUN")
                return Run_App(command[1]);
            else if (command[0] == "REG")
                return Reg_Import(CURR_DIR + command[1]);
            else if (command[0] == "COPY")
                 return File_Copy(CURR_DIR + command[1], command[2]);
            else
                return false;
        }

        private void Basic_Go_Click(object sender, EventArgs e)
        {            
            Basic_Go.Enabled = false;

            foreach (object item_checked in Basic_Box.CheckedItems)
                if (!Run_Encoded_Command(item_checked.ToString()))
                    Output_Line("Unknown: " + item_checked.ToString());

            Basic_Go.Enabled = true;
        }

        private void Link_Go_Click(object sender, EventArgs e)
        {
            Link_Go.Enabled = false;
                      
            foreach (object item_checked in Link_Box.CheckedItems)
                File_Copy(item_checked.ToString(), PUBLIC_DESKTOP);
            
            Link_Go.Enabled = true;
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
            App_Go.Enabled = false;
                                   
            foreach (object item_checked in App_Box.CheckedItems)
                Run_App(item_checked.ToString());
            
            App_Go.Enabled = true;
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
            if (File.Exists(source) && !File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
            {
                try
                {
                    File.Copy(source, Path.Combine(dest_dir, Path.GetFileName(source)));
                    if (File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
                        Add_Status("Done.");
                }
                catch
                {
                    Add_Status("Unable to copy!");
                    return false;
                }
                return true;
            }
            else if (File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
            {
                Add_Status("Alreay Exists.");
                return true;
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

        private void Post_Box_MouseLeave(object sender, EventArgs e)
        {
            if (Post_Box.CheckedIndices.Count < 1)
                Post_Go.Enabled = false;
            else
                Post_Go.Enabled = true;
        }

        private void Post_Go_Click(object sender, EventArgs e)
        {
            Post_Go.Enabled = false;

            foreach (object item_checked in Post_Box.CheckedItems)
                if (!Run_Encoded_Command(item_checked.ToString()))
                    Output_Line("Unknown: " + item_checked.ToString());

            Post_Go.Enabled = true;
        }
    }
}
