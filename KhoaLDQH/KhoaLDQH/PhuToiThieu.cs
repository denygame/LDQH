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

        private List<string> listVTsauBuoc2 = new List<string>();
        private List<string> listVPsauBuoc2 = new List<string>();


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

                for (int i = 0; i < listVP.Count; i++)
                    txtPhu.Text += "\t" + listVT[i] + " -> " + listVP[i] + "\r\n";

                txtPhu.Text += "\r\n\r\n◊◊ Bước 2: Loại bỏ các thuộc tính dư thừa bên phía trái của mỗi phụ thuộc hàm\r\n";


                string[] vpsauBuoc1 = listVP.ToArray();
                string[] vtsauBuoc1 = listVT.ToArray();


                listVTsauBuoc2 = listVT;
                listVPsauBuoc2 = listVP;

                ///phụ thuộc hàm có vế trái dư thừa
                for (int i = 0; i < listVP.Count; i++)
                {
                    if (listVT[i].Length != 1)
                    {
                        txtPhu.Text += "\r\n\t + Xét PTH: " + listVT[i] + " -> " + listVP[i] + "\r\n";
                        LoaiDuThua(listVT[i], txtPhu, listVP[i], vtsauBuoc1, vpsauBuoc1, i);
                    }
                }
                txtPhu.Text += "\r\n® Kết quả: F = {";
                for (int p = 0; p < listVTsauBuoc2.Count; p++)
                {
                    if (p == listVTsauBuoc2.Count - 1)
                    {
                        txtPhu.Text += listVTsauBuoc2[p] + "->" + listVPsauBuoc2[p] + "}\r\n";
                        break;
                    }
                    txtPhu.Text += listVTsauBuoc2[p] + "->" + listVPsauBuoc2[p] + ",";
                }




                string[] vtsauBuoc2 = listVTsauBuoc2.ToArray();
                string[] vpsauBuoc2 = listVPsauBuoc2.ToArray();

                txtPhu.Text += "\r\n\r\n◊◊ Bước 3: Loại bỏ các phụ thuộc hàm dư thừa\r\n";
                txtPhu.Text += "\r\nF = {";
                for (int p = 0; p < listVTsauBuoc2.Count; p++)
                {
                    if (p == listVTsauBuoc2.Count - 1)
                    {
                        txtPhu.Text += listVTsauBuoc2[p] + "->" + listVPsauBuoc2[p] + "}\r\n\r\n";
                        break;
                    }
                    txtPhu.Text += listVTsauBuoc2[p] + "->" + listVPsauBuoc2[p] + ",";
                }
                
                LoaiPTHDuThua(txtPhu, vtsauBuoc2, vpsauBuoc2);
            }
        }


        #region Buoc2LoaiTTduthuavetrai
        private void LoaiDuThua(string veTrai, TextBox txtPhu, string vePhai, string[] vtsauBuoc1, string[] vpsauBuoc1, int id)
        {
            for (int i = 0; i < veTrai.Length; i++)
            {
                txtPhu.Text += "• Loại " + veTrai[i] + ":  Ta có (" + PhanTuConLai(veTrai, veTrai[i].ToString()) + ")+  = {" + baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vtsauBuoc1, vpsauBuoc1, vtsauBuoc1.Length) + "}";
                if (solution.Chua(baodong.BD(PhanTuConLai(veTrai, veTrai[i].ToString()), vtsauBuoc1, vpsauBuoc1, vtsauBuoc1.Length), veTrai[i].ToString()) == 1)
                {
                    txtPhu.Text += " chứa " + veTrai[i].ToString() + " => " + veTrai[i].ToString() + " dư thừa\r\n";
                    string tam = veTrai;
                    listVTsauBuoc2.Add(solution.Tru(ref tam, veTrai[i].ToString()));
                    listVPsauBuoc2.Add(vePhai);

                    listVTsauBuoc2.Remove(veTrai);
                    listVPsauBuoc2.Remove(vePhai);

                    txtPhu.Text += "\t=> " + veTrai + "->" + vePhai + " trở thành: " + solution.Tru(ref tam, veTrai[i].ToString()) + "->" + vePhai + "\r\n";
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


        private void LoaiPTHDuThua(TextBox txtPhu, string[] vtsauBuoc2, string[] vpsauBuoc2)
        {
            string[] veTraibandau = listVTsauBuoc2.ToArray();
            string[] vePhaibandau = listVPsauBuoc2.ToArray();

            for (int i = 0; i < listVTsauBuoc2.Count; i++)
            {
                txtPhu.Text += "• Thử loại bỏ " + listVTsauBuoc2[i] + "->" + listVPsauBuoc2[i] + ":\r\n";

                //reset mảng
                vtsauBuoc2 = veTraibandau;
                vpsauBuoc2 = vePhaibandau;

                //doi cho pth dang xet xuong cuoi cung
                for (int j = 0; j < vtsauBuoc2.Length; j++)
                    if (vtsauBuoc2[j] == listVTsauBuoc2[i] && vpsauBuoc2[j] == listVPsauBuoc2[i])
                    {
                        doiChoxuongCuoi(vtsauBuoc2, j);
                        doiChoxuongCuoi(vpsauBuoc2, j);
                    }

                //tính bao đóng phải trừ vị trí cuối cùng ra, đó là PTH đang xét gỡ bỏ
                txtPhu.Text += "\tTa có: (" + listVTsauBuoc2[i] + ")+  = " + baodong.BD(listVTsauBuoc2[i], vtsauBuoc2, vpsauBuoc2, vtsauBuoc2.Length - 1);
                if (solution.Chua(baodong.BD(listVTsauBuoc2[i], vtsauBuoc2, vpsauBuoc2, vtsauBuoc2.Length - 1), listVPsauBuoc2[i]) == 1)
                {
                    txtPhu.Text += " chứa " + listVPsauBuoc2[i] + " nên " + listVTsauBuoc2[i] + "->" + listVPsauBuoc2[i] + " dư thừa\r\n";
                    txtPhu.Text += "\t==> Loại bỏ PTH: " + listVTsauBuoc2[i] + "->" + listVPsauBuoc2[i] + "\r\n\r\n";
                }
                else
                {
                    txtPhu.Text += " không chứa " + listVPsauBuoc2[i] + " nên " + listVTsauBuoc2[i] + "->" + listVPsauBuoc2[i] + " không dư thừa\r\n";
                    txtPhu.Text += "\t==> Không thể loại PTH: " + listVTsauBuoc2[i] + "->" + listVPsauBuoc2[i] + "\r\n\r\n";
                    //add vào kết quả
                    listKQVT.Add(listVTsauBuoc2[i]);
                    listKQVP.Add(listVPsauBuoc2[i]);
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
