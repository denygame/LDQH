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
        

        Solution solution = new Solution();
        BaoDong baodong = new BaoDong();

        public TimKhoa() { }



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
                solution.layData(txtF.Text, ref n, txtU);

                string tam = txtU.Text;
                //Tập thuộc tính nguồn (TN) : bao gồm các thuộc tính chỉ xuất hiện ở vế trái, không xuất hiện ở vế phải của F( tập phụ thuộc hàm) và các thuộc tính không xuất hiện ở cả vế trái và vế phải của F. <U-P>
                string TN = solution.Tru(ref tam, solution.Phai);           
                string TG = solution.Giao(solution.Trai, solution.Phai);    //Tập trung gian <Trái Phải>

                txtKhoa.Text += "◊◊ Bước 1: Từ các PTH, tìm TN <U-P>, TG <T Giao P> \r\n";
                txtKhoa.Text += "\tTập thuộc tính nguồn: TN = " + TN + "\r\n" + "\tTập thuộc tính trung gian: TG = " + TG + "\r\n\r\n";

                txtKhoa.Text += "◊◊ Bước 2: Kiểm tra tập thuộc tính nguồn TN \r\n";
                if (TG == "Ф")
                    txtKhoa.Text += "\tTG rỗng => "+"Lược đồ quan hệ chỉ có một khóa: K = TN =" + TN;
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

                    //string s = "AB";
                    //txtKhoa.Text += solution.Tru(ref s, "ABC");
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
            {
                if (i == TG.Length - 1)
                {
                    mang[i] = TG[i].ToString();
                    break;
                }
                mang[i] = TG[i].ToString();
            }
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
            //xóa không phải siêu khóa
            for (int i = 0; i < TapConTg.Count; i++)
                if (mangxoa[i] == 1) TapConTg.Remove(TapConTg[i]);

            //in ra
            txtKhoa.Text += "\r\n==> Vậy, tập các siêu khóa là: S = { ";
            for (int i = 0; i < TapConTg.Count; i++)
            {
                if (i == TapConTg.Count - 1) { txtKhoa.Text += TapConTg[i] + " }\r\n\r\n"; break; }
                txtKhoa.Text += TapConTg[i] + ", ";
            }
        }

        private void LoaiBoSieuKhoa(TextBox txtKhoa)
        {
            //sắp xếp theo độ dài ký tự
            for (int i = 0; i < TapConTg.Count; i++)
                for (int j = i + 1; j < TapConTg.Count; j++)
                    if (TapConTg[i].Length >= TapConTg[j].Length)
                    {
                        string temp = TapConTg[i];
                        TapConTg[i] = TapConTg[j];
                        TapConTg[j] = temp;
                    }

            del();
            txtKhoa.Text += "\r\n==> Vậy, tập các khóa của lược đồ là: K = { ";
            for (int i = 0; i < TapConTg.Count; i++)
            {
                if (i == TapConTg.Count - 1) { txtKhoa.Text += TapConTg[i] + " }\r\n\r\n"; break; }
                txtKhoa.Text += TapConTg[i] + ", ";
            }

        }



        /// <summary>
        /// xem lại
        /// </summary>
        private void del()    
        {
            int[] mangxoa = new int[TapConTg.Count];
            for (int i = 0; i < TapConTg.Count; i++)
                for (int j = 0; j < TapConTg.Count; j++)
                {
                    string s = TapConTg[i];
                    if (solution.Tru(ref s, TapConTg[j]) == "Ф")
                        mangxoa[j] = 1;
                }

            for (int i = 0; i < TapConTg.Count; i++)
                if (mangxoa[i] == 1) TapConTg.Remove(TapConTg[i]);
        }
        
    }
}
