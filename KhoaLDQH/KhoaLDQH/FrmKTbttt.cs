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
    public partial class FrmKTbttt : Form
    {
        public FrmKTbttt()
        {
            InitializeComponent();
        }

        private void btnPhanRaMatTin_Click(object sender, EventArgs e)
        {
            FrmKhoa f1 = new FrmKhoa();
            if (txtU.Text == "")
            {
                MessageBox.Show("Chưa nhập U!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                f1.Reset(txtShow);
                return;
            }
            if (f1.checkU(txtU) == 0) return;

            PhanRa pr = new PhanRa();
            pr.PhanRaKhongMatTin(txtU, txtF, txtPhanRa, txtShow);
        }
        
    }
}
