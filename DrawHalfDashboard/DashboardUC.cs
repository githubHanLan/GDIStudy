using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrawHalfDashboard
{
    public class DashboardUC:Control
    {

        #region Propertity
        /// <summary>
        /// 仪表量程最大值
        /// </summary>
        [DefaultValue(typeof(float), "200")]
        [Description("量程最大值")]
        public float MaxValue { get; set; } = 200;
        /// <summary>
        /// 仪表量程最小值
        /// </summary>
        [DefaultValue(typeof(float), "0")]
        [Description("量程最小值")]
        public float MinValue { get; set; }
        /// <summary>
        /// 仪表盘当前值
        /// </summary>
        [DefaultValue(typeof(float), "0")]
        [Description("当前值")]
        public float CurrentValue { get; set; } = 30;
        /// <summary>
        /// 仪表盘指针颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        [Description("指针颜色")]
        public Color PinColor { get; set; } = Color.Red;
        /// <summary>
        /// 起始角度
        /// </summary>
        [DefaultValue(typeof(int),"0")]
        [Description("起始角度")]
        public int StartArc { get; set; }
        /// <summary>
        /// 结束角度
        /// </summary>
        [DefaultValue(typeof(int), "360 ")]
        [Description("结束角度")]
        public int EndArc { get; set; } = 360;
        #endregion

        /// <summary>
        /// 仪表盘
        /// </summary>
        public DashboardUC()
        {
            //双缓存防止屏幕抖动
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        //绘制控件
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBack(e.Graphics);
            DrawPin(e.Graphics);
        }

        private void DrawBack(Graphics g)
        { 
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(this.Width/2, this.Height/2);//以中心点为画布的起始点

            float R = this.Width / 2f-15;


            g.DrawArc(new Pen(Color.Black, 3), -R,-R ,2*R,2*R,StartArc,EndArc);

            g.DrawEllipse(new Pen(Color.Black, 1), -3, -3, 2 *3, 2 * 3);

            double x = 0;
            for (int i = 0; i <= 180; i++)
            { 
                double rad = (x+StartArc) * Math.PI / 180;
                if (i % 10 == 0)
                {
                    float px1 = (float)((R - 5) * Math.Cos(rad));
                    float py1 = (float)((R - 5) * Math.Sin(rad));

                    float px2 = (float)((R- 18) * Math.Cos(rad));
                    float py2 = (float)((R - 18) * Math.Sin(rad));
                    g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(122, 179, 222)), 2), px1, py1, px2, py2);

                }
                else
                {
                    float px1 = (float)((R - 5) * Math.Cos(rad));
                    float py1 = (float)((R - 5) * Math.Sin(rad));

                    float px2 = (float)((R - 12) * Math.Cos(rad));
                    float py2 = (float)((R - 12) * Math.Sin(rad));
                    g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(77, 88, 124)), 1), px1, py1, px2, py2);
                }
                x -=3;
            }
            //g.DrawString(this.Text, new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.Black),(Width-30-this.Text.Length*10)/2f,Height/2f)
          
        }


        private void DrawPin(Graphics g)
        {
            
            g.SmoothingMode = SmoothingMode.HighQuality;
          

        }

        /// <summary>
        /// 控件大小改变
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

    }
}
