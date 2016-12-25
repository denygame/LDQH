﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KhoaLDQH
{
    class Solution
    {
        private string T, P;
        private string[] PTH, VT, VP;

        public string Trai { get { return T; } set { T = value; } }
        public string Phai { get { return P; } set { P = value; } }

        public string[] PhuThuocHam { get { return PTH; } set { PTH = value; } }

        public string[] VeTrai { get { return VT; } set { VT = value; } }

        public string[] VePhai { get { return VP; } set { VP = value; } }



        public Solution() { }

    
        public string XoaGiong(string s)
        {
            string tam = "";
            for (int i = 0; i < s.Length; i++)
            {
                int dem = 0;
                if (i == 0) tam += s[i];
                else
                {
                    for (int j = 0; j < tam.Length; j++)
                        if (tam[j] == s[i])
                            dem++;
                    if (dem == 0) tam += s[i];
                }
            }
            return BestChoice(tam);
        }

        public string BestChoice(string s) //sắp xếp lại theo thứ tự bảng chữ cái
        {
            char[] arr1;
            arr1 = s.ToCharArray(0, s.Length);

            for (int i = 0; i < s.Length - 1; i++)
                for (int j = i + 1; j < s.Length; j++)
                    if (arr1[i] > arr1[j])
                    {
                        char tam = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = tam;
                    }
            s = "";
            for (int i = 0; i < arr1.Length; i++)
                s = s + arr1[i];

            if (s == "") s = "Ф";
            return s;
        }

        public string Tru(ref string A, string B) //Tập hợp A - Tập hợp B
        {
            for (int i = 0; i < A.Length; i++)
            {
                int j = 0;
                while (j < B.Length)
                {
                    if (i >= A.Length) return BestChoice(A);
                    if (A[i] == B[j])
                        A = A.Remove(i, 1);
                    else j++;
                }
            }
            return BestChoice(A);
        }

        public string Giao(string A, string B)
        {
            string c = "";
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    if (A[i] == B[j])
                        c += A[i];
            return BestChoice(c);
        }

        public string Hop(string A, string B)
        {
            if (A == "Ф") A = "";
            if (B == "Ф") B = "";
            string C = A;
            Tru(ref C, B); //xóa các phần tử trong A giống B
            return BestChoice(C + B);
        }

        public int Chua(string A, string B)    //A có chứa B không
        {
            int ok = 1;
            if (A.IndexOf(B) == -1) ok = 0;
            return ok;
        }

        public int check(string s)
        {
            int demphay = 0, demmten = 0;

            if (s == "Ф") return 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') demphay++;
                if (s[i] == '-') demmten++;

                if (s[i] == '-' && s[i + 1] != '>')
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (i == 0 && (s[i] < 65 || s[i] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Giá trị của F nhập sai!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (s[i] == ',' && (s[i + 1] < 65 || s[i + 1] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Giá trị của F nhập sai!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (s[i] == '>' && i != s.Length - 1 && (s[i + 1] < 65 || s[i + 1] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Giá trị của F nhập sai!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (i == (s.Length - 1) && s[i] == '>')
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Giá trị của F nhập sai!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }

            if (demmten != demphay + 1)
            {
                MessageBox.Show("Chưa nhập chính xác phụ thuộc hàm!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        public void layData(string s, ref int n,TextBox txtU)
        {
            if (s == "Ф")
            {
                s = s.Replace("Ф", "");
                string t = txtU.Text;
                VT = new string[t.Length];
                VP = new string[t.Length];
                PTH = new string[t.Length];

                for (int i = 0; i < t.Length; i++)
                {
                    VT[i] = t[i].ToString();
                    VP[i] = t[i].ToString();
                }
                return;
            }

            else
            {
                using (StreamWriter sw = new StreamWriter("test.txt"))
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ',')
                            sw.WriteLine();
                        else sw.Write(s[i]);
                    }
                }

                string[] lines = File.ReadAllLines("test.txt");
                VT = new string[lines.Length];
                VP = new string[lines.Length];
                PTH = new string[lines.Length];
                n = lines.Length;

                for (int i = 0; i < lines.Length; i++)
                    PTH[i] = lines[i];


                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tam = lines[i].Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                    T += tam[0];
                    VT[i] = tam[0];

                    P += tam[1];
                    VP[i] = tam[1];
                }
                T = XoaGiong(T);
                P = XoaGiong(P);
            }
        }

        


    }
}

