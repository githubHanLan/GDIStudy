using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawHalfDashboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i = rd.Next(-123,123);
            
            this.halfDashboardUC1.ChangeValue = i/3.14f;
            this.halfDashboardUC1.Refresh();

            this.dashboardUC1.Text = i.ToString();
            this.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
