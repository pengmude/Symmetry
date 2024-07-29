namespace Symmetry
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存所有配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出所有配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.算法参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.添加1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加NG1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ok2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ng2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.plcToolStripMenuItem,
            this.算法参数ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.登录ToolStripMenuItem,
            this.添加1ToolStripMenuItem,
            this.添加NG1ToolStripMenuItem,
            this.添加ok2ToolStripMenuItem,
            this.添加ng2ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1542, 36);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存所有配置ToolStripMenuItem,
            this.导出所有配置ToolStripMenuItem});
            this.fileToolStripMenuItem.Enabled = false;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // 保存所有配置ToolStripMenuItem
            // 
            this.保存所有配置ToolStripMenuItem.Name = "保存所有配置ToolStripMenuItem";
            this.保存所有配置ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.保存所有配置ToolStripMenuItem.Text = "保存所有配置";
            // 
            // 导出所有配置ToolStripMenuItem
            // 
            this.导出所有配置ToolStripMenuItem.Name = "导出所有配置ToolStripMenuItem";
            this.导出所有配置ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.导出所有配置ToolStripMenuItem.Text = "导出所有配置";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像ToolStripMenuItem,
            this.数据窗口ToolStripMenuItem,
            this.日志窗口ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            this.viewToolStripMenuItem.Text = "视图";
            // 
            // 图像ToolStripMenuItem
            // 
            this.图像ToolStripMenuItem.Checked = true;
            this.图像ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.图像ToolStripMenuItem.Name = "图像ToolStripMenuItem";
            this.图像ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.图像ToolStripMenuItem.Text = "图像窗口";
            this.图像ToolStripMenuItem.Click += new System.EventHandler(this.图像ToolStripMenuItem_Click);
            // 
            // 数据窗口ToolStripMenuItem
            // 
            this.数据窗口ToolStripMenuItem.Checked = true;
            this.数据窗口ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.数据窗口ToolStripMenuItem.Name = "数据窗口ToolStripMenuItem";
            this.数据窗口ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.数据窗口ToolStripMenuItem.Text = "数据窗口";
            this.数据窗口ToolStripMenuItem.Click += new System.EventHandler(this.数据窗口ToolStripMenuItem_Click);
            // 
            // 日志窗口ToolStripMenuItem
            // 
            this.日志窗口ToolStripMenuItem.Checked = true;
            this.日志窗口ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.日志窗口ToolStripMenuItem.Name = "日志窗口ToolStripMenuItem";
            this.日志窗口ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.日志窗口ToolStripMenuItem.Text = "日志窗口";
            this.日志窗口ToolStripMenuItem.Click += new System.EventHandler(this.日志窗口ToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Enabled = false;
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            this.cameraToolStripMenuItem.Text = "相机";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.camToolStripMenuItem_Click);
            // 
            // plcToolStripMenuItem
            // 
            this.plcToolStripMenuItem.Enabled = false;
            this.plcToolStripMenuItem.Name = "plcToolStripMenuItem";
            this.plcToolStripMenuItem.Size = new System.Drawing.Size(59, 32);
            this.plcToolStripMenuItem.Text = "PLC";
            this.plcToolStripMenuItem.Click += new System.EventHandler(this.plcToolStripMenuItem_Click);
            // 
            // 算法参数ToolStripMenuItem
            // 
            this.算法参数ToolStripMenuItem.Enabled = false;
            this.算法参数ToolStripMenuItem.Name = "算法参数ToolStripMenuItem";
            this.算法参数ToolStripMenuItem.Size = new System.Drawing.Size(114, 32);
            this.算法参数ToolStripMenuItem.Text = "算法参数";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Enabled = false;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.登录ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.登录ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(250, 0, 0, 0);
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.Size = new System.Drawing.Size(1542, 854);
            this.dockPanel1.TabIndex = 3;
            this.dockPanel1.Theme = this.vS2015BlueTheme1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 36);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1542, 45);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dockPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1542, 854);
            this.panel1.TabIndex = 5;
            // 
            // 添加1ToolStripMenuItem
            // 
            this.添加1ToolStripMenuItem.Name = "添加1ToolStripMenuItem";
            this.添加1ToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.添加1ToolStripMenuItem.Text = "添加ok1";
            this.添加1ToolStripMenuItem.Click += new System.EventHandler(this.添加1ToolStripMenuItem_Click);
            // 
            // 添加NG1ToolStripMenuItem
            // 
            this.添加NG1ToolStripMenuItem.Name = "添加NG1ToolStripMenuItem";
            this.添加NG1ToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.添加NG1ToolStripMenuItem.Text = "添加NG1";
            this.添加NG1ToolStripMenuItem.Click += new System.EventHandler(this.添加NG1ToolStripMenuItem_Click);
            // 
            // 添加ok2ToolStripMenuItem
            // 
            this.添加ok2ToolStripMenuItem.Name = "添加ok2ToolStripMenuItem";
            this.添加ok2ToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.添加ok2ToolStripMenuItem.Text = "添加ok2";
            this.添加ok2ToolStripMenuItem.Click += new System.EventHandler(this.添加ok2ToolStripMenuItem_Click);
            // 
            // 添加ng2ToolStripMenuItem
            // 
            this.添加ng2ToolStripMenuItem.Name = "添加ng2ToolStripMenuItem";
            this.添加ng2ToolStripMenuItem.Size = new System.Drawing.Size(103, 32);
            this.添加ng2ToolStripMenuItem.Text = "添加ng2";
            this.添加ng2ToolStripMenuItem.Click += new System.EventHandler(this.添加ng2ToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Symmetry.Properties.Resources.单次执行;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "自动运行";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Symmetry.Properties.Resources.在线点检;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton2.Text = "toolStripButton3";
            this.toolStripButton2.ToolTipText = "在线点检";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::Symmetry.Properties.Resources.停止执行;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton3.Text = "toolStripButton2";
            this.toolStripButton3.ToolTipText = "停止运行";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 935);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "东莞市云田视觉对称度检测系统1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存所有配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出所有配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 算法参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志窗口ToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加NG1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ok2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ng2ToolStripMenuItem;
    }
}