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
        private string T_Giao_P, T, P;
        private string[] PTH, VT, VP; 

        private string[] mang;
        private int[] stt;

        private List<string> list = new List<string>();
        private List<string> listSX = new List<string>();


        public Solution() { }

        #region functions
        private string XoaGiong(string s)
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

        private string BestChoice(string s) //sắp xếp lại theo thứ tự bảng chữ cái
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

        private string Tru(ref string A, string B) //Tập hợp A - Tập hợp B
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

        private string Giao(string A, string B)
        {
            string c = "";
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    if (A[i] == B[j])
                        c += A[i];
            return BestChoice(c);
        }

        private string Hop(string A, string B)
        {
            if (A == "Ф") A = "";
            if (B == "Ф") B = "";
            string C = A;
            Tru(ref C, B); //xóa các phần tử trong A giống B
            return BestChoice(C + B);
        }

        private int Chua(string A, string B)    //A có chứa B không
        {
            int ok = 1;
            for (int i = 0; i < B.Length; i++)
                if (A.IndexOf(B) == -1) ok = 0;
            return ok;
        }

        private int check(string s)
        {
            int demphay = 0, demmten = 0;
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

        private void cat(string s, ref int n)
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

        private string BD(string S, string[] VT, string[] VP, int n)
        {
            S = MoRong(S, VT, VP, n);
            while (MoRong(S, VT, VP, n) != S)
                S = MoRong(S, VT, VP, n);
                
            return BestChoice(S);
        }


 //là hàm bao đóng, nhưng chỉ quét 1 lần lặp
        private string MoRong(string S, string[] VT, string[] VP, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string tam = VT[i];
                int ok = 1;

                //IndexOf() là một phương thức thuộc lớp String(class string) được sử                              dụng để xác định vị trí của một chuỗi trong một chuỗi khác, đầu tiên thôi.
                //S không có trong tam thì ok = 0
                if (S.IndexOf(tam) == -1)
                    ok = 0;
                        
                if (ok != 0)
                    S = Hop(S, VP[i]);
            }
            return BestChoice(S);
        }

        #endregion

        #region Khóa
        public void TimKhoa(TextBox txtU, TextBox txtF, TextBox txtKQ)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = XoaGiong(txtU.Text);

            string t = txtU.Text;
            if (txtF.Text == "")
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (i == t.Length - 1)
                    {
                        txtF.Text += t[i] + "->" + t[i];
                        break;
                    }
                    txtF.Text += t[i] + "->" + t[i] + ",";
                }
            }
            
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKQ.Text = "";


            if (check(txtF.Text) == 1)
            {
                txtKQ.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n\r\n";
                
                T = "";
                P = "";

                int n = 0;
                cat(txtF.Text, ref n);

                T_Giao_P = Giao(T, P);
                txtKQ.Text += "T = " + T + " \r\nP = " + P + " \r\nTP <T Giao P> = " + T_Giao_P + " \r\n\r\n";

                txtKQ.Text+= "\r\n\r\nx x x x x x x x x x x x x x x x x x x x x x x x x x x       TÌM MỘT KHÓA      x x x x x x x x x x x x x x x x x x x x x x x x x x\r\n\r\n";

                string U = txtU.Text;
                string K = Hop(Tru(ref U, P), T_Giao_P);
                txtKQ.Text += "Đặt K = ( U - P ) <Hợp> ( T <Giao> P) = " + K + "\r\n";

                for (int i = 0; i < T_Giao_P.Length; i++)
                {
                    string tam = "", trura, Sosanh;
                    tam += T_Giao_P[i];
                    string thaytheK = K;    //vì trong hàm trừ K sẽ tự động thay đổi làm sai kết quả
                    trura = Tru(ref thaytheK, tam);
                    Sosanh = MoRong(trura, VT, VP, n);
                    txtKQ.Text += " ==> ( K <" + K + "> - " + tam + " )+   = ( " + trura + " )+   = " + Sosanh;

                    if (Sosanh == txtU.Text)
                    {
                        txtKQ.Text += "  = U\r\n\t   => K = K <" + K + "> - " + tam + " = " + trura + "\r\n";
                        K = trura;
                    }
                    else
                        txtKQ.Text += "  != U\r\n";
                }
                txtKQ.Text += "\r\n Vậy K = " + K + " là một khóa của R.\r\n\r\n";


                txtKQ.Text += "\r\n\r\nx x x x x x x x x x x x x x x x x x x x x x x x x       TÌM TẤT CẢ CÁC KHÓA      x x x x x x x x x x x x x x x x x x x x x x x\r\n\r\n";


                List<string> listK = new List<string>();
                string Ki;
                listK.Add(K);
                int tongKhoa = 1;

                txtKQ.Text += "Đặt K* = {" + K + "}";
nhan:
                txtKQ.Text += "\r\n\r\n\r\n====> • XÉT K = " + K;
                for (int i = 0; i < PTH.Length; i++)
                {
                    txtKQ.Text += "\r\n\r\n   + Với " + PTH[i] + ":   " + VT[i] + " <Hợp> ( K - " + VP[i] + " ) = ";
                    string thayK = K;
                    Ki = BestChoice(Hop(VT[i], Tru(ref thayK, VP[i])));

                    txtKQ.Text += Ki;

                    int Chua_K = 0;
                    for (int j = 0; j < listK.Count; j++)
                        if (Chua(Ki, listK[j]) == 1) Chua_K = 1;

                    if (Chua_K == 1)
                        txtKQ.Text += "\t -> Chứa phần tử của K*";
                    else
                    {
                        txtKQ.Text += "\t -> Không chứa phần tử của K*";
                        txtKQ.Text += "\r\n\t     Đặt K' = " + Ki;

                        int ok = 1;
                        for (int j = 0; j < Ki.Length; j++)
                        {
                            string tam = "",trura;
                            tam += Ki[j];
                            txtKQ.Text += "\r\n\t     + ( K' - " + tam;
                            string thaytheKi = Ki;
                            trura = Tru(ref thaytheKi, tam);
                            tam = MoRong(trura, VT, VP, n);

                            txtKQ.Text += " )+ = (" + trura + ")+ = " + tam;
                            if (tam != txtU.Text)
                                txtKQ.Text += "  != U";
                            else
                            {
                                txtKQ.Text += "  = U";
                                ok = 0;
                            }
                        }
                        if (ok == 0)
                            txtKQ.Text += "\r\n\t     Vậy K' = " + Ki + " không phải là khóa.\r\n";
                        else
                        {
                            txtKQ.Text += "\r\n\t     Vậy K' = " + Ki + " là khóa.";
                            listK.Add(Ki);
                        }
                    }
                }

                if (tongKhoa < listK.Count)
                {
                    K = listK[tongKhoa];
                    tongKhoa++;
                    goto nhan;
                }
                
                //loại bỏ siêu khóa
                int[] status = new int[listK.Count];
                for (int i = 0; i < listK.Count; i++)
                    for (int j = 0; j < listK.Count; j++)
                    {
                        if (Chua(listK[i], listK[j]) == 1 && i != j)
                            status[i] = 1;
                    }
                
                int test = 0;
                txtKQ.Text += "\r\n\r\n\r\n\r\nx x x x x x x x x x x x x x x x x x x x x x x x x x x x          KẾT LUẬN         x x x x x x x x x x x x x x x x x x x x x x x x x x\r\n\r\n";
                txtKQ.Text += "\r\n\r\n  ◊  Tập các khóa của R là:  K* = {";
                for (int i = 0; i < listK.Count; i++)
                {
                    if (status[i] != 1)
                    {
                        if (test != 0) txtKQ.Text += ", ";
                        txtKQ.Text += listK[i];
                        test = 1;
                    }
                }
                txtKQ.Text += "}";
            }
        }

        #endregion

        #region BaoĐóng
        public void BaoDong(TextBox txtU, TextBox txtF, TextBox txtBD)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = XoaGiong(txtU.Text);
            
            string t = txtU.Text;
            if (txtF.Text == "")
                for (int i = 0; i < t.Length; i++)
                {
                    if (i == t.Length - 1)
                    {
                        txtF.Text += t[i] + "->" + t[i];
                        break;
                    }
                    txtF.Text += t[i] + "->" + t[i] + ",";
                }

            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtBD.Text = "";


            mang = new string[t.Length];
            stt = new int[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                if (i == t.Length - 1)
                {
                    mang[i] = t[i].ToString();
                    break;
                }
                mang[i] = t[i].ToString();
            }
            

            if (check(txtF.Text) == 1)
            {
                T = "";
                P = "";

                int n = 0;
                cat(txtF.Text, ref n);

                Try_VC(0, txtBD);

                //sắp xếp theo thứ tự A,B,C
                for (int i = 0; i < listSX.Count; i++)
                    for (int j = i + 1; j < listSX.Count; j++)
                        if (ChuyenKTthanhSo(listSX[i]) >= ChuyenKTthanhSo(listSX[j]))
                        {
                            string temp = listSX[i];
                            listSX[i] = listSX[j];
                            listSX[j] = temp;
                        }


                for (int i = 0; i < listSX.Count; i++)
                    txtBD.Text += (i + 1) + ".\t  ( " + listSX[i] + " )+  = " + BD(BestChoice(listSX[i]), VT, VP, PTH.Length) + "\r\n\r\n";
            }

        }
        
        private int ChuyenKTthanhSo(string s)
        {
            int tong = 0;
            for (int i = 0; i < s.Length; i++)
                tong += (int)s[i];
            return tong;
        }

        private void Try_VC(int i,TextBox txtBD)
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
                        listSX.Add(BestChoice(test));
                    }
                }
                else Try_VC(i + 1, txtBD);
            }

        }

        #endregion


    }
}

