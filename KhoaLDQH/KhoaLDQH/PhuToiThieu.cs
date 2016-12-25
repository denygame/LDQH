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

        private List<string> listVT = new List<string>();
        private List<string> listVP = new List<string>();

        public void PhuTT(TextBox txtU, TextBox txtF, TextBox txtPhu)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtPhu.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                txtPhu.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n====================== PHỦ TỐI THIỂU =====================\r\n\r\n";

                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU,txtF);



                txtPhu.Text += "◊◊ Bước 1: Chuyển vế phải của mỗi phụ thuộc hàm thành các thuộc tính đơn lẻ\r\n";

                ////xem 
                for (int i = 0; i < solution.VePhai.Length; i++)
                {
                    if (solution.VePhai[i].Length > 1)
                    {
                        for (int j = 0; j < solution.VePhai[i].Length; j++)
                        {
                            listVT.Add(solution.VeTrai[i]);
                            listVP.Add(solution.VePhai[i][j].ToString());
                        }
                    }
                    if(solution.VePhai[i].Length==1)
                    {
                        listVT.Add(solution.VeTrai[i]);
                        listVP.Add(solution.VePhai[i]);
                    }
                }

                for (int i = 0; i < listVP.Count; i++)
                    txtPhu.Text += "\t" + listVT[i] + " -> " + listVP[i] + "\r\n";

                txtPhu.Text += "\r\n\r\n◊◊ Bước 2: Loại bỏ các thuộc tính dư thừa bên phía trái của mỗi phụ thuộc hàm\r\n";


                string[] vt = listVT.ToArray();
                string[] vp = listVP.ToArray();

                ///phụ thuộc hàm có vế trái dư thừa
                for (int i = 0; i < listVP.Count; i++)
                {
                    if (listVT[i].Length != 1)
                    {
                        txtPhu.Text += "\r\n\t + Xét PTH: " + listVT[i] + " -> " + listVP[i] + "\r\n";
                        LoaiDuThua(listVT[i], txtPhu, listVP[i], vt, vp, i);

                        txtPhu.Text += "\r\n® Kết quả: F = {";
                        for (int p = 0; p < listVT.Count; p++)
                        {
                            if (p == listVT.Count - 1)
                            {
                                txtPhu.Text += listVT[p] + "->" + listVP[p] + "}\r\n";
                                break;
                            }
                            txtPhu.Text += listVT[p] + "->" + listVP[p] + ",";
                        }
                    }
                }

                txtPhu.Text += "\r\n\r\n◊◊ Bước 3: Loại bỏ các phụ thuộc hàm dư thừa\r\n";
                txtPhu.Text += "\r\nF = {";
                for (int p = 0; p < listVT.Count; p++)
                {
                    if (p == listVT.Count - 1)
                    {
                        txtPhu.Text += listVT[p] + "->" + listVP[p] + "}\r\n\r\n";
                        break;
                    }
                    txtPhu.Text += listVT[p] + "->" + listVP[p] + ",";
                }
                
                LoaiPTHDuThua(txtPhu,vt,vp);


            }
        }
        

        


        private void LoaiDuThua(string veTrai, TextBox txtPhu,string vePhai,string[] vt,string[] vp,int id)
        {
            for(int i=0;i<veTrai.Length;i++)
            {
                txtPhu.Text += "• Loại " + veTrai[i] + ":  Ta có (" + PhanTuConLai(veTrai, veTrai[i].ToString()) + ")+  = {" + baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vt, vp, vt.Length) + "}";
                if (solution.Chua(baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vt, vp, vt.Length), veTrai[i].ToString()) == 1)
                {
                    txtPhu.Text += " chứa " + veTrai[i].ToString() + " => " + veTrai[i].ToString() + " dư thừa\r\n";
                    string tam = veTrai;
                    listVT[id] = solution.Tru(ref tam, veTrai[i].ToString());
                }
                else
                {
                    txtPhu.Text += " không chứa " + veTrai[i].ToString() + " => " + veTrai[i].ToString() + " không dư thừa\r\n";
                }
            }
        }


        private string PhanTuConLai(string vtrai, string tc)
        {
            string s = vtrai;
            string re;
            re = solution.Tru(ref vtrai, tc);
            return re;
        }
        
        private void LoaiPTHDuThua(TextBox txtPhu,string[] vt, string[] vp)
        {
            for(int i=0;i<listVT.Count;i++)
            {
                txtPhu.Text += "• Thử loại bỏ " + listVT[i] + "->" + listVP[i] + ":\r\n";
                

                txtPhu.Text += "\tTa có: (" + listVT[i] + ")+  = " + baodong.BD(listVT[i], vt, vp, vt.Length );
                if(solution.Chua(baodong.BD(listVT[i], vt, vp, vt.Length),listVP[i])==1)
                {
                    txtPhu.Text += " chứa " + listVP[i] + " => " + listVT[i] + "->" + listVP[i] + " dư thừa\r\n";
                    listVT.Remove(listVT[i]);
                    listVP.Remove(listVP[i]);
                    i--;

                    txtPhu.Text += "\r\n=> F = {";
                    for (int p = 0; p < listVT.Count; p++)
                    {
                        if (p == listVT.Count - 1)
                        {
                            txtPhu.Text += listVT[p] + "->" + listVP[p] + "}\r\n";
                            break;
                        }
                        txtPhu.Text += listVT[p] + "->" + listVP[p] + ",";
                    }
                }
                else
                {
                    txtPhu.Text += " không chứa " + listVP[i] + " => " + listVT[i] + "->" + listVP[i] + " không dư thừa\r\n";
                    txtPhu.Text += "\r\n=> F giữ nguyên\r\n";
                }
                
            }
        }


    }
}
