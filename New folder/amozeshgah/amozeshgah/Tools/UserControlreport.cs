using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Controls;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Dialogs;
using Stimulsoft.Report.Components;
using amozeshgah.Data;

namespace amozeshgah.tools
{
    public partial class UserControlreport : UserControl
    {
        public UserControlreport()
        {
            InitializeComponent();
        }
        NetCollegeEntities db = new NetCollegeEntities();
        StiReport report = new StiReport();
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
          
            report.RegData("class", db.classTables );
            report.Load(Application.StartupPath + "/Reportclass.mrt");
            report.Render();
            report.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
          
            report.RegData("cotabel", db.CoTables);
            report.Load(Application.StartupPath + "/Reportco.mrt");
            report.Render();
            report.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
          
            
            report.RegData("selectcours", db.selectCourses);
            report.Load(Application.StartupPath+ "/Reportseco.mrt");
            report.Render();
            report.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
          
            
            report.RegData("st", db.stTables);
            report.Load(Application.StartupPath + "/Reportst.mrt");
            report.Render();
            report.Show();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
           
           
            report.RegData("te", db.teacherTables);
            report.Load(Application.StartupPath + "/Reportte.mrt");
            report.Render();
            report.Show();
        }
    }
}
