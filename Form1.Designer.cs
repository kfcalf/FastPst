namespace FastPst
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTopPaste = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddcopy = new System.Windows.Forms.Button();
            this.btnNoAdd = new System.Windows.Forms.Button();
            this.btnRestartExPlorer = new System.Windows.Forms.Button();
            this.chkSlashDirection = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTopPaste
            // 
            this.btnTopPaste.Location = new System.Drawing.Point(25, 12);
            this.btnTopPaste.Name = "btnTopPaste";
            this.btnTopPaste.Size = new System.Drawing.Size(112, 23);
            this.btnTopPaste.TabIndex = 0;
            this.btnTopPaste.Text = "顶部粘贴设置";
            this.toolTip1.SetToolTip(this.btnTopPaste, "第一个组合键：Ctrl + Home, Ctrl + V, Enter, Enter");
            this.btnTopPaste.UseVisualStyleBackColor = true;
            this.btnTopPaste.Click += new System.EventHandler(this.btnTopPaste_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(25, 69);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(112, 23);
            this.btnPaste.TabIndex = 1;
            this.btnPaste.Text = "底部粘贴设置";
            this.toolTip1.SetToolTip(this.btnPaste, "第二个组合键：Ctrl + End, Enter, Ctrl + V, Enter");
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(171, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "FastPst";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emsExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // emsExit
            // 
            this.emsExit.Name = "emsExit";
            this.emsExit.Size = new System.Drawing.Size(107, 22);
            this.emsExit.Text = "退出&E";
            this.emsExit.Click += new System.EventHandler(this.emsExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "光标在右侧文本框时按快捷键，点击左边按钮生效";
            // 
            // btnAddcopy
            // 
            this.btnAddcopy.Location = new System.Drawing.Point(25, 117);
            this.btnAddcopy.Name = "btnAddcopy";
            this.btnAddcopy.Size = new System.Drawing.Size(112, 23);
            this.btnAddcopy.TabIndex = 5;
            this.btnAddcopy.Text = "添加右键复制路径";
            this.btnAddcopy.UseVisualStyleBackColor = true;
            this.btnAddcopy.Click += new System.EventHandler(this.btnAddcopy_Click);
            // 
            // btnNoAdd
            // 
            this.btnNoAdd.Location = new System.Drawing.Point(143, 117);
            this.btnNoAdd.Name = "btnNoAdd";
            this.btnNoAdd.Size = new System.Drawing.Size(112, 23);
            this.btnNoAdd.TabIndex = 6;
            this.btnNoAdd.Text = "取消右键复制路径";
            this.btnNoAdd.UseVisualStyleBackColor = true;
            this.btnNoAdd.Click += new System.EventHandler(this.btnNoAdd_Click);
            // 
            // btnRestartExPlorer
            // 
            this.btnRestartExPlorer.Location = new System.Drawing.Point(283, 139);
            this.btnRestartExPlorer.Name = "btnRestartExPlorer";
            this.btnRestartExPlorer.Size = new System.Drawing.Size(52, 23);
            this.btnRestartExPlorer.TabIndex = 7;
            this.btnRestartExPlorer.Text = "生效";
            this.btnRestartExPlorer.UseVisualStyleBackColor = true;
            this.btnRestartExPlorer.Visible = false;
            this.btnRestartExPlorer.Click += new System.EventHandler(this.btnRestartExPlorer_Click);
            // 
            // chkSlashDirection
            // 
            this.chkSlashDirection.AutoSize = true;
            this.chkSlashDirection.Checked = true;
            this.chkSlashDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSlashDirection.Location = new System.Drawing.Point(260, 120);
            this.chkSlashDirection.Name = "chkSlashDirection";
            this.chkSlashDirection.Size = new System.Drawing.Size(54, 16);
            this.chkSlashDirection.TabIndex = 8;
            this.chkSlashDirection.Text = "使用/";
            this.chkSlashDirection.UseVisualStyleBackColor = true;
            this.chkSlashDirection.CheckedChanged += new System.EventHandler(this.chkSlashDirection_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(143, 150);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 165);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkSlashDirection);
            this.Controls.Add(this.btnRestartExPlorer);
            this.Controls.Add(this.btnNoAdd);
            this.Controls.Add(this.btnAddcopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnTopPaste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTopPaste;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emsExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAddcopy;
        private System.Windows.Forms.Button btnNoAdd;
        private System.Windows.Forms.Button btnRestartExPlorer;
        private System.Windows.Forms.CheckBox chkSlashDirection;
        private System.Windows.Forms.Label lblInfo;
    }
}

