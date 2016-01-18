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
        string public_desktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        string current_dir = Directory.GetCurrentDirectory();
        string link_path = @"E:\OSSI_Setup\Links";
        string app_path = @"E:\OSSI_Setup\Applications";

        private void OutputLine(string output)
        {
            string time = System.DateTime.Now.TimeOfDay.Hours.ToString("00") + ":";
            time = time + System.DateTime.Now.TimeOfDay.Minutes.ToString("00") + ":";
            time = time + System.DateTime.Now.TimeOfDay.Seconds.ToString("00");
            output = "(" + time + ") " + output + "\n\n";
            Output_box.Text = Output_box.Text.Insert(0, output);
        }

        private void AddStatus(string status)
        {
            string[] lines = Output_box.Lines;
            lines[0] = lines[0] + "  -  " + status;
            Output_box.Lines = lines;
            //Output_box.Text = Output_box.Text + "  -  " + status;
        }

        private void AddCmdOuput(string CmdOuput, string Cmd)
        {
            string divider = "****************************************************************************************************************";
            string[] lines = Output_box.Lines;
            CmdOuput = divider + Environment.NewLine + "> " + Cmd + Environment.NewLine + CmdOuput + divider;
            Output_box.Text = Output_box.Text.Insert(lines[0].Length + 1, CmdOuput);
        }

        private void ErrorBox(string message)
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
                string[] files = Directory.GetFiles(link_path, "*.*");

                foreach (string fle in files)
                {
                    Link_Box.Items.Add(fle, true);
                }
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                ErrorBox("Directory Not Found!");
            }

            Link_Box_MouseLeave(null, null);
        }

        private void Pop_Apps()
        {
            try
            {
                string[] files = Directory.GetFiles(app_path, "*.exe");
                foreach (string fle in files)
                    App_Box.Items.Add(fle, true);

                files = Directory.GetFiles(app_path, "*.msi");
                foreach (string fle in files)
                    App_Box.Items.Add(fle, true);
            }

            catch (System.IO.DirectoryNotFoundException)
            {
                ErrorBox("Directory Not Found!");
            }
        }

        private void Pop_Basic()
        {
            //Basic_Box_MouseLeave(null, null);
        }

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = public_desktop;
            Working_Dir.Text = current_dir;
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
            command("route print");
        }

        private void Link_Go_Click(object sender, EventArgs e)
        {
            Link_Go.Enabled = false;
                      
            foreach (object itemChecked in Link_Box.CheckedItems)
                file_copy(itemChecked.ToString(), public_desktop);
            
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
            //if (Basic_Box.CheckedIndices.Count < 1)
                //Basic_Go.Enabled = false;
            //else
                //Basic_Go.Enabled = true;
        }

        private void App_Go_Click(object sender, EventArgs e)
        {
            App_Go.Enabled = false;
            this.WindowState = FormWindowState.Minimized;
                       
            foreach (object itemChecked in App_Box.CheckedItems)
                run(itemChecked.ToString());
            
            App_Go.Enabled = true;
            this.WindowState = FormWindowState.Normal;
        }

        private bool Reg_Import(string reg_file)
        {
            string arg;
            if (File.Exists(reg_file))
            {
                OutputLine("Adding: " + Path.GetFileName(reg_file) + " to registry");
                arg = "/s " + reg_file;
                Process regeditProcess = Process.Start("regedit.exe", arg);
                regeditProcess.WaitForExit();
                AddStatus("Done.");
                return true;
            }
            else
            {
                OutputLine("File " + reg_file + " Not Found!");
                return false;
            }
        }

        private bool file_copy(string source, string dest_dir)
        {
            OutputLine("Copying: " + Path.GetFileName(source) + " -> " + dest_dir);
            if (File.Exists(source) && !File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
            {
                try
                {
                    File.Copy(source, Path.Combine(dest_dir, Path.GetFileName(source)));
                    if (File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
                        AddStatus("Done.");
                }
                catch
                {
                    AddStatus("Unable to copy!");
                    return false;
                }
                return true;
            }
            else if (File.Exists(Path.Combine(dest_dir, Path.GetFileName(source))))
            {
                AddStatus("Alreay Exists.");
                return true;
            }
            else
            {
                AddStatus("File Not Found!");
                return false;
            }
        }

        private bool command(string cmd)
        {
            OutputLine("Executing: " + cmd);
            if (cmd != "")
            {
                Process proc = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = false;
                startInfo.FileName = "cmd.exe";
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = false;
                startInfo.Arguments = "/C " + cmd;
                proc.StartInfo = startInfo;
                proc.Start();
                AddCmdOuput(proc.StandardOutput.ReadToEnd(), cmd);
                proc.WaitForExit();
                return true;
            }
            else
            {
                AddStatus("Empy Command!");
                return false;
            }
        }

        private bool run(string exe)
        {
            OutputLine("Running: " + Path.GetFileName(exe));
            if (File.Exists(exe))
            {
                try
                {
                    Process proc = new Process();
                    proc = Process.Start(exe);
                    proc.WaitForExit();
                    AddStatus("Done.");
                    return true;
                }

                catch
                {
                    AddStatus("Unable to run!");
                    return false;
                }
            }
            else
            {
                AddStatus("File Not Found!");
                return false;
            }
        }

        private void Output_box_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
