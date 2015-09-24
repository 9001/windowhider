namespace windowhider
{
    partial class Form1
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
            this._autostart = new System.Windows.Forms.CheckBox();
            this._autohide = new System.Windows.Forms.CheckBox();
            this._title = new System.Windows.Forms.TextBox();
            this._class = new System.Windows.Forms.TextBox();
            this._cProc = new System.Windows.Forms.CheckBox();
            this._proc = new System.Windows.Forms.TextBox();
            this._doStart = new System.Windows.Forms.Button();
            this._doHide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._freq = new System.Windows.Forms.TextBox();
            this._link = new System.Windows.Forms.LinkLabel();
            this._ini = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._cTitle = new System.Windows.Forms.CheckBox();
            this._cClass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _autostart
            // 
            this._autostart.AutoSize = true;
            this._autostart.Location = new System.Drawing.Point(12, 12);
            this._autostart.Name = "_autostart";
            this._autostart.Size = new System.Drawing.Size(118, 17);
            this._autostart.TabIndex = 0;
            this._autostart.Text = "Autostart on startup";
            this._autostart.UseVisualStyleBackColor = true;
            // 
            // _autohide
            // 
            this._autohide.AutoSize = true;
            this._autohide.Location = new System.Drawing.Point(141, 12);
            this._autohide.Name = "_autohide";
            this._autohide.Size = new System.Drawing.Size(118, 17);
            this._autohide.TabIndex = 1;
            this._autohide.Text = "Autohide on startup";
            this._autohide.UseVisualStyleBackColor = true;
            // 
            // _title
            // 
            this._title.Enabled = false;
            this._title.Location = new System.Drawing.Point(141, 69);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(220, 20);
            this._title.TabIndex = 3;
            // 
            // _class
            // 
            this._class.Location = new System.Drawing.Point(141, 95);
            this._class.Name = "_class";
            this._class.Size = new System.Drawing.Size(220, 20);
            this._class.TabIndex = 5;
            this._class.Text = "VisualStudioGlowWindow";
            // 
            // _cProc
            // 
            this._cProc.AutoSize = true;
            this._cProc.Checked = true;
            this._cProc.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cProc.Location = new System.Drawing.Point(12, 123);
            this._cProc.Name = "_cProc";
            this._cProc.Size = new System.Drawing.Size(97, 17);
            this._cProc.TabIndex = 6;
            this._cProc.Text = "Parent process";
            this._cProc.UseVisualStyleBackColor = true;
            this._cProc.CheckedChanged += new System.EventHandler(this._cProc_CheckedChanged);
            // 
            // _proc
            // 
            this._proc.Location = new System.Drawing.Point(141, 121);
            this._proc.Name = "_proc";
            this._proc.Size = new System.Drawing.Size(220, 20);
            this._proc.TabIndex = 7;
            this._proc.Text = "devenv";
            // 
            // _doStart
            // 
            this._doStart.Location = new System.Drawing.Point(291, 147);
            this._doStart.Name = "_doStart";
            this._doStart.Size = new System.Drawing.Size(70, 23);
            this._doStart.TabIndex = 8;
            this._doStart.Text = "S t a r t";
            this._doStart.UseVisualStyleBackColor = true;
            this._doStart.Click += new System.EventHandler(this._doStart_Click);
            // 
            // _doHide
            // 
            this._doHide.Location = new System.Drawing.Point(215, 147);
            this._doHide.Name = "_doHide";
            this._doHide.Size = new System.Drawing.Size(70, 23);
            this._doHide.TabIndex = 9;
            this._doHide.Text = "H i d e";
            this._doHide.UseVisualStyleBackColor = true;
            this._doHide.Click += new System.EventHandler(this._doHide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Check every... ( msec)";
            // 
            // _freq
            // 
            this._freq.Location = new System.Drawing.Point(141, 149);
            this._freq.Name = "_freq";
            this._freq.Size = new System.Drawing.Size(53, 20);
            this._freq.TabIndex = 11;
            this._freq.Text = "5000";
            // 
            // _link
            // 
            this._link.AutoSize = true;
            this._link.Location = new System.Drawing.Point(296, 13);
            this._link.Name = "_link";
            this._link.Size = new System.Drawing.Size(65, 13);
            this._link.TabIndex = 12;
            this._link.TabStop = true;
            this._link.Text = "github/9001";
            this._link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._link_LinkClicked);
            // 
            // _ini
            // 
            this._ini.AutoSize = true;
            this._ini.Location = new System.Drawing.Point(9, 40);
            this._ini.Name = "_ini";
            this._ini.Size = new System.Drawing.Size(26, 13);
            this._ini.TabIndex = 13;
            this._ini.Text = "ini:  ";
            this._ini.Click += new System.EventHandler(this._ini_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(-39, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(463, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "____________________________________________________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(-39, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "____________________________________________________________________________";
            // 
            // _cTitle
            // 
            this._cTitle.AutoSize = true;
            this._cTitle.Location = new System.Drawing.Point(12, 71);
            this._cTitle.Name = "_cTitle";
            this._cTitle.Size = new System.Drawing.Size(88, 17);
            this._cTitle.TabIndex = 16;
            this._cTitle.Text = "Window Title";
            this._cTitle.UseVisualStyleBackColor = true;
            this._cTitle.CheckedChanged += new System.EventHandler(this._cTitle_CheckedChanged);
            // 
            // _cClass
            // 
            this._cClass.AutoSize = true;
            this._cClass.Checked = true;
            this._cClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cClass.Location = new System.Drawing.Point(12, 97);
            this._cClass.Name = "_cClass";
            this._cClass.Size = new System.Drawing.Size(124, 17);
            this._cClass.TabIndex = 17;
            this._cClass.Text = "Window Class Name";
            this._cClass.UseVisualStyleBackColor = true;
            this._cClass.CheckedChanged += new System.EventHandler(this._cClass_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 182);
            this.Controls.Add(this._cClass);
            this.Controls.Add(this._cTitle);
            this.Controls.Add(this._ini);
            this.Controls.Add(this._link);
            this.Controls.Add(this._freq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._doHide);
            this.Controls.Add(this._doStart);
            this.Controls.Add(this._proc);
            this.Controls.Add(this._cProc);
            this.Controls.Add(this._class);
            this.Controls.Add(this._title);
            this.Controls.Add(this._autohide);
            this.Controls.Add(this._autostart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "windowhider";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _autostart;
        private System.Windows.Forms.CheckBox _autohide;
        private System.Windows.Forms.TextBox _title;
        private System.Windows.Forms.TextBox _class;
        private System.Windows.Forms.CheckBox _cProc;
        private System.Windows.Forms.TextBox _proc;
        private System.Windows.Forms.Button _doStart;
        private System.Windows.Forms.Button _doHide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _freq;
        private System.Windows.Forms.LinkLabel _link;
        private System.Windows.Forms.Label _ini;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _cTitle;
        private System.Windows.Forms.CheckBox _cClass;
    }
}

