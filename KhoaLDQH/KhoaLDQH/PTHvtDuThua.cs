using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class PTHvtDuThua
    {
        BaoDong baodong = new BaoDong();
        Solution solution = new Solution();
        TextBox txtF, txtKT, txtT, txtP;
        string t, p;
        PhuToiThieu ptt = new PhuToiThieu();

        public PTHvtDuThua(TextBox txtF,TextBox txtKT, TextBox txtT, TextBox txtP)
        {
            this.txtKT = txtKT; this.txtF = txtF; this.txtT = txtT; this.txtP = txtP;
            KiemTraPTHvtDuThua();
        }
        

        private void KiemTraPTHvtDuThua()
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

                int dem = 0;
                for(int i=0;i<solution.PhuThuocHam.Length;i++)
                    if (t == solution.VeTrai[i] && p == solution.VePhai[i]) dem++;
                if(dem == 0)
                {
                    txtKT.Text += "Không có phụ thuộc hàm này trong tập F";
                    return;
                }

                if (t.Length == 1)
                {
                    txtKT.Text += "Vế trái có 1 thuộc tính nên PTH này vế trái không dư thừa";
                    return;
                }
                else
                {
                    int test = 0;
                    for (int i = 0; i < t.Length; i++)
                    {
                        txtKT.Text += "Loại " + t[i] + " trong " + t + "->" + p + ":\r\n\tTa có (" + ptt.PhanTuConLai(t, t[i].ToString()) + ") +  = { " + baodong.BD(ptt.PhanTuConLai(t, t[i].ToString()), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) + " }";

                        if (solution.Chua(baodong.BD(ptt.PhanTuConLai(t, t[i].ToString()), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length), p) == 1)
                        {
                            txtKT.Text += " chứa " + p + " => " + t[i] + " dư thừa\r\n";
                            test++;
                        }
                        else
                            txtKT.Text += " không chứa " + p + "\r\n";
                    }

                    if (test != 0)
                        txtKT.Text += "\r\n==> Đây là PTH có vế trái dư thừa";
                    else
                        txtKT.Text += "\r\n==> PTH có vế trái không dư thừa";
                }
            }





        }
    }
}
