namespace ComputerSetup
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Exit_Button = new System.Windows.Forms.Button();
            this.desktop_path_box = new System.Windows.Forms.TextBox();
            this.Working_Dir = new System.Windows.Forms.TextBox();
            this.Basic_Box = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Basic_Setup_Box = new System.Windows.Forms.GroupBox();
            this.Basic_Go = new System.Windows.Forms.Button();
            this.App_Install_Box = new System.Windows.Forms.GroupBox();
            this.App_Go = new System.Windows.Forms.Button();
            this.App_Box = new System.Windows.Forms.CheckedListBox();
            this.Link_Setup_Box = new System.Windows.Forms.GroupBox();
            this.Link_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Link_Box = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Output_box = new System.Windows.Forms.RichTextBox();
            this.Post_Group_Box = new System.Windows.Forms.GroupBox();
            this.Post_Go = new System.Windows.Forms.Button();
            this.Post_Box = new System.Windows.Forms.CheckedListBox();
            this.change_dir_button = new System.Windows.Forms.Button();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.Clear_Output_Button = new System.Windows.Forms.Button();
            this.Basic_Edit_Button = new System.Windows.Forms.Button();
            this.Post_Edit_Button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Basic_Setup_Box.SuspendLayout();
            this.App_Install_Box.SuspendLayout();
            this.Link_Setup_Box.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Post_Group_Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(1044, 558);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(103, 31);
            this.Exit_Button.TabIndex = 0;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // desktop_path_box
            // 
            this.desktop_path_box.Location = new System.Drawing.Point(119, 19);
            this.desktop_path_box.Name = "desktop_path_box";
            this.desktop_path_box.ReadOnly = true;
            this.desktop_path_box.Size = new System.Drawing.Size(391, 20);
            this.desktop_path_box.TabIndex = 1;
            // 
            // Working_Dir
            // 
            this.Working_Dir.Location = new System.Drawing.Point(101, 27);
            this.Working_Dir.Name = "Working_Dir";
            this.Working_Dir.Size = new System.Drawing.Size(467, 20);
            this.Working_Dir.TabIndex = 2;
            // 
            // Basic_Box
            // 
            this.Basic_Box.FormattingEnabled = true;
            this.Basic_Box.HorizontalScrollbar = true;
            this.Basic_Box.Location = new System.Drawing.Point(6, 19);
            this.Basic_Box.Name = "Basic_Box";
            this.Basic_Box.Size = new System.Drawing.Size(504, 94);
            this.Basic_Box.TabIndex = 3;
            this.Basic_Box.MouseLeave += new System.EventHandler(this.Basic_Box_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "&Program";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Basic_Setup_Box
            // 
            this.Basic_Setup_Box.Controls.Add(this.Basic_Edit_Button);
            this.Basic_Setup_Box.Controls.Add(this.Basic_Go);
            this.Basic_Setup_Box.Controls.Add(this.Basic_Box);
            this.Basic_Setup_Box.Location = new System.Drawing.Point(12, 53);
            this.Basic_Setup_Box.Name = "Basic_Setup_Box";
            this.Basic_Setup_Box.Size = new System.Drawing.Size(637, 124);
            this.Basic_Setup_Box.TabIndex = 5;
            this.Basic_Setup_Box.TabStop = false;
            this.Basic_Setup_Box.Text = "Basic Setup";
            // 
            // Basic_Go
            // 
            this.Basic_Go.Location = new System.Drawing.Point(516, 19);
            this.Basic_Go.Name = "Basic_Go";
            this.Basic_Go.Size = new System.Drawing.Size(115, 55);
            this.Basic_Go.TabIndex = 4;
            this.Basic_Go.Text = "Go!";
            this.Basic_Go.UseVisualStyleBackColor = true;
            this.Basic_Go.Click += new System.EventHandler(this.Basic_Go_Click);
            // 
            // App_Install_Box
            // 
            this.App_Install_Box.Controls.Add(this.App_Go);
            this.App_Install_Box.Controls.Add(this.App_Box);
            this.App_Install_Box.Location = new System.Drawing.Point(12, 183);
            this.App_Install_Box.Name = "App_Install_Box";
            this.App_Install_Box.Size = new System.Drawing.Size(637, 121);
            this.App_Install_Box.TabIndex = 6;
            this.App_Install_Box.TabStop = false;
            this.App_Install_Box.Text = "Application Installation";
            // 
            // App_Go
            // 
            this.App_Go.Location = new System.Drawing.Point(516, 19);
            this.App_Go.Name = "App_Go";
            this.App_Go.Size = new System.Drawing.Size(115, 54);
            this.App_Go.TabIndex = 1;
            this.App_Go.Text = "Go!";
            this.App_Go.UseVisualStyleBackColor = true;
            this.App_Go.Click += new System.EventHandler(this.App_Go_Click);
            // 
            // App_Box
            // 
            this.App_Box.FormattingEnabled = true;
            this.App_Box.HorizontalScrollbar = true;
            this.App_Box.Location = new System.Drawing.Point(6, 18);
            this.App_Box.Name = "App_Box";
            this.App_Box.Size = new System.Drawing.Size(504, 94);
            this.App_Box.TabIndex = 0;
            this.App_Box.MouseLeave += new System.EventHandler(this.App_Box_MouseLeave);
            // 
            // Link_Setup_Box
            // 
            this.Link_Setup_Box.Controls.Add(this.Link_Go);
            this.Link_Setup_Box.Controls.Add(this.label1);
            this.Link_Setup_Box.Controls.Add(this.Link_Box);
            this.Link_Setup_Box.Controls.Add(this.desktop_path_box);
            this.Link_Setup_Box.Location = new System.Drawing.Point(12, 310);
            this.Link_Setup_Box.Name = "Link_Setup_Box";
            this.Link_Setup_Box.Size = new System.Drawing.Size(637, 152);
            this.Link_Setup_Box.TabIndex = 7;
            this.Link_Setup_Box.TabStop = false;
            this.Link_Setup_Box.Text = "Link Copy";
            // 
            // Link_Go
            // 
            this.Link_Go.Location = new System.Drawing.Point(516, 45);
            this.Link_Go.Name = "Link_Go";
            this.Link_Go.Size = new System.Drawing.Size(115, 54);
            this.Link_Go.TabIndex = 4;
            this.Link_Go.Text = "Go!";
            this.Link_Go.UseVisualStyleBackColor = true;
            this.Link_Go.Click += new System.EventHandler(this.Link_Go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Public Desktop Path:";
            // 
            // Link_Box
            // 
            this.Link_Box.FormattingEnabled = true;
            this.Link_Box.HorizontalScrollbar = true;
            this.Link_Box.Location = new System.Drawing.Point(9, 45);
            this.Link_Box.Name = "Link_Box";
            this.Link_Box.Size = new System.Drawing.Size(501, 94);
            this.Link_Box.TabIndex = 2;
            this.Link_Box.MouseLeave += new System.EventHandler(this.Link_Box_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Working Directory:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Output_box);
            this.groupBox1.Location = new System.Drawing.Point(655, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 499);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // Output_box
            // 
            this.Output_box.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Output_box.ForeColor = System.Drawing.SystemColors.Info;
            this.Output_box.Location = new System.Drawing.Point(6, 19);
            this.Output_box.Name = "Output_box";
            this.Output_box.ReadOnly = true;
            this.Output_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Output_box.Size = new System.Drawing.Size(480, 497);
            this.Output_box.TabIndex = 0;
            this.Output_box.Text = "";
            // 
            // Post_Group_Box
            // 
            this.Post_Group_Box.Controls.Add(this.Post_Edit_Button);
            this.Post_Group_Box.Controls.Add(this.Post_Go);
            this.Post_Group_Box.Controls.Add(this.Post_Box);
            this.Post_Group_Box.Location = new System.Drawing.Point(12, 468);
            this.Post_Group_Box.Name = "Post_Group_Box";
            this.Post_Group_Box.Size = new System.Drawing.Size(637, 121);
            this.Post_Group_Box.TabIndex = 10;
            this.Post_Group_Box.TabStop = false;
            this.Post_Group_Box.Text = "Post Setup Operations";
            // 
            // Post_Go
            // 
            this.Post_Go.Location = new System.Drawing.Point(516, 17);
            this.Post_Go.Name = "Post_Go";
            this.Post_Go.Size = new System.Drawing.Size(115, 51);
            this.Post_Go.TabIndex = 1;
            this.Post_Go.Text = "Go!";
            this.Post_Go.UseVisualStyleBackColor = true;
            this.Post_Go.Click += new System.EventHandler(this.Post_Go_Click);
            // 
            // Post_Box
            // 
            this.Post_Box.FormattingEnabled = true;
            this.Post_Box.Location = new System.Drawing.Point(8, 17);
            this.Post_Box.Name = "Post_Box";
            this.Post_Box.Size = new System.Drawing.Size(502, 94);
            this.Post_Box.TabIndex = 0;
            this.Post_Box.MouseLeave += new System.EventHandler(this.Post_Box_MouseLeave);
            // 
            // change_dir_button
            // 
            this.change_dir_button.Location = new System.Drawing.Point(574, 25);
            this.change_dir_button.Name = "change_dir_button";
            this.change_dir_button.Size = new System.Drawing.Size(75, 23);
            this.change_dir_button.TabIndex = 11;
            this.change_dir_button.Text = "Change";
            this.change_dir_button.UseVisualStyleBackColor = true;
            this.change_dir_button.Click += new System.EventHandler(this.change_dir_button_Click);
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Location = new System.Drawing.Point(655, 25);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(80, 23);
            this.Refresh_Button.TabIndex = 12;
            this.Refresh_Button.Text = "Refresh";
            this.Refresh_Button.UseVisualStyleBackColor = true;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // Clear_Output_Button
            // 
            this.Clear_Output_Button.Location = new System.Drawing.Point(1072, 30);
            this.Clear_Output_Button.Name = "Clear_Output_Button";
            this.Clear_Output_Button.Size = new System.Drawing.Size(75, 23);
            this.Clear_Output_Button.TabIndex = 13;
            this.Clear_Output_Button.Text = "Clear Output";
            this.Clear_Output_Button.UseVisualStyleBackColor = true;
            this.Clear_Output_Button.Click += new System.EventHandler(this.Clear_Output_Button_Click);
            // 
            // Basic_Edit_Button
            // 
            this.Basic_Edit_Button.Location = new System.Drawing.Point(516, 79);
            this.Basic_Edit_Button.Name = "Basic_Edit_Button";
            this.Basic_Edit_Button.Size = new System.Drawing.Size(115, 34);
            this.Basic_Edit_Button.TabIndex = 5;
            this.Basic_Edit_Button.Text = "Edit Basic Setup";
            this.Basic_Edit_Button.UseVisualStyleBackColor = true;
            this.Basic_Edit_Button.Click += new System.EventHandler(this.Basic_Edit_Button_Click);
            // 
            // Post_Edit_Button
            // 
            this.Post_Edit_Button.Location = new System.Drawing.Point(516, 71);
            this.Post_Edit_Button.Name = "Post_Edit_Button";
            this.Post_Edit_Button.Size = new System.Drawing.Size(115, 40);
            this.Post_Edit_Button.TabIndex = 2;
            this.Post_Edit_Button.Text = "Edit Post Setup";
            this.Post_Edit_Button.UseVisualStyleBackColor = true;
            this.Post_Edit_Button.Click += new System.EventHandler(this.Post_Edit_Button_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 601);
            this.Controls.Add(this.Clear_Output_Button);
            this.Controls.Add(this.Refresh_Button);
            this.Controls.Add(this.change_dir_button);
            this.Controls.Add(this.Working_Dir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Post_Group_Box);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Link_Setup_Box);
            this.Controls.Add(this.App_Install_Box);
            this.Controls.Add(this.Basic_Setup_Box);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Text = "Computer Setup";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Basic_Setup_Box.ResumeLayout(false);
            this.App_Install_Box.ResumeLayout(false);
            this.Link_Setup_Box.ResumeLayout(false);
            this.Link_Setup_Box.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Post_Group_Box.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.TextBox desktop_path_box;
        private System.Windows.Forms.TextBox Working_Dir;
        private System.Windows.Forms.CheckedListBox Basic_Box;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox Basic_Setup_Box;
        private System.Windows.Forms.GroupBox App_Install_Box;
        private System.Windows.Forms.Button Basic_Go;
        private System.Windows.Forms.CheckedListBox App_Box;
        private System.Windows.Forms.GroupBox Link_Setup_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox Link_Box;
        private System.Windows.Forms.Button App_Go;
        private System.Windows.Forms.Button Link_Go;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox Output_box;
        private System.Windows.Forms.GroupBox Post_Group_Box;
        private System.Windows.Forms.Button Post_Go;
        private System.Windows.Forms.CheckedListBox Post_Box;
        private System.Windows.Forms.Button change_dir_button;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button Refresh_Button;
        private System.Windows.Forms.Button Clear_Output_Button;
        private System.Windows.Forms.Button Basic_Edit_Button;
        private System.Windows.Forms.Button Post_Edit_Button;
    }
}

