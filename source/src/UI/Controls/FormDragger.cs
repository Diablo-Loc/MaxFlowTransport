using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace src.UI.Controls
{
    public class FormDragger
    {
        private Control dragArea;
        private Form targetForm;
        private Panel headerPanel;
        private Point dragStartPoint;
        private bool isDragging = false;

        private Color originalHeaderColor = Color.Transparent;
        private double originalOpacity = 1.0;

        public FormDragger(Control dragArea, Form form, Panel header = null)
        {
            this.dragArea = dragArea;
            this.targetForm = form;
            this.headerPanel = header;

            if (headerPanel != null)
                originalHeaderColor = headerPanel.BackColor;

            originalOpacity = form.Opacity;

          

            dragArea.MouseDown += DragArea_MouseDown;
            dragArea.MouseMove += DragArea_MouseMove;
            dragArea.MouseUp += DragArea_MouseUp;
        }

        private void DragArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);

                targetForm.Opacity = 0.85;
                if (headerPanel != null)
                    headerPanel.BackColor = Color.LightCoral;
            }
        }

        private void DragArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = dragArea.PointToScreen(e.Location);
                targetForm.Location = new Point(
                    currentScreenPos.X - dragStartPoint.X,
                    currentScreenPos.Y - dragStartPoint.Y);
            }
        }

        private void DragArea_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            targetForm.Opacity = originalOpacity;
            if (headerPanel != null)
                headerPanel.BackColor = originalHeaderColor;
        }

        public static class UIHelper
        {
            public static void ApplyRoundedCorners(Form form, int radius) 
            {
                Rectangle bounds = form.ClientRectangle;
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                form.Region = new Region(path);
            }
        }
    }
}