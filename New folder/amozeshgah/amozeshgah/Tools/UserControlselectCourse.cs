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
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControlselectCourse : UserControl
    {
        private bool IsEdit = false;
        public UserControlselectCourse()
        {
            InitializeComponent();
        }
        int price;
        int pardack;
        int mandeh;
        CoTable CoTable = new CoTable();

        void BindGrid()
        {
            comCoid.Enabled = false;
            txtDes.Enabled = false;
            txtGrade.Enabled = false;
            //txtMan.Enabled = false;
            txtPar.Enabled = false;
            txtRowId.Enabled = false;
            comStId.Enabled = false;

            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.selectCourses.ToList();
            dataGridViewX1.AutoGenerateColumns = false;

        }
        void btnEnebel()
        {

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            btnSave.Visible = false;
        }
        void btnDesibel()
        {

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelet.Enabled = false;
            btnSave.Visible = true;
        }

        private void UserControlselectCourse_Load(object sender, EventArgs e)
        {

            btnAdd.Enabled = true;
            NetCollegeEntities db = new NetCollegeEntities();

            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();


            comCoid.DataSource = db.CoTables.ToList();
            comCoid.DisplayMember = "coid";
            comCoid.ValueMember = "coid";



            comStId.DataSource = db.stTables.ToList();
            comStId.DisplayMember = "stFamily";
            comStId.ValueMember = "studentID";
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //NetCollegeEntities db = new NetCollegeEntities();


            //selectCourse selectCourse = db.selectCourse.Where(c => c.coid.ToString() == comCoid.SelectedItem.ToString()).SingleOrDefault();
            //CoTable coTable = db.CoTable.Where(c => c.coid == selectCourse.coid).Single();
            //txtprise.Text = coTable.price.ToString(); ;






            comCoid.Enabled = true;
            txtDes.Enabled = true;
            txtGrade.Enabled = true;

            txtPar.Enabled = true;
            txtRowId.Enabled = true;
            comStId.Enabled = true;

            txtDes.Text = "";
            txtGrade.Text = "0";
            txtPar.Text = "0";
            txtRowId.Text = "";
            txtRowId.Focus();
            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtDes.Enabled = true;
            txtGrade.Enabled = true;
            comCoid.Enabled = true;
            txtPar.Enabled = true;
            comStId.Enabled = true;
            btnSave.Visible = true;

            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;
            NetCollegeEntities db = new NetCollegeEntities();
            var selectco = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            selectCourse selectCourse = db.selectCourses.Where(c => c.rowID.ToString() == selectco).Single();
            txtDes.Text = selectCourse.description;
            txtGrade.Text = selectCourse.grade.ToString();
            txtPar.Text = selectCourse.pardakht;
            txtRowId.Text = selectCourse.rowID.ToString();
            comCoid.Text = selectCourse.coid;
            comStId.Text = selectCourse.stid;
            btnDesibel();

        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {

            btnDesibel();
            btnSave.Visible = false;

            try
            {
                string courset = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                if (RtlMessageBox.Show($"آیا از حذف {courset } مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    NetCollegeEntities db = new NetCollegeEntities();
                    var course = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    selectCourse selectCourse = db.selectCourses.Where(c => c.rowID.ToString() == course).Single();
                    db.Entry(selectCourse).State = System.Data.Entity.EntityState.Deleted;
                    db.selectCourses.Remove(selectCourse);
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

            if (IsEdit == false)
            {



                selectCourse selectCourse = new selectCourse();

                selectCourse.rowID = int.Parse(txtRowId.Text);
                selectCourse.description = txtDes.Text;
                selectCourse.pardakht = txtPar.Text;
                selectCourse.grade = int.Parse(txtGrade.Text);
                selectCourse.stid = comStId.SelectedValue.ToString();
                selectCourse.coid = comCoid.SelectedValue.ToString();


                try
                {
                    db.selectCourses.Add(selectCourse);
                    RtlMessageBox.Show(" دوره جدیدانتخاب شد  ");
                    db.SaveChanges();

                }

                catch (DbUpdateException)
                {

                    RtlMessageBox.Show("شماره دوره انتخابی تکراری است");
                }
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
            else
            {
                selectCourse selectCourse = new selectCourse();

                selectCourse.rowID = int.Parse(txtRowId.Text);
                selectCourse.description = txtDes.Text;
                selectCourse.pardakht = txtPar.Text;
                selectCourse.grade = int.Parse(txtGrade.Text);
                selectCourse.stid = comStId.SelectedValue.ToString();
                selectCourse.coid = comCoid.SelectedValue.ToString();
                db.Entry(selectCourse).State = System.Data.Entity.EntityState.Modified;
                IsEdit = false;
                RtlMessageBox.Show("ویرایش دوره انتخابی انجام شد");
                db.SaveChanges();

            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelet.Enabled = true;
            btnEnebel();
            BindGrid();

        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            NetCollegeEntities db = new NetCollegeEntities();

            var selectco = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            selectCourse selectCourse = db.selectCourses.Where(c => c.rowID.ToString() == selectco).Single();
            CoTable coTable = db.CoTables.Where(c => c.coid == selectCourse.coid).Single();
            txtprise.Text = coTable.price.ToString();




            price =Convert.ToInt32( txtprise.Text);
            pardack = Convert.ToInt32(selectCourse.pardakht);
            mandeh = price - pardack;

            txtmandeh.Text =mandeh.ToString();

            txtDes.Text = selectCourse.description;
            txtGrade.Text = selectCourse.grade.ToString();
            txtPar.Text = selectCourse.pardakht;
            txtRowId.Text = selectCourse.rowID.ToString();
            comCoid.Text = selectCourse.coid;
            comStId.Text = selectCourse.stid;
            if (mandeh<=0)
            {
                lbl.Image = amozeshgah.Properties.Resources.icons8_wink_48px;
            }
            else
            {
                lbl.Image = amozeshgah.Properties.Resources.icons8_question_48px;
            }





        }

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NetCollegeEntities db = new NetCollegeEntities();
                if (comboBoxEx1.SelectedIndex == 0)
                {
                    dataGridViewX1.DataSource = db.selectCourses.Where(c =>
                      c.rowID.ToString().Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 1)

                {
                    dataGridViewX1.DataSource = db.selectCourses.Where(c =>
                     c.stid.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 2)

                {
                    dataGridViewX1.DataSource = db.selectCourses.Where(c =>
                     c.grade.ToString().Contains(textBoxX1.Text)).ToList();
                }
                else if (comboBoxEx1.SelectedIndex == 3)

                {
                    dataGridViewX1.DataSource = db.selectCourses.Where(c =>
                     c.coid.Contains(textBoxX1.Text)).ToList();
                }

                else if (comboBoxEx1.SelectedIndex == 4)

                {
                    dataGridViewX1.DataSource = db.selectCourses.Where(c =>
                     c.pardakht.Contains(textBoxX1.Text)).ToList();
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

        private void txtRowId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
