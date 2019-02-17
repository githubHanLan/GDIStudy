using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] columns = textBox1.Text.Split(',');

            Font font = panel1.Font;//字体
            Brush color = Brushes.Black;//颜色
            Brush border = new SolidBrush(panel1.ForeColor);//用前景色画边框
            Pen borderStyle = new Pen(border, 1);

            //从什么位置开始画
            float top = 0F;//Y坐标
            float left = 0F;//X坐标
            //画笔X坐标偏移量，left1:最后一次位置，left2当前最远位置
            float left1 = left, left2 = 0F;
            float textLeft = 0F;//文本X坐标(F表示浮点数)
            float textTop = 0F;//文本Y坐标
            float textWidth = 0F;//文本宽度
            float textHeight = 0F;//文本高度
            const float columnHeight = 30F;//行高，包括边框在内
            const float columnPadding = 10F;//每一列左右多出10像素

            Graphics g = panel1.CreateGraphics();//在空间上创建画布
            textHeight = font.GetHeight(g);//高
            textTop = (columnHeight - textHeight) / 2;//上边
            for (int i = 0; i < columns.Length; i++)
            {
                //先计算文本
                textWidth = g.MeasureString(columns[i], font).Width;//宽
                textLeft = left1 + columnPadding;//左边
                left2 = textLeft + textWidth + columnPadding;

                //先画左边框
                g.DrawLine(borderStyle, left1, top, left1, columnHeight);

                //画文字
                g.DrawString(columns[i], font, color, textLeft, textTop);
                //注意左边的位置要开始偏移了
                left1 = left2;
            }
            g.DrawLine(borderStyle, left, top, left2, top);//上边框
            g.DrawLine(borderStyle, left, columnHeight, left2, columnHeight);//下边框
            g.DrawLine(borderStyle, left2, top, left2, columnHeight);//右边框

        }
    }
}
