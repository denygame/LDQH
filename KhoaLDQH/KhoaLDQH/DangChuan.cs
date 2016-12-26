﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class DangChuan
    {
        Solution solution = new Solution();
        BaoDong baodong = new BaoDong();
        TimKhoa timkhoa = new TimKhoa();

        List<string> ListTatCaKhoa = new List<string>();
        private int[] stt;
        private string[] mang;
        private List<string> list = new List<string>();
        private List<string> tapcon = new List<string>();

        private List<string> listVT;
        private List<string> listVP;

        public DangChuan() { }

        public void XacdinhChuan2(TextBox txtDC, TextBox txtU, TextBox txtF)
        {
            ListTatCaKhoa.Clear();
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtDC.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);


                timkhoa.GuiTapKhoaChoDC(txtU, txtF, ListTatCaKhoa);

                txtDC.Text += "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n====================== DẠNG CHUẨN 2 =====================\r\n\r\n";
                txtDC.Text += "◊◊ Bước 1: Tìm tất cả khóa của lược đồ\r\n";
                for (int i = 0; i < ListTatCaKhoa.Count; i++)
                    txtDC.Text += ListTatCaKhoa[i] + "\r\n";

                txtDC.Text += "\r\n\r\n◊◊ Bước 2: Với mỗi khóa K, tìm bao đóng của tất cả tập con thật sự S của K. Nếu có bao đóng S + chứa thuộc tính không khóa thì lược đồ không đạt chuẩn 2. Ngược lại thì lược đồ đạt chuẩn 2\r\n";

                string KhongKhoa = thuocTinhKhongKhoa(txtU);

                txtDC.Text += "\r\nThuộc tính không khóa là: {";
                if (KhongKhoa == "")
                    txtDC.Text += "Ф}\r\n\r\n";
                else
                {
                    for (int i = 0; i < KhongKhoa.Length; i++)
                    {
                        if (i == KhongKhoa.Length - 1)
                        {
                            txtDC.Text += KhongKhoa[i] + "}\r\n\r\n";
                            break;
                        }
                        txtDC.Text += KhongKhoa[i] + ",";
                    }
                }


                if (KhongKhoa == "")
                {
                    txtDC.Text += "\r\n==> Tập thuộc tính không khóa là rỗng nên lược đồ đạt chuẩn 2";
                    return;
                }
                else
                {

                    for (int i = 0; i < ListTatCaKhoa.Count; i++)
                    {
                        list.Clear();
                        tapcon.Clear();

                        //lấy từ ký tự vào mảng
                        mang = new string[ListTatCaKhoa[i].Length];
                        stt = new int[ListTatCaKhoa[i].Length];

                        for (int m = 0; m < ListTatCaKhoa[i].Length; m++)
                        {
                            if (m == ListTatCaKhoa[i].Length - 1)
                            {
                                mang[m] = ListTatCaKhoa[i][m].ToString();
                                break;
                            }
                            mang[m] = ListTatCaKhoa[i][m].ToString();
                        }

                        Try_VC(0);

                        for (int j = 0; j < tapcon.Count; j++)
                            for (int k = 0; k < KhongKhoa.Length; k++)
                                if (solution.Chua(baodong.BD(tapcon[j], solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length), KhongKhoa[k].ToString()) == 1)
                                {
                                    txtDC.Text += "\r\n==> Lược đồ không đạt chuẩn 2";
                                    return;
                                }
                    }
                    txtDC.Text += "\r\n==> Lược đồ đạt chuẩn 2";
                }
            }

        }


        //sinh tập con thực sự khác rỗng
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
                    if (list.Count != 0 && list.Count != mang.Length)
                    {
                        string test = "";
                        for (int k = 0; k < list.Count; k++)
                            test += list[k];
                        tapcon.Add(solution.BestChoice(test));
                    }
                }
                else Try_VC(i + 1);
            }
        }


        private string thuocTinhKhongKhoa(TextBox txtU)
        {
            string U = txtU.Text;
            for (int i = 0; i < ListTatCaKhoa.Count; i++)
                solution.Tru(ref U, ListTatCaKhoa[i]);
            return U;
        }




        private string thuocTinhKhoa()
        {
            string s = "";
            for (int i = 0; i < ListTatCaKhoa.Count; i++)
                s += ListTatCaKhoa[i];
            return solution.XoaGiong(s);
        }

        public void XacdinhChuan3(TextBox txtDC, TextBox txtU, TextBox txtF)
        {
            ListTatCaKhoa.Clear();
            listVP = new List<string>();
            listVT = new List<string>();

            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";
            
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtDC.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);
                
                timkhoa.GuiTapKhoaChoDC(txtU, txtF, ListTatCaKhoa);

                txtDC.Text += "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n====================== DẠNG CHUẨN 3 =====================\r\n\r\n";
                txtDC.Text += "◊◊ Bước 1: Tìm tất cả khóa của lược đồ\r\n";
                for (int i = 0; i < ListTatCaKhoa.Count; i++)
                    txtDC.Text += ListTatCaKhoa[i] + "\r\n";

                txtDC.Text += "\r\n\r\n◊◊ Bước 2: Từ F tạo F' có vế phải một thuộc tính đơn lẻ\r\n";
                ///xem
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
                txtDC.Text += "=> F' = {";
                for (int i = 0; i < listVP.Count; i++)
                {
                    if (i == listVP.Count - 1)
                    {
                        txtDC.Text += listVT[i] + "->" + listVP[i] + "}\r\n\r\n";
                        break;
                    }
                    txtDC.Text += listVT[i] + "->" + listVP[i] + ",";
                }

                txtDC.Text += "\r\n\r\n◊◊ Bước 3: Nếu mọi phụ thuộc hàm X -> A thuộc F' đều có X là siêu khóa hoặc A là thuộc tính khoá thì Q đạt chuẩn 3 ngược lại Q không đạt chuẩn 3\r\n";

                string ttKhoa = thuocTinhKhoa();
                
                int dem = 0;

                for (int i = 0; i < listVT.Count; i++)
                    if (solution.Chua(ttKhoa, listVP[i]) == 0)
                        for (int j = 0; j < ListTatCaKhoa.Count; j++)
                        {
                            if (solution.Chua(listVT[i], ListTatCaKhoa[j]) == 1)
                                dem++;
                        }
                    else dem++;
                       

                if(dem==listVP.Count)
                    txtDC.Text += "\r\n==> Lược đồ đạt chuẩn 3";
                else
                    txtDC.Text += "\r\n==> Lược đồ không đạt chuẩn 3";
            }




        }


        public void XacdinhChuanBC(TextBox txtDC, TextBox txtU, TextBox txtF)
        {
            ListTatCaKhoa.Clear();
            listVP = new List<string>();
            listVT = new List<string>();

            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";

            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtDC.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);

                timkhoa.GuiTapKhoaChoDC(txtU, txtF, ListTatCaKhoa);

                txtDC.Text += "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n===================== DẠNG CHUẨN BC =====================\r\n\r\n";
                txtDC.Text += "◊◊ Bước 1: Tìm tất cả khóa của lược đồ\r\n";
                for (int i = 0; i < ListTatCaKhoa.Count; i++)
                    txtDC.Text += ListTatCaKhoa[i] + "\r\n";

                txtDC.Text += "\r\n\r\n◊◊ Bước 2: Từ F tạo F' có vế phải một thuộc tính đơn lẻ\r\n";
                ///xem
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
                txtDC.Text += "=> F' = {";
                for (int i = 0; i < listVP.Count; i++)
                {
                    if (i == listVP.Count - 1)
                    {
                        txtDC.Text += listVT[i] + "->" + listVP[i] + "}\r\n\r\n";
                        break;
                    }
                    txtDC.Text += listVT[i] + "->" + listVP[i] + ",";
                }

                txtDC.Text += "\r\n\r\n◊◊ Bước 3: Nếu mọi phụ thuộc hàm X -> A thuộc F' (Chú ý: với A không thuộc X) đều có X là siêu khóa thì Q đạt chuẩn BC ngược lại Q không đạt chuẩn BC\r\n";

                int dem = 0;

                for (int i = 0; i < listVP.Count; i++)
                    if (solution.Chua(listVT[i], listVP[i]) == 0)
                        for (int j = 0; j < ListTatCaKhoa.Count; j++)
                            if (solution.Chua(listVT[i], ListTatCaKhoa[j]) == 1)
                                dem++;

                if(dem==listVP.Count)
                    txtDC.Text += "\r\n==> Lược đồ đạt chuẩn BC";
                else
                    txtDC.Text += "\r\n==> Lược đồ không đạt chuẩn BC";

            }
        }


            }




}