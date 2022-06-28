
namespace VKImageAnalysisModelBuilder
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
            this.Dataset_FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.Destination_FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.Test_FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.Dataset_TB = new System.Windows.Forms.TextBox();
            this.Destination_TB = new System.Windows.Forms.TextBox();
            this.Test_TB = new System.Windows.Forms.TextBox();
            this.Log_RTB = new System.Windows.Forms.RichTextBox();
            this.Dataset_BTN = new System.Windows.Forms.Button();
            this.Test_BTN = new System.Windows.Forms.Button();
            this.Destination_BTN = new System.Windows.Forms.Button();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Dataset_TB
            // 
            this.Dataset_TB.Location = new System.Drawing.Point(182, 15);
            this.Dataset_TB.Name = "Dataset_TB";
            this.Dataset_TB.Size = new System.Drawing.Size(538, 20);
            this.Dataset_TB.TabIndex = 0;
            this.Dataset_TB.Text = "Данные для обучения не выбраны";
            // 
            // Destination_TB
            // 
            this.Destination_TB.Location = new System.Drawing.Point(182, 73);
            this.Destination_TB.Name = "Destination_TB";
            this.Destination_TB.Size = new System.Drawing.Size(538, 20);
            this.Destination_TB.TabIndex = 1;
            this.Destination_TB.Text = "Папка назначения не выбрана";
            // 
            // Test_TB
            // 
            this.Test_TB.Location = new System.Drawing.Point(182, 44);
            this.Test_TB.Name = "Test_TB";
            this.Test_TB.Size = new System.Drawing.Size(538, 20);
            this.Test_TB.TabIndex = 2;
            this.Test_TB.Text = "Папка с тестовыми материалами не выбрана";
            // 
            // Log_RTB
            // 
            this.Log_RTB.Location = new System.Drawing.Point(12, 99);
            this.Log_RTB.Name = "Log_RTB";
            this.Log_RTB.Size = new System.Drawing.Size(776, 339);
            this.Log_RTB.TabIndex = 3;
            this.Log_RTB.Text = "Здесь будут результаты тестов";
            // 
            // Dataset_BTN
            // 
            this.Dataset_BTN.Location = new System.Drawing.Point(12, 12);
            this.Dataset_BTN.Name = "Dataset_BTN";
            this.Dataset_BTN.Size = new System.Drawing.Size(164, 23);
            this.Dataset_BTN.TabIndex = 4;
            this.Dataset_BTN.Text = "Выбрать датасет";
            this.Dataset_BTN.UseVisualStyleBackColor = true;
            this.Dataset_BTN.Click += new System.EventHandler(this.Dataset_BTN_Click);
            // 
            // Test_BTN
            // 
            this.Test_BTN.Location = new System.Drawing.Point(12, 41);
            this.Test_BTN.Name = "Test_BTN";
            this.Test_BTN.Size = new System.Drawing.Size(164, 23);
            this.Test_BTN.TabIndex = 5;
            this.Test_BTN.Text = "Выбрать папку для тестов";
            this.Test_BTN.UseVisualStyleBackColor = true;
            this.Test_BTN.Click += new System.EventHandler(this.Test_BTN_Click);
            // 
            // Destination_BTN
            // 
            this.Destination_BTN.Location = new System.Drawing.Point(12, 70);
            this.Destination_BTN.Name = "Destination_BTN";
            this.Destination_BTN.Size = new System.Drawing.Size(164, 23);
            this.Destination_BTN.TabIndex = 6;
            this.Destination_BTN.Text = "Папка назначения";
            this.Destination_BTN.UseVisualStyleBackColor = true;
            this.Destination_BTN.Click += new System.EventHandler(this.Destination_BTN_Click);
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(726, 12);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(62, 81);
            this.Start_BTN.TabIndex = 7;
            this.Start_BTN.Text = "Начать";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Start_BTN);
            this.Controls.Add(this.Destination_BTN);
            this.Controls.Add(this.Test_BTN);
            this.Controls.Add(this.Dataset_BTN);
            this.Controls.Add(this.Log_RTB);
            this.Controls.Add(this.Test_TB);
            this.Controls.Add(this.Destination_TB);
            this.Controls.Add(this.Dataset_TB);
            this.Name = "Form1";
            this.Text = "Обучение модели анализа изображений";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog Dataset_FBD;
        private System.Windows.Forms.FolderBrowserDialog Destination_FBD;
        private System.Windows.Forms.FolderBrowserDialog Test_FBD;
        private System.Windows.Forms.TextBox Dataset_TB;
        private System.Windows.Forms.TextBox Destination_TB;
        private System.Windows.Forms.TextBox Test_TB;
        private System.Windows.Forms.RichTextBox Log_RTB;
        private System.Windows.Forms.Button Dataset_BTN;
        private System.Windows.Forms.Button Test_BTN;
        private System.Windows.Forms.Button Destination_BTN;
        private System.Windows.Forms.Button Start_BTN;
    }
}

