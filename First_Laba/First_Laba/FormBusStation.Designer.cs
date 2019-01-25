namespace First_Laba
{
    partial class FormBusStation
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
            this.pictureBoxStation = new System.Windows.Forms.PictureBox();
            this.buttonSetBus = new System.Windows.Forms.Button();
            this.buttonSetDoubleBus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTakeBus = new System.Windows.Forms.PictureBox();
            this.buttonTakeBus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.listBoxLevels = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeBus)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxStation
            // 
            this.pictureBoxStation.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxStation.Location = new System.Drawing.Point(1, 2);
            this.pictureBoxStation.Name = "pictureBoxStation";
            this.pictureBoxStation.Size = new System.Drawing.Size(720, 530);
            this.pictureBoxStation.TabIndex = 0;
            this.pictureBoxStation.TabStop = false;
            // 
            // buttonSetBus
            // 
            this.buttonSetBus.Location = new System.Drawing.Point(752, 152);
            this.buttonSetBus.Name = "buttonSetBus";
            this.buttonSetBus.Size = new System.Drawing.Size(110, 46);
            this.buttonSetBus.TabIndex = 1;
            this.buttonSetBus.Text = "Припарковать автобус";
            this.buttonSetBus.UseVisualStyleBackColor = true;
            this.buttonSetBus.Click += new System.EventHandler(this.buttonSetBus_Click);
            // 
            // buttonSetDoubleBus
            // 
            this.buttonSetDoubleBus.Location = new System.Drawing.Point(752, 204);
            this.buttonSetDoubleBus.Name = "buttonSetDoubleBus";
            this.buttonSetDoubleBus.Size = new System.Drawing.Size(110, 51);
            this.buttonSetDoubleBus.TabIndex = 2;
            this.buttonSetDoubleBus.Text = "Припарковать двухэтажный автобус";
            this.buttonSetDoubleBus.UseVisualStyleBackColor = true;
            this.buttonSetDoubleBus.Click += new System.EventHandler(this.buttonSetDoubleBus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxTakeBus);
            this.groupBox1.Controls.Add(this.buttonTakeBus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maskedTextBox);
            this.groupBox1.Location = new System.Drawing.Point(727, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать автобус:";
            // 
            // pictureBoxTakeBus
            // 
            this.pictureBoxTakeBus.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxTakeBus.Location = new System.Drawing.Point(9, 83);
            this.pictureBoxTakeBus.Name = "pictureBoxTakeBus";
            this.pictureBoxTakeBus.Size = new System.Drawing.Size(153, 156);
            this.pictureBoxTakeBus.TabIndex = 3;
            this.pictureBoxTakeBus.TabStop = false;
            // 
            // buttonTakeBus
            // 
            this.buttonTakeBus.Location = new System.Drawing.Point(94, 55);
            this.buttonTakeBus.Name = "buttonTakeBus";
            this.buttonTakeBus.Size = new System.Drawing.Size(62, 22);
            this.buttonTakeBus.TabIndex = 2;
            this.buttonTakeBus.Text = "Забрать";
            this.buttonTakeBus.UseVisualStyleBackColor = true;
            this.buttonTakeBus.Click += new System.EventHandler(this.buttonTakeBus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Место:";
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(54, 29);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox.TabIndex = 0;
            // 
            // listBoxLevels
            // 
            this.listBoxLevels.FormattingEnabled = true;
            this.listBoxLevels.Location = new System.Drawing.Point(752, 21);
            this.listBoxLevels.Name = "listBoxLevels";
            this.listBoxLevels.Size = new System.Drawing.Size(137, 108);
            this.listBoxLevels.TabIndex = 4;
            this.listBoxLevels.SelectedIndexChanged += new System.EventHandler(this.listBoxLevels_SelectedIndexChanged);
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 533);
            this.Controls.Add(this.listBoxLevels);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetDoubleBus);
            this.Controls.Add(this.buttonSetBus);
            this.Controls.Add(this.pictureBoxStation);
            this.Name = "FormBusStation";
            this.Text = "FormBusStation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeBus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStation;
        private System.Windows.Forms.Button buttonSetBus;
        private System.Windows.Forms.Button buttonSetDoubleBus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxTakeBus;
        private System.Windows.Forms.Button buttonTakeBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.ListBox listBoxLevels;
    }
}