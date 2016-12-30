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
    public partial class FrmPTT : Form
    {
        public FrmPTT()
        {
            InitializeComponent();
        }

        private void btnPhuTT_Click(object sender, EventArgs e)
        {
            PhuToiThieu phu = new PhuToiThieu();
            phu.PhuTT(txtF, txtPhu);
        }
    }
}
