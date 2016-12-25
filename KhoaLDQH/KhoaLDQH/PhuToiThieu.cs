using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class PhuToiThieu
    {
        BaoDong baodong = new BaoDong();
        Solution solution = new Solution();


        public void PhuTT(TextBox txtU, TextBox txtF, TextBox txtKhoa)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKhoa.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                txtKhoa.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n====================== PHỦ TỐI THIỂU =====================\r\n\r\n";

                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU);
            }
        }
    }
}
