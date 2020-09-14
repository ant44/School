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
using amozeshgah.Data;

namespace Amozeshgah.Tools
{
    public partial class UserControlBackUp : UserControl
    {
        public UserControlBackUp()
        {
            InitializeComponent();
        }
        NetCollegeEntities  db = new NetCollegeEntities();
        bool IsBackup = false;

        private void Buttonpath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (folderBrowser.SelectedPath.Length == 3)
                        textBoxXpath.Text = folderBrowser.SelectedPath + "BackupFile" + "_" + DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" + DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + ".Bak";
                }
                else
                {
                    textBoxXpath.Text = folderBrowser.SelectedPath + "//BackupFile" + "_" + DateTime.Now.Date.Year + DateTime.Now.Date.Month + DateTime.Now.Date.Day + "_" + DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + ".Bak";

                }
            }
            catch (PathTooLongException)
            {
                RtlMessageBox.Show("مسیر طولانی است");
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel3.Enabled = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Enabled = true;
        }

       

        private void BackgroundWorkerresto_DoWork(object sender, DoWorkEventArgs e)
        {
            string command = "ALTER DATABASE NetCollege SET OFFLINE WITH ROLLBACK IMMEDIATE " +
               "RESTORE DATABASE NetCollege FROM DISK='" + textBoxXpathr.Text + "'WITH REPLACE " +
               "ALTER DATABASE NetCollege SET ONLINE";
            db.Database.CommandTimeout = 360;
            db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
        }

        private void UserControlBackUp_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void Btnbackaup_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxXpath.Text))
                RtlMessageBox.Show("مسیر ذخیره سازی را انتخاب کنید");
            else
            {
                panel1.Enabled = false;
                btnbackaup.Enabled = false;
                IsBackup = true;
                if (!backgroundWorkerback.IsBusy)
                    backgroundWorkerback.RunWorkerAsync();
            }
        }
        private void BackgroundWorkerback_DoWork(object sender, DoWorkEventArgs e)
        {
            string command = @"BACKUP DATABASE NetCollege TO DISk='" + textBoxXpath.Text + "'WITH INIT";
            db.Database.CommandTimeout = 360;
            db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, command);
        }



        private void Btnrestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxXpathr .Text))
                RtlMessageBox.Show("فایل پشتیبان را انتخاب کنید");

            else
            {
                if (RtlMessageBox.Show("فایل پشتیبان جایگزین شود؟", "نرم افزار مدیریت آموزشگاه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    panel3.Enabled = false;
                    btnpatheres .Enabled = false;
                    IsBackup  = true;
                    if (!backgroundWorkerresto.IsBusy)
                        backgroundWorkerresto.RunWorkerAsync();
                }
            }
        }

        private void Btnpatheres_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openBackup = new OpenFileDialog();
                openBackup.Filter = "sql Backup file(*.BAK)|*.BAK";
                if (openBackup.ShowDialog() == DialogResult.OK)
                    textBoxXpathr.Text = openBackup.FileName;
            }
            catch (PathTooLongException)
            {
                RtlMessageBox.Show("مسیر طولانی است");
            }
        }

        private void BackgroundWorkerback_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
                RtlMessageBox.Show("پشتیبان گیری با موفقیت انجام شد");
            else
                RtlMessageBox.Show("خطا در پشتیبان گیری");
            IsBackup = false;
            panel2.Enabled = true;
            btnbackaup.Enabled = true;

        }

        private void BackgroundWorkerresto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error == null)
            {
                RtlMessageBox.Show("بازیابی با موفقیت انجام شد نرم افزار مجدد راه اندازی خواهد شد");
                IsBackup = false;
                Application.Restart();
            }
            else
            {
                RtlMessageBox.Show("خطا در بازیابی");
                panel3.Enabled = true;
                btnpatheres.Enabled = true;
                IsBackup = false;
            }
        }

        private void UserControlBackUp_Leave(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (IsBackup==true)
                {
                    
                    RtlMessageBox.Show("در حال پشتیبان گیری");
                }
            }
            else
            {
                if (IsBackup==true)
                {
                   
                    RtlMessageBox.Show("در حال بازیابی");
                }
            }

        }
    }
}
