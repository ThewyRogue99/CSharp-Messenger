namespace Messenger
{
    partial class CreateServer
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
            this.ServerPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirm_connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.Max_Person = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerPass
            // 
            this.ServerPass.Location = new System.Drawing.Point(230, 98);
            this.ServerPass.Name = "ServerPass";
            this.ServerPass.Size = new System.Drawing.Size(243, 23);
            this.ServerPass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password for the server:";
            // 
            // confirm_connect
            // 
            this.confirm_connect.Location = new System.Drawing.Point(367, 250);
            this.confirm_connect.Name = "confirm_connect";
            this.confirm_connect.Size = new System.Drawing.Size(106, 35);
            this.confirm_connect.TabIndex = 3;
            this.confirm_connect.Text = "OK";
            this.confirm_connect.UseVisualStyleBackColor = true;
            this.confirm_connect.Click += new System.EventHandler(this.confirm_pass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter a username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "(Admin if not entered)";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(230, 184);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(243, 23);
            this.UsernameBox.TabIndex = 1;
            // 
            // Max_Person
            // 
            this.Max_Person.Location = new System.Drawing.Point(230, 257);
            this.Max_Person.Name = "Max_Person";
            this.Max_Person.Size = new System.Drawing.Size(100, 23);
            this.Max_Person.TabIndex = 2;
            this.Max_Person.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max member for server:";
            // 
            // CreateServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Max_Person);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confirm_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateServer";
            this.Text = "CreateServer";
            this.Load += new System.EventHandler(this.CreateServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirm_connect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox Max_Person;
        private System.Windows.Forms.Label label4;
    }
}