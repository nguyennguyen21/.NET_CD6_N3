using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdminLodash.Datepicker
{
    public class DateandTime : UserControl
    {
        private DateTimePicker dtPicker = new DateTimePicker();

        // Appearance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;
        private Image calendarIcon = Properties.Resources.calendarWhite;
        private Rectangle iconButtonArea;
        private bool isDropDownVisible = false;

        [Category("Custom")]
        public Color SkinColor
        {
            get => skinColor;
            set
            {
                skinColor = value;
                calendarIcon = (skinColor.GetBrightness() >= 0.8f) ?
                    Properties.Resources.calendarDark : Properties.Resources.calendarWhite;
                this.Invalidate();
            }
        }

        [Category("Custom")]
        public Color TextColor
        {
            get => textColor;
            set { textColor = value; this.Invalidate(); }
        }

        [Category("Custom")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Custom")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; this.Invalidate(); }
        }

        public DateTime Value
        {
            get => dtPicker.Value;
            set => dtPicker.Value = value;
        }

        public DateandTime()
        {
            this.MinimumSize = new Size(100, 35);
            this.Font = new Font("Segoe UI", 9.5F);
            this.Padding = new Padding(5);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;

            dtPicker.Format = DateTimePickerFormat.Short;
            dtPicker.Visible = false;
            dtPicker.ValueChanged += (s, e) => this.Invalidate();
            dtPicker.DropDown += (s, e) => isDropDownVisible = true;
            dtPicker.CloseUp += (s, e) => { isDropDownVisible = false; this.Invalidate(); };

            this.Controls.Add(dtPicker);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            Rectangle rectIcon = new Rectangle(rect.Right - 34, rect.Y, 34, rect.Height);
            iconButtonArea = rectIcon;

            using (SolidBrush bgBrush = new SolidBrush(skinColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (Pen borderPen = new Pen(borderColor, borderSize))
            {
                // Background
                g.FillRectangle(bgBrush, rect);

                // Border
                if (borderSize > 0)
                    g.DrawRectangle(borderPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

                // Highlight icon background if opened
                if (isDropDownVisible)
                    g.FillRectangle(new SolidBrush(Color.FromArgb(50, 64, 64, 64)), rectIcon);

                // Draw date text
                string dateText = dtPicker.Value.ToString("dd/MM/yyyy");
                using (StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("   " + dateText, this.Font, textBrush, rect, sf);
                }

                // Icon
                g.DrawImage(calendarIcon, rect.Right - calendarIcon.Width - 9, (rect.Height - calendarIcon.Height) / 2);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Cursor = iconButtonArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Point screenPoint = this.PointToScreen(iconButtonArea.Location);
            dtPicker.Location = this.PointToClient(screenPoint);
            dtPicker.Width = 1;
            dtPicker.Visible = true;
            SendKeys.Send("%{DOWN}"); // Mở lịch
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
