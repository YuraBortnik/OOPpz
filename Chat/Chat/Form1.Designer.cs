namespace Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connectButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.ipAdressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.connectButton.Location = new System.Drawing.Point(40, 198);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(115, 48);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Підключитися до серверу";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendButton.Location = new System.Drawing.Point(588, 281);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(125, 43);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Відправити повідомлення";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.disconnectButton.Location = new System.Drawing.Point(161, 198);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(133, 48);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "Відключитися від сервера";
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // ipAdressTextBox
            // 
            this.ipAdressTextBox.Location = new System.Drawing.Point(140, 59);
            this.ipAdressTextBox.Name = "ipAdressTextBox";
            this.ipAdressTextBox.Size = new System.Drawing.Size(100, 22);
            this.ipAdressTextBox.TabIndex = 3;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(140, 109);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 22);
            this.portTextBox.TabIndex = 4;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(402, 291);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(180, 33);
            this.messageTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP адреса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Порт";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(140, 152);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 22);
            this.usernameTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Нікнейм";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(425, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(288, 243);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipAdressTextBox);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.connectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chat";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox ipAdressTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button sendButton;
    }
}

