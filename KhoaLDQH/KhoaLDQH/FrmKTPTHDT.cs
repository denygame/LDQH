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
    public partial class FrmKTPTHDT : Form
    {
        public FrmKTPTHDT()
        {
            InitializeComponent();
        }

        private void btnKTPTH_Click(object sender, EventArgs e)
        {
            FrmKTsuyDien f = new FrmKTsuyDien();

            if (txtT.Text == "" || txtP.Text == "")
            {
                MessageBox.Show("Chưa nhập PTH!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (f.CheckPTH(txtT) == 0 || f.CheckPTH(txtP) == 0) return;
            txtT.Text = txtT.Text.ToUpper().Replace(" ", "");
            txtP.Text = txtP.Text.ToUpper().Replace(" ", "");
            PTHduthua pth = new PTHduthua(txtF, txtKT, txtT, txtP);
        }
    }
}
