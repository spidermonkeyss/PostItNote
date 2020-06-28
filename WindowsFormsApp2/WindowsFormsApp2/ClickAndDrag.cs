using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class ClickAndDrag
    {
        private static bool mouseDownOnNote = false;
        private static Point mouseDiffenceOnDown;

        public static void note_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            mouseDownOnNote = true;
            mouseDiffenceOnDown = new Point(Cursor.Position.X - control.Location.X, Cursor.Position.Y - control.Location.Y);
        }

        public static void note_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownOnNote)
            {
                Control control = (Control)sender;
                control.Parent.Refresh();
                control.Location = new Point(Cursor.Position.X - mouseDiffenceOnDown.X, Cursor.Position.Y - mouseDiffenceOnDown.Y);
            }
        }

        public static void note_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDownOnNote)
            {
                Control control = (Control)sender;
                control.Parent.Refresh();
                mouseDownOnNote = false;
            }
        }

    }
}
