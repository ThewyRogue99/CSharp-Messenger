namespace Messenger
{
    partial class MessengerWindow
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
            this.Members = new System.Windows.Forms.ListBox();
            this.Message_Box = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kick_button = new System.Windows.Forms.Button();
            this.info_button = new System.Windows.Forms.Button();
            this.typelabel = new System.Windows.Forms.Label();
            this.selectfile_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedfile_label = new System.Windows.Forms.Label();
            this.sendfile_button = new System.Windows.Forms.Button();
            this.join_room_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Members
            // 
            this.Members.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Members.FormattingEnabled = true;
            this.Members.ItemHeight = 15;
            this.Members.Location = new System.Drawing.Point(148, 73);
            this.Members.Name = "Members";
            this.Members.Size = new System.Drawing.Size(138, 229);
            this.Members.TabIndex = 4;
            // 
            // Message_Box
            // 
            this.Message_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Message_Box.Location = new System.Drawing.Point(302, 12);
            this.Message_Box.Multiline = true;
            this.Message_Box.Name = "Message_Box";
            this.Message_Box.ReadOnly = true;
            this.Message_Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Message_Box.Size = new System.Drawing.Size(470, 491);
            this.Message_Box.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(302, 554);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(470, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(163, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type a message:";
            // 
            // kick_button
            // 
            this.kick_button.Enabled = false;
            this.kick_button.Location = new System.Drawing.Point(12, 89);
            this.kick_button.Name = "kick_button";
            this.kick_button.Size = new System.Drawing.Size(75, 23);
            this.kick_button.TabIndex = 5;
            this.kick_button.Text = "Kick";
            this.kick_button.UseVisualStyleBackColor = true;
            this.kick_button.Click += new System.EventHandler(this.kick_button_Click);
            // 
            // info_button
            // 
            this.info_button.Location = new System.Drawing.Point(12, 12);
            this.info_button.Name = "info_button";
            this.info_button.Size = new System.Drawing.Size(75, 23);
            this.info_button.TabIndex = 6;
            this.info_button.Text = "Server Info";
            this.info_button.UseVisualStyleBackColor = true;
            this.info_button.Click += new System.EventHandler(this.info_button_Click);
            // 
            // typelabel
            // 
            this.typelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typelabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.typelabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.typelabel.Location = new System.Drawing.Point(302, 521);
            this.typelabel.Name = "typelabel";
            this.typelabel.Size = new System.Drawing.Size(470, 20);
            this.typelabel.TabIndex = 6;
            this.typelabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectfile_button
            // 
            this.selectfile_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectfile_button.Location = new System.Drawing.Point(12, 620);
            this.selectfile_button.Name = "selectfile_button";
            this.selectfile_button.Size = new System.Drawing.Size(124, 29);
            this.selectfile_button.TabIndex = 2;
            this.selectfile_button.Text = "Select a File";
            this.selectfile_button.UseVisualStyleBackColor = true;
            this.selectfile_button.Click += new System.EventHandler(this.selectfile_button_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(163, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Selected File: ";
            // 
            // selectedfile_label
            // 
            this.selectedfile_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedfile_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedfile_label.Location = new System.Drawing.Point(302, 622);
            this.selectedfile_label.Name = "selectedfile_label";
            this.selectedfile_label.Size = new System.Drawing.Size(385, 21);
            this.selectedfile_label.TabIndex = 9;
            this.selectedfile_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sendfile_button
            // 
            this.sendfile_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendfile_button.Enabled = false;
            this.sendfile_button.Location = new System.Drawing.Point(693, 618);
            this.sendfile_button.Name = "sendfile_button";
            this.sendfile_button.Size = new System.Drawing.Size(79, 29);
            this.sendfile_button.TabIndex = 3;
            this.sendfile_button.Text = "Send File";
            this.sendfile_button.UseVisualStyleBackColor = true;
            this.sendfile_button.Click += new System.EventHandler(this.sendfile_button_Click);
            // 
            // join_room_button
            // 
            this.join_room_button.Location = new System.Drawing.Point(148, 308);
            this.join_room_button.Name = "join_room_button";
            this.join_room_button.Size = new System.Drawing.Size(138, 23);
            this.join_room_button.TabIndex = 10;
            this.join_room_button.Text = "Unknown";
            this.join_room_button.UseVisualStyleBackColor = true;
            this.join_room_button.Click += new System.EventHandler(this.join_room_button_Click);
            // 
            // MessengerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.join_room_button);
            this.Controls.Add(this.sendfile_button);
            this.Controls.Add(this.selectedfile_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectfile_button);
            this.Controls.Add(this.typelabel);
            this.Controls.Add(this.info_button);
            this.Controls.Add(this.kick_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Message_Box);
            this.Controls.Add(this.Members);
            this.Name = "MessengerWindow";
            this.Text = "MessengerWindow";
            this.Load += new System.EventHandler(this.MessengerWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Members;
        private System.Windows.Forms.TextBox Message_Box;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kick_button;
        private System.Windows.Forms.Button info_button;
        private System.Windows.Forms.Label typelabel;
        private System.Windows.Forms.Button selectfile_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selectedfile_label;
        private System.Windows.Forms.Button sendfile_button;
        private System.Windows.Forms.Button join_room_button;
    }
}