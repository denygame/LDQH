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
    public partial class FrmPhanRa : Form
    {
        public FrmPhanRa()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                ChuanHoaPhanRa c = new ChuanHoaPhanRa(txtU, txtF, txtKQ);
                c.phanra3NFbtPTH();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                ChuanHoaPhanRa c = new ChuanHoaPhanRa(txtU, txtF, txtKQ);
                c.phanra3NFbtPTHvaTT();
            }
            comboBox1.Enabled = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            FrmKhoa f = new FrmKhoa();
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f.Reset(txtKQ);
                return;
            }
            f.checkU(txtU);
            if (txtU.Text != "")
                comboBox1.Enabled = true;
        }
    }
}
