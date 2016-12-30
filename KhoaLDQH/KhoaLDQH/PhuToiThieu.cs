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
        private List<string> listKQVT = new List<string>();
        private List<string> listKQVP = new List<string>();

        private List<string> listVTsauB1 = new List<string>();
        private List<string> listVPsauB1 = new List<string>();
        private List<string> listVTsauB2 = new List<string>();
        private List<string> listVPsauB2 = new List<string>();

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
                solution.layData(txtF.Text, ref n, txtU, txtF);
                
                txtPhu.Text += "◊◊ Bước 1: Chuyển vế phải của mỗi phụ thuộc hàm thành các thuộc tính đơn lẻ\r\n";

                ////xem 
                for (int i = 0; i < solution.VePhai.Length; i++)
                {
                    if (solution.VePhai[i].Length > 1)
                        for (int j = 0; j < solution.VePhai[i].Length; j++)
                        {
                            listVT.Add(solution.VeTrai[i]);
                            listVP.Add(solution.VePhai[i][j].ToString());
                        }

                    if (solution.VePhai[i].Length == 1)
                    {
                        listVT.Add(solution.VeTrai[i]);
                        listVP.Add(solution.VePhai[i]);
                    }
                }


                //loại bỏ pth giống nhau sau B1
                for (int i = 0; i < listVT.Count; i++)
                {
                    int dem = 0;
                    for (int j = i+1; j < listVP.Count; j++)
                    {
                        if (listVT[i] == listVT[j] && listVP[i] == listVP[j])
                            dem++;
                    }
                    if (dem == 0)
                    {
                        listVTsauB1.Add(listVT[i]);
                        listVPsauB1.Add(listVP[i]);
                    }
                }

                for (int i = 0; i < listVPsauB1.Count; i++)
                    txtPhu.Text += "\t" + listVTsauB1[i] + " -> " + listVPsauB1[i] + "\r\n";

                
                txtPhu.Text += "\r\n\r\n◊◊ Bước 2: Loại bỏ các thuộc tính dư thừa bên phía trái của mỗi phụ thuộc hàm\r\n";


                string[] vp = listVPsauB1.ToArray();
                string[] vt = listVTsauB1.ToArray();

                ///phụ thuộc hàm có vế trái dư thừa
                for (int i = 0; i < listVPsauB1.Count; i++)
                {
                    if (listVTsauB1[i].Length != 1)
                    {
                        txtPhu.Text += "\r\n\t + Xét PTH: " + listVTsauB1[i] + " -> " + listVPsauB1[i] + "\r\n";
                        LoaiDuThua(listVTsauB1[i], txtPhu, listVPsauB1[i], vt, vp, i);

                        txtPhu.Text += "\r\n® Kết quả: F = {";
                        for (int p = 0; p < listVTsauB1.Count; p++)
                        {
                            if (p == listVTsauB1.Count - 1)
                            {
                                txtPhu.Text += listVTsauB1[p] + "->" + listVPsauB1[p] + "}\r\n";
                                break;
                            }
                            txtPhu.Text += listVTsauB1[p] + "->" + listVPsauB1[p] + ",";
                        }
                    }
                    else
                    {
                        txtPhu.Text += "\r\n\t Chỉ xét những PTH có vế trái đa thuộc tính\r\n";
                        break;
                    }
                }

                //loại bỏ pth giống nhau sau B2
                for (int i = 0; i < listVTsauB1.Count; i++)
                {
                    int dem = 0;
                    for (int j = i + 1; j < listVPsauB1.Count; j++)
                    {
                        if (listVTsauB1[i] == listVTsauB1[j] && listVPsauB1[i] == listVPsauB1[j])
                            dem++;
                    }
                    if (dem == 0)
                    {
                        listVTsauB2.Add(listVTsauB1[i]);
                        listVPsauB2.Add(listVPsauB1[i]);
                    }
                }

                string[] vtsauB2= listVTsauB2.ToArray();
                string[] vpsauB2 = listVPsauB2.ToArray();

                txtPhu.Text += "\r\n\r\n◊◊ Bước 3: Loại bỏ các phụ thuộc hàm dư thừa\r\n";
                txtPhu.Text += "\r\nF = {";
                for (int p = 0; p < listVTsauB2.Count; p++)
                {
                    if (p == listVTsauB2.Count - 1)
                    {
                        txtPhu.Text += listVTsauB2[p] + "->" + listVPsauB2[p] + "}\r\n\r\n";
                        break;
                    }
                    txtPhu.Text += listVTsauB2[p] + "->" + listVPsauB2[p] + ",";
                }
                
                LoaiPTHDuThua(txtPhu, vtsauB2, vpsauB2);
            }
        }


        #region Buoc2LoaiTTduthuavetrai
        private void LoaiDuThua(string veTrai, TextBox txtPhu, string vePhai, string[] vt, string[] vp, int id)
        {
            for (int i = 0; i < veTrai.Length; i++)
            {
                txtPhu.Text += "• Loại " + veTrai[i] + ":  Ta có (" + PhanTuConLai(veTrai, veTrai[i].ToString()) + ")+  = {" + baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vt, vp, vt.Length) + "}";
                if (solution.Chua(baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vt, vp, vt.Length), veTrai[i].ToString()) == 1)
                {
                    txtPhu.Text += " chứa " + veTrai[i].ToString() + " => " + veTrai[i].ToString() + " dư thừa\r\n";
                    string tam = veTrai;
                    listVTsauB1[id] = solution.Tru(ref tam, veTrai[i].ToString());
                }
                else
                {
                    txtPhu.Text += " không chứa " + veTrai[i].ToString() + " => " + veTrai[i].ToString() + " không dư thừa\r\n";
                }
            }
        }


        public string PhanTuConLai(string vtrai, string tc)
        {
            string s = vtrai;
            string re;
            re = solution.Tru(ref vtrai, tc);
            return re;
        }

        #endregion

        #region Buoc3LoaiPTHduthua
        private void doiChoxuongCuoi(string[] v, int pos)
        {
            if (pos == v.Length - 1) return;
            for (int i = 0; i < v.Length; i++)
                if (i == pos)
                {
                    string temp = v[i];
                    v[i] = v[v.Length - 1];
                    v[v.Length - 1] = temp;
                }
        }


        private void LoaiPTHDuThua(TextBox txtPhu, string[] vt, string[] vp)
        {
            List<string> listTestVT = new List<string>();
            List<string> listTestVP = new List<string>();
            for (int j = 0; j < vt.Length; j++) listTestVT.Add(vt[j]);
            for (int j = 0; j < vp.Length; j++) listTestVP.Add(vp[j]);

            for (int i = 0; i < listVTsauB2.Count; i++)
            {
                txtPhu.Text += "• Thử loại bỏ " + listVTsauB2[i] + "->" + listVPsauB2[i] + ":\r\n";

                //thử loại bỏ
                listTestVT.Remove(vt[i]);
                listTestVP.Remove(vp[i]);
                
                

       
                txtPhu.Text += "\tTa có: (" + listVTsauB2[i] + ")+  = " + baodong.BD(listVTsauB2[i], listTestVT.ToArray(), listTestVP.ToArray(), listTestVT.Count);
                if (solution.Chua(baodong.BD(listVTsauB2[i], listTestVT.ToArray(), listTestVP.ToArray(), listTestVT.Count), listVPsauB2[i]) == 1)
                {
                    txtPhu.Text += " chứa " + listVPsauB2[i] + " nên " + listVTsauB2[i] + "->" + listVPsauB2[i] + " dư thừa\r\n";
                    txtPhu.Text += "\t==> Loại bỏ PTH: " + listVTsauB2[i] + "->" + listVPsauB2[i] + "\r\n\r\n";
                }
                else
                {
                    txtPhu.Text += " không chứa " + listVPsauB2[i] + " nên " + listVTsauB2[i] + "->" + listVPsauB2[i] + " không dư thừa\r\n";
                    txtPhu.Text += "\t==> Không thể loại PTH: " + listVTsauB2[i] + "->" + listVPsauB2[i] + "\r\n\r\n";
                    //k loại thì add lại
                    listTestVT.Add(vt[i]);
                    listTestVP.Add(vp[i]);
                    //add vào kết quả
                    listKQVT.Add(listVTsauB2[i]);
                    listKQVP.Add(listVPsauB2[i]);

                }

            }

            txtPhu.Text += "\r\nФ KẾT QUẢ: F = {";
            for (int i = 0; i < listKQVT.Count; i++)
            {
                if (i == listKQVT.Count - 1)
                {
                    txtPhu.Text += listKQVT[i] + " -> " + listKQVP[i] + "}\r\n\r\n";
                    break;
                }
                txtPhu.Text += listKQVT[i] + " -> " + listKQVP[i] + " , ";
            }
        }

        #endregion

    }
}
