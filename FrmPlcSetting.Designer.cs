namespace Symmetry
{
    partial class FrmPlcSetting
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.comboBox_bauterate = new System.Windows.Forms.ComboBox();
            this.comboBox_databit = new System.Windows.Forms.ComboBox();
            this.comboBox_stopbit = new System.Windows.Forms.ComboBox();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_com, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_connect, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_close, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_bauterate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_databit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_stopbit, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_parity, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_com
            // 
            this.comboBox_com.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_com.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_com.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(219, 49);
            this.comboBox_com.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(174, 29);
            this.comboBox_com.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据位";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "停止位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "校验位";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_connect
            // 
            this.button_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_connect.Location = new System.Drawing.Point(438, 289);
            this.button_connect.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(144, 56);
            this.button_connect.TabIndex = 3;
            this.button_connect.Text = "连接";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_close
            // 
            this.button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_close.Enabled = false;
            this.button_close.Location = new System.Drawing.Point(642, 289);
            this.button_close.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(146, 56);
            this.button_close.TabIndex = 3;
            this.button_close.Text = "关闭";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // comboBox_bauterate
            // 
            this.comboBox_bauterate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_bauterate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_bauterate.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_bauterate.FormattingEnabled = true;
            this.comboBox_bauterate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600"});
            this.comboBox_bauterate.Location = new System.Drawing.Point(627, 50);
            this.comboBox_bauterate.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_bauterate.Name = "comboBox_bauterate";
            this.comboBox_bauterate.Size = new System.Drawing.Size(176, 29);
            this.comboBox_bauterate.TabIndex = 1;
            // 
            // comboBox_databit
            // 
            this.comboBox_databit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_databit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_databit.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_databit.FormattingEnabled = true;
            this.comboBox_databit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBox_databit.Location = new System.Drawing.Point(219, 177);
            this.comboBox_databit.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_databit.Name = "comboBox_databit";
            this.comboBox_databit.Size = new System.Drawing.Size(174, 29);
            this.comboBox_databit.TabIndex = 1;
            // 
            // comboBox_stopbit
            // 
            this.comboBox_stopbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_stopbit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_stopbit.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_stopbit.FormattingEnabled = true;
            this.comboBox_stopbit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_stopbit.Location = new System.Drawing.Point(627, 177);
            this.comboBox_stopbit.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_stopbit.Name = "comboBox_stopbit";
            this.comboBox_stopbit.Size = new System.Drawing.Size(176, 29);
            this.comboBox_stopbit.TabIndex = 1;
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_parity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox_parity.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
            this.comboBox_parity.Location = new System.Drawing.Point(219, 304);
            this.comboBox_parity.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(174, 29);
            this.comboBox_parity.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网口连接";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "暂未开放";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPlcSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 422);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlcSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PLC设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_bauterate;
        private System.Windows.Forms.ComboBox comboBox_databit;
        private System.Windows.Forms.ComboBox comboBox_stopbit;
        private System.Windows.Forms.ComboBox comboBox_parity;
    }
}