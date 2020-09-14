using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControlclass : UserControl
    {
        public bool IsEdit = false;
        private object bs;

        public UserControlclass()
        {
            InitializeComponent();
        }
       
        void BindGrid()
        {
            txtCapacty.Enabled = false;
            txtClassID.Enabled = false;
            txtCooler.Enabled = false;
            txtDest.Enabled = false;
            txtVideo.Enabled = false;
            btnSave.Visible = false;
            txtCapacty.Text = "";
            txtClassID.Text = "";
            txtDest.Text = "";
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.classTables.ToList();
        }
        private void UserControlCourse_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
            txtCapacty.Enabled = true;
            txtClassID.Enabled = true;
            txtCooler.Enabled = true;
            txtDest.Enabled = true;
            txtVideo.Enabled = true;
            btnSave.Visible = true;
            IsEdit = false;
            txtCapacty.Text = "0";
            txtClassID.Text = "";
            txtDest.Text = "";
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelet.Enabled = false;
            txtClassID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtCapacty.Enabled = true;
            txtCooler.Enabled = true;
            txtDest.Enabled = true;
            txtVideo.Enabled = true;
            btnSave.Visible = true;
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;
            NetCollegeEntities db = new NetCollegeEntities();
            var coname = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            classTable classTable = db.classTables.Where(c => c.class_ID == coname).Single();
            txtCapacty.Text = classTable.capacity.ToString();
            txtClassID.Text = classTable.class_ID;
            txtCooler.Checked = Convert.ToBoolean(classTable.cooler);
            txtDest.Text = classTable.description;
            txtVideo.Checked = Convert.ToBoolean(classTable.video_projector);
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelet.Enabled = false;
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelet.Enabled = false;
            try
            {
                string classtabel = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {classtabel } مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var coname = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    classTable classTable = db.classTables.Where(c => c.class_ID == coname).Single();
                    db.Entry(classTable).State = System.Data.Entity.EntityState.Deleted;
                    db.classTables.Remove(classTable);
                    db.SaveChanges();
                    BindGrid();
                }
            }
            catch (Exception)
            {

                RtlMessageBox.Show("خطا در انجام حذف!");
            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            btnSave.Visible = false;
            BindGrid();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();
            if (IsEdit == false)
            {
                classTable classTable = new classTable()
                {
                    class_ID = txtClassID.Text,
                    capacity = Convert.ToInt32(txtCapacty.Text),
                    description = txtDest.Text,
                    cooler = txtCooler.Checked,
                    video_projector = txtVideo.Checked
                };
                try
                {
                    db.classTables.Add(classTable);
                    RtlMessageBox.Show(" کلاس جدیداضافه شد  ");
                    db.SaveChanges();
                    
                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("شماره کلاس تکراری است");
                }
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
            else
            {
                classTable classTable = new classTable();
                classTable.class_ID = txtClassID.Text;
                classTable.capacity = Convert.ToInt32(txtCapacty.Text);
                classTable.description = txtDest.Text;
                classTable.cooler = txtCooler.Checked;
                classTable.video_projector = txtVideo.Checked;
                db.Entry(classTable).State = System.Data.Entity.EntityState.Modified; IsEdit = false;
                RtlMessageBox.Show("ویرایش کلاس انجام شد");
                db.SaveChanges();
                
            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            BindGrid();
        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                var coname = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                classTable classTable = db.classTables.Where(c => c.class_ID == coname).Single();
                string classneme = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                txtClassID.Text = classTable.class_ID;
                txtCapacty.Text = Convert.ToString(classTable.capacity);
                txtDest.Text = classTable.description;
                txtVideo.Checked = Convert.ToBoolean(classTable.video_projector);
                txtCooler.Checked = Convert.ToBoolean(classTable.cooler);
            }
            catch (Exception)
            {

                RtlMessageBox.Show("رکوردی انتخاب نشده است");
            } 
        }

        private void Txtserch_TextChanged(object sender, EventArgs e)
        { NetCollegeEntities db = new NetCollegeEntities();
            if (comboBoxEx1.SelectedIndex==0)
            {
                dataGridViewX1.DataSource = db.classTables.Where(c =>
                  c.class_ID.Contains(txtserch.Text)).ToList();
            }
           else if(comboBoxEx1.SelectedIndex==1)

            {
                dataGridViewX1.DataSource = db.classTables.Where(c =>
                 c.capacity.ToString().Contains(txtserch.Text)).ToList();
            }
            else
            {
                BindGrid();
            }

        }
        //Where(c =>
        //        c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter)).ToList();
        private void TxtCapacty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
           
        }

        private void Txtserch_KeyPress(object sender, KeyPressEventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();
            bs = dataGridViewX1.DataSource = db.classTables.Local.Where(c => c.class_ID == txtserch.Text).ToList();
            bs = dataGridViewX1.DataSource.ToString();
        }
    }
}
