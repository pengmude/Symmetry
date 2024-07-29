namespace Symmetry
{
    partial class FrmImgeView
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ytPictrueBox1 = new YTPictrueBox();
            this.ytPictrueBox2 = new YTPictrueBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ytPictrueBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ytPictrueBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1338, 766);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ytPictrueBox1
            // 
            this.ytPictrueBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ytPictrueBox1.DisplayImageType = DisplayImageType.SRCIMG;
            this.ytPictrueBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ytPictrueBox1.Location = new System.Drawing.Point(3, 3);
            this.ytPictrueBox1.Name = "ytPictrueBox1";
            this.ytPictrueBox1.RenderImage = null;
            this.ytPictrueBox1.Size = new System.Drawing.Size(663, 760);
            this.ytPictrueBox1.SrcImage = null;
            this.ytPictrueBox1.TabIndex = 0;
            // 
            // ytPictrueBox2
            // 
            this.ytPictrueBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ytPictrueBox2.DisplayImageType = DisplayImageType.SRCIMG;
            this.ytPictrueBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ytPictrueBox2.Location = new System.Drawing.Point(672, 3);
            this.ytPictrueBox2.Name = "ytPictrueBox2";
            this.ytPictrueBox2.RenderImage = null;
            this.ytPictrueBox2.Size = new System.Drawing.Size(663, 760);
            this.ytPictrueBox2.SrcImage = null;
            this.ytPictrueBox2.TabIndex = 0;
            this.ytPictrueBox2.VisibleChanged += new System.EventHandler(this.ytPictrueBox2_VisibleChanged);
            // 
            // FrmImgeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1338, 766);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(261, 61);
            this.Name = "FrmImgeView";
            this.Text = "图像显示窗口";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImgeView_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private YTPictrueBox ytPictrueBox1;
        private YTPictrueBox ytPictrueBox2;
    }
}