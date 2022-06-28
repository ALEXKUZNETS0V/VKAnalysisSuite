namespace VKWallParser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Start_ID_TB = new System.Windows.Forms.TextBox();
            this.Finish_ID_TB = new System.Windows.Forms.TextBox();
            this.Button_GetInformation = new System.Windows.Forms.Button();
            this.Progress_Label = new System.Windows.Forms.Label();
            this.GenXVocabBTN = new System.Windows.Forms.Button();
            this.GenZVocabBTN = new System.Windows.Forms.Button();
            this.GenXVocabTB = new System.Windows.Forms.TextBox();
            this.GenZVocabTB = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogGenZ = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogGenX = new System.Windows.Forms.OpenFileDialog();
            this.DeletePreviousResultChB = new System.Windows.Forms.CheckBox();
            this.ResultFormatCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Первый ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Последний ID";
            // 
            // Start_ID_TB
            // 
            this.Start_ID_TB.Location = new System.Drawing.Point(16, 30);
            this.Start_ID_TB.Name = "Start_ID_TB";
            this.Start_ID_TB.Size = new System.Drawing.Size(100, 20);
            this.Start_ID_TB.TabIndex = 2;
            // 
            // Finish_ID_TB
            // 
            this.Finish_ID_TB.Location = new System.Drawing.Point(122, 30);
            this.Finish_ID_TB.Name = "Finish_ID_TB";
            this.Finish_ID_TB.Size = new System.Drawing.Size(100, 20);
            this.Finish_ID_TB.TabIndex = 3;
            // 
            // Button_GetInformation
            // 
            this.Button_GetInformation.Location = new System.Drawing.Point(228, 27);
            this.Button_GetInformation.Name = "Button_GetInformation";
            this.Button_GetInformation.Size = new System.Drawing.Size(90, 23);
            this.Button_GetInformation.TabIndex = 5;
            this.Button_GetInformation.Text = "Начать";
            this.Button_GetInformation.UseVisualStyleBackColor = true;
            this.Button_GetInformation.Click += new System.EventHandler(this.Button_GetInformation_Click);
            // 
            // Progress_Label
            // 
            this.Progress_Label.AutoSize = true;
            this.Progress_Label.Location = new System.Drawing.Point(13, 151);
            this.Progress_Label.Name = "Progress_Label";
            this.Progress_Label.Size = new System.Drawing.Size(0, 13);
            this.Progress_Label.TabIndex = 6;
            // 
            // GenXVocabBTN
            // 
            this.GenXVocabBTN.Location = new System.Drawing.Point(16, 96);
            this.GenXVocabBTN.Name = "GenXVocabBTN";
            this.GenXVocabBTN.Size = new System.Drawing.Size(196, 23);
            this.GenXVocabBTN.TabIndex = 7;
            this.GenXVocabBTN.Text = "Словарь X";
            this.GenXVocabBTN.UseVisualStyleBackColor = true;
            this.GenXVocabBTN.Click += new System.EventHandler(this.GenXVocabBTN_Click);
            // 
            // GenZVocabBTN
            // 
            this.GenZVocabBTN.Location = new System.Drawing.Point(16, 125);
            this.GenZVocabBTN.Name = "GenZVocabBTN";
            this.GenZVocabBTN.Size = new System.Drawing.Size(196, 23);
            this.GenZVocabBTN.TabIndex = 8;
            this.GenZVocabBTN.Text = "Словарь Z";
            this.GenZVocabBTN.UseVisualStyleBackColor = true;
            this.GenZVocabBTN.Click += new System.EventHandler(this.GenZVocabBTN_Click);
            // 
            // GenXVocabTB
            // 
            this.GenXVocabTB.Location = new System.Drawing.Point(219, 96);
            this.GenXVocabTB.Name = "GenXVocabTB";
            this.GenXVocabTB.Size = new System.Drawing.Size(569, 20);
            this.GenXVocabTB.TabIndex = 9;
            // 
            // GenZVocabTB
            // 
            this.GenZVocabTB.Location = new System.Drawing.Point(219, 125);
            this.GenZVocabTB.Name = "GenZVocabTB";
            this.GenZVocabTB.Size = new System.Drawing.Size(569, 20);
            this.GenZVocabTB.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialogGenX";
            // 
            // openFileDialogGenZ
            // 
            this.openFileDialogGenZ.FileName = "openFileDialogGenZ";
            // 
            // openFileDialogGenX
            // 
            this.openFileDialogGenX.FileName = "openFileDialogGenX";
            // 
            // DeletePreviousResultChB
            // 
            this.DeletePreviousResultChB.AutoSize = true;
            this.DeletePreviousResultChB.Location = new System.Drawing.Point(143, 71);
            this.DeletePreviousResultChB.Name = "DeletePreviousResultChB";
            this.DeletePreviousResultChB.Size = new System.Drawing.Size(190, 17);
            this.DeletePreviousResultChB.TabIndex = 14;
            this.DeletePreviousResultChB.Text = "Удалить предыдущий результат";
            this.DeletePreviousResultChB.UseVisualStyleBackColor = true;
            // 
            // ResultFormatCB
            // 
            this.ResultFormatCB.FormattingEnabled = true;
            this.ResultFormatCB.Items.AddRange(new object[] {
            "TXT",
            "SQL"});
            this.ResultFormatCB.Location = new System.Drawing.Point(16, 69);
            this.ResultFormatCB.Name = "ResultFormatCB";
            this.ResultFormatCB.Size = new System.Drawing.Size(121, 21);
            this.ResultFormatCB.TabIndex = 15;
            this.ResultFormatCB.Text = "Выбрать...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Формат вывода";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ResultFormatCB);
            this.Controls.Add(this.DeletePreviousResultChB);
            this.Controls.Add(this.GenZVocabTB);
            this.Controls.Add(this.GenXVocabTB);
            this.Controls.Add(this.GenZVocabBTN);
            this.Controls.Add(this.GenXVocabBTN);
            this.Controls.Add(this.Progress_Label);
            this.Controls.Add(this.Button_GetInformation);
            this.Controls.Add(this.Finish_ID_TB);
            this.Controls.Add(this.Start_ID_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "VKWallParser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Start_ID_TB;
        private System.Windows.Forms.TextBox Finish_ID_TB;
        private System.Windows.Forms.Button Button_GetInformation;
        private System.Windows.Forms.Label Progress_Label;
        private System.Windows.Forms.Button GenXVocabBTN;
        private System.Windows.Forms.Button GenZVocabBTN;
        private System.Windows.Forms.TextBox GenXVocabTB;
        private System.Windows.Forms.TextBox GenZVocabTB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogGenZ;
        private System.Windows.Forms.OpenFileDialog openFileDialogGenX;
        private System.Windows.Forms.CheckBox DeletePreviousResultChB;
        private System.Windows.Forms.ComboBox ResultFormatCB;
        private System.Windows.Forms.Label label4;
    }
}

