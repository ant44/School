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
using System.IO;
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControlTE : UserControl
    {
        private bool IsEdit = false;
        public UserControlTE()
        {
            InitializeComponent();
        }
        void BindGrid()
        {
            txtAdress.Enabled = false;
            txtCetifacrte.Enabled = false;
            txtExpert.Enabled = false;
            txtFamily.Enabled = false;
            txtName.Enabled = false;
            txtTeID.Enabled = false;
            txtTel.Enabled = false;
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.teacherTables.ToList();
            dataGridViewX1.AutoGenerateColumns = false;
        }

        private void UserControlTE_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();
        }
        void btnEnebel()
        {
            btnAddImage.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            btnSave.Visible = false;
        }
        void btnDesibel()
        {
            btnAddImage.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelet.Enabled = false;
            btnSave.Visible = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtAdress.Enabled = true;
            txtCetifacrte.Enabled = true;
            txtExpert.Enabled = true;
            txtFamily.Enabled = true;
            txtName.Enabled = true;
            txtTeID.Enabled = true;
            txtTel.Enabled = true;

            txtAdress.Text = "";
            txtCetifacrte.Text = "";
            txtExpert.Text = "";
            txtFamily.Text = "";
            txtName.Text = "";
            txtTeID.Text = "";
            txtTel.Text = "";

            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
            txtTeID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            IsEdit = true;
            btnAddImage.Enabled = true;
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;

            txtAdress.Enabled = true;
            txtCetifacrte.Enabled = true;
            txtExpert.Enabled = true;
            txtFamily.Enabled = true;
            txtName.Enabled = true;
            txtTel.Enabled = true;

            NetCollegeEntities db = new NetCollegeEntities();
            var teId = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            teacherTable teacherTable = db.teacherTables.Where(c => c.teacherId == teId).Single();

            txtAdress.Text =teacherTable.teacherAddress ;
            txtCetifacrte.Text =teacherTable.TeacherCetifacrte ;
            txtExpert.Text = teacherTable.TeacherExpert;
            txtFamily.Text = teacherTable.teacherFamily;
            txtName.Text = teacherTable.teacherName;
            txtTeID.Text = teacherTable.teacherId;
            txtTel.Text = teacherTable.teacherTel;
            pictureBox1.ImageLocation = Application.StartupPath + "/Images/te/" + teacherTable.teImage;

            btnDesibel();
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            btnDesibel();
            btnSave.Visible = false;
            btnAddImage.Enabled = false;
            try
            {

                string tenamename = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                string tefamily = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {tenamename + " " + tefamily} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var teID = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    teacherTable teacherTable = db.teacherTables.Where(c => c.teacherId == teID).Single();
                    db.Entry(teacherTable).State = System.Data.Entity.EntityState.Deleted;
                    db.teacherTables.Remove(teacherTable);
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
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pictureBox1.ImageLocation);
            string path = Application.StartupPath + "/Images/te/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
             else if (pictureBox1.Image==null)
            {
                pictureBox1.Image= amozeshgah.Properties.Resources.icons8_school_director_200px;
                
            }
            else
            {
                pictureBox1.Image.Save(path + imageName);
            }
            if (IsEdit == false)
            {



                teacherTable teacherTable = new teacherTable();
                teacherTable.teacherId = txtTeID.Text;
                teacherTable.teacherName = txtName.Text;
                teacherTable.teacherFamily = txtFamily.Text;
                teacherTable.TeacherCetifacrte = txtCetifacrte.Text;
                teacherTable.TeacherExpert = txtExpert.Text;
                teacherTable.teacherAddress = txtAdress.Text;
                teacherTable.teacherTel = txtTel.Text;
                teacherTable.teImage = imageName; ;

                try
                {
                    db.teacherTables.Add(teacherTable);
                    RtlMessageBox.Show(" استاد جدیداضافه شد  ");
                    db.SaveChanges();

                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("کد استاد تکراری است");
                }
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
            else
            {
                try
                {

                    teacherTable teacherTable = new teacherTable();
                    teacherTable.teacherId = txtTeID.Text;
                    teacherTable.teacherName = txtName.Text;
                    teacherTable.teacherFamily = txtFamily.Text;
                    teacherTable.TeacherCetifacrte = txtCetifacrte.Text;
                    teacherTable.TeacherExpert = txtExpert.Text;
                    teacherTable.teacherAddress = txtAdress.Text;
                    teacherTable.teacherTel = txtTel.Text;
                    teacherTable.teImage = imageName; ;
                    db.Entry(teacherTable).State = System.Data.Entity.EntityState.Modified;
                    IsEdit = false;
                    RtlMessageBox.Show("ویرایش استاد انجام شد");
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    RtlMessageBox.Show("خطا در انجام عملیات");
                }


            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            btnEnebel();
            BindGrid();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Filter = "Jpeg image(*.jpg)|*.jpg";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1 .Image = Image.FromFile(openFile.FileName);
                
            }
        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                var teId = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                teacherTable teacherTable = db.teacherTables.Where(c => c.teacherId == teId).Single();
                txtAdress.Text = teacherTable.teacherAddress;
                txtCetifacrte.Text = teacherTable.TeacherCetifacrte;
                txtExpert.Text = teacherTable.TeacherExpert;
                txtFamily.Text = teacherTable.teacherFamily;
                txtName.Text = teacherTable.teacherName;
                txtTeID.Text = teacherTable.teacherId;
                txtTel.Text = teacherTable.teacherTel;
                pictureBox1.ImageLocation = Application.StartupPath + "/Images/te/" + teacherTable.teImage;

            }
            catch (Exception)
            {

                RtlMessageBox.Show("رکوردی انتخاب نشده است");
            } 
        }

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                if (comboBoxEx1.SelectedIndex == 0)
                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                      c.teacherId.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 1)

                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                     c.teacherName.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 2)

                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                     c.teacherFamily.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 3)

                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                     c.TeacherExpert.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 4)

                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                     c.TeacherCetifacrte.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 5)

                {
                    dataGridViewX1.DataSource = db.teacherTables.Where(c =>
                     c.teacherAddress.Contains(textBoxX1.Text)).ToList();
                }

                else
                {
                    BindGrid();
                }
            }
            catch (Exception)
            {


                RtlMessageBox.Show("خطا در جستجو");
            }
        }

        private void TxtFamily_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
