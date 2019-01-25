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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTakeBus = new System.Windows.Forms.PictureBox();
            this.buttonTakeBus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.listBoxLevels = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeBus)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxStation
            // 
            this.pictureBoxStation.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxStation.Location = new System.Drawing.Point(1, 27);
            this.pictureBoxStation.Name = "pictureBoxStation";
            this.pictureBoxStation.Size = new System.Drawing.Size(729, 488);
            this.pictureBoxStation.TabIndex = 0;
            this.pictureBoxStation.TabStop = false;
            // 
            // buttonSetBus
            // 
            this.buttonSetBus.Location = new System.Drawing.Point(752, 166);
            this.buttonSetBus.Name = "buttonSetBus";
            this.buttonSetBus.Size = new System.Drawing.Size(110, 46);
            this.buttonSetBus.TabIndex = 1;
            this.buttonSetBus.Text = "Добавить автобус";
            this.buttonSetBus.UseVisualStyleBackColor = true;
            this.buttonSetBus.Click += new System.EventHandler(this.buttonSetBus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxTakeBus);
            this.groupBox1.Controls.Add(this.buttonTakeBus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maskedTextBox);
            this.groupBox1.Location = new System.Drawing.Point(736, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать автобус:";
            // 
            // pictureBoxTakeBus
            // 
            this.pictureBoxTakeBus.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxTakeBus.Location = new System.Drawing.Point(9, 83);
            this.pictureBoxTakeBus.Name = "pictureBoxTakeBus";
            this.pictureBoxTakeBus.Size = new System.Drawing.Size(138, 156);
            this.pictureBoxTakeBus.TabIndex = 3;
            this.pictureBoxTakeBus.TabStop = false;
            // 
            // buttonTakeBus
            // 
            this.buttonTakeBus.Location = new System.Drawing.Point(85, 55);
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
            this.maskedTextBox.Location = new System.Drawing.Point(51, 29);
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(895, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "txt file | *.txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "txt file | *.txt";
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 515);
            this.Controls.Add(this.listBoxLevels);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetBus);
            this.Controls.Add(this.pictureBoxStation);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormBusStation";
            this.Text = "FormBusStation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeBus)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStation;
        private System.Windows.Forms.Button buttonSetBus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxTakeBus;
        private System.Windows.Forms.Button buttonTakeBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.ListBox listBoxLevels;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}