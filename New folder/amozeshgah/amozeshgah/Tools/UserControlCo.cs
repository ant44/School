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
    public partial class UserControlCo : UserControl
    {
        private bool IsEdit = false;
        public UserControlCo()
        {
            InitializeComponent();
            
        }
        void BindGrid()
        {
            txtcapa.Enabled = false;
            txtCoID.Enabled = false;
            txtDataTime.Enabled = false;
            txtPrice.Enabled = false;
            txtTime.Enabled = false;
            comboBoxClass.Enabled = false;
            comboBoxDep.Enabled = false;
            comboBoxTE.Enabled = false;
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.CoTables.ToList();
            dataGridViewX1.AutoGenerateColumns = false;
        }


        private void UserControlCo_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();


            comboBoxClass.DataSource = db.classTables.ToList();
            comboBoxClass.DisplayMember = "class_ID";
            comboBoxClass.ValueMember = "class_ID";
            //comboBoxTE.SelectedIndex = 0;

            comboBoxDep.DataSource = db.DeptTables.ToList();
            comboBoxDep.DisplayMember = "deptId";
            comboBoxDep.ValueMember = "deptId";
            //comboBoxDep.SelectedIndex = 0;

            comboBoxTE.DataSource = db.teacherTables.ToList();
            comboBoxTE.DisplayMember = "teacherFamily";
            comboBoxTE.ValueMember = "teacherId";
            //comboBoxTE.SelectedIndex = 0;
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

            txtcapa.Enabled = true;
            txtCoID.Enabled = true;
            txtDataTime.Enabled = true;
            txtPrice.Enabled = true;
            txtTime.Enabled = true;
            comboBoxClass.Enabled = true;
            comboBoxDep.Enabled = true;
            comboBoxTE.Enabled = true;
            txtcapa.Text = "0";
            txtCoID.Text = "";
            txtDataTime.Text = "0";
            txtPrice.Text = "0";
            txtTime.Text = "0";
            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
            txtCoID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtcapa.Enabled = true;
            txtDataTime.Enabled = true;
            txtPrice.Enabled = true;
            txtTime.Enabled = true;
            comboBoxClass.Enabled = true;
            comboBoxDep.Enabled = true;
            comboBoxTE.Enabled = true;
            btnSave.Visible = true;
            btnAddImage.Enabled = true;
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;
            NetCollegeEntities db = new NetCollegeEntities();
            var cota = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            CoTable coTable = db.CoTables.Where(c => c.coid == cota).Single();
            txtcapa.Text = Convert.ToString(coTable.capacity);
            txtCoID.Text = coTable.coid;
            txtDataTime.Text = Convert.ToString(coTable.start_date);
            txtPrice.Text = Convert.ToString(coTable.price);
            txtTime.Text = Convert.ToString(coTable.hour);
            comboBoxClass.Text = coTable.classId;
            comboBoxDep.Text = coTable.dptID.ToString();
            comboBoxTE.Text = coTable.teacherId;
            pictureBox1.ImageLocation = Application.StartupPath + "/Images/co/" + coTable.logo;
            btnDesibel();
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            btnDesibel();
            btnSave.Visible = false;
            btnAddImage.Enabled = false;
            try
            {
                string cota = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {cota } مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var cotabel = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    CoTable coTable = db.CoTables.Where(c => c.coid == cotabel).Single();
                    db.Entry(coTable).State = System.Data.Entity.EntityState.Deleted;
                    db.CoTables.Remove(coTable);
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
            string path = Application.StartupPath + "/Images/co/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else if (pictureBox1.Image==null)
            {
                pictureBox1.Image= amozeshgah.Properties.Resources.icons8_courses_150px;
                
            }
            else
            {
                pictureBox1.Image.Save(path + imageName);
            }
            
            
            if (IsEdit == false)
            {
                


                CoTable coTable = new CoTable();

                coTable.coid = txtCoID.Text;
                coTable.capacity = Convert.ToInt32(txtcapa.Text);
                coTable.hour = Convert.ToInt32(txtTime.Text);
                coTable.price = Convert.ToInt32(txtPrice.Text);
                coTable.start_date = txtDataTime.Text;
                coTable.classId = comboBoxClass.SelectedValue.ToString();
                coTable.dptID = Convert.ToInt32(comboBoxDep.SelectedValue.ToString());
                coTable.teacherId = comboBoxTE.SelectedValue.ToString();
                coTable.logo = imageName;

                try
                {
                    db.CoTables.Add(coTable);
                    RtlMessageBox.Show(" دوره جدیداضافه شد  ");
                    db.SaveChanges();

                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("شماره دوره تکراری است");
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
                    CoTable coTable = new CoTable();
                    coTable.coid = txtCoID.Text;
                    coTable.capacity = Convert.ToInt32(txtcapa.Text);
                    coTable.hour = Convert.ToInt32(txtTime.Text);
                    coTable.price = Convert.ToInt32(txtPrice.Text);
                    coTable.start_date = txtDataTime.Text;
                    coTable.classId = comboBoxClass.SelectedValue.ToString();
                    coTable.dptID = Convert.ToInt32(comboBoxDep.SelectedValue.ToString());
                    coTable.teacherId = comboBoxTE.SelectedValue.ToString();
                    coTable.logo = imageName;
                    db.Entry(coTable).State = System.Data.Entity.EntityState.Modified;
                    IsEdit = false;
                    RtlMessageBox.Show("ویرایش دوره انجام شد");
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    RtlMessageBox.Show("مقدار وارده درست نمی باشد  ");
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

                pictureBox1 .ImageLocation = openFile.FileName;
            }
        }


        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                NetCollegeEntities db = new NetCollegeEntities();
                var cota = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                CoTable coTable = db.CoTables.Where(c => c.coid == cota).Single();
                txtcapa.Text = Convert.ToString(coTable.capacity);
                txtCoID.Text = coTable.coid;
                txtDataTime.Text = Convert.ToString(coTable.start_date);
                txtPrice.Text = Convert.ToString(coTable.price);
                txtTime.Text = Convert.ToString(coTable.hour);
                comboBoxClass.Text = coTable.classId;
                comboBoxDep.Text = coTable.dptID.ToString();
                comboBoxTE.Text = coTable.teacherId;
                pictureBox1.ImageLocation = Application.StartupPath + "/Images/co/" + coTable.logo;
            

            
        }

        private void TxtDataTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                if (comboBoxEx1.SelectedIndex == 0)
                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                      c.coid.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 1)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.dptID.ToString().Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 2)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.classId.Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 3)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.teacherId.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 4)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.capacity.ToString().Contains(textBoxX1.Text)).ToList();
                }


                else if (comboBoxEx1.SelectedIndex == 5)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.price.ToString().Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 6)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.hour.ToString().Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 7)

                {
                    dataGridViewX1.DataSource = db.CoTables.Where(c =>
                     c.start_date.ToString().Contains(textBoxX1.Text)).ToList();
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

        private void txtCoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
