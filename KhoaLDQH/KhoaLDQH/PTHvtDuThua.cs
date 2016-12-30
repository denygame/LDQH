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
        TextBox txtU, txtF, txtKT, txtT, txtP;
        string t, p;
        PhuToiThieu ptt = new PhuToiThieu();

        public PTHvtDuThua(TextBox txtU,TextBox txtF,TextBox txtKT, TextBox txtT, TextBox txtP)
        {
            this.txtKT = txtKT; this.txtF = txtF; this.txtU = txtU; this.txtT = txtT; this.txtP = txtP;
            KiemTraPTHvtDuThua();
        }
        

        private void KiemTraPTHvtDuThua()
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);
            
            if (txtF.Text == "") txtF.Text += "Ф";
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKT.Text = "";


            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";
                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);

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
                    for (int i = 0; i < t.Length; i++)
                    {
                        txtKT.Text += "Loại " + t[i] + " trong " + t + "->" + p + ":\r\n Ta có (" + ptt.PhanTuConLai(t, t[i].ToString()) + ") +  = { " + baodong.BD(ptt.PhanTuConLai(t, t[i].ToString()), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) + "}\r\n";

                        if (solution.Chua(baodong.BD(ptt.PhanTuConLai(t, t[i].ToString()), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length), t[i].ToString()) == 1)
                        {
                            txtKT.Text += " chứa " + t[i] + " => " + t[i] + " dư thừa\r\n";
                            txtKT.Text += "\r\n==> Đây là PTH có vế trái dư thừa";
                            return;
                        }
                        else
                            txtKT.Text += " không chứa " + t[i] + "\r\n";
                    }
                    txtF.Text += "\r\n==> PTH có vế trái không dư thừa";
                }
            }





        }
    }
}
