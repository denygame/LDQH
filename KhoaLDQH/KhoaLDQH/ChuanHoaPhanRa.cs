using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class ChuanHoaPhanRa
    {
        Solution solution = new Solution();
        TextBox txtU, txtF, txtKQ;
        PhuToiThieu ptt = new PhuToiThieu();
        TimKhoa tk = new TimKhoa();

        List<string> vtPTT = new List<string>();
        List<string> vpPTT = new List<string>();


        public ChuanHoaPhanRa(TextBox txtU, TextBox txtF, TextBox txtKQ)
        {
            this.txtU = txtU; this.txtF = txtF; this.txtKQ = txtKQ;
        }

        public void phanra3NFbtPTH()
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);
            
            if (txtF.Text == "") txtF.Text += "Ф";
            
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKQ.Text = "";

            List<string> listKQ = new List<string>();
            if (solution.check(txtF.Text) == 1)
            {
                ptt.PTTforDifClass(txtF, vtPTT, vpPTT);

                txtKQ.Text += "◊◊ Phủ tối thiểu của lược đồ trên là:\r\nG = {";
                for (int i = 0; i < vtPTT.Count; i++)
                {
                    if (i == vtPTT.Count - 1)
                    {
                        txtKQ.Text += vtPTT[i] + " -> " + vpPTT[i] + "}\r\n\r\n";
                        break;
                    }
                    txtKQ.Text += vtPTT[i] + " -> " + vpPTT[i] + ", ";
                }

                for (int i = 0; i < vtPTT.Count; i++)
                {
                    string s = "";
                    s += vtPTT[i] + vpPTT[i];
                    for (int j = i + 1; j < vtPTT.Count; j++)
                        if (vtPTT[i] == vtPTT[j])
                            s += vtPTT[j] + vpPTT[j];
                    listKQ.Add(solution.XoaGiong(s));
                }

                string ttconlai = "";
                for (int i = 0; i < txtU.Text.Length; i++)
                {
                    int test = 0;
                    for (int j = 0; j < listKQ.Count; j++)
                        for (int chay = 0; chay < listKQ[j].Length; chay++)
                            if (txtU.Text[i] == listKQ[j][chay]) test++;
                    if (test == 0) ttconlai += txtU.Text[i];
                }
                if (ttconlai != "") listKQ.Add(ttconlai);


                

                for(int i=0;i<listKQ.Count;i++)
                {
                    for (int j = 0; j < listKQ.Count; j++)
                        if (solution.Chua(listKQ[i], listKQ[j]) == 1 && i != j)
                        {
                            listKQ.RemoveAt(j);
                            j--;
                        }
                }
                txtKQ.Text += "◊◊ KẾT QUẢ PHÂN RÃ:\r\n";
                for(int i=0;i<listKQ.Count;i++)
                    txtKQ.Text += "=> R" + (i + 1) + ": { " + listKQ[i] + " }\r\n";
            }
        }

        public void phanra3NFbtPTHvaTT()
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            if (txtF.Text == "") txtF.Text += "Ф";

            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKQ.Text = "";

            List<string> listKQ = new List<string>();
            if (solution.check(txtF.Text) == 1)
            {
                string khoa = "";
                tk.Tim1KhoaChoClassKhac(txtU, txtF, ref khoa);
                txtKQ.Text += "Một khóa <khóa tối thiểu> của quan hệ là: " + khoa + "\r\n\r\n";

                ptt.PTTforDifClass(txtF, vtPTT, vpPTT);
                
                for (int i = 0; i < vtPTT.Count; i++)
                {
                    string s = "";
                    s += vtPTT[i] + vpPTT[i];
                    for (int j = i + 1; j < vtPTT.Count; j++)
                        if (vtPTT[i] == vtPTT[j])
                            s += vtPTT[j] + vpPTT[j];
                    listKQ.Add(solution.XoaGiong(s));
                }

                string ttconlai = "";
                for (int i = 0; i < txtU.Text.Length; i++)
                {
                    int test = 0;
                    for (int j = 0; j < listKQ.Count; j++)
                        for (int chay = 0; chay < listKQ[j].Length; chay++)
                            if (txtU.Text[i] == listKQ[j][chay]) test++;
                    if (test == 0) ttconlai += txtU.Text[i];
                }
                if (ttconlai != "") listKQ.Add(ttconlai);

                
                for (int i = 0; i < listKQ.Count; i++)
                {
                    for (int j = 0; j < listKQ.Count; j++)
                        if (solution.Chua(listKQ[i], listKQ[j]) == 1 && i != j)
                        {
                            listKQ.RemoveAt(j);
                            j--;
                        }
                }
                txtKQ.Text += "◊◊ Theo phân rã bảo toàn PTH ta được:\r\n";
                for (int i = 0; i < listKQ.Count; i++)
                    txtKQ.Text += "=> R" + (i + 1) + ": { " + listKQ[i] + " }\r\n";

                int dem = 0;
                for (int i = 0; i < listKQ.Count; i++)
                    if (solution.Chua(listKQ[i], khoa) == 1) dem++;
                if(dem==0)
                {
                    txtKQ.Text += "\r\nDo không có bộ phân rã nào chứa khóa nên thêm 1 tập phân rã\r\n";
                    txtKQ.Text += "=> R" + (listKQ.Count + 1) + ": { " + khoa + " }\r\n";
                }
            }
        }








    }
}
