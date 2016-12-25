using System;
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
            MessageBox.Show("Nhập các thuộc tính theo dạng U = abc (có thể viết hoa)!\r\nNhập phụ thuộc hàm F theo dạng F = A->B,C->A (có thể viết thường)!", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nguyễn Thanh Huy\r\n\r\nLiên Hệ: thanhhuy96.gtvt@gmail.com", "Liên Hệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BaoDong bd = new BaoDong();
            bd.ShowBD(txtU, txtF, txtBD);
        }

        private void txtU_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8);
        }

        private void txtF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 32 || e.KeyChar == 62 || e.KeyChar == 8);
        }

        private void txtU_Enter(object sender, EventArgs e)
        {
            txtU.Text = "";
            txtF.Text = "";
        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BaoDong bd = new BaoDong();
            bd.TapCon(txtU, txtF, txtBD);
            txtBD.Text += "Tập con: " + bd.TapCon(txtU, txtF, txtBD) + "\r\n\r\n\r\nTập con thực sự < trừ tập con t = U >: " + (bd.TapCon(txtU, txtF, txtBD) - 1) + "\r\n\r\n\r\nTập con thực sự khác rỗng: " + (bd.TapCon(txtU, txtF, txtBD) - 2);
        }

        private void btnMKhoa_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PhuToiThieu phu = new PhuToiThieu();
            phu.PhuTT(txtU, txtF, txtPhu);
        }
    }
}
