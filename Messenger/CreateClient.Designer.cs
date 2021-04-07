namespace Messenger
{
    partial class CreateClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address: ";
            // 
            // IpBox
            // 
            this.IpBox.Location = new System.Drawing.Point(201, 83);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(293, 23);
            this.IpBox.TabIndex = 0;
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(201, 168);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(293, 23);
            this.PassBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(45, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server password: ";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(201, 243);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(293, 23);
            this.UsernameBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(93, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username: ";
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(375, 306);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(119, 44);
            this.connect_button.TabIndex = 3;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // CreateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.IpBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateClient";
            this.Text = "CreateClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpBox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connect_button;
    }
}