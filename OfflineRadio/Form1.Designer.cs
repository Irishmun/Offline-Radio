namespace OfflineRadio
{
    partial class Form1
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
            this.BT_Play = new System.Windows.Forms.Button();
            this.BT_CloseProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_Play
            // 
            this.BT_Play.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BT_Play.FlatAppearance.BorderSize = 0;
            this.BT_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Play.Location = new System.Drawing.Point(39, 88);
            this.BT_Play.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Play.Name = "BT_Play";
            this.BT_Play.Size = new System.Drawing.Size(23, 18);
            this.BT_Play.TabIndex = 0;
            this.BT_Play.UseVisualStyleBackColor = false;
            // 
            // BT_CloseProgram
            // 
            this.BT_CloseProgram.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BT_CloseProgram.FlatAppearance.BorderSize = 0;
            this.BT_CloseProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_CloseProgram.Location = new System.Drawing.Point(264, 3);
            this.BT_CloseProgram.Margin = new System.Windows.Forms.Padding(0);
            this.BT_CloseProgram.Name = "BT_CloseProgram";
            this.BT_CloseProgram.Size = new System.Drawing.Size(9, 9);
            this.BT_CloseProgram.TabIndex = 1;
            this.BT_CloseProgram.UseVisualStyleBackColor = false;
            this.BT_CloseProgram.Click += new System.EventHandler(this.BT_CloseProgram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OfflineRadio.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(275, 116);
            this.Controls.Add(this.BT_CloseProgram);
            this.Controls.Add(this.BT_Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_Play;
        private System.Windows.Forms.Button BT_CloseProgram;
    }
}