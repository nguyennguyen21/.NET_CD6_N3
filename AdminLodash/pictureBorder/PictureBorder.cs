using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdminLodash.pictureBorder
{
    public class PictureBorder : PictureBox
    {
        // Fields
        private int borderSize = 2;
        private Color borderColor = Color.RoyalBlue;
        private Color borderColor2 = Color.HotPink;
        private DashStyle borderLineStyle = DashStyle.Solid;
        private DashCap borderCapStyle = DashCap.Flat;
        private float gradientAngle = 50F;

        // Constructor
        public PictureBorder()
        {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Properties
        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor2
        {
            get => borderColor2;
            set { borderColor2 = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public DashStyle BorderLineStyle
        {
            get => borderLineStyle;
            set { borderLineStyle = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public DashCap BorderCapStyle
        {
            get => borderCapStyle;
            set { borderCapStyle = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public float GradientAngle
        {
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); }
        }

        // Override OnResize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width); // Keep it square
        }

        // Override OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var graph = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize * 3 : 1;

            using (var borderGColor = new LinearGradientBrush(rectBorder, borderColor, borderColor2, gradientAngle))
            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent?.BackColor ?? Color.White, smoothSize))
            using (var penBorder = new Pen(borderGColor, borderSize))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.DashStyle = borderLineStyle;
                penBorder.DashCap = borderCapStyle;
                pathRegion.AddEllipse(rectContourSmooth);
                this.Region = new Region(pathRegion);

                // Drawing
                graph.DrawEllipse(penSmooth, rectContourSmooth); // Smoothing
                if (borderSize > 0)
                    graph.DrawEllipse(penBorder, rectBorder);     // Border
            }
        }
    }
}
