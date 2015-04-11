namespace ConsoleInputAssist
{
    partial class FormCIA
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCIA));
            this.buttonGetWindowName = new System.Windows.Forms.Button();
            this.textBoxWindowName = new System.Windows.Forms.TextBox();
            this.textBoxHwnd = new System.Windows.Forms.TextBox();
            this.listBoxSend = new System.Windows.Forms.ListBox();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonEmpty = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.checkBoxSendEnter = new System.Windows.Forms.CheckBox();
            this.checkBoxSendOnClick = new System.Windows.Forms.CheckBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.checkBoxClearOnAdd = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxSendMsg = new System.Windows.Forms.CheckBox();
            this.numericUpDownSleepTime = new System.Windows.Forms.NumericUpDown();
            this.buttonCheckUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetWindowName
            // 
            this.buttonGetWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetWindowName.Location = new System.Drawing.Point(338, 11);
            this.buttonGetWindowName.Name = "buttonGetWindowName";
            this.buttonGetWindowName.Size = new System.Drawing.Size(102, 23);
            this.buttonGetWindowName.TabIndex = 0;
            this.buttonGetWindowName.Text = "捕获窗口(&G)";
            this.buttonGetWindowName.UseVisualStyleBackColor = true;
            this.buttonGetWindowName.Click += new System.EventHandler(this.buttonGetWindowName_Click);
            this.buttonGetWindowName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonGetWindowName_MouseDown);
            // 
            // textBoxWindowName
            // 
            this.textBoxWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWindowName.Location = new System.Drawing.Point(13, 13);
            this.textBoxWindowName.Name = "textBoxWindowName";
            this.textBoxWindowName.ReadOnly = true;
            this.textBoxWindowName.Size = new System.Drawing.Size(212, 21);
            this.textBoxWindowName.TabIndex = 1;
            // 
            // textBoxHwnd
            // 
            this.textBoxHwnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHwnd.Location = new System.Drawing.Point(231, 13);
            this.textBoxHwnd.Name = "textBoxHwnd";
            this.textBoxHwnd.ReadOnly = true;
            this.textBoxHwnd.Size = new System.Drawing.Size(101, 21);
            this.textBoxHwnd.TabIndex = 2;
            // 
            // listBoxSend
            // 
            this.listBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSend.FormattingEnabled = true;
            this.listBoxSend.ItemHeight = 12;
            this.listBoxSend.Location = new System.Drawing.Point(13, 67);
            this.listBoxSend.Name = "listBoxSend";
            this.listBoxSend.Size = new System.Drawing.Size(319, 364);
            this.listBoxSend.TabIndex = 3;
            this.listBoxSend.Click += new System.EventHandler(this.listBoxSend_Click);
            this.listBoxSend.DoubleClick += new System.EventHandler(this.listBoxSend_DoubleClick);
            this.listBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSend_KeyDown);
            this.listBoxSend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSend_MouseDown);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdd.Location = new System.Drawing.Point(13, 40);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(319, 21);
            this.textBoxAdd.TabIndex = 4;
            this.textBoxAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAdd_KeyDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(338, 38);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(101, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "添加(&A)";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModify.Location = new System.Drawing.Point(338, 96);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(101, 23);
            this.buttonModify.TabIndex = 7;
            this.buttonModify.Text = "修改(&M)";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(338, 205);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(101, 23);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "发送(&S)";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonEmpty
            // 
            this.buttonEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmpty.Location = new System.Drawing.Point(338, 234);
            this.buttonEmpty.Name = "buttonEmpty";
            this.buttonEmpty.Size = new System.Drawing.Size(101, 23);
            this.buttonEmpty.TabIndex = 11;
            this.buttonEmpty.Text = "清空(&E)";
            this.buttonEmpty.UseVisualStyleBackColor = true;
            this.buttonEmpty.Click += new System.EventHandler(this.buttonEmpty_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(338, 409);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 23);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "退出(&x)";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(338, 351);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(101, 23);
            this.buttonHelp.TabIndex = 17;
            this.buttonHelp.Text = "使用说明(&H)..";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // checkBoxSendEnter
            // 
            this.checkBoxSendEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSendEnter.AutoSize = true;
            this.checkBoxSendEnter.Checked = true;
            this.checkBoxSendEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSendEnter.Location = new System.Drawing.Point(338, 263);
            this.checkBoxSendEnter.Name = "checkBoxSendEnter";
            this.checkBoxSendEnter.Size = new System.Drawing.Size(84, 16);
            this.checkBoxSendEnter.TabIndex = 12;
            this.checkBoxSendEnter.Text = "发送回车符";
            this.checkBoxSendEnter.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendOnClick
            // 
            this.checkBoxSendOnClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSendOnClick.AutoSize = true;
            this.checkBoxSendOnClick.Location = new System.Drawing.Point(338, 285);
            this.checkBoxSendOnClick.Name = "checkBoxSendOnClick";
            this.checkBoxSendOnClick.Size = new System.Drawing.Size(84, 16);
            this.checkBoxSendOnClick.TabIndex = 13;
            this.checkBoxSendOnClick.Text = "单击即发送";
            this.checkBoxSendOnClick.UseVisualStyleBackColor = true;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsert.Location = new System.Drawing.Point(338, 67);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(101, 23);
            this.buttonInsert.TabIndex = 6;
            this.buttonInsert.Text = "插入(&I)";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // checkBoxClearOnAdd
            // 
            this.checkBoxClearOnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxClearOnAdd.AutoSize = true;
            this.checkBoxClearOnAdd.Checked = true;
            this.checkBoxClearOnAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClearOnAdd.Location = new System.Drawing.Point(338, 329);
            this.checkBoxClearOnAdd.Name = "checkBoxClearOnAdd";
            this.checkBoxClearOnAdd.Size = new System.Drawing.Size(84, 16);
            this.checkBoxClearOnAdd.TabIndex = 16;
            this.checkBoxClearOnAdd.Text = "添加后清空";
            this.checkBoxClearOnAdd.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(338, 125);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(101, 23);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "导入(&<)..";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(338, 154);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "导出(&>)..";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxSendMsg
            // 
            this.checkBoxSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSendMsg.AutoSize = true;
            this.checkBoxSendMsg.Checked = true;
            this.checkBoxSendMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSendMsg.Location = new System.Drawing.Point(338, 307);
            this.checkBoxSendMsg.Name = "checkBoxSendMsg";
            this.checkBoxSendMsg.Size = new System.Drawing.Size(42, 16);
            this.checkBoxSendMsg.TabIndex = 14;
            this.checkBoxSendMsg.Text = "MSG";
            this.checkBoxSendMsg.UseVisualStyleBackColor = true;
            this.checkBoxSendMsg.CheckedChanged += new System.EventHandler(this.checkBoxSendMsg_CheckedChanged);
            // 
            // numericUpDownSleepTime
            // 
            this.numericUpDownSleepTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSleepTime.Enabled = false;
            this.numericUpDownSleepTime.Location = new System.Drawing.Point(386, 306);
            this.numericUpDownSleepTime.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.numericUpDownSleepTime.Name = "numericUpDownSleepTime";
            this.numericUpDownSleepTime.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownSleepTime.TabIndex = 15;
            // 
            // buttonCheckUpdate
            // 
            this.buttonCheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckUpdate.Location = new System.Drawing.Point(338, 380);
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.Size = new System.Drawing.Size(101, 23);
            this.buttonCheckUpdate.TabIndex = 18;
            this.buttonCheckUpdate.Text = "检查更新(&U)..";
            this.buttonCheckUpdate.Click += new System.EventHandler(this.buttonCheckUpdate_Click);
            // 
            // FormCIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 449);
            this.Controls.Add(this.numericUpDownSleepTime);
            this.Controls.Add(this.checkBoxSendMsg);
            this.Controls.Add(this.checkBoxClearOnAdd);
            this.Controls.Add(this.checkBoxSendOnClick);
            this.Controls.Add(this.checkBoxSendEnter);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCheckUpdate);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonEmpty);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxAdd);
            this.Controls.Add(this.listBoxSend);
            this.Controls.Add(this.textBoxHwnd);
            this.Controls.Add(this.textBoxWindowName);
            this.Controls.Add(this.buttonGetWindowName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(390, 488);
            this.Name = "FormCIA";
            this.Text = "ConsoleInputAssist by bss";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCIA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetWindowName;
        private System.Windows.Forms.TextBox textBoxWindowName;
        private System.Windows.Forms.TextBox textBoxHwnd;
        private System.Windows.Forms.ListBox listBoxSend;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonEmpty;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.CheckBox checkBoxSendEnter;
        private System.Windows.Forms.CheckBox checkBoxSendOnClick;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.CheckBox checkBoxClearOnAdd;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxSendMsg;
        private System.Windows.Forms.NumericUpDown numericUpDownSleepTime;
        private System.Windows.Forms.Button buttonCheckUpdate;
    }
}

