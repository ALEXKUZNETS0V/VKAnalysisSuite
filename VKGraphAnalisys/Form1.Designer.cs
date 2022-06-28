namespace VKGraphAnalisys
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
            this.LinkTB = new System.Windows.Forms.TextBox();
            this.StartBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RatingTXT_CB = new System.Windows.Forms.CheckBox();
            this.Progress_LB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinkTB
            // 
            this.LinkTB.Location = new System.Drawing.Point(12, 25);
            this.LinkTB.Name = "LinkTB";
            this.LinkTB.Size = new System.Drawing.Size(189, 20);
            this.LinkTB.TabIndex = 0;
            // 
            // StartBTN
            // 
            this.StartBTN.Location = new System.Drawing.Point(207, 23);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(75, 23);
            this.StartBTN.TabIndex = 1;
            this.StartBTN.Text = "Начать";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Идентификатор сообщества";
            // 
            // RatingTXT_CB
            // 
            this.RatingTXT_CB.AutoSize = true;
            this.RatingTXT_CB.Location = new System.Drawing.Point(12, 51);
            this.RatingTXT_CB.Name = "RatingTXT_CB";
            this.RatingTXT_CB.Size = new System.Drawing.Size(205, 17);
            this.RatingTXT_CB.TabIndex = 3;
            this.RatingTXT_CB.Text = "Вывод в TXT по количеству друзей";
            this.RatingTXT_CB.UseVisualStyleBackColor = true;
            // 
            // Progress_LB
            // 
            this.Progress_LB.AutoSize = true;
            this.Progress_LB.Location = new System.Drawing.Point(12, 71);
            this.Progress_LB.Name = "Progress_LB";
            this.Progress_LB.Size = new System.Drawing.Size(128, 13);
            this.Progress_LB.TabIndex = 4;
            this.Progress_LB.Text = "Готово к началу работы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 109);
            this.Controls.Add(this.Progress_LB);
            this.Controls.Add(this.RatingTXT_CB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.LinkTB);
            this.Name = "Form1";
            this.Text = "Графовый анализ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LinkTB;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RatingTXT_CB;
        private System.Windows.Forms.Label Progress_LB;
    }
}

