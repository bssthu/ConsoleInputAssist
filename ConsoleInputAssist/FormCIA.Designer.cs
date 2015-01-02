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
            this.buttonGetWindowName = new System.Windows.Forms.Button();
            this.textBoxWindowName = new System.Windows.Forms.TextBox();
            this.textBoxHwnd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGetWindowName
            // 
            this.buttonGetWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetWindowName.Location = new System.Drawing.Point(358, 11);
            this.buttonGetWindowName.Name = "buttonGetWindowName";
            this.buttonGetWindowName.Size = new System.Drawing.Size(102, 23);
            this.buttonGetWindowName.TabIndex = 0;
            this.buttonGetWindowName.Text = "捕获窗口(&G)";
            this.buttonGetWindowName.UseVisualStyleBackColor = true;
            this.buttonGetWindowName.Click += new System.EventHandler(this.buttonGetWindowName_Click);
            // 
            // textBoxWindowName
            // 
            this.textBoxWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWindowName.Location = new System.Drawing.Point(13, 13);
            this.textBoxWindowName.Name = "textBoxWindowName";
            this.textBoxWindowName.ReadOnly = true;
            this.textBoxWindowName.Size = new System.Drawing.Size(237, 21);
            this.textBoxWindowName.TabIndex = 1;
            // 
            // textBoxHwnd
            // 
            this.textBoxHwnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHwnd.Location = new System.Drawing.Point(256, 13);
            this.textBoxHwnd.Name = "textBoxHwnd";
            this.textBoxHwnd.ReadOnly = true;
            this.textBoxHwnd.Size = new System.Drawing.Size(96, 21);
            this.textBoxHwnd.TabIndex = 2;
            // 
            // FormCIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 292);
            this.Controls.Add(this.textBoxHwnd);
            this.Controls.Add(this.textBoxWindowName);
            this.Controls.Add(this.buttonGetWindowName);
            this.Name = "FormCIA";
            this.Text = "ConsoleInputAssist by bss";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetWindowName;
        private System.Windows.Forms.TextBox textBoxWindowName;
        private System.Windows.Forms.TextBox textBoxHwnd;
    }
}

