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
    public partial class FrmKTPTHvtDT : Form
    {
        public FrmKTPTHvtDT()
        {
            InitializeComponent();
        }

        private void btnKTPTH_Click(object sender, EventArgs e)
        {
            FrmKhoa f1 = new FrmKhoa();
            FrmKTsuyDien f = new FrmKTsuyDien();
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f1.Reset(txtKT);
                return;
            }

            if (f1.checkU(txtU) == 0) return;

            if (txtT.Text == "" || txtP.Text == "")
            {
                MessageBox.Show("Chưa nhập PTH!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (f.CheckPTH(txtT) == 0 || f.CheckPTH(txtP) == 0) return;
            txtT.Text = txtT.Text.ToUpper().Replace(" ", "");
            txtP.Text = txtP.Text.ToUpper().Replace(" ", "");
            PTHvtDuThua pth = new PTHvtDuThua(txtU, txtF, txtKT, txtT,txtP);
        }
    }
}
