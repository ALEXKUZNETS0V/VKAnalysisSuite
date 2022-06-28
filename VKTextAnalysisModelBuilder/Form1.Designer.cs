
namespace VKTextAnalysisModel
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
            this.openFileDialogDS = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.GetDS_BTN = new System.Windows.Forms.Button();
            this.DSPath_TB = new System.Windows.Forms.TextBox();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.Log_RTB = new System.Windows.Forms.RichTextBox();
            this.OutputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OutputDialog_BTN = new System.Windows.Forms.Button();
            this.OutputFolder_TB = new System.Windows.Forms.TextBox();
            this.Test_TB = new System.Windows.Forms.TextBox();
            this.Test_BTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogDS
            // 
            this.openFileDialogDS.FileName = "openFileDialogDS";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // GetDS_BTN
            // 
            this.GetDS_BTN.Location = new System.Drawing.Point(3, 8);
            this.GetDS_BTN.Name = "GetDS_BTN";
            this.GetDS_BTN.Size = new System.Drawing.Size(168, 26);
            this.GetDS_BTN.TabIndex = 0;
            this.GetDS_BTN.Text = "Выбрать датасет";
            this.GetDS_BTN.UseVisualStyleBackColor = true;
            this.GetDS_BTN.Click += new System.EventHandler(this.GetDS_BTN_Click);
            // 
            // DSPath_TB
            // 
            this.DSPath_TB.Location = new System.Drawing.Point(177, 12);
            this.DSPath_TB.Name = "DSPath_TB";
            this.DSPath_TB.Size = new System.Drawing.Size(530, 20);
            this.DSPath_TB.TabIndex = 1;
            this.DSPath_TB.Text = "Данные для обучения не выбраны";
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(713, 8);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(75, 55);
            this.Start_BTN.TabIndex = 2;
            this.Start_BTN.Text = "Начать";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Log_RTB
            // 
            this.Log_RTB.Location = new System.Drawing.Point(3, 69);
            this.Log_RTB.Name = "Log_RTB";
            this.Log_RTB.Size = new System.Drawing.Size(785, 275);
            this.Log_RTB.TabIndex = 3;
            this.Log_RTB.Text = "Здесь будет прогресс и характеристики модели";
            // 
            // OutputDialog_BTN
            // 
            this.OutputDialog_BTN.Location = new System.Drawing.Point(3, 40);
            this.OutputDialog_BTN.Name = "OutputDialog_BTN";
            this.OutputDialog_BTN.Size = new System.Drawing.Size(168, 23);
            this.OutputDialog_BTN.TabIndex = 4;
            this.OutputDialog_BTN.Text = "Папка назначения";
            this.OutputDialog_BTN.UseVisualStyleBackColor = true;
            this.OutputDialog_BTN.Click += new System.EventHandler(this.OutputDialog_BTN_Click);
            // 
            // OutputFolder_TB
            // 
            this.OutputFolder_TB.Location = new System.Drawing.Point(177, 43);
            this.OutputFolder_TB.Name = "OutputFolder_TB";
            this.OutputFolder_TB.Size = new System.Drawing.Size(530, 20);
            this.OutputFolder_TB.TabIndex = 5;
            this.OutputFolder_TB.Text = "Папка назначения не выбрана";
            // 
            // Test_TB
            // 
            this.Test_TB.Location = new System.Drawing.Point(3, 353);
            this.Test_TB.Name = "Test_TB";
            this.Test_TB.Size = new System.Drawing.Size(704, 20);
            this.Test_TB.TabIndex = 6;
            this.Test_TB.Text = "Здесь можно ввести выражение для пробы модели";
            // 
            // Test_BTN
            // 
            this.Test_BTN.Location = new System.Drawing.Point(713, 350);
            this.Test_BTN.Name = "Test_BTN";
            this.Test_BTN.Size = new System.Drawing.Size(75, 23);
            this.Test_BTN.TabIndex = 7;
            this.Test_BTN.Text = "Тест";
            this.Test_BTN.UseVisualStyleBackColor = true;
            this.Test_BTN.Click += new System.EventHandler(this.Test_BTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.Test_BTN);
            this.Controls.Add(this.Test_TB);
            this.Controls.Add(this.OutputFolder_TB);
            this.Controls.Add(this.OutputDialog_BTN);
            this.Controls.Add(this.Log_RTB);
            this.Controls.Add(this.Start_BTN);
            this.Controls.Add(this.DSPath_TB);
            this.Controls.Add(this.GetDS_BTN);
            this.Name = "Form1";
            this.Text = "Создать модель по набору данных";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogDS;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.RichTextBox Log_RTB;
        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.TextBox DSPath_TB;
        private System.Windows.Forms.Button GetDS_BTN;
        private System.Windows.Forms.TextBox OutputFolder_TB;
        private System.Windows.Forms.Button OutputDialog_BTN;
        private System.Windows.Forms.FolderBrowserDialog OutputFolderDialog;
        private System.Windows.Forms.Button Test_BTN;
        private System.Windows.Forms.TextBox Test_TB;
    }
}

