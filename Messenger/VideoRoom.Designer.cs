namespace Messenger
{
    partial class VideoRoom
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
            this.CameraSelect = new System.Windows.Forms.ComboBox();
            this.videoFrame = new System.Windows.Forms.PictureBox();
            this.join_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.MemberBox = new System.Windows.Forms.ListBox();
            this.StatLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraSelect
            // 
            this.CameraSelect.FormattingEnabled = true;
            this.CameraSelect.Location = new System.Drawing.Point(539, 12);
            this.CameraSelect.Name = "CameraSelect";
            this.CameraSelect.Size = new System.Drawing.Size(140, 23);
            this.CameraSelect.TabIndex = 0;
            // 
            // videoFrame
            // 
            this.videoFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoFrame.Location = new System.Drawing.Point(12, 12);
            this.videoFrame.Name = "videoFrame";
            this.videoFrame.Size = new System.Drawing.Size(521, 533);
            this.videoFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoFrame.TabIndex = 1;
            this.videoFrame.TabStop = false;
            // 
            // join_button
            // 
            this.join_button.Location = new System.Drawing.Point(577, 467);
            this.join_button.Name = "join_button";
            this.join_button.Size = new System.Drawing.Size(75, 23);
            this.join_button.TabIndex = 2;
            this.join_button.Text = "Join Room";
            this.join_button.UseVisualStyleBackColor = true;
            this.join_button.Click += new System.EventHandler(this.join_button_Click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Location = new System.Drawing.Point(577, 522);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(75, 23);
            this.disconnect_button.TabIndex = 3;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            // 
            // MemberBox
            // 
            this.MemberBox.FormattingEnabled = true;
            this.MemberBox.ItemHeight = 15;
            this.MemberBox.Location = new System.Drawing.Point(548, 114);
            this.MemberBox.Name = "MemberBox";
            this.MemberBox.Size = new System.Drawing.Size(120, 139);
            this.MemberBox.TabIndex = 4;
            // 
            // StatLabel
            // 
            this.StatLabel.AutoSize = true;
            this.StatLabel.Location = new System.Drawing.Point(589, 256);
            this.StatLabel.Name = "StatLabel";
            this.StatLabel.Size = new System.Drawing.Size(58, 15);
            this.StatLabel.TabIndex = 5;
            this.StatLabel.Text = "Unknown";
            this.StatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VideoRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 557);
            this.Controls.Add(this.StatLabel);
            this.Controls.Add(this.MemberBox);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.join_button);
            this.Controls.Add(this.videoFrame);
            this.Controls.Add(this.CameraSelect);
            this.Name = "VideoRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoRoom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoRoom_FormClosing);
            this.Load += new System.EventHandler(this.VideoRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CameraSelect;
        private System.Windows.Forms.PictureBox videoFrame;
        private System.Windows.Forms.Button join_button;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.ListBox MemberBox;
        private System.Windows.Forms.Label StatLabel;
    }
}