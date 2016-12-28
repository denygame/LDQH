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
    public partial class Form2 : Form
    {
        private SendData obj;
        public Form2(SendData obj)
        {
            InitializeComponent();
            this.obj = obj;

            txtU.Text = obj.U;
            txtF.Text = obj.F;
        }

        private int CheckX()
        {
            string tam = "0123456789!@#$%^&*()_+/-=|{}[]?><.';,:";
            tam.ToCharArray();
            string s = txtX.Text;
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < tam.Length; j++)
                    if (s[i] == tam[j])
                    {
                        MessageBox.Show("Nhập X không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                f1.Reset(txtBDX);
                return;
            }
            if (f1.checkU(txtU) == 0) return;


            if(txtX.Text == "")
            {
                MessageBox.Show("Chưa nhập X!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckX() == 0) return;
            Solution solution = new Solution();
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);
            txtX.Text = solution.XoaGiong(txtX.Text);
            txtX.Text = txtX.Text.ToUpper().Replace(" ", "");
            if (txtF.Text == "") txtF.Text += "Ф";

            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtBDX.Text = "";

            BaoDong baodong = new BaoDong();
            baodong.BDcuaX(txtU, txtF, txtX, txtBDX);
        }

        



    }
}
