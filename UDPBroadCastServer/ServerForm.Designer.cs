namespace UDPBroadCastServer
{
    partial class ServerForm
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
                server.UDPsend.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.endBroadcastBtn = new System.Windows.Forms.Button();
            this.startBoardcastBtn = new System.Windows.Forms.Button();
            this.connectedGroupbox = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.classSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.connectedGroupbox.SuspendLayout();
            this.classSettingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(575, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 440);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "笔记：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "选择文件";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(475, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(19, 77);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(531, 318);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.endBroadcastBtn);
            this.groupBox2.Controls.Add(this.startBoardcastBtn);
            this.groupBox2.Location = new System.Drawing.Point(575, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 142);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "屏幕广播";
            // 
            // endBroadcastBtn
            // 
            this.endBroadcastBtn.Location = new System.Drawing.Point(348, 43);
            this.endBroadcastBtn.Name = "endBroadcastBtn";
            this.endBroadcastBtn.Size = new System.Drawing.Size(93, 44);
            this.endBroadcastBtn.TabIndex = 6;
            this.endBroadcastBtn.Text = "结束广播";
            this.endBroadcastBtn.UseVisualStyleBackColor = true;
            this.endBroadcastBtn.Click += new System.EventHandler(this.endBroadcastBtn_Click);
            // 
            // startBoardcastBtn
            // 
            this.startBoardcastBtn.Location = new System.Drawing.Point(118, 43);
            this.startBoardcastBtn.Name = "startBoardcastBtn";
            this.startBoardcastBtn.Size = new System.Drawing.Size(93, 44);
            this.startBoardcastBtn.TabIndex = 5;
            this.startBoardcastBtn.Text = "开始广播";
            this.startBoardcastBtn.UseVisualStyleBackColor = true;
            this.startBoardcastBtn.Click += new System.EventHandler(this.startBoardcastBtn_Click);
            // 
            // connectedGroupbox
            // 
            this.connectedGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectedGroupbox.Controls.Add(this.listView1);
            this.connectedGroupbox.Location = new System.Drawing.Point(12, 160);
            this.connectedGroupbox.Name = "connectedGroupbox";
            this.connectedGroupbox.Size = new System.Drawing.Size(557, 440);
            this.connectedGroupbox.TabIndex = 6;
            this.connectedGroupbox.TabStop = false;
            this.connectedGroupbox.Text = "已连接的学生端";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(6, 14);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(545, 420);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // classSettingGroupBox
            // 
            this.classSettingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classSettingGroupBox.Controls.Add(this.button5);
            this.classSettingGroupBox.Location = new System.Drawing.Point(18, 12);
            this.classSettingGroupBox.Name = "classSettingGroupBox";
            this.classSettingGroupBox.Size = new System.Drawing.Size(551, 142);
            this.classSettingGroupBox.TabIndex = 7;
            this.classSettingGroupBox.TabStop = false;
            this.classSettingGroupBox.Text = "课程";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 47);
            this.button5.TabIndex = 0;
            this.button5.Text = "steamVR教室";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.openClassRoom_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 612);
            this.Controls.Add(this.classSettingGroupBox);
            this.Controls.Add(this.connectedGroupbox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerForm";
            this.Text = "教师端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.connectedGroupbox.ResumeLayout(false);
            this.classSettingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button startBoardcastBtn;
        private System.Windows.Forms.Button endBroadcastBtn;
        private System.Windows.Forms.GroupBox connectedGroupbox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox classSettingGroupBox;
        private System.Windows.Forms.Button button5;
    }
}

