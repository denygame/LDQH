namespace KhoaLDQH
{
    partial class Form3
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
            this.btnBD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSD = new System.Windows.Forms.TextBox();
            this.txtVT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.txtU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBD
            // 
            this.btnBD.BackColor = System.Drawing.Color.Black;
            this.btnBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBD.ForeColor = System.Drawing.Color.Red;
            this.btnBD.Location = new System.Drawing.Point(465, 110);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(127, 26);
            this.btnBD.TabIndex = 22;
            this.btnBD.Text = "Kết Quả";
            this.btnBD.UseVisualStyleBackColor = false;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(192, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "KIỂM TRA PTH SUY DIỄN";
            // 
            // txtSD
            // 
            this.txtSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSD.Location = new System.Drawing.Point(28, 142);
            this.txtSD.Multiline = true;
            this.txtSD.Name = "txtSD";
            this.txtSD.ReadOnly = true;
            this.txtSD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSD.Size = new System.Drawing.Size(564, 103);
            this.txtSD.TabIndex = 20;
            // 
            // txtVT
            // 
            this.txtVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVT.Location = new System.Drawing.Point(371, 70);
            this.txtVT.Name = "txtVT";
            this.txtVT.Size = new System.Drawing.Size(84, 24);
            this.txtVT.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(401, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "F có suy diễn được?";
            // 
            // txtF
            // 
            this.txtF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF.Location = new System.Drawing.Point(63, 91);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(231, 24);
            this.txtF.TabIndex = 17;
            // 
            // txtU
            // 
            this.txtU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtU.Location = new System.Drawing.Point(63, 53);
            this.txtU.Name = "txtU";
            this.txtU.Size = new System.Drawing.Size(231, 24);
            this.txtU.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(24, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "F =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "U =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "=>";
            // 
            // txtVP
            // 
            this.txtVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVP.Location = new System.Drawing.Point(496, 70);
            this.txtVP.Name = "txtVP";
            this.txtVP.Size = new System.Drawing.Size(84, 24);
            this.txtVP.TabIndex = 24;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.txtVP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSD);
            this.Controls.Add(this.txtVT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtF);
            this.Controls.Add(this.txtU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm Tra Phụ Thuộc Hàm Suy Diễn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSD;
        private System.Windows.Forms.TextBox txtVT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.TextBox txtU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVP;
    }
}