using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class TimKhoa
    {
        private string[] mang;
        private int[] stt;
        private List<string> list = new List<string>();
        private List<string> TapConTg = new List<string>();
        private List<string> listSieuKhoa = new List<string>();
        private List<string> listKhoa = new List<string>();

        Solution solution = new Solution();
        BaoDong baodong = new BaoDong();

        public TimKhoa() { }


        #region TìmMọiKhóa
        public void TimMoiKhoa(TextBox txtU, TextBox txtF, TextBox txtKhoa)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;
            
            if(txtF.Text=="")  txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKhoa.Text = "";


            if (solution.check(txtF.Text) == 1)
            {
                txtKhoa.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n======================== MỌI KHÓA =======================\r\n\r\n";

                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU,txtF);

                string tam = txtU.Text;
                //Tập thuộc tính nguồn (TN) : bao gồm các thuộc tính chỉ xuất hiện ở vế trái, không xuất hiện ở vế phải của F( tập phụ thuộc hàm) và các thuộc tính không xuất hiện ở cả vế trái và vế phải của F. <U-P>
                string TN = solution.Tru(ref tam, solution.Phai);           
                string TG = solution.Giao(solution.Trai, solution.Phai);    //Tập trung gian <Trái Phải>

                txtKhoa.Text += "◊◊ Bước 1: Từ các PTH, tìm TN <U-P>, TG <T Giao P> \r\n";
                txtKhoa.Text += "\tTập thuộc tính nguồn: TN = " + TN + "\r\n" + "\tTập thuộc tính trung gian: TG = " + TG + "\r\n\r\n";

                txtKhoa.Text += "◊◊ Bước 2: Kiểm tra tập thuộc tính nguồn TN \r\n";
                if (TG == "Ф")
                    txtKhoa.Text += "\tTG rỗng => "+"Lược đồ quan hệ chỉ có một khóa: K = TN = " + TN;
                else
                {
                    txtKhoa.Text += "\tTG không rỗng. Thực hiện bước 3\r\n\r\n";
                    txtKhoa.Text += "◊◊ Bước 3:  Tìm tất cả các tập con Xi của tập trung gian TG <kể cả tập rỗng>\r\n";

                    SinhTapConTG(TG);

                    txtKhoa.Text += "\tCác tập con tìm được: X = { ";
                    for(int i=0;i<TapConTg.Count;i++)
                    {
                        if (i == TapConTg.Count - 1) { txtKhoa.Text += TapConTg[i] + " }\r\n\r\n"; break; }
                        txtKhoa.Text += TapConTg[i] + ", ";
                    }

                    txtKhoa.Text += "◊◊ Bước 4:  Tìm các siêu khóa Si từ tập con Xi với TN bằng cách tính bao đóng\r\n";
                    TimSieuKhoa(TN, txtKhoa, txtU);

                    txtKhoa.Text += "◊◊ Bước 5:  Tìm khóa bằng cách loại bỏ các siêu khóa không tối thiểu\r\n";
                    LoaiBoSieuKhoa(txtKhoa);
                }

            }
        }
        

        #region B3SinhTapConTG
        private void SinhTapConTG(string TG)
        {
            //lấy từ ký tự vào mảng
            mang = new string[TG.Length];
            stt = new int[TG.Length];

            for (int i = 0; i < TG.Length; i++)
                mang[i] = TG[i].ToString();

            Try_VC(0);
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
                        TapConTg.Add(solution.BestChoice(test));
                    }
                    if (list.Count == 0)
                        TapConTg.Add("Ф");
                }
                else Try_VC(i + 1);
            }
        }
        #endregion

        #region B4B5SieuKhoaVaKhoa
        private void TimSieuKhoa(string TN, TextBox txtKhoa,TextBox txtU)
        {
            //hợp lại
            for (int i = 0; i < TapConTg.Count; i++)
                TapConTg[i] = solution.Hop(TapConTg[i], TN);
            txtKhoa.Text += "\t• (Xi ∪ TN) = { ";
            for (int i = 0; i < TapConTg.Count; i++)
            {
                if (i == TapConTg.Count - 1) { txtKhoa.Text += TapConTg[i] + " }\r\n\r\n"; break; }
                txtKhoa.Text += TapConTg[i] + ", ";
            }
            
            //tìm bao đóng
            int[] mangxoa = new int[TapConTg.Count];
            
            txtKhoa.Text += "\t=> Tìm bao đóng:\r\n\r\n";
            for (int i = 0; i < TapConTg.Count; i++)
            {
                txtKhoa.Text += "\t+Bao đóng của { " + TapConTg[i] + " } là: ( " + TapConTg[i] + " )+  = " + baodong.BD(TapConTg[i], solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length);
                

                if (baodong.BD(TapConTg[i], solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) == txtU.Text)
                    txtKhoa.Text += " => là siêu khóa\r\n";
                else
                {
                    txtKhoa.Text += " => không là siêu khóa, xóa khỏi danh sách\r\n";
                    mangxoa[i] = 1;
                }
            }
            
            //xóa không phải siêu khóa -> add vào lishSieuKhoa
            for (int i = 0; i < TapConTg.Count; i++)
                if (mangxoa[i] == 0)
                    listSieuKhoa.Add(TapConTg[i]);
            
            //in ra
            txtKhoa.Text += "\r\n==> Vậy, tập các siêu khóa là: S = { ";
            for (int i = 0; i < listSieuKhoa.Count; i++)
            {
                if (i == listSieuKhoa.Count - 1) { txtKhoa.Text += listSieuKhoa[i] + " }\r\n\r\n"; break; }
                txtKhoa.Text += listSieuKhoa[i] + ", ";
            }
        }



        private void LoaiBoSieuKhoa(TextBox txtKhoa)
        {
            //sắp xếp theo độ dài ký tự
            for (int i = 0; i < listSieuKhoa.Count; i++)
                for (int j = i + 1; j < listSieuKhoa.Count; j++)
                    if (listSieuKhoa[i].Length >= listSieuKhoa[j].Length)
                    {
                        string temp = listSieuKhoa[i];
                        listSieuKhoa[i] = listSieuKhoa[j];
                        listSieuKhoa[j] = temp;
                    }

            del();
            txtKhoa.Text += "\r\n==> Vậy, tập các khóa của lược đồ là: K = { ";
            for (int i = 0; i < listKhoa.Count; i++)
            {
                if (i == listKhoa.Count - 1) { txtKhoa.Text += listKhoa[i] + " }\r\n\r\n"; break; }
                txtKhoa.Text += listKhoa[i] + ", ";
            }

        }
        
        private void del()    
        {
            int[] mangxoa = new int[listSieuKhoa.Count];
            for (int i = 0; i < listSieuKhoa.Count; i++)
                for (int j = i + 1; j < listSieuKhoa.Count; j++)
                {
                    string s = listSieuKhoa[i];
                    if (solution.Tru(ref s, listSieuKhoa[j]) == "Ф")
                        mangxoa[j] = 1;
                }


            for (int i = 0; i < listSieuKhoa.Count; i++)
                if (mangxoa[i] == 0)
                    listKhoa.Add(listSieuKhoa[i]);
        }
        #endregion

        #endregion


        public void Tim1Khoa(TextBox txtU, TextBox txtF, TextBox txtKhoa)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiong(txtU.Text);

            string t = txtU.Text;

            if (txtF.Text == "") txtF.Text += "Ф";


            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");
            txtKhoa.Text = "";

            if (solution.check(txtF.Text) == 1)
            {
                txtKhoa.Text = "R = <U, F>\r\nU = " + txtU.Text + "\r\nF = { " + txtF.Text + " }\r\n======================== MỘT KHÓA =======================\r\n\r\n";

                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU,txtF);

                string K = txtU.Text;
                string tam = K;
                char[] mangKyTu = K.ToCharArray(0, K.Length);

                txtKhoa.Text += "◊◊ Bước 1: K = U = " + K + " \r\n\r\n";
                
                for(int i=0;i<mangKyTu.Length;i++)
                {
                    string k = solution.Tru(ref tam, mangKyTu[i].ToString());
                    txtKhoa.Text += "◊◊ Bước " + (i + 2) + ": ( K - " + mangKyTu[i] + " )+  = " + " ( " + k + " )+  =  " + baodong.BD(k, solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length);
                    if (baodong.BD(k, solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) == txtU.Text)
                    {
                        K = solution.Tru(ref K, mangKyTu[i].ToString());
                        txtKhoa.Text += " = U, loại " + mangKyTu[i] + " ra khỏi K => K = " + K + "\r\n";
                    }
                    else txtKhoa.Text += "  != U => K = " + K + "\r\n";
                    tam = K;
                }
                txtKhoa.Text += "\r\n\r\nVậy, một khóa của lược đồ quan hệ là: K = " + K;
            }
        }



   //hàm này add khóa vào list trong khi gọi, dùng cho bên dạng chuẩn
        public void GuiTapKhoaChoDC(TextBox txtU, TextBox txtF,List<string> listLayquaDC)
        {
            string t = txtU.Text;
            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";

                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);

                string tam = txtU.Text;
                string TN = solution.Tru(ref tam, solution.Phai);
                string TG = solution.Giao(solution.Trai, solution.Phai);

                if (TG == "Ф")
                {
                    listLayquaDC.Add(TN);
                    return;
                }
                else
                {
                    SinhTapConTG(TG);
                    
   //TimSieuKhoa(TN, txtKhoa, txtU);
                    for (int i = 0; i < TapConTg.Count; i++)
                        TapConTg[i] = solution.Hop(TapConTg[i], TN);
                    int[] mangxoa = new int[TapConTg.Count];


                    for (int i = 0; i < TapConTg.Count; i++)
                    {
                        if (baodong.BD(TapConTg[i], solution.VeTrai, solution.VePhai, solution.PhuThuocHam.Length) == txtU.Text)
                            mangxoa[i] = 0;
                        else mangxoa[i] = 1;
                    }

                    //xóa không phải siêu khóa -> add vào listSieuKhoa
                    for (int i = 0; i < TapConTg.Count; i++)
                        if (mangxoa[i] == 0)
                            listSieuKhoa.Add(TapConTg[i]);


    //LoaiBoSieuKhoa(txtKhoa);
                    //sắp xếp theo độ dài ký tự
                    for (int i = 0; i < listSieuKhoa.Count; i++)
                        for (int j = i + 1; j < listSieuKhoa.Count; j++)
                            if (listSieuKhoa[i].Length >= listSieuKhoa[j].Length)
                            {
                                string temp = listSieuKhoa[i];
                                listSieuKhoa[i] = listSieuKhoa[j];
                                listSieuKhoa[j] = temp;
                            }

               //del()     
                    int[] mangxoa1 = new int[listSieuKhoa.Count];
                    for (int i = 0; i < listSieuKhoa.Count; i++)
                        for (int j = i + 1; j < listSieuKhoa.Count; j++)
                        {
                            string s = listSieuKhoa[i];
                            if (solution.Tru(ref s, listSieuKhoa[j]) == "Ф")
                                mangxoa1[j] = 1;
                        }
                    for (int i = 0; i < listSieuKhoa.Count; i++)
                        if (mangxoa1[i] == 0)
                            listLayquaDC.Add(listSieuKhoa[i]);


                }


            }






        }

    }
}
