namespace KhoaLDQH
{
    partial class FrmPTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPTT));
            this.btnPhuTT = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhu = new System.Windows.Forms.TextBox();
            this.txtF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPhuTT
            // 
            this.btnPhuTT.BackColor = System.Drawing.Color.Black;
            this.btnPhuTT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhuTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhuTT.ForeColor = System.Drawing.Color.Red;
            this.btnPhuTT.Location = new System.Drawing.Point(659, 88);
            this.btnPhuTT.Name = "btnPhuTT";
            this.btnPhuTT.Size = new System.Drawing.Size(127, 26);
            this.btnPhuTT.TabIndex = 35;
            this.btnPhuTT.Text = "Kết Quả";
            this.btnPhuTT.UseVisualStyleBackColor = false;
            this.btnPhuTT.Click += new System.EventHandler(this.btnPhuTT_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(292, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 22);
            this.label5.TabIndex = 34;
            this.label5.Text = "TÌM PHỦ TỐI THIỂU";
            // 
            // txtPhu
            // 
            this.txtPhu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhu.Location = new System.Drawing.Point(12, 120);
            this.txtPhu.Multiline = true;
            this.txtPhu.Name = "txtPhu";
            this.txtPhu.ReadOnly = true;
            this.txtPhu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhu.Size = new System.Drawing.Size(774, 307);
            this.txtPhu.TabIndex = 33;
            // 
            // txtF
            // 
            this.txtF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF.Location = new System.Drawing.Point(90, 55);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(640, 24);
            this.txtF.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "F =";
            // 
            // FrmPTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 439);
            this.Controls.Add(this.btnPhuTT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhu);
            this.Controls.Add(this.txtF);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phủ Tối Thiểu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPhuTT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhu;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.Label label3;
    }
}