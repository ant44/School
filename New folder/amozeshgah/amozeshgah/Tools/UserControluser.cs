using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControluser : UserControl
    {
        private bool IsEdit = false;
        public UserControluser()
        {
            InitializeComponent();
        }
        void BindGrid()
        {
            txtfamily.Enabled = false;
            txtname.Enabled = false;
            txtpass.Enabled = false;
            comAcsses.Enabled = false;
            txtuser.Enabled = false;
            
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.usersTables.ToList();
            dataGridViewX1.AutoGenerateColumns = false;

        }
        void btnEnebel()
        {

            btnAdd.Enabled = true;
            
            btnDelet.Enabled = true;
            btnSave.Visible = false;
        }
        void btnDesibel()
        {

            btnAdd.Enabled = false;
            
            btnDelet.Enabled = false;
            btnSave.Visible = true;
        }

        private void UserControluser_Load(object sender, EventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();


            comAcsses.SelectedIndex = 1;


            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtfamily.Enabled = true;
            txtname.Enabled = true;
            txtpass.Enabled = true;
            comAcsses.Enabled = true;
            txtuser.Enabled = true;
            comAcsses.Enabled = true;

            txtfamily.Text = "";
            txtname.Text = "";
            txtpass.Text = "";
            comAcsses.Text = "";
            txtuser.Text = "";
            txtuser.Focus();
            comAcsses.Enabled = true;
            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
        }

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


       

        private void BtnDelet_Click(object sender, EventArgs e)
        {

            btnDesibel();
            btnSave.Visible = false;

            try
            {
                string userna = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {userna } مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var user = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    usersTable usersTable = db.usersTables.Where(c => c.username == user).Single();
                    db.Entry(usersTable).State = System.Data.Entity.EntityState.Deleted;
                    db.usersTables.Remove(usersTable);
                    db.SaveChanges();
                    BindGrid();
                }
            }
            catch (Exception)
            {

                RtlMessageBox.Show("خطا در انجام حذف!");
            }
            btnEnebel();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnEnebel();
            BindGrid();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();
            string password = encrypt(txtpass.Text);
            if (IsEdit == false)
            {



                usersTable usersTable = new usersTable()
                {
                    username=txtuser.Text,
                    password=password,
                    uname=txtname.Text,
                    ufamily=txtfamily.Text,
                    accessType=comAcsses.SelectedIndex+1
                };

               


                try
                {
                    db.usersTables.Add(usersTable);
                    RtlMessageBox.Show(" کاربر جدیداضافه شد  ");
                    db.SaveChanges();

                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("یوزر نیم  تکراری است");
                }
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
           
            btnAdd.Enabled = true;
           
            btnDelet.Enabled = true;
            btnEnebel();
            BindGrid();

        }


    }
}
