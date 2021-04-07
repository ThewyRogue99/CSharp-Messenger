namespace Messenger
{
    partial class Entry
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
            this.connect_button = new System.Windows.Forms.Button();
            this.create_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(143, 185);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(200, 50);
            this.connect_button.TabIndex = 0;
            this.connect_button.Text = "Connect to a server";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(143, 241);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(200, 50);
            this.create_button.TabIndex = 1;
            this.create_button.Text = "Create a server";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.connect_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Entry";
            this.Text = "Entry";
            this.Load += new System.EventHandler(this.Entry_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button create_button;
    }
}