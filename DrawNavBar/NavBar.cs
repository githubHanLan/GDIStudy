using System.Windows.Forms;

namespace DrawNavBar
{
    public partial class NavBar :Control
    {
        public NavBar()
        {
            //双缓存防止屏幕抖动
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}
