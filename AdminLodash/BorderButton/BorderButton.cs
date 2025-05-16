using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace AdminLodash
{
   
    public class BorderButton : Button
    {
        //fields
        private int borderSize = 0;
        private int BoderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;

        public int BorderSize { 
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Border Button")]
        public int BoderRadius1 { 
            get => BoderRadius;
            set
            {   if (value <= this.Height)
                {
                    BoderRadius = value;
                }
                else
                {
                    BoderRadius1 = this.Height;
                    this.Invalidate();
                }

               
            }
        }
        [Category("Border Button")]
        public Color BorderColor { 
            get => borderColor; 
            set
            {
                this.Invalidate();
            }
        }

       
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }
        //Contructor
        public BorderButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumAquamarine;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if(BoderRadius1 > this.Height)
            {
                BoderRadius1 = this.Height;
            }
        }
        //Methods
        private GraphicsPath GetFigurePath(RectangleF rect,float radius) {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X,rect.Y,radius,radius,180,90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBoder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);
        if (BoderRadius > 2) // Round button
          {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BoderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBoder,BoderRadius-1F))
                using(Pen penSurface = new Pen(this.Parent.BackColor,2))
                using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region( pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Draw control Border
                    if(borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                    
                    
                }
          }
            else //Normal Button
            {
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(container_BackColorchanged);
         
        }
        private void container_BackColorchanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }

    }
}
