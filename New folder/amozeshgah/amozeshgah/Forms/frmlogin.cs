using amozeshgah.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApplicationAmmozeshgah;

namespace Amozeshgah.Forms
{
    public partial class frmlogin : Form
    {
        public bool IsLogin = false;
        public frmlogin()
        {
            InitializeComponent();
        }
        int ac;
        string encrypt(string input)
        {
            string output = string.Empty;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            Byte[] B = Encoding.UTF8.GetBytes(input);
            byte[] passInBytes = md5.ComputeHash(B);
            output = BitConverter.ToString(passInBytes);
            output = output.Replace("-", "");
            return output;
        }
        private void Frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();
            string ramz = encrypt(txtpass.Text);
            var q = db.usersTables .Where(x => x.username == txtuser .Text && x.password == ramz).ToList();

            if (q.Count>0)
            {

                
               
               RtlMessageBox .Show("خوش امدید  " + q[0].uname + " " + q[0].ufamily);
                User.AccessType = (int)q[0].accessType;
                User.Uname = q[0].uname;
                User.Ufamily = q[0].ufamily;
                DialogResult = DialogResult.OK;
            }
            else
           RtlMessageBox.Show("نام یا رمز کاربری اشتباه است");
        }

        private void ButtonX1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
