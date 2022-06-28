
namespace VKWallImageMLAnalyzer
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
            this.Model_FD = new System.Windows.Forms.OpenFileDialog();
            this.SelectModel_BTN = new System.Windows.Forms.Button();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.Model_TB = new System.Windows.Forms.TextBox();
            this.Target_TB = new System.Windows.Forms.TextBox();
            this.OutputFormat_CHL = new System.Windows.Forms.CheckedListBox();
            this.Target_CB = new System.Windows.Forms.ComboBox();
            this.OutputFormat_LBL = new System.Windows.Forms.Label();
            this.Target_LBL = new System.Windows.Forms.Label();
            this.Progress_LB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Model_FD
            // 
            this.Model_FD.FileName = " ";
            // 
            // SelectModel_BTN
            // 
            this.SelectModel_BTN.Location = new System.Drawing.Point(652, 12);
            this.SelectModel_BTN.Name = "SelectModel_BTN";
            this.SelectModel_BTN.Size = new System.Drawing.Size(136, 23);
            this.SelectModel_BTN.TabIndex = 0;
            this.SelectModel_BTN.Text = "Выберите модель";
            this.SelectModel_BTN.UseVisualStyleBackColor = true;
            this.SelectModel_BTN.UseWaitCursor = true;
            this.SelectModel_BTN.Click += new System.EventHandler(this.SelectModel_BTN_Click);
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(652, 42);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(136, 23);
            this.Start_BTN.TabIndex = 1;
            this.Start_BTN.Text = "Начать";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Model_TB
            // 
            this.Model_TB.Location = new System.Drawing.Point(12, 15);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(634, 20);
            this.Model_TB.TabIndex = 2;
            // 
            // Target_TB
            // 
            this.Target_TB.Location = new System.Drawing.Point(12, 45);
            this.Target_TB.Name = "Target_TB";
            this.Target_TB.Size = new System.Drawing.Size(634, 20);
            this.Target_TB.TabIndex = 3;
            this.Target_TB.Text = "Введите идентификатор цели";
            // 
            // OutputFormat_CHL
            // 
            this.OutputFormat_CHL.BackColor = System.Drawing.SystemColors.Control;
            this.OutputFormat_CHL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OutputFormat_CHL.FormattingEnabled = true;
            this.OutputFormat_CHL.Items.AddRange(new object[] {
            "CSV",
            "SQL"});
            this.OutputFormat_CHL.Location = new System.Drawing.Point(12, 84);
            this.OutputFormat_CHL.Name = "OutputFormat_CHL";
            this.OutputFormat_CHL.Size = new System.Drawing.Size(120, 34);
            this.OutputFormat_CHL.TabIndex = 4;
            // 
            // Target_CB
            // 
            this.Target_CB.FormattingEnabled = true;
            this.Target_CB.Items.AddRange(new object[] {
            "Пользователь",
            "Сообщество"});
            this.Target_CB.Location = new System.Drawing.Point(138, 84);
            this.Target_CB.Name = "Target_CB";
            this.Target_CB.Size = new System.Drawing.Size(121, 21);
            this.Target_CB.TabIndex = 5;
            this.Target_CB.Text = "Не выбрано";
            // 
            // OutputFormat_LBL
            // 
            this.OutputFormat_LBL.AutoSize = true;
            this.OutputFormat_LBL.Location = new System.Drawing.Point(12, 68);
            this.OutputFormat_LBL.Name = "OutputFormat_LBL";
            this.OutputFormat_LBL.Size = new System.Drawing.Size(91, 13);
            this.OutputFormat_LBL.TabIndex = 6;
            this.OutputFormat_LBL.Text = "Формат Вывода";
            // 
            // Target_LBL
            // 
            this.Target_LBL.AutoSize = true;
            this.Target_LBL.Location = new System.Drawing.Point(135, 68);
            this.Target_LBL.Name = "Target_LBL";
            this.Target_LBL.Size = new System.Drawing.Size(33, 13);
            this.Target_LBL.TabIndex = 7;
            this.Target_LBL.Text = "Цель";
            // 
            // Progress_LB
            // 
            this.Progress_LB.AutoSize = true;
            this.Progress_LB.Location = new System.Drawing.Point(12, 121);
            this.Progress_LB.Name = "Progress_LB";
            this.Progress_LB.Size = new System.Drawing.Size(134, 13);
            this.Progress_LB.TabIndex = 8;
            this.Progress_LB.Text = "Готово к наачалу работы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Progress_LB);
            this.Controls.Add(this.Target_LBL);
            this.Controls.Add(this.OutputFormat_LBL);
            this.Controls.Add(this.Target_CB);
            this.Controls.Add(this.OutputFormat_CHL);
            this.Controls.Add(this.Target_TB);
            this.Controls.Add(this.Model_TB);
            this.Controls.Add(this.Start_BTN);
            this.Controls.Add(this.SelectModel_BTN);
            this.Name = "Form1";
            this.Text = "Анализ изображений в публикациях с помощью нейросети";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog Model_FD;
        private System.Windows.Forms.Button SelectModel_BTN;
        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.TextBox Model_TB;
        public System.Windows.Forms.TextBox Target_TB;
        private System.Windows.Forms.CheckedListBox OutputFormat_CHL;
        private System.Windows.Forms.ComboBox Target_CB;
        private System.Windows.Forms.Label OutputFormat_LBL;
        private System.Windows.Forms.Label Target_LBL;
        private System.Windows.Forms.Label Progress_LB;
    }
}

