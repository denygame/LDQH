using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoaLDQH
{
    class PhanRa
    {
        Solution solution = new Solution();
        private int[,] mangDien_ab;  //mảng điền ab
        private string[] mangThuocTinh, mangPhanRa;
        private List<int> toHop2bo = new List<int>();
        private int[] mang;

        public void PhanRaKhongMatTin(TextBox txtU, TextBox txtF, TextBox txtPhanRa, TextBox txtShow)
        {
            txtU.Text = txtU.Text.ToUpper().Replace(" ", "");
            txtU.Text = solution.XoaGiongPR(txtU.Text);
            string t = txtU.Text;
            if (txtF.Text == "") txtF.Text += "Ф";
            txtF.Text = txtF.Text.ToUpper().Replace(" ", "");


            string tam = "0123456789!@#$%^&*()_+/=|{}[]?>-<.';:";
            tam.ToCharArray();
            string s = txtPhanRa.Text;
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < tam.Length; j++)
                    if (s[i] == tam[j])
                    {
                        MessageBox.Show("Nhập p không đúng định dạng!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

            txtPhanRa.Text = txtPhanRa.Text.ToUpper().Replace(" ", "");
            if (txtPhanRa.Text == "")
            {
                MessageBox.Show("Bắt buộc phải nhập các bộ cần phân rã!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtShow.Text = "";


            if (solution.check(txtF.Text) == 1)
            {
                solution.Trai = "";
                solution.Phai = "";
                int n = 0;
                solution.layData(txtF.Text, ref n, txtU, txtF);
                solution.layDataForFormPR(txtPhanRa.Text, txtPhanRa);


                mangThuocTinh = new string[txtU.Text.Length];
                for (int i = 0; i < txtU.Text.Length; i++)
                    mangThuocTinh[i] = txtU.Text[i].ToString();

                mangPhanRa = new string[solution.PhanRaThanhCacBo.Length];
                mangPhanRa = solution.PhanRaThanhCacBo;

                mangDien_ab = new int[mangPhanRa.Length, mangThuocTinh.Length];  //dòng trước cột sau

                //khởi tạo a,b
                for (int i = 0; i < mangPhanRa.Length; i++)
                    for (int j = 0; j < mangThuocTinh.Length; j++)
                    {
                        if (solution.Chua(mangPhanRa[i], mangThuocTinh[j]) == 1)
                            mangDien_ab[i, j] = 1;      //mục tiêu là 1 dòng = 1
                        else mangDien_ab[i, j] = 0;
                    }

                for(int i=0; i<mangThuocTinh.Length;i++)
                    txtShow.Text += mangThuocTinh[i] + "  ";
                txtShow.Text += "\r\n";
                for (int i = 0; i < mangPhanRa.Length; i++)
                {
                    for (int j = 0; j < mangThuocTinh.Length; j++)
                    {
                        txtShow.Text += mangDien_ab[i, j] + "   ";
                        if (j == mangThuocTinh.Length - 1) txtShow.Text += "  " + mangPhanRa[i];
                    }
                    txtShow.Text += "\r\n";
                }



                if (mangPhanRa.Length == 1)
                {
                    for (int i = 0; i < mangPhanRa.Length; i++)
                        for (int j = 0; j < mangThuocTinh.Length; j++)
                            if (mangDien_ab[i, j] == 0)
                            {
                                txtShow.Text += "Không bảo toàn thông tin";
                                return;
                            }
                            else
                            {
                                txtShow.Text += "Bảo toàn thông tin";
                                return;
                            }
                }
                else
                {
                    mang = new int[mangPhanRa.Length];
                    for (int i = 0; i < mangPhanRa.Length; i++)
                        mang[i] = i;


                    //tất cả tổ hợp chập 2 <2 dòng> của các dòng
                    ToHop(); 

                    List<int> listchuaVitriVT = new List<int>();
                    List<int> listchuaVitriVP = new List<int>();

                    nhan:   //nhãn để quay lại khi còn thay đổi được
                    for (int a = 0; a < solution.PhuThuocHam.Length; a++)
                    {
                        listchuaVitriVT.Clear();
                        listchuaVitriVP.Clear();
                        string vt = solution.VeTrai[a];
                        string vp = solution.VePhai[a];
                        
                        for (int i = 0; i < mangThuocTinh.Length; i++)                  //cột
                            if (solution.Chua(vt, mangThuocTinh[i]) == 1)
                                listchuaVitriVT.Add(i);
                        
                        for (int i = 0; i < mangThuocTinh.Length; i++)
                            if (solution.Chua(vp, mangThuocTinh[i]) == 1)
                                listchuaVitriVP.Add(i);
                        

                        for (int cot = 0; cot < listchuaVitriVT.Count; cot++)
                        {
                            for (int dong = 0; dong < toHop2bo.Count; dong = dong + 2)
                                if (mangDien_ab[toHop2bo[dong], listchuaVitriVT[cot]] == mangDien_ab[toHop2bo[dong + 1],listchuaVitriVT[cot]])
                                {
                                    int dem = 0;
                                    for (int test = 0; test < listchuaVitriVT.Count; test++)
                                        if (listchuaVitriVT[test] != listchuaVitriVT[cot])
                                            if (mangDien_ab[toHop2bo[dong],listchuaVitriVT[test]] == mangDien_ab[toHop2bo[dong + 1],listchuaVitriVT[test]]) dem++;

                                    //nếu các thuộc tính còn lại của vế trái cũng bằng nhau thì vế phải bằng max
                                    if (dem == listchuaVitriVT.Count - 1)
                                    {
                                        for (int p = 0; p < listchuaVitriVP.Count; p++)
                                        {
                                            int m = Max(mangDien_ab[toHop2bo[dong],listchuaVitriVP[p]], mangDien_ab[toHop2bo[dong + 1],listchuaVitriVP[p]]);
                                            mangDien_ab[toHop2bo[dong], listchuaVitriVP[p]] = m;
                                            mangDien_ab[toHop2bo[dong + 1],listchuaVitriVP[p]] = m;
                                        }
                                    }
                                }
                        }
                        
                        txtShow.Text += "\r\n\r\n" + vt + "->" + vp + "\r\n";
                        for (int i = 0; i < mangPhanRa.Length; i++)
                        {
                            for (int j = 0; j < mangThuocTinh.Length; j++)
                                txtShow.Text += mangDien_ab[i, j] + "  ";
                            txtShow.Text += "\r\n";
                        }

                        //kt xem có dòng nào bằng 1 thì dừng, bttt
                        for (int i = 0; i < mangPhanRa.Length; i++)
                            if (Sum1Row(i) == mangThuocTinh.Length)
                            {
                                txtShow.Text += "Bảo toàn thông tin";
                                return;
                            }
                    }
                    

                    //quay ngược lại nếu còn dc 
                    for (int a = 0; a < solution.PhuThuocHam.Length; a++)
                    {
                        listchuaVitriVP.Clear();
                        listchuaVitriVT.Clear();
                        string vt = solution.VeTrai[a];
                        string vp = solution.VePhai[a];
                        
                        for (int xetVT = 0; xetVT < vt.Length; xetVT++)
                            for (int i = 0; i < mangThuocTinh.Length; i++)                  //cột
                                if (solution.Chua(vt[xetVT].ToString(), mangThuocTinh[i]) == 1)
                                    listchuaVitriVT.Add(i);
                        
                        for (int xetVP = 0; xetVP < vp.Length; xetVP++)
                            for (int i = 0; i < mangThuocTinh.Length; i++)
                                if (solution.Chua(vp[xetVP].ToString(), mangThuocTinh[i]) == 1)
                                    listchuaVitriVP.Add(i);

                        for (int cot = 0; cot < listchuaVitriVT.Count; cot++)
                        {
                            for (int dong = 0; dong < toHop2bo.Count; dong = dong + 2)
                                if (mangDien_ab[toHop2bo[dong],listchuaVitriVT[cot]] == mangDien_ab[toHop2bo[dong + 1],listchuaVitriVT[cot]])
                                {
                                    int dem = 0;
                                    for (int test = 0; test < listchuaVitriVT.Count; test++)
                                        if (listchuaVitriVT[test] != listchuaVitriVT[cot])
                                            if (mangDien_ab[toHop2bo[dong], listchuaVitriVT[test]] == mangDien_ab[toHop2bo[dong + 1], listchuaVitriVT[test]]) dem++;

                                    //nếu các thuộc tính còn lại của vế trái cũng bằng nhau thì vế phải bằng max
                                    if (dem == listchuaVitriVT.Count - 1)
                                        for (int p = 0; p < listchuaVitriVP.Count; p++)
                                            if (mangDien_ab[toHop2bo[dong], listchuaVitriVP[p]] != mangDien_ab[toHop2bo[dong + 1], listchuaVitriVP[p]])
                                            {
                                                txtShow.Text += "\r\n\r\n=> Quay lại:";
                                                goto nhan;
                                            }
                                }
                        }
                    }
                    txtShow.Text += "Không bảo toàn thông tin";
                    

                }

            }
        }

        private int Sum1Row(int hang)
        {
            int s = 0;
            for (int i = 0; i < mangThuocTinh.Length; i++)
                s += mangDien_ab[hang, i];
            return s;
        }

        private int Max(int a, int b)
        {
            if (a == b) return a;
            if (a > b) return a;
            else return b;
        }
        
        //xem lại tổ hợp
        private void ToHop()
        {
            for (int i = 0; i < mangPhanRa.Length; i++)
                for (int j = i + 1; j < mangPhanRa.Length; j++)
                {
                    toHop2bo.Add(mang[i]);
                    toHop2bo.Add(mang[j]);
                }
        }
    }
}
