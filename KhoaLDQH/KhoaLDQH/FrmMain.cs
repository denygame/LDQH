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
            if (!checkExistsForm("Form1"))
            {
                Form1 f = new Form1();
                f.MdiParent = this;
                f.Show();

            }
            else
                ActiveChildForm("Form1");
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDSD f = new HDSD();
            f.ShowDialog();
        }

        private void vềPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("VEPM"))
            {
                VEPM f = new VEPM();
                f.MdiParent = this;
                f.Show();

            }
            else ActiveChildForm("VEPM");
        }

        private void vềTácGỉaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("VETG"))
            {
                VETG f = new VETG();
                f.MdiParent = this;
                f.Show();

            }
            else ActiveChildForm("VETG");
        }

        private void tìmBaoĐóngCủaXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendData obj = new SendData();
            if (!checkExistsForm("Form2"))
            {
                Form2 f = new Form2(obj);
                f.MdiParent = this;
                f.Show();

            }
            else ActiveChildForm("Form2");

        }

        private void kiểmTraPTHSuyDiễnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("Form3"))
            {
                Form3 f = new Form3();
                f.MdiParent = this;
                f.Show();

            }
            else ActiveChildForm("Form3");
        }

        private void phânRãBảoToànThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkExistsForm("Form4"))
            {
                Form4 f = new Form4();
                f.MdiParent = this;
                f.Show();

            }
            else ActiveChildForm("Form4");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileInfo fileRoute = new FileInfo("test.txt");
            fileRoute.Delete();
            FileInfo fileRoute1 = new FileInfo("testPR.txt");
            fileRoute1.Delete();
        }
    }
}
