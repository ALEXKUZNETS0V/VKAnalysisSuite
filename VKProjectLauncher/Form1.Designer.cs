namespace VKProjectLauncher
{
    partial class LauncherForm
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
            this.AccountQuantityTB = new System.Windows.Forms.TextBox();
            this.GetTokenBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VKWallParser = new System.Windows.Forms.Button();
            this.DeauthorizeBTN = new System.Windows.Forms.Button();
            this.GraphingAnalisysBTN = new System.Windows.Forms.Button();
            this.MLTextAnalisysBTN = new System.Windows.Forms.Button();
            this.MLImageAnalisysBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccountQuantityTB
            // 
            this.AccountQuantityTB.Location = new System.Drawing.Point(13, 31);
            this.AccountQuantityTB.Name = "AccountQuantityTB";
            this.AccountQuantityTB.Size = new System.Drawing.Size(121, 20);
            this.AccountQuantityTB.TabIndex = 0;
            this.AccountQuantityTB.Text = "1";
            // 
            // GetTokenBTN
            // 
            this.GetTokenBTN.Location = new System.Drawing.Point(140, 29);
            this.GetTokenBTN.Name = "GetTokenBTN";
            this.GetTokenBTN.Size = new System.Drawing.Size(86, 23);
            this.GetTokenBTN.TabIndex = 1;
            this.GetTokenBTN.Text = "Авторизация";
            this.GetTokenBTN.UseVisualStyleBackColor = true;
            this.GetTokenBTN.Click += new System.EventHandler(this.GetTokenBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество аккаунтов";
            // 
            // VKWallParser
            // 
            this.VKWallParser.Location = new System.Drawing.Point(13, 57);
            this.VKWallParser.Name = "VKWallParser";
            this.VKWallParser.Size = new System.Drawing.Size(294, 42);
            this.VKWallParser.TabIndex = 3;
            this.VKWallParser.Text = "Парсинг стен пользователей";
            this.VKWallParser.UseVisualStyleBackColor = true;
            this.VKWallParser.Click += new System.EventHandler(this.VKWallParser_Click);
            // 
            // DeauthorizeBTN
            // 
            this.DeauthorizeBTN.Location = new System.Drawing.Point(232, 29);
            this.DeauthorizeBTN.Name = "DeauthorizeBTN";
            this.DeauthorizeBTN.Size = new System.Drawing.Size(75, 23);
            this.DeauthorizeBTN.TabIndex = 4;
            this.DeauthorizeBTN.Text = "Выйти";
            this.DeauthorizeBTN.UseVisualStyleBackColor = true;
            this.DeauthorizeBTN.Click += new System.EventHandler(this.DeauthorizeBTN_Click);
            // 
            // GraphingAnalisysBTN
            // 
            this.GraphingAnalisysBTN.Location = new System.Drawing.Point(13, 105);
            this.GraphingAnalisysBTN.Name = "GraphingAnalisysBTN";
            this.GraphingAnalisysBTN.Size = new System.Drawing.Size(294, 42);
            this.GraphingAnalisysBTN.TabIndex = 5;
            this.GraphingAnalisysBTN.Text = "Графовый анализ сообщества";
            this.GraphingAnalisysBTN.UseVisualStyleBackColor = true;
            this.GraphingAnalisysBTN.Click += new System.EventHandler(this.GraphingAnalisysBTN_Click);
            // 
            // MLTextAnalisysBTN
            // 
            this.MLTextAnalisysBTN.Location = new System.Drawing.Point(13, 153);
            this.MLTextAnalisysBTN.Name = "MLTextAnalisysBTN";
            this.MLTextAnalisysBTN.Size = new System.Drawing.Size(294, 42);
            this.MLTextAnalisysBTN.TabIndex = 6;
            this.MLTextAnalisysBTN.Text = "Анализ текстов с помощью нейросети";
            this.MLTextAnalisysBTN.UseVisualStyleBackColor = true;
            this.MLTextAnalisysBTN.Click += new System.EventHandler(this.MLTextAnalisysBTN_Click);
            // 
            // MLImageAnalisysBTN
            // 
            this.MLImageAnalisysBTN.Location = new System.Drawing.Point(12, 204);
            this.MLImageAnalisysBTN.Name = "MLImageAnalisysBTN";
            this.MLImageAnalisysBTN.Size = new System.Drawing.Size(294, 42);
            this.MLImageAnalisysBTN.TabIndex = 7;
            this.MLImageAnalisysBTN.Text = "Анализ изображений с помощью нейросети";
            this.MLImageAnalisysBTN.UseVisualStyleBackColor = true;
            this.MLImageAnalisysBTN.Click += new System.EventHandler(this.MLImageAnalisysBTN_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 450);
            this.Controls.Add(this.MLImageAnalisysBTN);
            this.Controls.Add(this.MLTextAnalisysBTN);
            this.Controls.Add(this.GraphingAnalisysBTN);
            this.Controls.Add(this.DeauthorizeBTN);
            this.Controls.Add(this.VKWallParser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetTokenBTN);
            this.Controls.Add(this.AccountQuantityTB);
            this.Name = "LauncherForm";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AccountQuantityTB;
        private System.Windows.Forms.Button GetTokenBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VKWallParser;
        private System.Windows.Forms.Button DeauthorizeBTN;
        private System.Windows.Forms.Button GraphingAnalisysBTN;
        private System.Windows.Forms.Button MLTextAnalisysBTN;
        private System.Windows.Forms.Button MLImageAnalisysBTN;
    }
}

