namespace ChatApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NotifTitle = new System.Windows.Forms.Label();
            this.NotifContent = new System.Windows.Forms.Label();
            this.Dismisslabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // NotifTitle
            // 
            this.NotifTitle.AutoSize = true;
            this.NotifTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotifTitle.Location = new System.Drawing.Point(12, 21);
            this.NotifTitle.Name = "NotifTitle";
            this.NotifTitle.Size = new System.Drawing.Size(126, 19);
            this.NotifTitle.TabIndex = 0;
            this.NotifTitle.Text = "Notification title";
            this.NotifTitle.Click += new System.EventHandler(this.NotifTitle_Click);
            // 
            // NotifContent
            // 
            this.NotifContent.AutoSize = true;
            this.NotifContent.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.NotifContent.Location = new System.Drawing.Point(12, 54);
            this.NotifContent.Name = "NotifContent";
            this.NotifContent.Size = new System.Drawing.Size(97, 19);
            this.NotifContent.TabIndex = 1;
            this.NotifContent.Text = "NotifContent";
            this.NotifContent.Click += new System.EventHandler(this.NotifContent_Click);
            // 
            // Dismisslabel
            // 
            this.Dismisslabel.AutoSize = true;
            this.Dismisslabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dismisslabel.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.Dismisslabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Dismisslabel.Location = new System.Drawing.Point(279, 21);
            this.Dismisslabel.Name = "Dismisslabel";
            this.Dismisslabel.Size = new System.Drawing.Size(53, 19);
            this.Dismisslabel.TabIndex = 3;
            this.Dismisslabel.Text = "Dismiss";
            this.Dismisslabel.Click += new System.EventHandler(this.Dismisslabel_Click);
            this.Dismisslabel.MouseLeave += new System.EventHandler(this.Dismisslabel_MouseLeave);
            this.Dismisslabel.MouseHover += new System.EventHandler(this.Dismisslabel_MouseHover);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Message Notification";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(152)))), ((int)(((byte)(239)))));
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 10);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(340, 106);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dismisslabel);
            this.Controls.Add(this.NotifContent);
            this.Controls.Add(this.NotifTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NotifTitle;
        private System.Windows.Forms.Label NotifContent;
        private System.Windows.Forms.Label Dismisslabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
    }
}

