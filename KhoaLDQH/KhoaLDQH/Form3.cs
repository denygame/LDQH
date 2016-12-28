using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private int CheckPTH(TextBox txttest)
        {
            string tam = "0123456789!@#$%^&*()_+/-=|{}[]?><.';,:";
            tam.ToCharArray();
            string s = txttest.Text;
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < tam.Length; j++)
                    if (s[i] == tam[j])
                    {
                        MessageBox.Show("Nhập PTH không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
            return 1;
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f1.Reset(txtSD);
                return;
            }

            if (f1.checkU(txtU) == 0) return;

            if (txtVT.Text == "" || txtVP.Text=="")
            {
                MessageBox.Show("Chưa nhập PTH!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckPTH(txtVT) == 0 || CheckPTH(txtVP)==0) return;
            

            Solution solution = new Solution();
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            txtVT.Text = txtVT.Text.ToUpper().Replace(" ", "");
            txtVP.Text = txtVP.Text.ToUpper().Replace(" ", "");

            if (txtF.Text == "") txtF.Text += "Ф";

            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtSD.Text = "";

            BaoDong baodong = new BaoDong();
            baodong.ktPTHsuydien(txtU, txtF, txtVT, txtVP, txtSD);
        }
    }
}
