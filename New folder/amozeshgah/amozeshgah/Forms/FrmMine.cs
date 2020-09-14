
using amozeshgah.Data;
using amozeshgah.tools;
using Amozeshgah.Forms;
using Amozeshgah.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WpfApplicationAmmozeshgah;

namespace Amozeshgah
{
    public partial class FrmMine : Form
    {
        public FrmMine()
        {
            InitializeComponent();
            timer1.Start();
        }
        PersianCalendar pc = new PersianCalendar();

        #region move;
        Point lastClick;
        public void frmDrag_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }
        public void frmDrag_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }
        #endregion

        #region movepanel
        private void Panemove_MouseDown(object sender, MouseEventArgs e)
        {
            frmDrag_MouseDown(sender, e);

        }

        private void Panemove_MouseMove(object sender, MouseEventArgs e)
        {
            frmDrag_MouseMove(sender, e);

        }
        private void Labelmove_MouseDown(object sender, MouseEventArgs e)
        {
            frmDrag_MouseDown(sender, e);

        }

        private void Labelmove_MouseMove(object sender, MouseEventArgs e)
        {
            frmDrag_MouseMove(sender, e);
        }



        #endregion

        public void AddControlToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelExAdd.Controls.Clear();
            panelExAdd.Controls.Add(c);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            DateTime dt = DateTime.Now;
            labelX1.Text = dt.ToString( "HH:MM:ss");
            analogClockControl1.Value =dt ;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            NetCollegeEntities db = new NetCollegeEntities();
            DateTime dt = DateTime.Now;
            labelX2.Text = dt.ToString(pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now) );
           

            this.Hide();
            frmlogin frmlogin = new frmlogin();

            if (frmlogin.ShowDialog() == DialogResult.OK)
            {
                if (User.AccessType != 1)
                {
                    btnadduser .Visible  = false;
                }
                
                this.Show();
                frmlogin.Hide();
            }
            else
            {
                Application.Exit();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnClass_Click(object sender, EventArgs e)
        {
            UserControlclass userControlclass = new UserControlclass();
            AddControlToPanel(userControlclass);
        }

        private void BtnCourse_Click(object sender, EventArgs e)
        {
            UserControlCo userControlCo = new UserControlCo();
            AddControlToPanel(userControlCo);
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            UserControlSt userControlSt = new UserControlSt();
            AddControlToPanel(userControlSt);
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            UserControlTE userControlTE = new UserControlTE();
            AddControlToPanel(userControlTE);
        }

        private void Btnselectcurse_Click(object sender, EventArgs e)
        {
            UserControlselectCourse userControlselectCourse = new UserControlselectCourse();
            AddControlToPanel(userControlselectCourse);
        }

        private void BtnAcademy_Click(object sender, EventArgs e)
        {
            UserControldep userControldep = new UserControldep();
            AddControlToPanel(userControldep);
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            UserControlBackUp userControlBackUp = new UserControlBackUp();
            AddControlToPanel(userControlBackUp);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            panelExAdd.Controls.Clear();
            panelExAdd.Controls.Add(groupPanel1);
           
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            BtnAcademy.Enabled = true;
            BtnBackup.Enabled = true;
        }

        private void ButtonX2_Click(object sender, EventArgs e)
        {
            BtnAcademy.Enabled = true;
            BtnBackup.Enabled = false;
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            UserControlreport userControlreport = new UserControlreport();
            AddControlToPanel(userControlreport);
        }

        private void labelmove_Click(object sender, EventArgs e)
        {
            panelExAdd.Controls.Clear();
            panelExAdd.Controls.Add(groupPanel1);
        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            UserControluser userControluser = new UserControluser();
            AddControlToPanel(userControluser);
        }
    }
}
