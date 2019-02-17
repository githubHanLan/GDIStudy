using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawCalendar
{
    public partial class Calendar : Form
    {
       

        public Calendar()
        {
            InitializeComponent();
            DrawControls();
        }

        #region 绘制空间
        //绘制控件
        private void DrawControls()
        {
            var btnToday = new Button();
            btnToday.Location = new Point(300, 15);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(80, 21);
            btnToday.TabIndex = 0;
            btnToday.Text = "跳转到今天";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Click += new EventHandler(this.btnToday_Click);

            var lblYear = new Label();
            lblYear.Name = "lblYear";
            lblYear.Text = "年份";
            lblYear.Location = new Point(91, 19);
            lblYear.Size = new Size(29, 20);
            lblYear.BackColor = Color.Transparent;

            var lblMonth = new Label();
            lblMonth.Name = "lblMonth";
            lblMonth.Text = "月份";
            lblMonth.Location = new Point(190, 19);
            lblMonth.Size = new Size(29, 20);
            lblMonth.BackColor = Color.Transparent;

            var cmbSelectYear = new ComboBox();
            cmbSelectYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectYear.FormattingEnabled = true;
            cmbSelectYear.Location = new Point(120, 15);
            cmbSelectYear.Name = "cmbSelectYear";
            cmbSelectYear.AutoSize = false;
            cmbSelectYear.Size = new Size(50, 20);
            cmbSelectYear.TabIndex = 0;
            cmbSelectYear.SelectionChangeCommitted += new EventHandler(cmbSelectYear_SelectionChangeCommitted);

            var cmbSelectMonth = new ComboBox();
            cmbSelectMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectMonth.FormattingEnabled = true;
            cmbSelectMonth.Location = new Point(220, 15);
            cmbSelectMonth.Name = "cmbSelectYear";
            cmbSelectMonth.AutoSize = false;
            cmbSelectMonth.Size = new Size(50, 20);
            cmbSelectMonth.TabIndex = 0;
            cmbSelectMonth.SelectionChangeCommitted += new EventHandler(cmbSelectMonth_SelectionChangeCommitted);

            var panelDateInfo = new Panel();
            panelDateInfo.BackColor = Color.White;
            panelDateInfo.Location = new Point(575, 45);
            panelDateInfo.Size = new Size(165, 390);
            panelDateInfo.Paint += new PaintEventHandler(panelDateInfo_Paint);

            var lblShowTime = new Label();
            lblShowTime.Location = new Point(600, 470);
            lblShowTime.BackColor = Color.Transparent;
            lblShowTime.AutoSize = true;
            lblShowTime.Name = "lblShowTime";

            var label1 = new Label();
            label1.AutoSize = false;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new Point(252, 449);
            label1.Name = "label1";
            label1.Size = new Size(176, 13);
            label1.TabIndex = 0;
            label1.Text = "飞鸿踏雪泥 www.zhuoyuegzs.com";
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = 400;
            label1.Click += new EventHandler(label1_Click);

            //for (int i = 1949; i <= 2049; i++)
            //{
            //    cmbSelectYear.Items.Add(i);
            //    if (i == dtNow.Year)
            //    {
            //        cmbSelectYear.SelectedItem = i;
            //        selectYear = i;
            //    }
            //}
            //for (int i = 1; i <= 12; i++)
            //{
            //    cmbSelectMonth.Items.Add(i);
            //    if (i == dtNow.Month)
            //    {
            //        cmbSelectMonth.SelectedItem = i;
            //        selectMonth = i;
            //    }
            //}
            panelMonthInfo.Controls.Add(btnToday);
            panelMonthInfo.Controls.Add(lblMonth);
            panelMonthInfo.Controls.Add(lblYear);
            panelMonthInfo.Controls.Add(cmbSelectYear);
            panelMonthInfo.Controls.Add(cmbSelectMonth);
            panelMonthInfo.Controls.Add(panelDateInfo);
            panelMonthInfo.Controls.Add(lblShowTime);
            panelMonthInfo.Controls.Add(label1);
        }

        private void cmbSelectMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void panelDateInfo_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmbSelectYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }




        #endregion
    }
}
