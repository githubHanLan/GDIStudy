using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawHalfDashboard
{
    public partial class HalfDashboardUC : Control
    {
        /// <summary>
        /// 仪表盘背景图片
        /// </summary>
        private Image dashboardImage;

        /// <summary>
        /// 定义仪表盘画布的最大为370
        /// </summary>
        private int maxSize=370;

        /// <summary>
        /// 仪表盘画布的放大倍数，默认1
        /// </summary>
        private float multiple = 1;

        /// <summary>
        /// 定义该仪表盘的直径大小
        /// </summary>
        private float diameter;

        /// <summary>
        /// 每个间隔值
        /// </summary>
        private int intervalValue;

        /// <summary>
        /// 仪表盘显示的最小值，默认为0
        /// </summary>
        private float minValue = 0;


        /// <summary>
        /// 仪表盘显示的最小值
        /// </summary>
        [Category("wyl")]
        [Description("仪表盘显示的最小值")]
        public float MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                if (value >= MaxValue)
                {
                    MessageBox.Show("最小值不能超过最大值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minValue = 0;
                }
                else
                {
                    minValue = value;
                    //drawBackImage();
                }
            }

        }

        /// <summary>
        /// 仪表盘上显示的最大值，默认123。
        /// </summary>
        private float maxValue = 123;

        /// <summary>
        /// 仪表盘上显示的最大值
        /// </summary>
        [Category("wyl")]
        [Description("仪表盘上显示的最大值")]
        public float MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                if (value <= MinValue)
                {
                    MessageBox.Show("最大值不能低于最小值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxValue = 123;
                }
                else
                {
                    maxValue = value;
                    //drawBackImage();
                }
            }
        }

        // <summary>
        /// 仪表盘变换的值,默认为0；
        /// </summary>
        private float changeValue = 0;

        /// <summary>
        /// 仪表盘变换的值
        /// </summary>
        public float ChangeValue
        {
            get
            {
                return changeValue;
            }
            set
            {
                changeValue = value;
            }
        }

        /// <summary>
        /// 指针颜色
        /// </summary>
        private Color pinColor = Color.FromArgb(191, 148, 28);

        public Color PinColor
        {
            get
            {
                return pinColor;
            }
            set
            {
                pinColor = value;
            }
        }



        public HalfDashboardUC()
        {
            
            //双缓存防止屏幕抖动
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
   
        }

        //private int uintfontsize = 40;
        /// <summary>
        /// 初始化仪表盘画布
        /// </summary>
        private void InitialCanvas()
        {
            //对比控件的长高，以最小值为仪表盘的半径
            if (this.Width > 2 * this.Height)
            {
                diameter = 2 * this.Height - 15;
            }
            else
            {
                diameter = this.Width - 15;
            }
            multiple = (float)diameter / maxSize;//计算仪表盘放大倍数
            //如果半径大于仪表盘的最大值，则设定放大倍数为默认值
            if (multiple > 1)
            {
                multiple = 1;
                diameter = maxSize;
            }
            intervalValue = (int)((MaxValue - minValue) / 3);//计算每个间隔之间的值
        }

        /// <summary>
        /// 画底图
        /// </summary>
        private void drawBackImage()
        {

            Bitmap bit = new Bitmap(this.Width, this.Height);
            Graphics gp = Graphics.FromImage(bit);
            gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            float radius = diameter / 2;//半径
            float cerX = this.Width / 2;
            float cerY = this.Height / 2 + radius / 2 - 10 * multiple;
            //float cerY = this.Height - 20 ;
            gp.TranslateTransform(cerX, cerY);//以中心点为画布的起始点
            //gp.DrawPie(new Pen(new SolidBrush(Color.FromArgb(19,20,25)),3), -radius, -radius, diameter, diameter, 175, 190);
            gp.DrawArc(new Pen(new SolidBrush(Color.FromArgb(19, 20, 25)), 3), -radius, -radius, diameter, diameter, 175, 190);
            float x1 = (float)((radius) * Math.Cos(175 * Math.PI / 180));
            float y1 = (float)((radius) * Math.Sin(175 * Math.PI / 180));
            float x2 = (float)((radius) * Math.Cos(5 * Math.PI / 180));
            float y2 = (float)((radius) * Math.Sin(5 * Math.PI / 180));
           // gp.DrawLine(new Pen(new SolidBrush(Color.FromArgb(19, 20, 25)), 3), x1, y1, x2, y2);

            //gp.DrawEllipse(new Pen(Brushes.Red), -5, -5, 10, 10);
            float startRad = 180;//起始角度
            float sweepShot = 0;//旋转角度
            //gp.DrawLine(new Pen(Brushes.Red), -radius, 0, -(radius - 10), 0);
            for (int i = 0; i <= 30; i++)
            {
                double rad = (sweepShot + startRad) * Math.PI / 180;
                if (i % 5 == 0)
                {
                    float px1 = (float)((radius - 5) * Math.Cos(rad));
                    float py1 = (float)((radius - 5) * Math.Sin(rad));

                    float px2 = (float)((radius - 15) * Math.Cos(rad));
                    float py2 = (float)((radius - 15) * Math.Sin(rad));
                    gp.DrawLine(new Pen(new SolidBrush(Color.FromArgb(122, 179, 222)), 2), px1, py1, px2, py2);

                }
                else
                {

                    float px1 = (float)((radius - 5) * Math.Cos(rad));
                    float py1 = (float)((radius - 5) * Math.Sin(rad));

                    float px2 = (float)((radius - 10) * Math.Cos(rad));
                    float py2 = (float)((radius - 10) * Math.Sin(rad));
                    gp.DrawLine(new Pen(new SolidBrush(Color.FromArgb(77, 88, 124)), 1), px1, py1, px2, py2);
                }
                sweepShot += 6;
            }
            //刻度字体
            Font scaleFont = new Font("宋体", 9, FontStyle.Bold);
            startRad = 270;//起始角度
            sweepShot = 0;//旋转角度
            Color c1 = Color.FromArgb(0, 192, 0);
            for (int i = 0; i < 4; i++)
            {
                int tempValue = i * intervalValue;
                SizeF tempSf = gp.MeasureString(tempValue.ToString(), scaleFont);
                //计算角度值
                double rad = (sweepShot + startRad) * Math.PI / 180;
                float px = (float)((radius - 18) * Math.Cos(rad));
                float py = (float)((radius - 18) * Math.Sin(rad));
                if (sweepShot == 0)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Wheat, px - tempSf.Width / 2, py);
                }
                else if (sweepShot == 30)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width + 5 * multiple, py - tempSf.Height / 2 + 10 * multiple);
                }
                else if (sweepShot == 60)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width, py - tempSf.Height / 2 + 5 * multiple);
                }
                else if (sweepShot == 90)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width, py - tempSf.Height / 2);

                }
                //else if (sweepShot == 120)
                //{
                //    gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width, py - tempSf.Height / 2);
                //}
                sweepShot += 30;
            }
            startRad = 270;//起始角度
            sweepShot = 0;//旋转角度
            for (int i = 0; i < 4; i++)
            {
                int tempValue = -i * intervalValue;
                SizeF tempSf = gp.MeasureString(tempValue.ToString(), scaleFont);
                //计算角度值
                double rad = (sweepShot + startRad) * Math.PI / 180;
                float px = (float)((radius - 18 * multiple) * Math.Cos(rad));
                float py = (float)((radius - 18 * multiple) * Math.Sin(rad));
                if (sweepShot == -30)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px, py + tempSf.Height / 2);
                }
                else if (sweepShot == -60)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px + tempSf.Width / 2 - 10 * multiple, py + tempSf.Height / 2 - 5 * multiple);
                }
                else if (sweepShot == -90)
                {
                    gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px + tempSf.Width / 2, py - tempSf.Height / 2);

                }


                sweepShot -= 30;
            }

            gp.Dispose();
            this.BackgroundImage = bit;
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="g"></param>
        private void DrawPin(Graphics g)
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);
            Graphics gp = Graphics.FromImage(bit);
            gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            float radius = diameter / 2;//半径
            float startRad = 270;//起始角度
            float sweepShot = (float)(ChangeValue / MaxValue * 90);//旋转角度
            float cerX = this.Width / 2;
            float cerY = this.Height / 2 + radius / 2 - 10 * multiple;
            gp.TranslateTransform(cerX, cerY);//以中心点为画布的起始点
            //gp.DrawEllipse(new Pen(PinColor, 1), -5, -5, 10, 10);//画中心圆圈
            double rad = (sweepShot + startRad) * Math.PI / 180;//计算角度
            float px = (float)((radius - 15) * Math.Cos(rad));
            float py = (float)((radius - 15) * Math.Sin(rad));
            PointF[] pf = new PointF[] { new PointF(0, -radius + 15), new PointF(-4, 0), new PointF(4, 0) };
            gp.RotateTransform(sweepShot);
            //PointF[] pf = new PointF[] { new PointF(px, py), new PointF(-4, 0), new PointF(4, 0) };
            gp.FillPolygon(new SolidBrush(PinColor), pf);

            //gp.DrawLine(new Pen(new SolidBrush(PinColor), 3f), 0, 0, px, py);


            g.DrawImage(bit, 0, 0);
            gp.Dispose();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            DrawPin(e.Graphics);
        }
      
        protected override void OnResize(EventArgs e)
        {
            InitialCanvas();
            drawBackImage();
        }
      
    }
}

