namespace TypingGame
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
            this.lbGameKeys = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCorrect = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMissed = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAccuracy = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDifficulty = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbDifficulty = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGameKeys
            // 
            this.lbGameKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGameKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGameKeys.FormattingEnabled = true;
            this.lbGameKeys.ItemHeight = 108;
            this.lbGameKeys.Location = new System.Drawing.Point(0, 0);
            this.lbGameKeys.MultiColumn = true;
            this.lbGameKeys.Name = "lbGameKeys";
            this.lbGameKeys.Size = new System.Drawing.Size(860, 137);
            this.lbGameKeys.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCorrect,
            this.lblMissed,
            this.lblTotal,
            this.lblAccuracy,
            this.lblDifficulty,
            this.pbDifficulty});
            this.statusStrip1.Location = new System.Drawing.Point(0, 115);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCorrect
            // 
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(55, 17);
            this.lblCorrect.Text = "Correct:0";
            // 
            // lblMissed
            // 
            this.lblMissed.Name = "lblMissed";
            this.lblMissed.Size = new System.Drawing.Size(58, 17);
            this.lblMissed.Text = "Misssed:0";
            // 
            // lblTotal
            // 
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 17);
            this.lblTotal.Text = "Total:0";
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(75, 17);
            this.lblAccuracy.Text = "Accuracy:0%";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(262, 17);
            this.lblDifficulty.Spring = true;
            this.lblDifficulty.Text = "Difficulty";
            this.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbDifficulty
            // 
            this.pbDifficulty.Name = "pbDifficulty";
            this.pbDifficulty.Size = new System.Drawing.Size(100, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 137);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbGameKeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Typing Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGameKeys;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCorrect;
        private System.Windows.Forms.ToolStripStatusLabel lblMissed;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblAccuracy;
        private System.Windows.Forms.ToolStripStatusLabel lblDifficulty;
        private System.Windows.Forms.ToolStripProgressBar pbDifficulty;
    }
}

