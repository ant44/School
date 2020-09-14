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
    public partial class UserControldep : UserControl
    {
        public bool IsEdit = false;
        public UserControldep()
        {
            InitializeComponent();
        }
        void BindGrid()
        {
            txtdeptId.Enabled = false;
            txtdeptName.Enabled = false;
            txtboss.Enabled = false;
           
            txtdeptId.Text = "";
            txtdeptName.Text = "";
            txtboss.Text = "";
            NetCollegeEntities db = new NetCollegeEntities();
            dataGridViewX1.DataSource = db.DeptTables.ToList();


        }
        private void UserControldep_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
            dataGridViewX1.AutoGenerateColumns = false;
            btnSave.Visible = false;
            BindGrid();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtdeptId.Enabled = true;
            txtdeptName.Enabled = true;
            txtboss.Enabled = true;
            
            txtdeptId.Text = "";
            txtdeptName.Text = "";
            txtboss.Text = "";
            IsEdit = false;
            btnDesibel();
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_43px;
            txtdeptId.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
           
            txtdeptName.Enabled = true;
            txtboss.Enabled = true;
            btnSave.Image = amozeshgah.Properties.Resources.icons8_save_as;
            IsEdit = true;
            NetCollegeEntities db = new NetCollegeEntities();
            var dep = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            DeptTable deptTable = db.DeptTables.Where(c => c.deptId.ToString() == dep).Single();
            txtdeptId.Text = deptTable.deptId.ToString();
            txtdeptName.Text = deptTable.deptName;
            txtboss.Text = deptTable.boss;
            btnDesibel();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {


            btnEnebel();
            BindGrid();
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            btnDesibel();
            btnSave.Visible = false;
            if (dataGridViewX1.CurrentRow !=null )
            {
                try
                {
                    string dep = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    if (RtlMessageBox.Show($"آیا از حذف {dep } مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        NetCollegeEntities db = new NetCollegeEntities();
                        var dept = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                        DeptTable deptTable = db.DeptTables.Where(c => c.deptId.ToString() == dept).Single();
                        db.Entry(deptTable).State = System.Data.Entity.EntityState.Deleted;
                        db.DeptTables.Remove(deptTable);
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
            else
            {
                RtlMessageBox.Show("رکوردی انتخاب نشده است");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            NetCollegeEntities db = new NetCollegeEntities();

            if (IsEdit == false)
            {



                DeptTable deptTable = new DeptTable();

                deptTable.deptName = txtdeptName.Text;
                deptTable.boss = txtboss.Text;

                try
                {
                    db.DeptTables.Add(deptTable);
                    RtlMessageBox.Show(" ساختمان جدیداضافه شد  ");
                    db.SaveChanges();

                }

               
                catch
                {
                    RtlMessageBox.Show("خطا در انجام عملیات");
                }
            }
            else
            {
                DeptTable deptTable = new DeptTable();
                deptTable.deptName = txtdeptName.Text;
                deptTable.boss = txtboss.Text;
                deptTable.deptId = int.Parse(txtdeptId.Text );

                db.Entry(deptTable).State = System.Data.Entity.EntityState.Modified;
                IsEdit = false;
                RtlMessageBox.Show("ویرایش ساختمان  انجام شد");
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
            var dep = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            DeptTable deptTable = db.DeptTables.Where(c => c.deptId.ToString() == dep).Single();
            txtdeptId.Text = deptTable.deptId.ToString();
            txtdeptName.Text = deptTable.deptName;
            txtboss.Text = deptTable.boss;
            
        }

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            NetCollegeEntities db = new NetCollegeEntities();
            if (comboBoxEx1.SelectedIndex == 0)
            {
                dataGridViewX1.DataSource = db.DeptTables.Where(c =>
                  c.deptId.ToString().Contains(textBoxX1.Text)).ToList();
            }
            else if (comboBoxEx1.SelectedIndex == 1)

            {
                dataGridViewX1.DataSource = db.DeptTables.Where(c =>
                 c.deptName.Contains(textBoxX1.Text)).ToList();
            }
            else if (comboBoxEx1.SelectedIndex == 2)

            {
                dataGridViewX1.DataSource = db.DeptTables.Where(c =>
                 c.boss.Contains(textBoxX1.Text)).ToList();
            }
            else if(textBoxX1.Text=="")
            {
                BindGrid();
            }
        }
    }
}
