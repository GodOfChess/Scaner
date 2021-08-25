
namespace GraphicScriptInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ScanButton = new System.Windows.Forms.Button();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComputerListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MacText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.IPButton = new System.Windows.Forms.Button();
            this.MACButton = new System.Windows.Forms.Button();
            this.NameButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ScanButton.Location = new System.Drawing.Point(625, 368);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(126, 44);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "START";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // ComboBox
            // 
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Items.AddRange(new object[] {
            "Все кабинеты",
            "U301",
            "U302",
            "U303",
            "U304",
            "U306",
            "U307",
            "U308",
            "U309",
            "U310",
            "U311",
            "U312",
            "U313",
            "U314",
            "U315",
            "Ошибки"});
            this.ComboBox.Location = new System.Drawing.Point(630, 101);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(121, 23);
            this.ComboBox.TabIndex = 1;
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбрать кабинет";
            // 
            // ComputerListBox
            // 
            this.ComputerListBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ComputerListBox.FormattingEnabled = true;
            this.ComputerListBox.ItemHeight = 18;
            this.ComputerListBox.Location = new System.Drawing.Point(12, 183);
            this.ComputerListBox.Name = "ComputerListBox";
            this.ComputerListBox.Size = new System.Drawing.Size(542, 202);
            this.ComputerListBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Поиск по MAC";
            // 
            // MacText
            // 
            this.MacText.Location = new System.Drawing.Point(188, 102);
            this.MacText.Name = "MacText";
            this.MacText.Size = new System.Drawing.Size(121, 23);
            this.MacText.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Поиск по IP";
            // 
            // IPText
            // 
            this.IPText.Location = new System.Drawing.Point(365, 102);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(121, 23);
            this.IPText.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Поиск по имени";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(12, 102);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(121, 23);
            this.NameText.TabIndex = 10;
            this.NameText.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(12, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(230, 59);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 11;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // IPButton
            // 
            this.IPButton.Location = new System.Drawing.Point(365, 131);
            this.IPButton.Name = "IPButton";
            this.IPButton.Size = new System.Drawing.Size(121, 23);
            this.IPButton.TabIndex = 12;
            this.IPButton.Text = "Поиск";
            this.IPButton.UseVisualStyleBackColor = true;
            this.IPButton.Click += new System.EventHandler(this.IPButton_Click);
            // 
            // MACButton
            // 
            this.MACButton.Location = new System.Drawing.Point(188, 131);
            this.MACButton.Name = "MACButton";
            this.MACButton.Size = new System.Drawing.Size(121, 23);
            this.MACButton.TabIndex = 13;
            this.MACButton.Text = "Поиск";
            this.MACButton.UseVisualStyleBackColor = true;
            this.MACButton.Click += new System.EventHandler(this.MACButton_Click);
            // 
            // NameButton
            // 
            this.NameButton.Location = new System.Drawing.Point(12, 131);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(121, 23);
            this.NameButton.TabIndex = 14;
            this.NameButton.Text = "Поиск";
            this.NameButton.UseVisualStyleBackColor = true;
            this.NameButton.Click += new System.EventHandler(this.NameButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(288, 29);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(463, 28);
            this.ProgressBar.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Список компьютеров";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(122, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 34);
            this.button1.TabIndex = 21;
            this.button1.Text = "Вывести информацию в текстовый файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.NameButton);
            this.Controls.Add(this.MACButton);
            this.Controls.Add(this.IPButton);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IPText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MacText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComputerListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.ScanButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Scaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.ComboBox ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MacText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IPText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button IPButton;
        private System.Windows.Forms.Button MACButton;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ComputerListBox;
    }
}

