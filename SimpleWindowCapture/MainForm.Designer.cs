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
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboBoxPicture = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonTitle = new System.Windows.Forms.Button();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.buttonHandle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Handle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.panel_tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tools
            // 
            this.panel_tools.BackColor = System.Drawing.Color.White;
            this.panel_tools.Controls.Add(this.checkBoxTopMost);
            this.panel_tools.Controls.Add(this.buttonStop);
            this.panel_tools.Controls.Add(this.comboBoxPicture);
            this.panel_tools.Controls.Add(this.comboBoxType);
            this.panel_tools.Controls.Add(this.buttonTitle);
            this.panel_tools.Controls.Add(this.textBox_Title);
            this.panel_tools.Controls.Add(this.buttonHandle);
            this.panel_tools.Controls.Add(this.label2);
            this.panel_tools.Controls.Add(this.textBox_Handle);
            this.panel_tools.Controls.Add(this.label4);
            this.panel_tools.Controls.Add(this.label3);
            this.panel_tools.Controls.Add(this.label1);
            this.panel_tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_tools.Location = new System.Drawing.Point(0, 345);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(544, 106);
            this.panel_tools.TabIndex = 0;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(440, 40);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(78, 56);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboBoxPicture
            // 
            this.comboBoxPicture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPicture.FormattingEnabled = true;
            this.comboBoxPicture.Location = new System.Drawing.Point(397, 10);
            this.comboBoxPicture.Name = "comboBoxPicture";
            this.comboBoxPicture.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPicture.TabIndex = 3;
            this.comboBoxPicture.SelectedIndexChanged += new System.EventHandler(this.comboBoxPicture_SelectedIndexChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(176, 10);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxType.TabIndex = 3;
            // 
            // buttonTitle
            // 
            this.buttonTitle.Location = new System.Drawing.Point(355, 40);
            this.buttonTitle.Name = "buttonTitle";
            this.buttonTitle.Size = new System.Drawing.Size(75, 23);
            this.buttonTitle.TabIndex = 2;
            this.buttonTitle.Text = "Start";
            this.buttonTitle.UseVisualStyleBackColor = true;
            this.buttonTitle.Click += new System.EventHandler(this.buttonTitle_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(65, 42);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(280, 21);
            this.textBox_Title.TabIndex = 1;
            // 
            // buttonHandle
            // 
            this.buttonHandle.Location = new System.Drawing.Point(355, 73);
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
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // textBox_Handle
            // 
            this.textBox_Handle.Location = new System.Drawing.Point(65, 74);
            this.textBox_Handle.Name = "textBox_Handle";
            this.textBox_Handle.Size = new System.Drawing.Size(280, 21);
            this.textBox_Handle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Picture Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Capture Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 78);
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
            this.pictureBox.Size = new System.Drawing.Size(544, 345);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(20, 12);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(66, 16);
            this.checkBoxTopMost.TabIndex = 5;
            this.checkBoxTopMost.Text = "TopMost";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.Click += new System.EventHandler(this.checkBoxTopMost_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 451);
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
        private System.Windows.Forms.Button buttonTitle;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPicture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
    }
}

