using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data.Entity.Infrastructure;
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControlSt : UserControl
    {
        private bool IsEdit = false;

        public UserControlSt()
        {
            InitializeComponent();
        }
        void BindGrid()
        {
            txtStAdress.Enabled = false;
            txtSTFamily.Enabled = false;
            txtStID.Enabled = false;
            txtStName.Enabled = false;
            txtStTel.Enabled = false;
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.stTables.ToList();
            dataGridViewX1.AutoGenerateColumns = false;
        }

        private void UserControlSt_Load(object sender, EventArgs e)
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
            txtStAdress.Enabled = true;
            txtSTFamily.Enabled = true;
            txtStID.Enabled = true;
            txtStName.Enabled = true;
            txtStTel.Enabled = true;
            txtStAdress.Text = "";
            txtSTFamily.Text = "";
            txtStID.Text = "";
            txtStName.Text = "";
            txtStTel.Text = "";
            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
            txtStID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtStAdress.Enabled = true;
            txtSTFamily.Enabled = true;
            txtStName.Enabled = true;
            txtStTel.Enabled = true;
            btnSave.Visible = true;
            btnAddImage.Enabled = true;
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;
            NetCollegeEntities db = new NetCollegeEntities();
            var stID = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            stTable stTable = db.stTables.Where(c => c.studentID == stID).Single();
            txtStAdress.Text = stTable.stAddress;
            txtSTFamily.Text = stTable.stFamily;
            txtStID.Text = stTable.studentID;
            txtStName.Text = stTable.stName;
            txtStTel.Text = stTable.stTel;
            pictureBox1.ImageLocation = Application.StartupPath + "/Images/st/" + stTable.stImage;
            btnDesibel();


        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            btnDesibel();
            btnSave.Visible = false;
            btnAddImage.Enabled = false;
            try
            {
           
                string stname = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                string stfamily = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {stname + " " + stfamily} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var sttable = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    stTable stTable = db.stTables.Where(c => c.studentID == sttable).Single();
                    db.Entry(stTable).State = System.Data.Entity.EntityState.Deleted;
                    db.stTables .Remove(stTable );
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
            string path = Application.StartupPath + "/Images/st/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else if (pictureBox1.Image == null)
            {
                pictureBox1.Image = amozeshgah.Properties.Resources.icons8_student_male_200px;

            }
            pictureBox1.Image.Save(path + imageName);
            if (IsEdit == false)
            {
                


                stTable stTable = new stTable();
                stTable.studentID = txtStID.Text;
                stTable.stName = txtStName.Text;
                stTable.stFamily = txtSTFamily.Text;
                stTable.stTel = txtStTel.Text;
                stTable.stAddress = txtStAdress.Text;
                stTable.stImage = imageName;
                

                try
                {
                    db.stTables.Add(stTable);
                    RtlMessageBox.Show(" دانشجو جدیداضافه شد  ");
                    db.SaveChanges();

                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("شماره دانشجویی تکراری است");
                }
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
            else
            {
                stTable stTable = new stTable();
                stTable.studentID = txtStID.Text;
                stTable.stName = txtStName.Text;
                stTable.stFamily = txtSTFamily.Text;
                stTable.stTel = txtStTel.Text;
                stTable.stAddress = txtStAdress.Text;
                stTable.stImage = imageName;
                
                db.Entry(stTable).State = System.Data.Entity.EntityState.Modified;
                IsEdit = false;
                RtlMessageBox.Show("ویرایش دانشجو انجام شد");
                db.SaveChanges();

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

                pictureBox1.ImageLocation = openFile.FileName;
            }
        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                var stID = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                stTable stTable = db.stTables.Where(c => c.studentID == stID).Single();
                txtStAdress.Text = stTable.stAddress;
                txtSTFamily.Text = stTable.stFamily;
                txtStID.Text = stTable.studentID;
                txtStName.Text = stTable.stName;
                txtStTel.Text = stTable.stTel;
                pictureBox1.ImageLocation = Application.StartupPath + "/Images/st/" + stTable.stImage;
            
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
                    dataGridViewX1.DataSource = db.stTables.Where(c =>
                      c.studentID.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 1)

                {
                    dataGridViewX1.DataSource = db.stTables.Where(c =>
                     c.stName.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 2)

                {
                    dataGridViewX1.DataSource = db.stTables.Where(c =>
                     c.stFamily.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 3)

                {
                    dataGridViewX1.DataSource = db.stTables.Where(c =>
                     c.stTel.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 4)

                {
                    dataGridViewX1.DataSource = db.stTables.Where(c =>
                     c.stAddress.Contains(textBoxX1.Text)).ToList();
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
    }
}
