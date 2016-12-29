using System;
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
        private string[] PTH, VT, VP, phanRaThanhCacBo;

        public string Trai { get { return T; } set { T = value; } }
        public string Phai { get { return P; } set { P = value; } }

        public string[] PhuThuocHam { get { return PTH; } set { PTH = value; } }

        public string[] VeTrai { get { return VT; } set { VT = value; } }

        public string[] VePhai { get { return VP; } set { VP = value; } }

        public string[] PhanRaThanhCacBo { get { return phanRaThanhCacBo; } set { phanRaThanhCacBo = value; } }



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

        public string XoaGiongPR(string s)
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
            return tam;
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

        public int Chua(string A, string B)    //A có chứa B không? -> 1 chứa, 0 là không chứa
        {
            int dem = 0;
            for (int i = 0; i < B.Length; i++)
            {
                if (A.IndexOf(B[i]) != -1)
                    dem++;
            }
            if (dem == B.Length) return 1;
            return 0;
        }

        public int check(string s)
        {
            if (s == "Ф") return 1;
            string tam = "0123456789!@#$%^&*()_+/=|{}[]?<.';:";
            tam.ToCharArray();

            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < tam.Length; j++)
                    if (s[i] == tam[j])
                    {
                        MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }


            int demphay = 0, demmten = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') demphay++;
                if (s[i] == '-') demmten++;

                if (s[i] == '-' && s[i + 1] != '>')
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (i == 0 && (s[i] < 65 || s[i] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (s[i] == ',' && (s[i + 1] < 65 || s[i + 1] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (s[i] == '>' && i != s.Length - 1 && (s[i + 1] < 65 || s[i + 1] > 90))
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                if (i == (s.Length - 1) && s[i] == '>')
                {
                    demphay = 0; demmten = 0;
                    MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }

            if (demmten != demphay + 1)
            {
                MessageBox.Show("Nhập F không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        public void layData(string s, ref int n, TextBox txtU, TextBox txtF)
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
                    VT[i] = XoaGiong(VT[i]);
                    VP[i] = t[i].ToString();
                    VP[i] = XoaGiong(VP[i]);
                    T += t[i].ToString();
                    P += t[i].ToString();
                }
                T = XoaGiong(T);
                P = XoaGiong(P);
                return;
            }

            if (s != "Ф")
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
                    VT[i] = XoaGiong(VT[i]);

                    P += tam[1];
                    VP[i] = tam[1];
                    VP[i] = XoaGiong(VP[i]);
                }
                T = XoaGiong(T);
                P = XoaGiong(P);

                txtF.Text = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == lines.Length - 1)
                    {
                        txtF.Text += VT[i] + "->" + VP[i];
                        break;
                    }
                    txtF.Text += VT[i] + "->" + VP[i] + ",";
                }
            }
        }


        //lấy các bộ phân rã bảo toàn thông tin
        public void layDataForFormPR(string s, TextBox txtPhanRa)
        {
            using (StreamWriter sw = new StreamWriter("testPR.txt"))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ',')
                        sw.WriteLine();
                    else sw.Write(s[i]);
                }
            }

            string[] lines = File.ReadAllLines("testPR.txt");
            phanRaThanhCacBo = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
                phanRaThanhCacBo[i] = XoaGiong(lines[i]);
        }
    }
    

}


