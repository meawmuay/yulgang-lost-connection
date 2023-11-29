namespace Yulgang_Lost_Connection
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.checkedListBoxProcess = new System.Windows.Forms.CheckedListBox();
            this.buttonLoadProcess = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerBot = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLineNotify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxProcess
            // 
            this.checkedListBoxProcess.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBoxProcess.FormattingEnabled = true;
            this.checkedListBoxProcess.Location = new System.Drawing.Point(12, 34);
            this.checkedListBoxProcess.Name = "checkedListBoxProcess";
            this.checkedListBoxProcess.Size = new System.Drawing.Size(287, 157);
            this.checkedListBoxProcess.TabIndex = 1;
            // 
            // buttonLoadProcess
            // 
            this.buttonLoadProcess.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoadProcess.Location = new System.Drawing.Point(308, 35);
            this.buttonLoadProcess.Name = "buttonLoadProcess";
            this.buttonLoadProcess.Size = new System.Drawing.Size(107, 30);
            this.buttonLoadProcess.TabIndex = 2;
            this.buttonLoadProcess.Text = "โหลดข้อมูลเกม";
            this.buttonLoadProcess.UseVisualStyleBackColor = true;
            this.buttonLoadProcess.Click += new System.EventHandler(this.buttonLoadProcess_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLog.ForeColor = System.Drawing.Color.Gray;
            this.textBoxLog.Location = new System.Drawing.Point(12, 202);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(403, 123);
            this.textBoxLog.TabIndex = 20;
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.ForeColor = System.Drawing.Color.Crimson;
            this.buttonStop.Location = new System.Drawing.Point(308, 109);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(107, 33);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "หยุดทำงาน";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.ForeColor = System.Drawing.Color.Green;
            this.buttonStart.Location = new System.Drawing.Point(308, 67);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(107, 40);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "เริ่มทำงาน";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerBot
            // 
            this.timerBot.Tick += new System.EventHandler(this.timerBot_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout,
            this.ToolStripMenuItemUpdate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(427, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(58, 20);
            this.ToolStripMenuItemAbout.Text = "เกี่ยวกับ";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // ToolStripMenuItemUpdate
            // 
            this.ToolStripMenuItemUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToolStripMenuItemUpdate.Name = "ToolStripMenuItemUpdate";
            this.ToolStripMenuItemUpdate.Size = new System.Drawing.Size(52, 20);
            this.ToolStripMenuItemUpdate.Text = "อัปเดต";
            this.ToolStripMenuItemUpdate.Click += new System.EventHandler(this.ToolStripMenuItemUpdate_Click);
            // 
            // buttonLineNotify
            // 
            this.buttonLineNotify.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLineNotify.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonLineNotify.Location = new System.Drawing.Point(308, 161);
            this.buttonLineNotify.Name = "buttonLineNotify";
            this.buttonLineNotify.Size = new System.Drawing.Size(107, 30);
            this.buttonLineNotify.TabIndex = 5;
            this.buttonLineNotify.Text = "ตั้งค่า Line Notify";
            this.buttonLineNotify.UseVisualStyleBackColor = true;
            this.buttonLineNotify.Click += new System.EventHandler(this.buttonLineNotify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(10, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "โปรแกรมแจกฟรีโดย แมวหมวย";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLineNotify);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonLoadProcess);
            this.Controls.Add(this.checkedListBoxProcess);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yulgang Lost Connection";
            this.Load += new System.EventHandler(this.FormMain_LoadAsync);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox checkedListBoxProcess;
        private Button buttonLoadProcess;
        private TextBox textBoxLog;
        private Button buttonStop;
        private Button buttonStart;
        private System.Windows.Forms.Timer timerBot;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItemAbout;
        private ToolStripMenuItem ToolStripMenuItemUpdate;
        private Button buttonLineNotify;
        private Label label1;
    }
}