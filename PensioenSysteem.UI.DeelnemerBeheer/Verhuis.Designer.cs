namespace PensioenSysteem.UI.DeelnemerBeheer
{
    partial class Verhuis
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
            this.straatTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.huisnummerTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toevoegingTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.postcodeTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plaatsTextbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Straat";
            // 
            // straatTextbox
            // 
            this.straatTextbox.Location = new System.Drawing.Point(119, 10);
            this.straatTextbox.Name = "straatTextbox";
            this.straatTextbox.Size = new System.Drawing.Size(324, 20);
            this.straatTextbox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Huisnummer";
            // 
            // huisnummerTextbox
            // 
            this.huisnummerTextbox.Location = new System.Drawing.Point(119, 36);
            this.huisnummerTextbox.Name = "huisnummerTextbox";
            this.huisnummerTextbox.Size = new System.Drawing.Size(64, 20);
            this.huisnummerTextbox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Toevoeging";
            // 
            // toevoegingTextbox
            // 
            this.toevoegingTextbox.Location = new System.Drawing.Point(119, 62);
            this.toevoegingTextbox.Name = "toevoegingTextbox";
            this.toevoegingTextbox.Size = new System.Drawing.Size(64, 20);
            this.toevoegingTextbox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Postcode";
            // 
            // postcodeTextbox
            // 
            this.postcodeTextbox.Location = new System.Drawing.Point(119, 88);
            this.postcodeTextbox.Name = "postcodeTextbox";
            this.postcodeTextbox.Size = new System.Drawing.Size(107, 20);
            this.postcodeTextbox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Plaats";
            // 
            // plaatsTextbox
            // 
            this.plaatsTextbox.Location = new System.Drawing.Point(119, 114);
            this.plaatsTextbox.Name = "plaatsTextbox";
            this.plaatsTextbox.Size = new System.Drawing.Size(324, 20);
            this.plaatsTextbox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Verhuis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 184);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.plaatsTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.postcodeTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toevoegingTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.huisnummerTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.straatTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Verhuis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verhuis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox straatTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox huisnummerTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox toevoegingTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox postcodeTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox plaatsTextbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}