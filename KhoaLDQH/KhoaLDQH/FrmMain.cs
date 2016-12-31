using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KhoaLDQH
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //chọn thuộc tính IsMdiContainer = True để thiết lập form 1 là cha
        private bool checkExistsForm(string name)       //kiểm tra form con mở chưa
        {
            bool check = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void ActiveChildForm(string name)
        {
            foreach (Form f in this.MdiChildren)
                if (f.Name == name)
                {
                    f.Activate();
                    break;
                }
        }

        private void baoĐóngKhóaPTTDạngChuẩnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmKhoa"))
            {
                FrmKhoa f = new FrmKhoa();
                f.MdiParent = this;
                f.Show();
            }
            else
                ActiveChildForm("FrmKhoa");
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDSD f = new HDSD();
            f.ShowDialog();
        }

        private void vềPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmPhanMem"))
            {
                FrmPhanMem f = new FrmPhanMem();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmPhanMem");
        }

        private void vềTácGỉaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmTacGia"))
            {
                FrmTacGia f = new FrmTacGia();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmTacGia");
        }

        private void tìmBaoĐóngCủaXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendData obj = new SendData();
            if (!checkExistsForm("FrmTimBD"))
            {
                FrmTimBD f = new FrmTimBD(obj);
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmTimBD");
        }

        private void kiểmTraPTHSuyDiễnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmKTsuyDien"))
            {
                FrmKTsuyDien f = new FrmKTsuyDien();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmKTsuyDien");
        }

        private void phânRãBảoToànThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmKTbttt"))
            {
                FrmKTbttt f = new FrmKTbttt();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmKTbttt");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileInfo fileRoute = new FileInfo("test.txt");
            fileRoute.Delete();
            FileInfo fileRoute1 = new FileInfo("testPR.txt");
            fileRoute1.Delete();
            FileInfo fileRoute2 = new FileInfo("testKU.txt");
            fileRoute2.Delete();
        }

        private void kiểmTraVếTráiPTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmKTPTHvtDT"))
            {
                FrmKTPTHvtDT f = new FrmKTPTHvtDT();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmKTPTHvtDT");
        }

        private void phủTốiThiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmPTT"))
            {
                FrmPTT f = new FrmPTT();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmPTT");
        }

        private void kiểmTraPTHDưThừaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmKTPTHDT"))
            {
                FrmKTPTHDT f = new FrmKTPTHDT();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmKTPTHDT");
        }

        private void chuẩnHóaBằngPPPhânRãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("FrmPhanRa"))
            {
                FrmPhanRa f = new FrmPhanRa();
                f.MdiParent = this;
                f.Show();
            }
            else ActiveChildForm("FrmPhanRa");
        }
    }
}
