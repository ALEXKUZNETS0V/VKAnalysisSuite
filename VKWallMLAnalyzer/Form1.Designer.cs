
namespace VKWallMLAnalyzer
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
            this.SelectModel_BTN = new System.Windows.Forms.Button();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.OutputFormat_CHL = new System.Windows.Forms.CheckedListBox();
            this.Model_TB = new System.Windows.Forms.TextBox();
            this.Target_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Target_CB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Model_FD = new System.Windows.Forms.OpenFileDialog();
            this.Mode_TC = new System.Windows.Forms.TabControl();
            this.Analisys_TAB = new System.Windows.Forms.TabPage();
            this.Search_TAB = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reposts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search_TargetType_CB = new System.Windows.Forms.ComboBox();
            this.Search_BTN = new System.Windows.Forms.Button();
            this.Search_Keywords_TB = new System.Windows.Forms.TextBox();
            this.Search_ID_TB = new System.Windows.Forms.TextBox();
            this.Progress_LB = new System.Windows.Forms.Label();
            this.Mode_TC.SuspendLayout();
            this.Analisys_TAB.SuspendLayout();
            this.Search_TAB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectModel_BTN
            // 
            this.SelectModel_BTN.Location = new System.Drawing.Point(332, 6);
            this.SelectModel_BTN.Name = "SelectModel_BTN";
            this.SelectModel_BTN.Size = new System.Drawing.Size(120, 23);
            this.SelectModel_BTN.TabIndex = 0;
            this.SelectModel_BTN.Text = "Выберите модель";
            this.SelectModel_BTN.UseVisualStyleBackColor = true;
            this.SelectModel_BTN.Click += new System.EventHandler(this.SelectModel_BTN_Click);
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(332, 32);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(120, 23);
            this.Start_BTN.TabIndex = 1;
            this.Start_BTN.Text = "Начать";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // OutputFormat_CHL
            // 
            this.OutputFormat_CHL.BackColor = System.Drawing.SystemColors.MenuBar;
            this.OutputFormat_CHL.FormattingEnabled = true;
            this.OutputFormat_CHL.Items.AddRange(new object[] {
            "CSV",
            "SQL"});
            this.OutputFormat_CHL.Location = new System.Drawing.Point(6, 71);
            this.OutputFormat_CHL.Name = "OutputFormat_CHL";
            this.OutputFormat_CHL.Size = new System.Drawing.Size(120, 34);
            this.OutputFormat_CHL.TabIndex = 2;
            // 
            // Model_TB
            // 
            this.Model_TB.Location = new System.Drawing.Point(6, 6);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(320, 20);
            this.Model_TB.TabIndex = 3;
            // 
            // Target_TB
            // 
            this.Target_TB.Location = new System.Drawing.Point(6, 32);
            this.Target_TB.Name = "Target_TB";
            this.Target_TB.Size = new System.Drawing.Size(320, 20);
            this.Target_TB.TabIndex = 4;
            this.Target_TB.Text = "Введите идентификатор цели";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Форматы вывода";
            // 
            // Target_CB
            // 
            this.Target_CB.FormattingEnabled = true;
            this.Target_CB.Items.AddRange(new object[] {
            "Пользователь",
            "Сообщество"});
            this.Target_CB.Location = new System.Drawing.Point(132, 71);
            this.Target_CB.Name = "Target_CB";
            this.Target_CB.Size = new System.Drawing.Size(121, 21);
            this.Target_CB.TabIndex = 6;
            this.Target_CB.Text = "Не выбрано";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Цель";
            // 
            // Model_FD
            // 
            this.Model_FD.FileName = "Model_FD";
            // 
            // Mode_TC
            // 
            this.Mode_TC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mode_TC.Controls.Add(this.Analisys_TAB);
            this.Mode_TC.Controls.Add(this.Search_TAB);
            this.Mode_TC.Location = new System.Drawing.Point(12, -4);
            this.Mode_TC.Name = "Mode_TC";
            this.Mode_TC.SelectedIndex = 0;
            this.Mode_TC.Size = new System.Drawing.Size(776, 442);
            this.Mode_TC.TabIndex = 8;
            // 
            // Analisys_TAB
            // 
            this.Analisys_TAB.BackColor = System.Drawing.Color.Transparent;
            this.Analisys_TAB.Controls.Add(this.Progress_LB);
            this.Analisys_TAB.Controls.Add(this.Model_TB);
            this.Analisys_TAB.Controls.Add(this.label2);
            this.Analisys_TAB.Controls.Add(this.SelectModel_BTN);
            this.Analisys_TAB.Controls.Add(this.Target_CB);
            this.Analisys_TAB.Controls.Add(this.Start_BTN);
            this.Analisys_TAB.Controls.Add(this.label1);
            this.Analisys_TAB.Controls.Add(this.OutputFormat_CHL);
            this.Analisys_TAB.Controls.Add(this.Target_TB);
            this.Analisys_TAB.Location = new System.Drawing.Point(4, 22);
            this.Analisys_TAB.Name = "Analisys_TAB";
            this.Analisys_TAB.Padding = new System.Windows.Forms.Padding(3);
            this.Analisys_TAB.Size = new System.Drawing.Size(768, 416);
            this.Analisys_TAB.TabIndex = 0;
            this.Analisys_TAB.Text = "Анализ";
            // 
            // Search_TAB
            // 
            this.Search_TAB.BackColor = System.Drawing.SystemColors.Control;
            this.Search_TAB.Controls.Add(this.dataGridView1);
            this.Search_TAB.Controls.Add(this.Search_TargetType_CB);
            this.Search_TAB.Controls.Add(this.Search_BTN);
            this.Search_TAB.Controls.Add(this.Search_Keywords_TB);
            this.Search_TAB.Controls.Add(this.Search_ID_TB);
            this.Search_TAB.Location = new System.Drawing.Point(4, 22);
            this.Search_TAB.Name = "Search_TAB";
            this.Search_TAB.Padding = new System.Windows.Forms.Padding(3);
            this.Search_TAB.Size = new System.Drawing.Size(768, 416);
            this.Search_TAB.TabIndex = 1;
            this.Search_TAB.Text = "Поиск";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.link,
            this.ID,
            this.Post_ID,
            this.text,
            this.likes,
            this.reposts,
            this.Label,
            this.probability});
            this.dataGridView1.Location = new System.Drawing.Point(6, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(756, 355);
            this.dataGridView1.TabIndex = 4;
            // 
            // name
            // 
            this.name.HeaderText = "Имя/название";
            this.name.Name = "name";
            // 
            // link
            // 
            this.link.HeaderText = "Ссылка";
            this.link.Name = "link";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Post_ID
            // 
            this.Post_ID.HeaderText = "ID записи";
            this.Post_ID.Name = "Post_ID";
            // 
            // text
            // 
            this.text.HeaderText = "Текст";
            this.text.Name = "text";
            // 
            // likes
            // 
            this.likes.HeaderText = "Количество лайков";
            this.likes.Name = "likes";
            // 
            // reposts
            // 
            this.reposts.HeaderText = "Количество репостов";
            this.reposts.Name = "reposts";
            // 
            // Label
            // 
            this.Label.HeaderText = "Вывод";
            this.Label.Name = "Label";
            // 
            // probability
            // 
            this.probability.HeaderText = "Вероятность";
            this.probability.Name = "probability";
            // 
            // Search_TargetType_CB
            // 
            this.Search_TargetType_CB.FormattingEnabled = true;
            this.Search_TargetType_CB.Items.AddRange(new object[] {
            "Пользователь",
            "Сообщество"});
            this.Search_TargetType_CB.Location = new System.Drawing.Point(641, 35);
            this.Search_TargetType_CB.Name = "Search_TargetType_CB";
            this.Search_TargetType_CB.Size = new System.Drawing.Size(121, 21);
            this.Search_TargetType_CB.TabIndex = 3;
            this.Search_TargetType_CB.Text = "Тип цели";
            // 
            // Search_BTN
            // 
            this.Search_BTN.Location = new System.Drawing.Point(641, 6);
            this.Search_BTN.Name = "Search_BTN";
            this.Search_BTN.Size = new System.Drawing.Size(121, 23);
            this.Search_BTN.TabIndex = 2;
            this.Search_BTN.Text = "Поиск";
            this.Search_BTN.UseVisualStyleBackColor = true;
            this.Search_BTN.Click += new System.EventHandler(this.Search_BTN_Click);
            // 
            // Search_Keywords_TB
            // 
            this.Search_Keywords_TB.Location = new System.Drawing.Point(6, 32);
            this.Search_Keywords_TB.Name = "Search_Keywords_TB";
            this.Search_Keywords_TB.Size = new System.Drawing.Size(629, 20);
            this.Search_Keywords_TB.TabIndex = 1;
            this.Search_Keywords_TB.Text = "Ключевые слова через запятую";
            // 
            // Search_ID_TB
            // 
            this.Search_ID_TB.Location = new System.Drawing.Point(6, 6);
            this.Search_ID_TB.Name = "Search_ID_TB";
            this.Search_ID_TB.Size = new System.Drawing.Size(629, 20);
            this.Search_ID_TB.TabIndex = 0;
            this.Search_ID_TB.Text = "Идентификатор";
            // 
            // Progress_LB
            // 
            this.Progress_LB.AutoSize = true;
            this.Progress_LB.Location = new System.Drawing.Point(6, 108);
            this.Progress_LB.Name = "Progress_LB";
            this.Progress_LB.Size = new System.Drawing.Size(128, 13);
            this.Progress_LB.TabIndex = 9;
            this.Progress_LB.Text = "Готово к началу работы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.Mode_TC);
            this.Name = "Form1";
            this.Text = "Анализ публикаций с помощью нейросети";
            this.Mode_TC.ResumeLayout(false);
            this.Analisys_TAB.ResumeLayout(false);
            this.Analisys_TAB.PerformLayout();
            this.Search_TAB.ResumeLayout(false);
            this.Search_TAB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectModel_BTN;
        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.CheckedListBox OutputFormat_CHL;
        private System.Windows.Forms.TextBox Model_TB;
        private System.Windows.Forms.TextBox Target_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Target_CB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog Model_FD;
        private System.Windows.Forms.TabControl Mode_TC;
        private System.Windows.Forms.TabPage Analisys_TAB;
        private System.Windows.Forms.TabPage Search_TAB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn link;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.DataGridViewTextBoxColumn likes;
        private System.Windows.Forms.DataGridViewTextBoxColumn reposts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn probability;
        private System.Windows.Forms.ComboBox Search_TargetType_CB;
        private System.Windows.Forms.Button Search_BTN;
        private System.Windows.Forms.TextBox Search_Keywords_TB;
        private System.Windows.Forms.TextBox Search_ID_TB;
        private System.Windows.Forms.Label Progress_LB;
    }
}

