namespace SimpleWindowCapture
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_tools = new System.Windows.Forms.Panel();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.button_title = new System.Windows.Forms.Button();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.buttonHandle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Handle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel_tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tools
            // 
            this.panel_tools.BackColor = System.Drawing.Color.White;
            this.panel_tools.Controls.Add(this.comboBox_Type);
            this.panel_tools.Controls.Add(this.button_title);
            this.panel_tools.Controls.Add(this.textBox_Title);
            this.panel_tools.Controls.Add(this.buttonHandle);
            this.panel_tools.Controls.Add(this.label2);
            this.panel_tools.Controls.Add(this.textBox_Handle);
            this.panel_tools.Controls.Add(this.label1);
            this.panel_tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_tools.Location = new System.Drawing.Point(0, 378);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(717, 50);
            this.panel_tools.TabIndex = 0;
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(580, 15);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Type.TabIndex = 3;
            // 
            // button_title
            // 
            this.button_title.Location = new System.Drawing.Point(461, 12);
            this.button_title.Name = "button_title";
            this.button_title.Size = new System.Drawing.Size(75, 23);
            this.button_title.TabIndex = 2;
            this.button_title.Text = "Start";
            this.button_title.UseVisualStyleBackColor = true;
            this.button_title.Click += new System.EventHandler(this.button_title_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(351, 13);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(100, 21);
            this.textBox_Title.TabIndex = 1;
            // 
            // buttonHandle
            // 
            this.buttonHandle.Location = new System.Drawing.Point(181, 13);
            this.buttonHandle.Name = "buttonHandle";
            this.buttonHandle.Size = new System.Drawing.Size(75, 23);
            this.buttonHandle.TabIndex = 2;
            this.buttonHandle.Text = "Start";
            this.buttonHandle.UseVisualStyleBackColor = true;
            this.buttonHandle.Click += new System.EventHandler(this.buttonHandle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // textBox_Handle
            // 
            this.textBox_Handle.Location = new System.Drawing.Point(71, 14);
            this.textBox_Handle.Name = "textBox_Handle";
            this.textBox_Handle.Size = new System.Drawing.Size(100, 21);
            this.textBox_Handle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Handle";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(717, 378);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 428);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel_tools);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleWindowCapture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_tools.ResumeLayout(false);
            this.panel_tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonHandle;
        private System.Windows.Forms.TextBox textBox_Handle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_title;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Type;
    }
}

