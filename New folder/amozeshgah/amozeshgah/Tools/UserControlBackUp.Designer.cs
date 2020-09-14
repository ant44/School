namespace Amozeshgah.Tools
{
    partial class UserControlBackUp
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel3 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxXpathr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnpatheres = new DevComponents.DotNetBar.ButtonX();
            this.btnrestore = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxXpath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonpath = new DevComponents.DotNetBar.ButtonX();
            this.btnbackaup = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.backgroundWorkerback = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerresto = new System.ComponentModel.BackgroundWorker();
            this.panelEx1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panel3);
            this.panelEx1.Controls.Add(this.panel2);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(700, 557);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel3.Controls.Add(this.textBoxXpathr);
            this.panel3.Controls.Add(this.btnpatheres);
            this.panel3.Controls.Add(this.btnrestore);
            this.panel3.Controls.Add(this.labelX2);
            this.panel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 87);
            this.panel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel3.Style.GradientAngle = 90;
            this.panel3.TabIndex = 8;
            // 
            // textBoxXpathr
            // 
            this.textBoxXpathr.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.textBoxXpathr.Border.Class = "TextBoxBorder";
            this.textBoxXpathr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXpathr.DisabledBackColor = System.Drawing.Color.Black;
            this.textBoxXpathr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxXpathr.ForeColor = System.Drawing.Color.White;
            this.textBoxXpathr.Location = new System.Drawing.Point(120, 16);
            this.textBoxXpathr.Name = "textBoxXpathr";
            this.textBoxXpathr.PreventEnterBeep = true;
            this.textBoxXpathr.Size = new System.Drawing.Size(407, 23);
            this.textBoxXpathr.TabIndex = 3;
            // 
            // btnpatheres
            // 
            this.btnpatheres.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnpatheres.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnpatheres.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnpatheres.Location = new System.Drawing.Point(39, 16);
            this.btnpatheres.Name = "btnpatheres";
            this.btnpatheres.Size = new System.Drawing.Size(75, 23);
            this.btnpatheres.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnpatheres.TabIndex = 2;
            this.btnpatheres.Text = "....";
            this.btnpatheres.Click += new System.EventHandler(this.Btnpatheres_Click);
            // 
            // btnrestore
            // 
            this.btnrestore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnrestore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnrestore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnrestore.Location = new System.Drawing.Point(363, 45);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(164, 23);
            this.btnrestore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnrestore.TabIndex = 1;
            this.btnrestore.Text = "بازیابی";
            this.btnrestore.Click += new System.EventHandler(this.Btnrestore_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX2.Location = new System.Drawing.Point(533, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(147, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "انتخاب فایل پشتیبان  :";
            // 
            // panel2
            // 
            this.panel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel2.Controls.Add(this.textBoxXpath);
            this.panel2.Controls.Add(this.buttonpath);
            this.panel2.Controls.Add(this.btnbackaup);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 88);
            this.panel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel2.Style.GradientAngle = 90;
            this.panel2.TabIndex = 4;
            // 
            // textBoxXpath
            // 
            this.textBoxXpath.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.textBoxXpath.Border.Class = "TextBoxBorder";
            this.textBoxXpath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXpath.DisabledBackColor = System.Drawing.Color.Black;
            this.textBoxXpath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxXpath.ForeColor = System.Drawing.Color.White;
            this.textBoxXpath.Location = new System.Drawing.Point(120, 22);
            this.textBoxXpath.Name = "textBoxXpath";
            this.textBoxXpath.PreventEnterBeep = true;
            this.textBoxXpath.Size = new System.Drawing.Size(407, 23);
            this.textBoxXpath.TabIndex = 3;
            // 
            // buttonpath
            // 
            this.buttonpath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonpath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonpath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonpath.Location = new System.Drawing.Point(39, 23);
            this.buttonpath.Name = "buttonpath";
            this.buttonpath.Size = new System.Drawing.Size(75, 23);
            this.buttonpath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonpath.TabIndex = 2;
            this.buttonpath.Text = "....";
            this.buttonpath.Click += new System.EventHandler(this.Buttonpath_Click);
            // 
            // btnbackaup
            // 
            this.btnbackaup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnbackaup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnbackaup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnbackaup.Location = new System.Drawing.Point(363, 51);
            this.btnbackaup.Name = "btnbackaup";
            this.btnbackaup.Size = new System.Drawing.Size(164, 23);
            this.btnbackaup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnbackaup.TabIndex = 1;
            this.btnbackaup.Text = "شروع پشتیبان گیری";
            this.btnbackaup.Click += new System.EventHandler(this.Btnbackaup_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX1.Location = new System.Drawing.Point(546, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(134, 34);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "مسیر ذخیره سازی  :";
            // 
            // panel1
            // 
            this.panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 55);
            this.panel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel1.Style.GradientAngle = 90;
            this.panel1.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton2.Location = new System.Drawing.Point(448, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(66, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "بازیابی";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton1.Location = new System.Drawing.Point(569, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "پشتیبان گیری";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // backgroundWorkerback
            // 
            this.backgroundWorkerback.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerback_DoWork);
            this.backgroundWorkerback.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerback_RunWorkerCompleted);
            // 
            // backgroundWorkerresto
            // 
            this.backgroundWorkerresto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerresto_DoWork);
            this.backgroundWorkerresto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerresto_RunWorkerCompleted);
            // 
            // UserControlBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "UserControlBackUp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(700, 557);
            this.Load += new System.EventHandler(this.UserControlBackUp_Load);
            this.Leave += new System.EventHandler(this.UserControlBackUp_Leave);
            this.panelEx1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panel2;
        private DevComponents.DotNetBar.PanelEx panel1;
        private DevComponents.DotNetBar.PanelEx panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXpathr;
        private DevComponents.DotNetBar.ButtonX btnpatheres;
        private DevComponents.DotNetBar.ButtonX btnrestore;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXpath;
        private DevComponents.DotNetBar.ButtonX buttonpath;
        private DevComponents.DotNetBar.ButtonX btnbackaup;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerback;
        private System.ComponentModel.BackgroundWorker backgroundWorkerresto;
    }
}
