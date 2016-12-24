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

   //ctrl mã ascii là 17, delete mã ascii là 8
        private void txtU_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8);
        }

        private void txtF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 32 || e.KeyChar == 62 || e.KeyChar == 8);
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Solution s = new Solution();
            s.TimKhoa(txtU, txtF, txtKQ);
        }

        private void txtU_Enter(object sender, EventArgs e)
        {
            txtU.Text = "";
            txtF.Text = "";
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập lược đồ quan hệ!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Solution solution = new Solution();
            solution.BaoDong(txtU, txtF, txtBaoDong);
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
    }
}
