using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class PTHduthua
    {
        BaoDong baodong = new BaoDong();
        Solution solution = new Solution();
        TextBox txtF, txtKT, txtT, txtP;
        string t, p;
        PhuToiThieu ptt = new PhuToiThieu();

        public PTHduthua(TextBox txtF, TextBox txtKT, TextBox txtT, TextBox txtP)
        {
            this.txtKT = txtKT; this.txtF = txtF; this.txtT = txtT; this.txtP = txtP;
            KiemTraPTHDuThua();
        }

        private void KiemTraPTHDuThua()
        {
            if (txtF.Text == "")
            {
                MessageBox.Show("Chưa nhập F", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKT.Text = "";
            txtT.Text = solution.XoaGiong(txtT.Text);
            txtP.Text = solution.XoaGiong(txtP.Text);
            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";
                int n = 0;
                solution.layDataKhongU(txtF.Text, ref n, txtF);

                t = txtT.Text;
                p = txtP.Text;
                int dem = 0, pthThu = 0;
                for (int i = 0; i < solution.PhuThuocHam.Length; i++)
                    if (t == solution.VeTrai[i] && p == solution.VePhai[i])
                    {
                        dem++;
                        pthThu = i;
                    }
                if (dem == 0)
                {
                    txtKT.Text += "Không có phụ thuộc hàm này trong tập F";
                    return;
                }

                
                List<string> listTestVT = new List<string>();
                List<string> listTestVP = new List<string>();
                for (int j = 0; j < solution.VeTrai.Length; j++) listTestVT.Add(solution.VeTrai[j]);
                for (int j = 0; j < solution.VePhai.Length; j++) listTestVP.Add(solution.VePhai[j]);

                listTestVT.RemoveAt(pthThu);
                listTestVP.RemoveAt(pthThu);

                txtKT.Text += "\tTa có: (" + txtT.Text + ")+  = " + baodong.BD(txtT.Text, listTestVT.ToArray(), listTestVP.ToArray(), listTestVT.Count);

                if (solution.Chua(baodong.BD(txtT.Text, listTestVT.ToArray(), listTestVP.ToArray(), listTestVT.Count), txtP.Text) == 1)
                {
                    txtKT.Text += " chứa " + txtP.Text + " nên " + txtT.Text + "->" + txtP.Text + " dư thừa\r\n";
                    txtKT.Text += "\t==> Loại bỏ PTH: " + txtT.Text + "->" + txtP.Text + "\r\n\r\n";
                }
                else
                {
                    txtKT.Text += " không chứa " + txtP.Text + " nên " + txtT.Text + "->" + txtP.Text + " không dư thừa\r\n";
                    txtKT.Text += "\t==> Không thể loại PTH: " + txtT.Text + "->" + txtP.Text + "\r\n\r\n";
                }



            }




        }
    }
}
