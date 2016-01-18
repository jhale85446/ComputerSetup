﻿using System;
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
        string CURR_DIR = Directory.GetCurrentDirectory();
        string LINK_PATH = @"E:\OSSI_Setup\Links";
        string APP_PATH = @"E:\OSSI_Setup\Applications";
        string BASIC_PATH = @"E:\OSSI_Setup";
        string BASIC_FILENAME = "basic_setup.txt";

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
                string[] files = Directory.GetFiles(LINK_PATH, "*.*");

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
                string[] files = Directory.GetFiles(APP_PATH, "*.exe");
                foreach (string file in files)
                    App_Box.Items.Add(file, true);

                files = Directory.GetFiles(APP_PATH, "*.msi");
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
            
            if (!File.Exists(Path.Combine(BASIC_PATH, BASIC_FILENAME)))
            {
                Output_Line(BASIC_FILENAME + " Not Found!");
                return;
            }

            try
            {
                StreamReader file = new StreamReader(Path.Combine(BASIC_PATH, BASIC_FILENAME));

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
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Basic_Go_Click(object sender, EventArgs e)
        {
            string[] command;

            Basic_Go.Enabled = false;

            foreach (object item_checked in Basic_Box.CheckedItems)
            {
                command = Parse_Command(item_checked.ToString());
                if (command[0] == "CMD")
                    Run_Cmd(command[1]);
                else if (command[0] == "RUN")
                    Run_App(command[1]);
                else if (command[0] == "REG")
                    Reg_Import(command[1]);
                else if (command[0] == "COPY")
                    File_Copy(command[1], command[2]);
                else
                    Output_Line("Unknown: " + item_checked.ToString());
            }

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
            this.WindowState = FormWindowState.Minimized;
                       
            foreach (object item_checked in App_Box.CheckedItems)
                Run_App(item_checked.ToString());
            
            App_Go.Enabled = true;
            this.WindowState = FormWindowState.Normal;
        }

        private bool Reg_Import(string reg_file)
        {
            string arg;
            if (File.Exists(reg_file))
            {
                Output_Line("Adding: " + Path.GetFileName(reg_file) + " to registry");
                arg = "/s " + reg_file;
                Process regeditProcess = Process.Start("regedit.exe", arg);
                regeditProcess.WaitForExit();
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
                    Process proc = new Process();
                    proc = Process.Start(exe);
                    proc.WaitForExit();
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
    }
}
