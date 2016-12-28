using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class BaoDong
    {
        public BaoDong() { }

        Solution solution = new Solution();

        private string[] mang;
        private int[] stt;

        private List<string> list = new List<string>();
        private List<string> listSX = new List<string>();


        public string BD(string S, string[] VT, string[] VP, int n)
        {
            S = MoRong(S, VT, VP, n);
            while (MoRong(S, VT, VP, n) != S)
                S = MoRong(S, VT, VP, n);

            return solution.BestChoice(S);
        }


        //hàm duyệt bao đóng 1 lần các pth
        private string MoRong(string S, string[] VT, string[] VP, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (solution.Chua(S,VT[i]) == 1)
                    S = solution.Hop(S, VP[i]);
            }
            return solution.BestChoice(S);
        }

        public void ShowBD(TextBox txtU, TextBox txtF, TextBox txtBD, ComboBox cb)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;
            if (txtF.Text == "") txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtBD.Text = "";

            //lấy từ ký tự vào mảng
            mang = new string[t.Length];
            stt = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
                mang[i] = t[i].ToString();
            

            if (solution.check(txtF.Text) == 1)
            {
                txtBD.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n======================= BAO ĐÓNG =======================\r\n\r\n";
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU,txtF);

                Try_VC(0);
                SapXep();

                for (int i = 0; i < listSX.Count; i++)
                {
                    cb.Items.Add(listSX[i]);

                    txtBD.Text += (i + 1) + ".\t  ( " + listSX[i] + " )+  = " + BD(solution.BestChoice(listSX[i]), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) + "\r\n\r\n";
                }
            }
        }

        public void chonComboBox(ComboBox cb, TextBox txtBD, TextBox txtU, TextBox txtF)
        {
            list.Clear();
            listSX.Clear();
            string t = txtU.Text;
            //lấy từ ký tự vào mảng
            mang = new string[t.Length];
            stt = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
                mang[i] = t[i].ToString();

            solution.Trai = "";
            solution.Phai = "";

            int n = 0;
            solution.layData(txtF.Text, ref n, txtU, txtF);

            Try_VC(0);
            SapXep();

            txtBD.Text = "";
            txtBD.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n======================= BAO ĐÓNG =======================\r\n\r\n";

            txtBD.Text += (cb.SelectedIndex + 1) + ".\t  ( " + listSX[cb.SelectedIndex] + " )+  = " + BD(solution.BestChoice(listSX[cb.SelectedIndex]), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) + "\r\n\r\n";
            
        }

        private void SapXep()
        {
            //sắp xếp theo độ dài ký tự
            for (int i = 0; i < listSX.Count; i++)
                for (int j = i + 1; j < listSX.Count; j++)
                    if(listSX[i].Length>=listSX[j].Length)
                    {
                        string temp = listSX[i];
                        listSX[i] = listSX[j];
                        listSX[j] = temp;
                    }
        }


        private void Try_VC(int i)
        {
            for (int j = 0; j <= 1; j++)
            {
                stt[i] = j;
                if (stt[i] == 1)
                    list.Add(mang[i]);
                else list.Remove(mang[i]);
                if (i == mang.Length - 1)
                {
                    if (list.Count != 0)
                    {
                        string test = "";
                        for (int k = 0; k < list.Count; k++)
                            test += list[k];
                        listSX.Add(solution.BestChoice(test));
                    }
                }
                else Try_VC(i + 1);
            }
        }
        

        
        public int TapCon(TextBox txtU,TextBox txtF,TextBox txtBD)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);
            if (txtF.Text == "") txtF.Text += "Ф";
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtBD.Text = "";
            txtBD.Text += "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n======================== TẬP CON ========================\r\n\r\n";
            return (int)Math.Pow(2, txtU.Text.Length);
        }



        public void BDcuaX(TextBox txtU, TextBox txtF, TextBox txtX, TextBox txtBDX)
        {
            string t = txtU.Text;

            //lấy từ ký tự vào mảng
            mang = new string[t.Length];
            stt = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
                mang[i] = t[i].ToString();
            if (solution.check(txtF.Text) == 1)
            {
                txtBDX.Text = "======================== BAO ĐÓNG CỦA X ========================\r\n";
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);

                txtBDX.Text += "\t\t(X)+  =  ("+txtX.Text+")+  =  " + BD(solution.BestChoice(txtX.Text), solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) + "\r\n\r\n";
            }
        }


        public void ktPTHsuydien(TextBox txtU, TextBox txtF, TextBox txtVT,TextBox txtVP, TextBox txtSD)
        {
            string t = txtU.Text;

            //lấy từ ký tự vào mảng
            mang = new string[t.Length];
            stt = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
                mang[i] = t[i].ToString();
            if (solution.check(txtF.Text) == 1)
            {
                txtSD.Text = "======================= PTH SUY DIỄN =======================\r\n";
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);


                string vtPTH = solution.XoaGiong(txtVT.Text);
                string vpPTH = solution.XoaGiong(txtVP.Text);

                if (solution.Chua(BD(vtPTH, solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length), vpPTH) == 1)
                    txtSD.Text += "PTH: " + txtVT.Text + "->" + txtVP.Text + " là phụ thuộc hàm suy diễn được từ lược đồ quan hệ đã cho";
                else txtSD.Text += "PTH: " + txtVT.Text + "->" + txtVP.Text + " là phụ thuộc hàm không thể suy diễn được từ lược đồ quan hệ đã cho";
            }
        }
    }
}
