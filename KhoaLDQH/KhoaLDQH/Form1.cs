﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KhoaLDQH
{
    public partial class Form1 : Form
    {
        public int checkU(TextBox txtU)
        {
            string tam = "0123456789!@#$%^&*()_+/-=|{}[]?><.';,:";
            tam.ToCharArray();
            string s = txtU.Text;
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < tam.Length; j++)
                    if (s[i] == tam[j])
                    {
                        MessageBox.Show("Nhập U không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
            return 1;
        }


        public void Reset(TextBox txttest)
        {
            txttest.Text = "";
            if (txttest == txtBD)
                comboBox1.Items.Clear();
            
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Save(string KQ)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "TXT file|*.txt";
            DialogResult test = a.ShowDialog();

            if (test == DialogResult.OK)
                using (StreamWriter sw = new StreamWriter(a.FileName))
                    sw.WriteLine(KQ);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileInfo fileRoute = new FileInfo("test.txt");
            fileRoute.Delete();
        }

        private void btnMuiTen_Click(object sender, EventArgs e)
        {
            txtF.Text += "->";
            txtF.Focus();

            //di chuyển con trỏ về cuối textbox
            txtF.SelectionLength = 0;
            txtF.SelectionStart = txtF.Text.Length;
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDSD hd = new HDSD();
            hd.ShowDialog();
        }
        

        private void btnBD_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.Items.Clear();
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtBD);
                return;
            }
            if (checkU(txtU) == 0) return;
            if (txtU.Text.Length > 8)
            {
                DialogResult chon = MessageBox.Show("Thuật toán tìm tất cả bao đóng của lược đồ quan hệ có nhiều hơn 8 thuộc tính sẽ làm chương trình chạy chậm và có thể bị đột tử nếu nhiều hơn 10 thuộc tính :)), vui lòng nhấn OK để tìm bao đóng của X", "Thông Báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (chon == DialogResult.OK)
                {
                    SendData obj = new SendData();
                    obj.U = txtU.Text;
                    obj.F = txtF.Text;

                    Form2 f2 = new Form2(obj);
                    f2.ShowDialog();
                }
            }

            else
            {
                BaoDong bd = new BaoDong();
                bd.ShowBD(txtU, txtF, txtBD, comboBox1);
            }
        }
        
        private void btnTC_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtBD);
                return;
            }
            if (checkU(txtU) == 0) return;
            BaoDong bd = new BaoDong();
            bd.TapCon(txtU, txtF, txtBD);
            txtBD.Text += "Tập con: " + bd.TapCon(txtU, txtF, txtBD) + "\r\n\r\n\r\nTập con thực sự < trừ tập con t = U >: " + (bd.TapCon(txtU, txtF, txtBD) - 1) + "\r\n\r\n\r\nTập con thực sự khác rỗng: " + (bd.TapCon(txtU, txtF, txtBD) - 2);
        }

        private void btnMKhoa_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtKhoa);
                return;
            }
            if (checkU(txtU) == 0) return;
            TimKhoa tk = new TimKhoa();
            tk.TimMoiKhoa(txtU, txtF, txtKhoa);
        }

        private void btnSaveBD_Click(object sender, EventArgs e)
        {
            if (txtBD.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save(txtBD.Text);
        }

        private void btn1Khoa_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtKhoa);
                return;
            }
            if (checkU(txtU) == 0) return;
            TimKhoa tk = new TimKhoa();
            tk.Tim1Khoa(txtU, txtF, txtKhoa);
        }

        private void btnSaveKhoa_Click(object sender, EventArgs e)
        {
            if (txtKhoa.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save(txtKhoa.Text);
        }

        private void btnSavePhu_Click(object sender, EventArgs e)
        {
            if (txtPhu.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save(txtPhu.Text);
        }

        private void btnPhu_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtPhu);
                return;
            }
            if (checkU(txtU) == 0) return;
            PhuToiThieu phu = new PhuToiThieu();
            phu.PhuTT(txtU, txtF, txtPhu);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaoDong bd = new BaoDong();
            bd.chonComboBox(comboBox1, txtBD, txtU, txtF);
        }

        private void btnDC2_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtPhu);
                return;
            }
            if (checkU(txtU) == 0) return;
            DangChuan dc = new DangChuan();
            dc.XacdinhChuan2(txtDC, txtU, txtF);
        }

        private void btnDC3_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtPhu);
                return;
            }
            if (checkU(txtU) == 0) return;
            DangChuan dc = new DangChuan();
            dc.XacdinhChuan3(txtDC, txtU, txtF);
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtPhu);
                return;
            }
            if (checkU(txtU) == 0) return;
            DangChuan dc = new DangChuan();
            dc.XacdinhChuanBC(txtDC, txtU, txtF);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDC.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save(txtDC.Text);
        }

        private void tìmBaoĐóngCủaXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendData obj = new SendData();
            Form2 f2 = new Form2(obj);
            f2.ShowDialog();
        }

        private void btnXDchuan_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset(txtPhu);
                return;
            }
            DangChuan dc = new DangChuan();
            dc.XacdinhCHUAN(txtDC, txtU, txtF);
        }

        private void kiểmTraPTHSuyDiễnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void vềPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VEPM f = new VEPM();
            f.ShowDialog();
        }

        private void vềTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VETG f = new VETG();
            f.ShowDialog();
        }

        private void armstrongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Armstrong f = new Armstrong();
            f.ShowDialog();
        }

        //private void txtU_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar.ToString().IndexOfAny(@"0123456789!@#$%^&*()_+-/=|\{}[]?><.,';:".ToCharArray()) != -1)
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Tập thuộc tính U chỉ được nhập các ký tự abc", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //        e.Handled = false;
        //}

        //private void txtF_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar.ToString().IndexOfAny(@"0123456789!@#$%^&*()_+/=|\{}[]?<.';:".ToCharArray()) != -1)
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Tập thuộc tính F chỉ được nhập các ký tự abc, ký hiệu -> và dấu phẩy", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //        e.Handled = false;
        //}
    }
}
