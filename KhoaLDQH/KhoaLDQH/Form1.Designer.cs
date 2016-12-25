namespace KhoaLDQH
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnMuiTen = new System.Windows.Forms.Button();
            this.txtF = new System.Windows.Forms.TextBox();
            this.txtU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBD = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSaveBD = new System.Windows.Forms.Button();
            this.btnTC = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnMKhoa = new System.Windows.Forms.Button();
            this.btnSaveKhoa = new System.Windows.Forms.Button();
            this.btn1Khoa = new System.Windows.Forms.Button();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnMuiTen);
            this.splitContainer1.Panel1.Controls.Add(this.txtF);
            this.splitContainer1.Panel1.Controls.Add(this.txtU);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(692, 522);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnMuiTen
            // 
            this.btnMuiTen.Location = new System.Drawing.Point(438, 104);
            this.btnMuiTen.Name = "btnMuiTen";
            this.btnMuiTen.Size = new System.Drawing.Size(42, 24);
            this.btnMuiTen.TabIndex = 5;
            this.btnMuiTen.Text = "→";
            this.btnMuiTen.UseVisualStyleBackColor = true;
            this.btnMuiTen.Click += new System.EventHandler(this.btnMuiTen_Click);
            // 
            // txtF
            // 
            this.txtF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF.Location = new System.Drawing.Point(61, 104);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(371, 24);
            this.txtF.TabIndex = 4;
            this.txtF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtF_KeyPress);
            // 
            // txtU
            // 
            this.txtU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtU.Location = new System.Drawing.Point(61, 66);
            this.txtU.Name = "txtU";
            this.txtU.Size = new System.Drawing.Size(371, 24);
            this.txtU.TabIndex = 3;
            this.txtU.Enter += new System.EventHandler(this.txtU_Enter);
            this.txtU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtU_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "F =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "U =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "R = < U , F >";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnToolStripMenuItem,
            this.liênHệToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn";
            this.hướngDẫnToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnToolStripMenuItem_Click);
            // 
            // liênHệToolStripMenuItem
            // 
            this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.liênHệToolStripMenuItem.Text = "Liên Hệ";
            this.liênHệToolStripMenuItem.Click += new System.EventHandler(this.liênHệToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBD);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBD
            // 
            this.tabBD.Controls.Add(this.splitContainer2);
            this.tabBD.Location = new System.Drawing.Point(4, 22);
            this.tabBD.Name = "tabBD";
            this.tabBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabBD.Size = new System.Drawing.Size(678, 354);
            this.tabBD.TabIndex = 0;
            this.tabBD.Text = "Bao Đóng";
            this.tabBD.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer2.Panel1.Controls.Add(this.btnSaveBD);
            this.splitContainer2.Panel1.Controls.Add(this.btnTC);
            this.splitContainer2.Panel1.Controls.Add(this.btnBD);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtBD);
            this.splitContainer2.Size = new System.Drawing.Size(672, 348);
            this.splitContainer2.SplitterDistance = 124;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnSaveBD
            // 
            this.btnSaveBD.BackColor = System.Drawing.Color.Black;
            this.btnSaveBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBD.ForeColor = System.Drawing.Color.Red;
            this.btnSaveBD.Location = new System.Drawing.Point(18, 290);
            this.btnSaveBD.Name = "btnSaveBD";
            this.btnSaveBD.Size = new System.Drawing.Size(85, 27);
            this.btnSaveBD.TabIndex = 2;
            this.btnSaveBD.Text = "Lưu KQ";
            this.btnSaveBD.UseVisualStyleBackColor = false;
            // 
            // btnTC
            // 
            this.btnTC.BackColor = System.Drawing.Color.Black;
            this.btnTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTC.ForeColor = System.Drawing.Color.Red;
            this.btnTC.Location = new System.Drawing.Point(18, 97);
            this.btnTC.Name = "btnTC";
            this.btnTC.Size = new System.Drawing.Size(85, 29);
            this.btnTC.TabIndex = 1;
            this.btnTC.Text = "Tập Con";
            this.btnTC.UseVisualStyleBackColor = false;
            this.btnTC.Click += new System.EventHandler(this.btnTC_Click);
            // 
            // btnBD
            // 
            this.btnBD.BackColor = System.Drawing.Color.Black;
            this.btnBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBD.ForeColor = System.Drawing.Color.Red;
            this.btnBD.Location = new System.Drawing.Point(11, 36);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(101, 26);
            this.btnBD.TabIndex = 0;
            this.btnBD.Text = "Kết Quả";
            this.btnBD.UseVisualStyleBackColor = false;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // txtBD
            // 
            this.txtBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBD.Location = new System.Drawing.Point(3, 3);
            this.txtBD.Multiline = true;
            this.txtBD.Name = "txtBD";
            this.txtBD.ReadOnly = true;
            this.txtBD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBD.Size = new System.Drawing.Size(538, 342);
            this.txtBD.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 354);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Khóa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer3.Panel1.Controls.Add(this.btnMKhoa);
            this.splitContainer3.Panel1.Controls.Add(this.btnSaveKhoa);
            this.splitContainer3.Panel1.Controls.Add(this.btn1Khoa);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtKhoa);
            this.splitContainer3.Size = new System.Drawing.Size(672, 348);
            this.splitContainer3.SplitterDistance = 124;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnMKhoa
            // 
            this.btnMKhoa.BackColor = System.Drawing.Color.Black;
            this.btnMKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMKhoa.ForeColor = System.Drawing.Color.Red;
            this.btnMKhoa.Location = new System.Drawing.Point(3, 86);
            this.btnMKhoa.Name = "btnMKhoa";
            this.btnMKhoa.Size = new System.Drawing.Size(118, 26);
            this.btnMKhoa.TabIndex = 3;
            this.btnMKhoa.Text = "Tìm Mọi Khóa";
            this.btnMKhoa.UseVisualStyleBackColor = false;
            this.btnMKhoa.Click += new System.EventHandler(this.btnMKhoa_Click);
            // 
            // btnSaveKhoa
            // 
            this.btnSaveKhoa.BackColor = System.Drawing.Color.Black;
            this.btnSaveKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveKhoa.ForeColor = System.Drawing.Color.Red;
            this.btnSaveKhoa.Location = new System.Drawing.Point(18, 290);
            this.btnSaveKhoa.Name = "btnSaveKhoa";
            this.btnSaveKhoa.Size = new System.Drawing.Size(85, 27);
            this.btnSaveKhoa.TabIndex = 2;
            this.btnSaveKhoa.Text = "Lưu KQ";
            this.btnSaveKhoa.UseVisualStyleBackColor = false;
            // 
            // btn1Khoa
            // 
            this.btn1Khoa.BackColor = System.Drawing.Color.Black;
            this.btn1Khoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1Khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1Khoa.ForeColor = System.Drawing.Color.Red;
            this.btn1Khoa.Location = new System.Drawing.Point(3, 36);
            this.btn1Khoa.Name = "btn1Khoa";
            this.btn1Khoa.Size = new System.Drawing.Size(118, 26);
            this.btn1Khoa.TabIndex = 0;
            this.btn1Khoa.Text = "Tìm Một Khóa";
            this.btn1Khoa.UseVisualStyleBackColor = false;
            // 
            // txtKhoa
            // 
            this.txtKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoa.Location = new System.Drawing.Point(3, 3);
            this.txtKhoa.Multiline = true;
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKhoa.Size = new System.Drawing.Size(538, 342);
            this.txtKhoa.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 522);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết Kế Cơ Sở Dữ Liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabBD.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.TextBox txtU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMuiTen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liênHệToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBD;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.Button btnSaveBD;
        private System.Windows.Forms.Button btnTC;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnMKhoa;
        private System.Windows.Forms.Button btnSaveKhoa;
        private System.Windows.Forms.Button btn1Khoa;
        private System.Windows.Forms.TextBox txtKhoa;
    }
}