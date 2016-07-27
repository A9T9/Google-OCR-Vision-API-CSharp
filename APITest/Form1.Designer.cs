namespace OCRAPITest
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbJson = new System.Windows.Forms.RadioButton();
            this.btnPdf = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Google = new System.Windows.Forms.RadioButton();
            this.rb_OCR = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPDF = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Location = new System.Drawing.Point(13, 175);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(265, 284);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(365, 146);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(304, 373);
            this.txtResult.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(284, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 61);
            this.button2.TabIndex = 3;
            this.button2.Text = "Recognize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "ChineseSimplified",
            "ChineseTraditional ",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Finnish",
            "French",
            "German",
            "Greek ",
            "Hungarian",
            "Italian",
            "Japanese",
            "Korean  ",
            "Norwegian",
            "Polish",
            "Portuguese",
            "Russian ",
            "Spanish",
            "Swedish ",
            "Turkish"});
            this.cmbLanguage.Location = new System.Drawing.Point(210, 48);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(160, 21);
            this.cmbLanguage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Language";
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Checked = true;
            this.rbText.Location = new System.Drawing.Point(20, 25);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 17);
            this.rbText.TabIndex = 6;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbJson
            // 
            this.rbJson.AutoSize = true;
            this.rbJson.Location = new System.Drawing.Point(19, 50);
            this.rbJson.Name = "rbJson";
            this.rbJson.Size = new System.Drawing.Size(47, 17);
            this.rbJson.TabIndex = 7;
            this.rbJson.Text = "Json";
            this.rbJson.UseVisualStyleBackColor = true;
            this.rbJson.CheckedChanged += new System.EventHandler(this.rbJson_CheckedChanged);
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(177, 90);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(113, 23);
            this.btnPdf.TabIndex = 8;
            this.btnPdf.Text = "Load PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Google);
            this.groupBox1.Controls.Add(this.rb_OCR);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 76);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select OCR API to use";
            // 
            // rb_Google
            // 
            this.rb_Google.AutoSize = true;
            this.rb_Google.Location = new System.Drawing.Point(19, 23);
            this.rb_Google.Name = "rb_Google";
            this.rb_Google.Size = new System.Drawing.Size(229, 17);
            this.rb_Google.TabIndex = 1;
            this.rb_Google.TabStop = true;
            this.rb_Google.Text = "Google  [remember to add your api key first]";
            this.rb_Google.UseVisualStyleBackColor = true;
            this.rb_Google.CheckedChanged += new System.EventHandler(this.rb_Google_CheckedChanged);
            // 
            // rb_OCR
            // 
            this.rb_OCR.AutoSize = true;
            this.rb_OCR.Location = new System.Drawing.Point(19, 46);
            this.rb_OCR.Name = "rb_OCR";
            this.rb_OCR.Size = new System.Drawing.Size(206, 17);
            this.rb_OCR.TabIndex = 0;
            this.rb_OCR.TabStop = true;
            this.rb_OCR.Text = "OCR.Space [free \"helloworld\" api key]";
            this.rb_OCR.UseVisualStyleBackColor = true;
            this.rb_OCR.CheckedChanged += new System.EventHandler(this.rb_OCR_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "TYPE_UNSPECIFIED",
            "FACE_DETECTION",
            "LANDMARK_DETECTION",
            "LOGO_DETECTION",
            "LABEL_DETECTION",
            "TEXT_DETECTION",
            "SAFE_SEARCH_DETECTION",
            "IMAGE_PROPERTIES"});
            this.cmbType.Location = new System.Drawing.Point(210, 23);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(160, 21);
            this.cmbType.TabIndex = 10;
            this.cmbType.Text = "Google Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnPdf);
            this.groupBox2.Controls.Add(this.rbJson);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbType);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cmbLanguage);
            this.groupBox2.Location = new System.Drawing.Point(293, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 129);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // txtPDF
            // 
            this.txtPDF.Enabled = false;
            this.txtPDF.Location = new System.Drawing.Point(13, 146);
            this.txtPDF.Name = "txtPDF";
            this.txtPDF.Size = new System.Drawing.Size(264, 20);
            this.txtPDF.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 531);
            this.Controls.Add(this.txtPDF);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Google OCR - Vision API - Test App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbJson;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_Google;
        private System.Windows.Forms.RadioButton rb_OCR;
        private System.Windows.Forms.TextBox txtPDF;
    }
}

