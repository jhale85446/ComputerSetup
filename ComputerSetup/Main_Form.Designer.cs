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
            this.Exit_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Working_Dir = new System.Windows.Forms.TextBox();
            this.Basic_Box = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            this.Basic_Setup_Box.SuspendLayout();
            this.App_Install_Box.SuspendLayout();
            this.Link_Setup_Box.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(808, 439);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(75, 23);
            this.Exit_Button.TabIndex = 0;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(391, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Working_Dir
            // 
            this.Working_Dir.Location = new System.Drawing.Point(101, 27);
            this.Working_Dir.Name = "Working_Dir";
            this.Working_Dir.Size = new System.Drawing.Size(542, 20);
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
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "&Program";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Basic_Setup_Box
            // 
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
            this.Link_Setup_Box.Controls.Add(this.textBox1);
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
            this.groupBox1.Location = new System.Drawing.Point(655, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 395);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // Output_box
            // 
            this.Output_box.Location = new System.Drawing.Point(6, 19);
            this.Output_box.Name = "Output_box";
            this.Output_box.ReadOnly = true;
            this.Output_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Output_box.Size = new System.Drawing.Size(480, 370);
            this.Output_box.TabIndex = 0;
            this.Output_box.Text = "";
            this.Output_box.TextChanged += new System.EventHandler(this.Output_box_TextChanged);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Link_Setup_Box);
            this.Controls.Add(this.App_Install_Box);
            this.Controls.Add(this.Basic_Setup_Box);
            this.Controls.Add(this.Working_Dir);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.TextBox textBox1;
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
    }
}

